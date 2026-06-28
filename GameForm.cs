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

        // Элементы всплывающего баннера
        private Panel panelInfo;
        private Label lblInfoText;
        private Label lblClose;

        // Словарь фактов, разделенный по уровням
        private Dictionary<int, Dictionary<string, string>> levelFacts = new Dictionary<int, Dictionary<string, string>>
            {
                { 1, new Dictionary<string, string> {
                    { "head", "ЧЕРЕП: Достигал 1.5 метров в длину, а невероятная сила укуса могла дробить кости!" },
                    { "sheia", "ШЕЯ: S-образная шея работала как мощная пружина для удержания тяжелой головы." },
                    { "arms", "ПЕРЕДНИЕ ЛАПЫ: Были крошечными (всего по два пальца), но при этом удивительно сильными." },
                    { "ribs", "ГРУДНАЯ КЛЕТКА: Защищала гигантские легкие, которые позволяли хищнику долго преследовать добычу." },
                    { "taz", "ТАЗ: Служил мощнейшей опорой всего тела, ведь этот гигант весил как школьный автобус!" },
                    { "leg_front", "НОГА: Огромные мышцы на ногах позволяли бегать со скоростью до 27 км/ч." },
                    { "leg_back", "НОГА: Сильные задние конечности — главный двигатель динозавра при прыжке и беге." },
                    { "tail", "ХВОСТ: Работал как тяжелый балансир, чтобы динозавр не падал носом вперед во время бега." }
                }},
                { 2, new Dictionary<string, string> {
                    { "head", "ЧЕРЕП: У кошек очень большие глазницы!" },
                    { "sheya", "ШЕЯ: Кошки могут поворачивать голову почти на 180 градусов, выслеживая свою добычу." },
                    { "noga1", "ПЕРЕДНИЕ ЛАПЫ: У кошек нет обычных ключиц, поэтому они могут пролезать в любые узкие щели." },
                    { "noga2", "ПЕРЕДНИЕ ЛАПЫ: Мягкие подушечки на лапках позволяют подкрадываться совершенно бесшумно." },
                    { "ribs", "ГРУДНАЯ КЛЕТКА: Узкая, но очень гибкая — это помогает кошкам развивать огромную скорость." },
                    { "spina", "ПОЗВОНОЧНИК: Настоящая пружина! В нём на 20 костей больше, чем у человека." },
                    { "noga3", "ЗАДНИЕ ЛАПЫ: Работают как мощные катапульты. Кот может прыгнуть в высоту в 5 раз больше своего роста!" },
                    { "noga4", "ЗАДНИЕ ЛАПЫ: Сильные мышцы бедра помогают мгновенно срываться с места за игрушкой." },
                    { "tail", "ХВОСТ: Это не просто украшение, а настоящий руль! С его помощью кошка удерживает равновесие на заборах." }
                }},
                                    { 3, new Dictionary<string, string> {
                    { "head", "ЧЕРЕП: Состоит из 29 костей и работает как прочный шлем, защищая наш самый главный компьютер — мозг!" },
                    { "sheya", "ШЕЯ: У нас 7 шейных позвонков — ровно столько же, сколько у жирафа с его длиннющей шеей." },
                    { "lopat1", "ЛОПАТКА: Эта плоская кость скользит по ребрам и позволяет нам поднимать руки высоко вверх." },
                    { "lopat2", "ЛОПАТКА: К лопаткам крепится множество мышц спины, отвечающих за нашу осанку." },
                    { "cluchis1", "КЛЮЧИЦА: Единственная кость, которая соединяет руку с туловищем. Она работает как распорка!" },
                    { "cluchis2", "КЛЮЧИЦА: Эта кость ломается чаще других, если неудачно упасть на вытянутую руку." },
                    { "plesho1", "ПЛЕЧЕВАЯ КОСТЬ: Самая длинная кость верхней конечности, к которой крепятся сильные мышцы руки." },
                    { "plesho2", "ПЛЕЧЕВАЯ КОСТЬ: Шаровидный сустав этой кости позволяет вращать рукой на все 360 градусов." },
                    { "predplesho1", "ПРЕДПЛЕЧЬЕ: Состоит из двух косточек (лучевой и локтевой), позволяя нам переворачивать кисти рук." },
                    { "predplesho2", "ПРЕДПЛЕЧЬЕ: Забавно, но «локтем» мы называем именно конец локтевой кости предплечья." },
                    { "ruka1", "КИСТЬ: В одной руке целых 27 мелких косточек! Это позволяет нам писать, рисовать и играть на пианино." },
                    { "ruka2", "КИСТЬ: Большой палец противопоставлен остальным — именно это позволяет нам крепко хватать предметы." },
                    { "ribs", "РЁБРА: У нас 12 пар ребер. При глубоком вдохе они расширяются, прямо как меха у баяна!" },
                    { "spina", "ПОЗВОНОЧНИК: Это гибкая основа нашего тела. Он состоит из 33-34 позвонков, сложенных как башенка." },
                    { "taz", "ТАЗ: Защищает внутренние органы и переносит вес тела на ноги. У человека он имеет удобную форму чаши." },
                    { "bedro1", "БЕДРЕННАЯ КОСТЬ: Самая длинная и прочная кость в организме. Она способна выдержать вес легкового авто!" },
                    { "bedro2", "БЕДРЕННАЯ КОСТЬ: Внутри этой большой кости находится костный мозг, который создает клетки крови." },
                    { "golen1", "ГОЛЕНЬ: Здесь находится большеберцовая кость — главная опора нашей ноги." },
                    { "golen2", "ГОЛЕНЬ: Параллельно идет тонкая малоберцовая кость, к которой крепятся мышцы для движения стопой." },
                    { "stopa1", "СТОПА: В стопе 26 костей! Она работает как рессора, круто смягчая наши шаги при беге и прыжках." },
                    { "stopa2", "СТОПА: На стопы приходится весь наш вес. Свод стопы пружинит, чтобы мы не уставали при долгой ходьбе." }
                }}
            };

        private int secondsPassed = 0;
        private int mistakesCount = 0;
        private int selectedLevel = 1;
        private Dictionary<string, Bitmap> bitmapCache = new Dictionary<string, Bitmap>();
        private SkeletonDefinition skeleton;
        private HashSet<string> placedBones = new HashSet<string>();
        private List<string> availableNeighbors = new List<string>();

        private Dictionary<string, PictureBox> slotBoxes = new Dictionary<string, PictureBox>();
        private List<PictureBox> choiceBoxes = new List<PictureBox>();

        private static readonly Dictionary<string, string> mirrorPairs = new Dictionary<string, string>
            {
                {"golen1","golen2"},    {"golen2","golen1"},
                {"bedro1","bedro2"},    {"bedro2","bedro1"},
                {"ruka1","ruka2"},      {"ruka2","ruka1"},
                {"predplesho1","predplesho2"}, {"predplesho2","predplesho1"},
                {"plesho1","plesho2"},  {"plesho2","plesho1"},
                {"lopat1","lopat2"},    {"lopat2","lopat1"},
                {"cluchis1","cluchis2"},{"cluchis2","cluchis1"},
                {"stopa1","stopa2"},    {"stopa2","stopa1"},
            };


        private bool isDragging = false;
        private string draggingBoneId = null;
        private Image draggingImage = null;
        private Rectangle draggingRect;
        private Point dragOffset;
        private PictureBox hiddenSourcePb = null;

        private List<(Image img, Rectangle rect)> assemblyDrawList = new List<(Image, Rectangle)>();

        // *** ДОБАВЛЕНО: силуэт скелета на фоне
        private Image silhouetteImage;
        private Rectangle silhouetteRect;

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

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, victoryPanel, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, pausePanel, new object[] { true });


            // Инициализация панели фактов
            panelInfo = new Panel();
            panelInfo.Size = new Size(650, 85);
            panelInfo.BackColor = Color.LightYellow; // Можно сменить цвет
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Visible = false; // Изначально скрыта

            // Кнопка закрытия (крестик)
            lblClose = new Label();
            lblClose.Size = new Size(25, 25);
            lblClose.Location = new Point(620, 5);
            lblClose.Text = "✕";
            lblClose.Font = new Font("Arial", 12, FontStyle.Bold);
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += (s, ev) => { panelInfo.Visible = false; };

            // Текст факта
            lblInfoText = new Label();
            lblInfoText.Location = new Point(30, 15);
            lblInfoText.Size = new Size(590, 55);
            lblInfoText.TextAlign = ContentAlignment.MiddleCenter;

            panelInfo.Controls.Add(lblClose);
            panelInfo.Controls.Add(lblInfoText);
            this.Controls.Add(panelInfo); // Добавляем на форму
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
            bitmapCache.Clear();
            assemblyDrawList.Clear();
            if (panelInfo != null) panelInfo.Visible = false;

            skeleton = SkeletonLibrary.GetSkeleton(level);

            // *** ДОБАВЛЕНО: выбираем силуэт по уровню и центрируем его в зоне сборки
            switch (level)
            {
                case 2: silhouetteImage = Properties.Resources.cat_template; break;
                case 3: silhouetteImage = Properties.Resources.men_template; break;
                default: silhouetteImage = Properties.Resources.dino_template; break;
            }
            Bitmap silBmp = new Bitmap(silhouetteImage);
            Rectangle silBounds = GetOpaqueBounds(silBmp);

            // Берём bbox всего скелета — складываем все кости вместе
            Bitmap skelBmp = new Bitmap(1200, 700);
            using (Graphics g = Graphics.FromImage(skelBmp))
            {
                foreach (var bone in skeleton.Bones)
                {
                    Image boneImg = GetBoneImage(bone.ImageKey);
                    g.DrawImage(boneImg, 0, 0, 1200, 700);
                }
            }
            Rectangle skelBounds = GetOpaqueBounds(skelBmp);

            float scaleX = (float)skelBounds.Width / silBounds.Width;
            float scaleY = (float)skelBounds.Height / silBounds.Height;
            float scale = Math.Min(scaleX, scaleY);

            int silW = (int)(silBounds.Width * scale);
            int silH = (int)(silBounds.Height * scale);
            int silX = 450 + skelBounds.X - (int)(silBounds.X * scale) + 5 ;
            int silY = 270 + skelBounds.Y - (int)(silBounds.Y * scale) - 14; // подбирай 30

            silhouetteRect = new Rectangle(silX, silY, silW, silH);
            // *** КОНЕЦ ДОБАВЛЕНИЯ

            PlaceBoneInAssembly(skeleton.StartBoneId);
            placedBones.Add(skeleton.StartBoneId);

            RefreshChoicePanel();
            TimerGame.Start();
        }

        private void PlaceBoneInAssembly(string boneId)
        {
            var bone = skeleton.GetBone(boneId);
            if (bone == null) return;

            int paperX = 450;
            int paperY = 270;
            int paperWidth = 1200;
            int paperHeight = 550;

            assemblyDrawList.Add((GetBoneImage(bone.ImageKey), new Rectangle(paperX, paperY, paperWidth, paperHeight)));

            this.Invalidate();
        }

        private void RefreshChoicePanel()
        {
            foreach (var pb in choiceBoxes)
                this.Controls.Remove(pb);
            choiceBoxes.Clear();
            availableNeighbors.Clear();

            // Собираем все неразмещённые кости
            foreach (var bone in skeleton.Bones)
            {
                if (!placedBones.Contains(bone.Id))
                    availableNeighbors.Add(bone.Id);
            }

            var rng = new Random();
            availableNeighbors = availableNeighbors.OrderBy(x => rng.Next()).ToList();

            int count = availableNeighbors.Count;
            if (count == 0) return;

            int boneW = count > 8 ? 90 : 150;
            int boneH = count > 8 ? 90 : 150;
            int spacing = count > 8 ? 15 : 30;

            int availableWidth = this.Width - 40;
            int maxPerRow = availableWidth / (boneW + spacing);
            if (maxPerRow < 1) maxPerRow = 1;

            for (int i = 0; i < count; i++)
            {
                string boneId = availableNeighbors[i];
                var boneDef = skeleton.GetBone(boneId);

                int row = i / maxPerRow;
                int col = i % maxPerRow;

                int itemsInThisRow = Math.Min(maxPerRow, count - row * maxPerRow);
                int totalW = itemsInThisRow * boneW + (itemsInThisRow - 1) * spacing;
                int startX = (this.Width - totalW) / 2;

                int x = startX + col * (boneW + spacing);
                int y = ChoiceZone.Y + row * (boneH + spacing) + 170;

                PictureBox pb = new PictureBox();
                pb.Size = new Size(boneW, boneH);
                pb.Location = new Point(x, y);
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
            draggingImage = pb.Image;

            hiddenSourcePb = pb;
            pb.Visible = false;

            int imgWidth = draggingImage.Width;
            int imgHeight = draggingImage.Height;

            Point clientMousePos = this.PointToClient(Cursor.Position);
            draggingRect = new Rectangle(clientMousePos.X - (imgWidth / 2), clientMousePos.Y - (imgHeight / 2), imgWidth, imgHeight);

            this.Invalidate(draggingRect);
        }

        private void ChoiceBone_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingImage == null) return;

            Rectangle oldRect = draggingRect;
            oldRect.Inflate(5, 5);

            int imgWidth = draggingImage.Width;
            int imgHeight = draggingImage.Height;

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

            Point dropPoint = this.PointToClient(Cursor.Position);
            bool isInAssemblyZone = AssemblyZone.Contains(dropPoint);

            // *** ИЗМЕНЕНО: убрана проверка соседей — теперь любой порядок сборки
            if (isInAssemblyZone && IsDropOnBoneSlot(draggingBoneId, dropPoint))
            {
                placedBones.Add(draggingBoneId);
                PlaceBoneInAssembly(draggingBoneId);
                this.Controls.Remove(hiddenSourcePb);
                choiceBoxes.Remove(hiddenSourcePb);
                hiddenSourcePb.Dispose();
                RefreshChoicePanel();

                // === ВСТАВЛЯЕМ СЮДА (Сразу после установки и обновления панели выбора) ===
                if (levelFacts.ContainsKey(selectedLevel) && levelFacts[selectedLevel].ContainsKey(draggingBoneId))
                {
                    lblInfoText.Text = levelFacts[selectedLevel][draggingBoneId];
                    panelInfo.Location = new Point((this.Width - panelInfo.Width) / 2, 50);
                    panelInfo.Visible = true;
                    panelInfo.BringToFront();
                }
                // === КОНЕЦ ВСТАВКИ ===

                CheckVictory();
            }
            else
            {
                hiddenSourcePb.Visible = true;
                mistakesCount++;
                lblMistakes.Text = mistakesCount.ToString();
            }
            // *** КОНЕЦ ИЗМЕНЕНИЯ

            Rectangle clearRect = draggingRect;
            clearRect.Inflate(5, 5);

            draggingImage = null;
            draggingBoneId = null;
            hiddenSourcePb = null;

            this.Invalidate(clearRect);
        }

        // Константы сборочной зоны — чтобы не дублировать магические числа
        private const int PaperX = 450, PaperY = 270, PaperW = 1200, PaperH = 550;

        private bool IsDropOnBoneSlot(string boneId, Point dropPoint)
        {
            if (CheckPixelsAt(boneId, dropPoint)) return true;

            if (mirrorPairs.TryGetValue(boneId, out string mirrorId) && !placedBones.Contains(mirrorId))
                if (CheckPixelsAt(mirrorId, dropPoint))
                    return true;

            return false;
        }

        private bool CheckPixelsAt(string boneId, Point screenPt, int radius = 40)
        {
            var bone = skeleton.GetBone(boneId);
            if (bone == null) return false;

            Bitmap bmp = GetCachedBitmap(bone.ImageKey);

            // Правильный пересчёт: экранные координаты → пиксели изображения с учётом масштаба
            float sx = (float)bmp.Width / PaperW;   // для 1200x700: sx=1.0, sy=700/550≈1.27
            float sy = (float)bmp.Height / PaperH;

            int cx = (int)((screenPt.X - PaperX) * sx);
            int cy = (int)((screenPt.Y - PaperY) * sy);

            // Радиус тоже масштабируем, чтобы зона захвата на экране осталась той же
            int rx = (int)(radius * sx) + 1;
            int ry = (int)(radius * sy) + 1;

            for (int dx = -rx; dx <= rx; dx++)
                for (int dy = -ry; dy <= ry; dy++)
                {
                    int px = cx + dx, py = cy + dy;
                    if (px < 0 || py < 0 || px >= bmp.Width || py >= bmp.Height) continue;
                    if (bmp.GetPixel(px, py).A > 30) return true;
                }

            return false;
        }

        // Создаём собственную копию, а не ссылку на ресурс — иначе Dispose() в ClearLevel
        // портит ResourceManager-кэш и следующий уровень падает
        private Bitmap GetCachedBitmap(string imageKey)
        {
            if (!bitmapCache.TryGetValue(imageKey, out Bitmap bmp))
            {
                bmp = new Bitmap(GetBoneImage(imageKey));
                bitmapCache[imageKey] = bmp;
            }
            return bmp;
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
            int stars = 3;
            if (mistakesCount > 3) stars = 1;
            else if (mistakesCount > 1) stars = 2;

            Image sourceBg;
            if (stars == 1) sourceBg = Properties.Resources.pobeda1;
            else if (stars == 2) sourceBg = Properties.Resources.pobeda2;
            else sourceBg = Properties.Resources.pobeda3;

            Bitmap preSizedBg = new Bitmap(victoryPanel.Width, victoryPanel.Height);

            using (Graphics g = Graphics.FromImage(preSizedBg))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                g.DrawImage(sourceBg, 0, 0, victoryPanel.Width, victoryPanel.Height);

                using (Font font = new Font(lblVictoryTime.Font.FontFamily, lblVictoryTime.Font.Size, lblVictoryTime.Font.Style))
                using (Brush brush = new SolidBrush(lblVictoryTime.ForeColor))
                {
                    g.DrawString(secondsPassed.ToString(), font, brush, lblVictoryTime.Left, lblVictoryTime.Top);
                    g.DrawString(mistakesCount.ToString(), font, brush, lblVictoryMistakes.Left, lblVictoryMistakes.Top);
                }
            }

            lblVictoryTime.Visible = false;
            lblVictoryMistakes.Visible = false;

            victoryPanel.BackgroundImage = preSizedBg;
            victoryPanel.BackgroundImageLayout = ImageLayout.None;

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
            victoryPanel.Visible = false;
            assemblyDrawList.Clear();
            foreach (var bmp in bitmapCache.Values) bmp.Dispose();
            bitmapCache.Clear();

            // *** ДОБАВЛЕНО: сбрасываем силуэт при очистке уровня
            silhouetteImage = null;
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

        private Rectangle GetOpaqueBounds(Bitmap bmp)
        {
            int minX = bmp.Width, minY = bmp.Height, maxX = 0, maxY = 0;

            var data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int stride = data.Stride;
            byte[] pixels = new byte[Math.Abs(stride) * bmp.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);
            bmp.UnlockBits(data);

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    byte a = pixels[y * stride + x * 4 + 3];
                    if (a > 10)
                    {
                        if (x < minX) minX = x;
                        if (y < minY) minY = y;
                        if (x > maxX) maxX = x;
                        if (y > maxY) maxY = y;
                    }
                }

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            // *** ДОБАВЛЕНО: 0. Первым рисуем силуэт-подсказку на фоне
            if (silhouetteImage != null)
                e.Graphics.DrawImage(silhouetteImage, silhouetteRect);

            // 1. Поверх силуэта — уже собранные кости (вплавление)
            foreach (var (img, rect) in assemblyDrawList)
                e.Graphics.DrawImage(img, rect);

            // 2. В самом конце — кость под курсором при перетаскивании
            if (isDragging && draggingImage != null)
                e.Graphics.DrawImage(draggingImage, draggingRect);
        }
    }
}