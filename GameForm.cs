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
        public event EventHandler SettingsClicked;
        private Bitmap lightScreenshot;
        private TransparentPanel overlayPanel;


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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            pausePanel.Enabled = false;
            pausePanel.SendToBack();
            this.Load += GameForm_Load;
            this.Paint += GameForm_Paint;
            lblTime.Parent = activetime;
            lblTime.BackColor = Color.Transparent;
            lblMistakes.Parent = activetime;
            lblMistakes.BackColor = Color.Transparent;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            overlayPanel = new TransparentPanel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.Visible = false;
            this.Controls.Add(overlayPanel);

            // переносим pausePanel внутрь overlayPanel
            this.Controls.Remove(pausePanel);
            pausePanel.Location = new Point(
                (overlayPanel.Width - pausePanel.Width) / 2,
                (overlayPanel.Height - pausePanel.Height) / 2);
            overlayPanel.Controls.Add(pausePanel);
            pausePanel.Visible = true;
        }

        public void ShowPause()
        {
            lightScreenshot = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(lightScreenshot, new Rectangle(0, 0, this.Width, this.Height));

            Bitmap dark = new Bitmap(lightScreenshot);
            using (Graphics g = Graphics.FromImage(dark))
            using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                g.FillRectangle(brush, 0, 0, dark.Width, dark.Height);

            overlayPanel.BackgroundImage = dark;
            overlayPanel.BackgroundImageLayout = ImageLayout.Stretch;
            overlayPanel.Visible = true;
            overlayPanel.Size = this.ClientSize;
            overlayPanel.BringToFront();
            pausePanel.Enabled = true;
        }



        private void buttonbuter_MouseEnter(object sender, EventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuterlight;
        }

        private void buttonbuter_MouseLeave(object sender, EventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuternormal;
        }

        private void buttonbuter_MouseDown(object sender, MouseEventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuterpress;
        }

        private void buttonbuter_Click(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void TogglePause()
        {
            bool pausing = !overlayPanel.Visible;
            if (pausing)
            {
                TimerGame.Stop();
                pausePanel.Enabled = true;

                buttonbuter.Image = Properties.Resources.buttonbuternormal;

                // сначала сохраняем светлый скриншот
                lightScreenshot = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(lightScreenshot, new Rectangle(0, 0, this.Width, this.Height));

                // затем делаем затемнённый
                Bitmap dark = new Bitmap(lightScreenshot);
                using (Graphics g = Graphics.FromImage(dark))
                using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                    g.FillRectangle(brush, 0, 0, dark.Width, dark.Height);

                overlayPanel.BackgroundImage = dark;
                overlayPanel.BackgroundImageLayout = ImageLayout.Stretch;
                overlayPanel.Visible = true;
                overlayPanel.Size = this.ClientSize;
                overlayPanel.BringToFront();
            }
            else
            {
                TimerGame.Start();
                pausePanel.Enabled = false;

                // показываем светлый скриншот пока overlay ещё видим
                overlayPanel.BackgroundImage = lightScreenshot;
                overlayPanel.Refresh();

                // теперь убираем overlay — под ним уже готовый светлый кадр
                overlayPanel.Visible = false;

                if (overlayPanel.BackgroundImage != null)
                {
                    overlayPanel.BackgroundImage.Dispose();
                    overlayPanel.BackgroundImage = null;
                }
                if (lightScreenshot != null)
                {
                    lightScreenshot.Dispose();
                    lightScreenshot = null;
                }
            }
        }


        public void StartLevel(int level)
        {
            selectedLevel = level;
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "0";
            lblMistakes.Text = "0";
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
            pausePanel.SendToBack();
            activetime.BringToFront();
            buttonbuter.BringToFront();

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
            overlayPanel.Visible = false;
            pausePanel.Enabled = false;
            assemblyDrawList.Clear();
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
            lblTime.Text = "" + secondsPassed + "";
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ClearLevel();
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "0";
            lblMistakes.Text = "0";
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var (img, rect) in assemblyDrawList)
                e.Graphics.DrawImage(img, rect);
        }


        private void btnPauseSettings_MouseEnter(object sender, EventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonlight2;
        }

        private void btnPauseSettings_MouseLeave(object sender, EventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonnormal2;
        }

        private void btnPauseSettings_MouseDown(object sender, MouseEventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonpress2;
        }

        private void btnPauseSettings_Click(object sender, EventArgs e)
        {
            TogglePause();
            TimerGame.Stop();
            SettingsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEndGame_MouseEnter(object sender, EventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend2;
        }

        private void btnEndGame_MouseLeave(object sender, EventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend1;
        }

        private void btnEndGame_MouseDown(object sender, MouseEventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend3;
        }

        private void btnEndGame_Click_1(object sender, EventArgs e)
        {
            ClearLevel();
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnResume_MouseEnter(object sender, EventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo2;
        }

        private void btnResume_MouseLeave(object sender, EventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo1;
        }

        private void btnResume_MouseDown(object sender, MouseEventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo3;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            TogglePause();
        }
    }


    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            this.BackColor = Color.Transparent;
        }
    }
}