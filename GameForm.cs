using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private List<(Image img, Rectangle rect)> assemblyDrawList = new List<(Image, Rectangle)>();

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

        private void TogglePause()
        {
            bool pausing = !overlayPanel.Visible;
            if (pausing)
            {
                TimerGame.Stop();
                pausePanel.Enabled = false;
                pausePanel.Visible = false;

                buttonbuter.Image = Properties.Resources.buttonbuternormal;

                lightScreenshot = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(lightScreenshot, new Rectangle(0, 0, this.Width, this.Height));

                Bitmap dark = new Bitmap(lightScreenshot);
                using (Graphics g = Graphics.FromImage(dark))
                using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                    g.FillRectangle(brush, 0, 0, dark.Width, dark.Height);

                overlayPanel.BackgroundImage = dark;
                overlayPanel.BackgroundImageLayout = ImageLayout.Stretch;
                overlayPanel.Size = this.ClientSize;
                overlayPanel.Visible = true;
                overlayPanel.BringToFront();
                overlayPanel.Refresh();

                pausePanel.Visible = true;
                pausePanel.Enabled = true;
            }
            else
            {
                TimerGame.Start();
                pausePanel.Enabled = false;
                pausePanel.Visible = false;

                overlayPanel.BackgroundImage = lightScreenshot;
                overlayPanel.Refresh();

                overlayPanel.Visible = false;
                pausePanel.Visible = true;

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
            assemblyDrawList.Clear();

            skeleton = SkeletonLibrary.GetSkeleton(level);

            PlaceBoneInAssembly(skeleton.StartBoneId);
            placedBones.Add(skeleton.StartBoneId);

            RefreshChoicePanel();
            TimerGame.Start();
        }

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
    }
}