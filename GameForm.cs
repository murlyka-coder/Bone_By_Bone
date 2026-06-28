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
        private string draggingBoneId = null;
        private Image draggingImage = null; // Картинка, которая рисуется при перетаскивании
        private Rectangle draggingRect;     // Координаты этой картинки
        private Point dragOffset;
        private PictureBox hiddenSourcePb = null; // Ссылка на иконку внизу, чтобы вернуть ее при промахе

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
            // Включаем скрытую двойную буферизацию для панели победы
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, victoryPanel, new object[] { true });

            // Рекомендую сразу сделать то же самое и для панели паузы, чтобы она работала идеально гладко:
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, pausePanel, new object[] { true });
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

            // Настройте эти цифры под вашу текстуру фона
            int paperX = 450;       // Сдвигаем правее (было 130)
            int paperY = 270; // было 220, увеличь на сколько нужно
            int paperWidth = 1200;  // Ширина холста сборки
            int paperHeight = 550;  // Высота холста сборки

            assemblyDrawList.Add((GetBoneImage(bone.ImageKey), new Rectangle(paperX, paperY, paperWidth, paperHeight)));

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

            int boneW = 150;
            int boneH = 150;
            int zoneY = ChoiceZone.Y + (ChoiceZone.Height - boneH) / 2 + 60;
            int totalW = count * boneW + (count - 1) * 20;
            int startX = (this.Width - totalW) / 2;

            for (int i = 0; i < count; i++)
            {
                string boneId = availableNeighbors[i];
                var boneDef = skeleton.GetBone(boneId);

                PictureBox pb = new PictureBox();
                pb.Size = new Size(boneW, boneH);
                pb.Location = new Point(startX + i * (boneW + 30), zoneY);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.Transparent;
                pb.Image = GetBoneImage(boneDef.GameImageKey);
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


        private void ChoiceBone_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            PictureBox pb = (PictureBox)sender;

            isDragging = true;
            draggingBoneId = (string)pb.Tag;

            // Берем вашу готовую маленькую картинку
            draggingImage = pb.Image;

            hiddenSourcePb = pb;
            pb.Visible = false;

            // Считываем реальные размеры вашей картинки "game"
            int imgWidth = draggingImage.Width;
            int imgHeight = draggingImage.Height;

            // Центрируем захват ровно по середине вашей картинки
            Point clientMousePos = this.PointToClient(Cursor.Position);
            draggingRect = new Rectangle(clientMousePos.X - (imgWidth / 2), clientMousePos.Y - (imgHeight / 2), imgWidth, imgHeight);

            this.Invalidate(draggingRect);
        }

        private void ChoiceBone_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingImage == null) return;

            Rectangle oldRect = draggingRect;
            oldRect.Inflate(5, 5);

            // Снова берем реальные размеры
            int imgWidth = draggingImage.Width;
            int imgHeight = draggingImage.Height;

            // Двигаем прямоугольник с родными пропорциями
            Point clientMousePos = this.PointToClient(Cursor.Position);
            draggingRect = new Rectangle(clientMousePos.X - (imgWidth / 2), clientMousePos.Y - (imgHeight / 2), imgWidth, imgHeight);

            Rectangle newRect = draggingRect;
            newRect.Inflate(5, 5);

            this.Invalidate(oldRect);
            this.Invalidate(newRect);
        }

        private void ChoiceBone_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;
            isDragging = false;

            // Узнаем, где игрок отпустил кнопку
            Point dropPoint = this.PointToClient(Cursor.Position);

            // Проверяем, находится ли курсор в верхней половине экрана (AssemblyZone)
            bool isInAssemblyZone = AssemblyZone.Contains(dropPoint);

            // Проверяем соседей
            bool isValidNeighbor = false;
            foreach (var placedId in placedBones)
            {
                var placedBone = skeleton.GetBone(placedId);
                if (placedBone.Neighbors.Contains(draggingBoneId))
                {
                    isValidNeighbor = true;
                    break;
                }
            }

            // Если отпустили в нужной зоне и сосед правильный — кость "примагничивается"
            if (isInAssemblyZone && isValidNeighbor)
            {
                placedBones.Add(draggingBoneId);

                // Тут кость жестко встанет на 130, 170 в своем оригинальном размере 1660x470
                PlaceBoneInAssembly(draggingBoneId);

                this.Controls.Remove(hiddenSourcePb);
                choiceBoxes.Remove(hiddenSourcePb);
                hiddenSourcePb.Dispose();

                RefreshChoicePanel();
                CheckVictory();
            }
            else
            {
                // Промах
                hiddenSourcePb.Visible = true;
                mistakesCount++;
                lblMistakes.Text = mistakesCount.ToString();
            }

            // Запоминаем последнюю зону отрисовки перед очисткой
            Rectangle clearRect = draggingRect;
            clearRect.Inflate(5, 5);

            // Сбрасываем переменные
            draggingImage = null;
            draggingBoneId = null;
            hiddenSourcePb = null;

            // Стираем кость с курсора
            this.Invalidate(clearRect);
        }

        private void CheckVictory()
        {
            if (placedBones.Count == skeleton.Bones.Count)
            {
                TimerGame.Stop();
                btnComplete.Visible = true;
                btnComplete.BringToFront();
            }
        }

        private void ShowVictory()
        {
            // 1. Вычисляем количество звезд
            int stars = 3;
            if (mistakesCount > 3) stars = 1;
            else if (mistakesCount > 1) stars = 2;

            // 2. Достаем исходную картинку
            Image sourceBg;
            if (stars == 1) sourceBg = Properties.Resources.pobeda1;
            else if (stars == 2) sourceBg = Properties.Resources.pobeda2;
            else sourceBg = Properties.Resources.pobeda3;

            // 3. Создаем чистый холст строго под размеры панели
            Bitmap preSizedBg = new Bitmap(victoryPanel.Width, victoryPanel.Height);

            using (Graphics g = Graphics.FromImage(preSizedBg))
            {
                // Включаем максимальное сглаживание для графики и текста
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Рисуем картинку фона
                g.DrawImage(sourceBg, 0, 0, victoryPanel.Width, victoryPanel.Height);

                // МАГИЯ: Рисуем текст времени и ошибок прямо на текстуре фона!
                // Используем координаты (Left, Top) твоих лейблов, так как они уже правильно выставлены на панели
                using (Font font = new Font(lblVictoryTime.Font.FontFamily, lblVictoryTime.Font.Size, lblVictoryTime.Font.Style))
                using (Brush brush = new SolidBrush(lblVictoryTime.ForeColor))
                {
                    // Рисуем время
                    g.DrawString(secondsPassed.ToString(), font, brush, lblVictoryTime.Left, lblVictoryTime.Top);
                    // Рисуем ошибки
                    g.DrawString(mistakesCount.ToString(), font, brush, lblVictoryMistakes.Left, lblVictoryMistakes.Top);
                }
            }

            // Скрываем оригинальные лейблы, чтобы они не мерцали поверх нашей новой отрисовки
            lblVictoryTime.Visible = false;
            lblVictoryMistakes.Visible = false;

            // Отдаем панели уже полностью готовое изображение с цифрами
            victoryPanel.BackgroundImage = preSizedBg;
            victoryPanel.BackgroundImageLayout = ImageLayout.None;

            // 4. Стандартный процесс создания темного оверлея (без изменений)
            pausePanel.Visible = false;
            pausePanel.Enabled = false;
            inGameSettingsPanel.Visible = false;
            victoryPanel.Visible = false;
            overlayPanel.Visible = false;

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

            victoryPanel.Visible = true;
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

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            // 1. Сначала фон скелета (все, что уже закреплено)
            foreach (var (img, rect) in assemblyDrawList)
            {
                e.Graphics.DrawImage(img, rect);
            }

            // 2. В ПОСЛЕДНЮЮ ОЧЕРЕДЬ — перетаскиваемая кость.
            // Она всегда будет рисоваться поверх всего, что нарисовано выше.
            if (isDragging && draggingImage != null)
            {
                e.Graphics.DrawImage(draggingImage, draggingRect);
            }
        }





    }
}