using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bone_By_Bone
{
    public partial class GameForm : UserControl
    {
        public event EventHandler BackToMenuClicked;

        private int secondsPassed = 0;
        private int mistakesCount = 0;
        private int selectedLevel = 1;

        private SkeletonDefinition skeleton;
        private HashSet<string> placedBones = new HashSet<string>();
        private List<string> availableNeighbors = new List<string>();

        private Dictionary<string, PictureBox> slotBoxes = new Dictionary<string, PictureBox>();
        private List<PictureBox> choiceBoxes = new List<PictureBox>();

        private bool isDragging = false;
        private PictureBox draggingBone = null;
        private string draggingBoneId = null;
        private Point dragOffset;
        private Point dragOriginalLocation;

        private Rectangle AssemblyZone => new Rectangle(0, 0, this.Width, (int)(this.Height * 0.65));
        private Rectangle ChoiceZone => new Rectangle(0, (int)(this.Height * 0.65), this.Width, (int)(this.Height * 0.35));

        public GameForm()
        {
            InitializeComponent();
            this.Paint += GameForm_Paint;
        }

        public void StartLevel(int level)
        {
            selectedLevel = level;
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "Время: 0 сек";
            lblMistakes.Text = "Ошибки: 0";
            btnBackToMenu.Visible = false;

            ClearLevel();
            System.Diagnostics.Debug.WriteLine($"GameForm size: {this.Width} x {this.Height}");
            assemblyDrawList.Clear();

            skeleton = SkeletonLibrary.GetSkeleton(level);

            PlaceBoneInAssembly(skeleton.StartBoneId);
            placedBones.Add(skeleton.StartBoneId);

            RefreshChoicePanel();
            TimerGame.Start();
        }

        private List<(Image img, Rectangle rect)> assemblyDrawList = new List<(Image, Rectangle)>();

        private void PlaceBoneInAssembly(string boneId)
        {
            var bone = skeleton.GetBone(boneId);
            if (bone == null) return;

            assemblyDrawList.Add((GetBoneImage(bone.ImageKey), new Rectangle(bone.SlotPosition, bone.BoneSize)));
            slotBoxes[boneId] = new PictureBox { Location = bone.SlotPosition, Size = bone.BoneSize };
            this.Invalidate();
        }

        private void RefreshChoicePanel()
        {
            foreach (var pb in choiceBoxes)
                this.Controls.Remove(pb);
            choiceBoxes.Clear();
            availableNeighbors.Clear();

            foreach (var bone in skeleton.Bones)
            {
                if (!placedBones.Contains(bone.Id))
                    availableNeighbors.Add(bone.Id);
            }

            // Перемешиваем
            var rng = new Random();
            availableNeighbors = availableNeighbors.OrderBy(x => rng.Next()).ToList();

            int count = availableNeighbors.Count;
            if (count == 0) return;

            int boneW = 200;
            int boneH = 200;
            int zoneY = ChoiceZone.Y + (ChoiceZone.Height - boneH) / 2;
            int totalW = count * boneW + (count - 1) * 30;
            int startX = (this.Width - totalW) / 2;

            for (int i = 0; i < count; i++)
            {
                string boneId = availableNeighbors[i];
                var boneDef = skeleton.GetBone(boneId);

                PictureBox pb = new PictureBox();
                pb.Size = new Size(boneW, boneH);
                pb.Location = new Point(startX + i * (boneW + 30), zoneY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackColor = Color.Transparent;
                pb.Image = GetBoneImage(boneDef.ImageKey);
                pb.Tag = boneId;
                pb.Cursor = Cursors.Hand;

                pb.MouseDown += ChoiceBone_MouseDown;
                pb.MouseMove += ChoiceBone_MouseMove;
                pb.MouseUp += ChoiceBone_MouseUp;

                this.Controls.Add(pb);
                pb.BringToFront();
                choiceBoxes.Add(pb);

            }
            lblTime.BringToFront();
            lblMistakes.BringToFront();
            btnBackToMenu.BringToFront();

            System.Diagnostics.Debug.WriteLine($"availableNeighbors count: {availableNeighbors.Count}");
            System.Diagnostics.Debug.WriteLine($"ChoiceZone: Y={ChoiceZone.Y}, H={ChoiceZone.Height}");
            System.Diagnostics.Debug.WriteLine($"GameForm size: {this.Width}x{this.Height}");
            foreach (var n in availableNeighbors)
                System.Diagnostics.Debug.WriteLine($"  bone: {n}");
        }

        private void ChoiceBone_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            PictureBox pb = (PictureBox)sender;
            isDragging = true;
            draggingBone = pb;
            draggingBoneId = (string)pb.Tag;
            dragOffset = e.Location;
            dragOriginalLocation = pb.Location;
            pb.Size = new Size(240, 240); // увеличиваем при захвате
            pb.BringToFront();
        }

        private void ChoiceBone_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingBone == null) return;
            draggingBone.Left += e.X - dragOffset.X;
            draggingBone.Top += e.Y - dragOffset.Y;
        }

        private void ChoiceBone_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingBone == null) return;
            isDragging = false;

            Point center = new Point(
                draggingBone.Left + draggingBone.Width / 2,
                draggingBone.Top + draggingBone.Height / 2
            );

            if (AssemblyZone.Contains(center))
            {
                // Ищем кость к которой физически поднесли
                bool isValidNeighbor = false;
                foreach (var placedId in placedBones)
                {
                    var placedBone = skeleton.GetBone(placedId);
                    if (!placedBone.Neighbors.Contains(draggingBoneId)) continue;

                    // Проверяем физическое расстояние до этой кости на экране
                    PictureBox slotPb = slotBoxes[placedId];
                    Point slotCenter = new Point(
                        slotPb.Left + slotPb.Width / 2,
                        slotPb.Top + slotPb.Height / 2
                    );
                    int dx = Math.Abs(center.X - slotCenter.X);
                    int dy = Math.Abs(center.Y - slotCenter.Y);

                    if (dx < 150 && dy < 150) // радиус притяжения — подгонишь под себя
                    {
                        isValidNeighbor = true;
                        break;
                    }
                }

                if (isValidNeighbor)
                {
                    this.Controls.Remove(draggingBone);
                    choiceBoxes.Remove(draggingBone);
                    placedBones.Add(draggingBoneId);
                    PlaceBoneInAssembly(draggingBoneId);
                    RefreshChoicePanel();
                    CheckVictory();
                }
                else
                {
                    draggingBone.Size = new Size(200, 200);
                    draggingBone.Location = dragOriginalLocation;
                    mistakesCount++;
                    lblMistakes.Text = "Ошибки: " + mistakesCount;
                }
            }
            else
            {
                draggingBone.Size = new Size(200, 200);
                draggingBone.Location = dragOriginalLocation;
            }

            draggingBone = null;
            draggingBoneId = null;
        }

        private void CheckVictory()
        {
            if (placedBones.Count == skeleton.Bones.Count)
            {
                TimerGame.Stop();
                int stars = 3;
                if (mistakesCount > 3) stars = 1;
                else if (mistakesCount > 1) stars = 2;
                string rating = new string('★', stars) + new string('☆', 3 - stars);
                MessageBox.Show($"Скелет собран!\n\nВремя: {secondsPassed} сек.\nОшибок: {mistakesCount}\nОценка: {rating}", "Победа!");
                btnBackToMenu.Visible = true;
            }
        }

        private void ClearLevel()
        {
            foreach (var pb in slotBoxes.Values) this.Controls.Remove(pb);
            foreach (var pb in choiceBoxes) this.Controls.Remove(pb);
            slotBoxes.Clear();
            choiceBoxes.Clear();
            placedBones.Clear();
            availableNeighbors.Clear();
            TimerGame.Stop();
        }

        private Image GetBoneImage(string imageKey)
        {
            Image original = (Image)Properties.Resources.ResourceManager.GetObject(imageKey);
            if (original != null) return original;

            Bitmap bmp = new Bitmap(150, 150);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Gray);
                g.DrawString(imageKey, new Font("Arial", 8), Brushes.White, 5, 65);
            }
            return bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblTime.Text = "Время: " + secondsPassed + " сек";
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ClearLevel();
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "Время: 0 сек";
            lblMistakes.Text = "Ошибки: 0";
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var (img, rect) in assemblyDrawList)
                e.Graphics.DrawImage(img, rect);
        }
    }
}