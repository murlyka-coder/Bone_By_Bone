using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Bone_By_Bone
{
    public partial class GameForm : UserControl
    {
        public event EventHandler BackToMenuClicked;
        private int secondsPassed = 0;
        private bool isDragging = false;
        private Point startPoint;
        private List<PictureBox> activeBones = new List<PictureBox>();
        private List<PictureBox> activeTargets = new List<PictureBox>();
        private int mistakesCount = 0;
        private int selectedLevel = 1;
        private LevelConfig levelConfig = new LevelConfig();
        // Элементы всплывающего баннера
        private Panel panelInfo;
        private Label lblInfoText;
        private Label lblClose; // Крестик закрытия

        // Список интересных фактов
        private string[] dinoFacts = new string[]
        {
    "ЧЕРЕП: Достигал 1.5 метров в длину и обладал сокрушительной силой укуса в 3.5 тонны!",
    "ШЕЯ: Была короткой и невероятно мускулистой, чтобы надежно удерживать тяжелую голову.",
    "РЕБРА: Образовывали прочный панцирь, защищавшую легкие и сердце этого гиганта.",
    "ЛАПКА: Передние лапы были двупалыми и крошечными, но при этом на удивление сильными.",
    "ТАЗ: Служил мощной опорой для тяжелых ног и помогал удерживать массивный вес тела.",
    "НОГА: Сильные задние ноги позволяли Т-Рексу развивать скорость при беге до 20-25 км/ч.",
    "ХВОСТ: Длинный и тяжелый хвост служил балансиром, удерживая равновесие при беге."
        };

        // СТРОКИ ОБЪЯВЛЕНИЯ ПЛАНШЕТОВ ДОЛЖНЫ СТОЯТЬ СТРОГО ТУТ:
        private PictureBox picSkel;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public GameForm()
        {
            InitializeComponent();

            // Создаем панель баннера (белый фон)
            panelInfo = new Panel();
            panelInfo.Size = new Size(650, 85);
            panelInfo.Location = new Point((910 - 650) / 2, 10); // Центрируем по ширине экрана
            panelInfo.BackColor = Color.White; // СТРОГО БЕЛЫЙ ФОН
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Visible = false;

            // Кнопка-крестик «Х» в правом верхнем углу панели
            lblClose = new Label();
            lblClose.Size = new Size(25, 25);
            lblClose.Location = new Point(620, 5); // В углу панели
            lblClose.Text = "✕";
            lblClose.ForeColor = Color.Black; // Черный цвет
            lblClose.Font = new Font("Arial", 12, FontStyle.Bold);
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += (s, ev) => { panelInfo.Visible = false; };

            // Текст внутри баннера (черный цвет) - идеально центрирован
            lblInfoText = new Label();
            lblInfoText.Location = new Point(30, 15); // Симметричные отступы
            lblInfoText.Size = new Size(590, 55);    // Симметричная ширина под центр
            lblInfoText.ForeColor = Color.Black;
            lblInfoText.Font = new Font("Arial", 11, FontStyle.Bold);
            lblInfoText.TextAlign = ContentAlignment.MiddleCenter;

            // Собираем всё вместе
            panelInfo.Controls.Add(lblClose);
            panelInfo.Controls.Add(lblInfoText);
            this.Controls.Add(panelInfo);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblTime.Text = "Время: " + secondsPassed + " сек";

        }


        public void StartLevel(int level)
        {
            selectedLevel = level;

            ClearActiveLevel();
            var data = levelConfig.GetLevel(level);
            int boneCount = data.boneCount;

            Image[] boneImages = null;
            Point[] targetLocations = null;
            Size[] boneSizes = null;

            // 1. Создаем прозрачный холст на ВЕСЬ экран ноутбука
            picSkel = new PictureBox();
            picSkel.Name = "picSkel";
            picSkel.Size = new Size(this.Width, this.Height - 60);
            picSkel.Location = new Point(0, 20);
            picSkel.BackColor = Color.Transparent;
            picSkel.SizeMode = PictureBoxSizeMode.Normal; // Обычный режим

            // 2. Создаем чистый прозрачный рисунок размером с экран и рисуем силуэт 600х400 строго по центру
            Bitmap bmp = new Bitmap(picSkel.Width, picSkel.Height);
            int dinoWidth = 600; // Идеальная ширина
            int dinoHeight = 400; // Идеальная высота
            int offsetX = (bmp.Width - dinoWidth) / 2;
            int offsetY = (bmp.Height - dinoHeight) / 2 - 30; // Чуть приподнят над полками

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Прорисовываем силуэт динозавра по центру пустого прозрачного холста
                g.DrawImage(Properties.Resources.dino_template, offsetX, offsetY, dinoWidth, dinoHeight);
            }
            picSkel.Image = bmp; // Назначаем этот рисунок нашей панели
            this.Controls.Add(picSkel);

            if (level == 1)
            {
                boneCount = 7;

                boneImages = new Image[]
                {
            Properties.Resources.dino_skull,
            Properties.Resources.dino_neck,
            Properties.Resources.dino_ribs,
            Properties.Resources.dino_arm,
            Properties.Resources.dino_pelvis,
            Properties.Resources.dino_leg,
            Properties.Resources.dino_tail
                };

                int boardHeight = picSkel.Height;
                int dockY = boardHeight - 110; // Высота деревянных полок

                // Размеры костей под масштаб 600х400
                boneSizes = new Size[]
                {
            new Size(100, 80),  // Череп
            new Size(45, 60),   // Шея
            new Size(100, 80),  // Рёбра
            new Size(75, 75),   // Лапка
            new Size(70, 60),   // Таз
            new Size(90, 120),  // Нога
            new Size(150, 75)   // Хвост
                };

                // Координаты целей относительно центрального силуэта
                targetLocations = new Point[]
                {
            new Point(offsetX + 20, offsetY + 40),   // Череп
            new Point(offsetX + 145, offsetY + 40),  // Шея
            new Point(offsetX + 200, offsetY + 90),  // Рёбра
            new Point(offsetX + 110, offsetY + 170), // Лапка
            new Point(offsetX + 200, offsetY + 170),  // Таз 
            new Point(offsetX + 280, offsetY + 170), // Нога
            new Point(offsetX + 400, offsetY + 110)  // Хвост
                };

                // --- ГЕНЕРАЦИЯ ЭЛЕМЕНТОВ НА ЭКРАНЕ ---
                int cellWidth = this.Width / 8; // Ширина ячейки под ящики

                for (int i = 0; i < boneCount; i++)
                {
                    Size currentSize = (boneSizes != null) ? boneSizes[i] : data.boneSize;

                    // 1. Создаем цель
                    PictureBox target = new PictureBox();
                    target.Size = currentSize;
                    target.BackColor = Color.Transparent; // Полностью невидима
                    target.BorderStyle = BorderStyle.None;
                    target.SizeMode = PictureBoxSizeMode.Zoom;
                    target.Location = targetLocations[i];

                    picSkel.Controls.Add(target); // Добавляем в полноэкранный picSkel
                    activeTargets.Add(target);

                    // 2. Создаем кость
                    PictureBox bone = new PictureBox();
                    bone.Size = currentSize;
                    bone.BackColor = Color.Transparent;
                    bone.SizeMode = PictureBoxSizeMode.Zoom;
                    bone.Image = boneImages[i];

                    // Раскладываем кости со 2-й по 8-ю ячейку (первая пустая)
                    int cellIndex = i + 1;
                    int cellCenter = cellIndex * cellWidth + cellWidth / 2;
                    int posX = cellCenter - (currentSize.Width / 2);

                    bone.Location = new Point(posX, dockY);
                    bone.Tag = target;

                    bone.MouseDown += DynamicBone_MouseDown;
                    bone.MouseMove += DynamicBone_MouseMove;
                    bone.MouseUp += DynamicBone_MouseUp;

                    picSkel.Controls.Add(bone); // Добавляем в полноэкранный picSkel! 
                    activeBones.Add(bone);

                    bone.BringToFront();
                }

                TimerGame.Start();
                return;
            }
        }

        // Метод проверки: установлены ли все кости на свои цели
        private void CheckVictory()
        {
            // Победа наступает, когда все активные кости вплавлены в динозавра (стали невидимыми)
            bool allSnapped = activeBones.All(b => !b.Visible);

            if (allSnapped)
            {
                TimerGame.Stop();

                int stars = 3;
                var thresholds = levelConfig.GetStarThresholds(selectedLevel);
                int timeFor3Stars = thresholds.timeFor3Stars;
                int timeFor2Stars = thresholds.timeFor2Stars;

                if (secondsPassed >= timeFor2Stars || mistakesCount > 3) stars = 1;
                else if (secondsPassed >= timeFor3Stars || mistakesCount > 1) stars = 2;

                string starRating = new string('★', stars) + new string('☆', 3 - stars);
                MessageBox.Show($"Динозавр собран!\n\nВремя: {secondsPassed} сек.\nОшибок: {mistakesCount}\nОценка: {starRating}", "Победа!");

                btnBackToMenu.Visible = true;
            }
        }


        private void ClearActiveLevel()
        {
            btnBackToMenu.Visible = false;

            // Возвращаем видимость костям перед очисткой
            foreach (var b in activeBones) b.Visible = true;

            // Удаляем полноэкранный холст
            Control board = this.Controls["picSkel"];
            if (board != null) this.Controls.Remove(board);

            activeBones.Clear();
            activeTargets.Clear();
        }

        private void DynamicBone_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox bone = (PictureBox)sender;
            PictureBox target = (PictureBox)bone.Tag;

            // Если кость уже стоит на месте цели — её нельзя двигать
            if (bone.Location == target.Location) return;

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = e.Location;
                bone.BringToFront();
            }
        }

        private void DynamicBone_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                PictureBox bone = (PictureBox)sender;
                bone.Left += e.X - startPoint.X;
                bone.Top += e.Y - startPoint.Y;
            }
        }

        private void DynamicBone_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            PictureBox bone = (PictureBox)sender;
            PictureBox target = (PictureBox)bone.Tag;

            if (bone.Location == target.Location) return;

            // Считаем расстояние напрямую (так как кость и цель имеют одного полноэкранного родителя!)
            int deltaX = Math.Abs(bone.Left - target.Left);
            int deltaY = Math.Abs(bone.Top - target.Top);

            if (deltaX < 35 && deltaY < 35) // Кость встала на место
            {
                // === НОВЫЙ ТРЮК: ВПЛАВЛЕНИЕ ПИКСЕЛЕЙ В ФОН ===
                using (Graphics g = Graphics.FromImage(picSkel.Image))
                {
                    // Рисуем картинку кости прямо на холсте динозавра по координатам цели
                    g.DrawImage(bone.Image, target.Left, target.Top, target.Width, target.Height);
                }
                picSkel.Invalidate(); // Принудительно обновляем экран, чтобы показать изменения

                bone.Visible = false; // Саму летающую кость полностью убираем!

                // === ВЫВОД ИНФОРМАЦИИ ПРИ СБОРКЕ ===
                int boneIndex = activeBones.IndexOf(bone);
                if (boneIndex >= 0 && boneIndex < dinoFacts.Length)
                {
                    lblInfoText.Text = dinoFacts[boneIndex];
                    panelInfo.Visible = true;
                    panelInfo.BringToFront(); // Показываем баннер на переднем плане
                }

                // Бесшумный запуск звука
                try
                {
                    string soundPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sounds", "snap.mp3");
                    if (!System.IO.File.Exists(soundPath)) soundPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sounds", "snap.wav");

                    if (System.IO.File.Exists(soundPath))
                    {
                        mciSendString("close snap", null, 0, 0);
                        string fileType = soundPath.EndsWith(".mp3") ? "mpegvideo" : "waveaudio";
                        mciSendString($"open \"{soundPath}\" type {fileType} alias snap", null, 0, 0);
                        mciSendString("play snap", null, 0, 0);
                    }
                }
                catch { }

                CheckVictory();
            }
            else
            {
                mistakesCount++;
                lblMistakes.Text = "Ошибки: " + mistakesCount;
            }
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Сбрасываем время и ошибки
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "Время: 0 сек";
            lblMistakes.Text = "Ошибки: 0";

            // Перезапускаем текущий выбранный уровень
            StartLevel(selectedLevel);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ClearActiveLevel();
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "Время: 0 сек";
            lblMistakes.Text = "Ошибки: 0";
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
