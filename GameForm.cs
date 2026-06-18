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
        private bool isDragging = false;
        private Point startPoint;
        private List<PictureBox> activeBones = new List<PictureBox>();
        private List<PictureBox> activeTargets = new List<PictureBox>();
        private int mistakesCount = 0;
        private int selectedLevel = 1;
        private LevelConfig levelConfig = new LevelConfig();

        public GameForm()
        {
            InitializeComponent();
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
            Size boneSize = data.boneSize;


            // --- УМНЫЙ РАСЧЕТ ШАГА ---
            // Нам нужно распределить кости в пределах ширины панели (700 пикселей)
            int margin = 20; // отступ от левого и правого краев панели
            int availableWidth = panelGame.Width - (margin * 2) - boneSize.Width; // доступная ширина для шага
            float step = (float)availableWidth / (boneCount - 1); // расстояние между левыми краями соседних костей

            for (int i = 0; i < boneCount; i++)
            {
                // Вычисляем точную координату X для i-й кости
                int posX = margin + (int)(i * step);

                // 1. Создаем цель
                PictureBox target = new PictureBox();
                target.Size = boneSize;
                target.BackColor = Color.DimGray;
                target.Location = new Point(posX, 80); // используемposX
                target.Size = boneSize;
                target.BackColor = Color.DimGray;
                target.BorderStyle = BorderStyle.FixedSingle; // ДОБАВИТЬ ЭТУ СТРОКУ
                target.Location = new Point(posX, 80);

                panelGame.Controls.Add(target);
                activeTargets.Add(target);

                // 2. Создаем кость
                PictureBox bone = new PictureBox();
                bone.Size = boneSize;
                bone.BackColor = Color.White;
                bone.Location = new Point(posX, 340); // используем posX
                bone.Tag = target;
                bone.Size = boneSize;
                bone.BackColor = Color.White;
                bone.BorderStyle = BorderStyle.FixedSingle; // ДОБАВИТЬ ЭТУ СТРОКУ
                bone.Location = new Point(posX, 340);

                bone.MouseDown += DynamicBone_MouseDown;
                bone.MouseMove += DynamicBone_MouseMove;
                bone.MouseUp += DynamicBone_MouseUp;

                panelGame.Controls.Add(bone);
                activeBones.Add(bone);

                bone.BringToFront();
            }

            panelGame.Visible = true;
            TimerGame.Start();
        }




        // Метод проверки: установлены ли все кости на свои цели
        private void CheckVictory()
        {
            bool allSnapped = true;
            foreach (var bone in activeBones)
            {
                PictureBox target = (PictureBox)bone.Tag;
                if (bone.Location != target.Location)
                {
                    allSnapped = false;
                    break;
                }
            }

            // Если все кости на местах — это победа!
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
                MessageBox.Show($"Уровень пройден!\n\nВремя: {secondsPassed} сек.\nОшибок: {mistakesCount}\nОценка: {starRating}", "Победа!");

                btnBackToMenu.Visible = true;
            }
        }



        // Метод удаления костей с экрана при возврате в меню
        private void ClearActiveLevel()
        {
            btnBackToMenu.Visible = false;
            foreach (var b in activeBones) panelGame.Controls.Remove(b);
            foreach (var t in activeTargets) panelGame.Controls.Remove(t);
            activeBones.Clear();
            activeTargets.Clear();
        }



        private void DynamicBone_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox bone = (PictureBox)sender;
            PictureBox target = (PictureBox)bone.Tag; // находим цель, привязанную к этой кости

            // Если кость уже стоит на месте цели — её нельзя двигать
            if (bone.Location == target.Location) return;

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = e.Location;
                bone.BringToFront(); // выводим кость на передний план при перетаскивании
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
            PictureBox target = (PictureBox)bone.Tag; // получаем цель для этой кости

            if (bone.Location == target.Location) return;

            // Считаем расстояние до цели
            int deltaX = Math.Abs(bone.Left - target.Left);
            int deltaY = Math.Abs(bone.Top - target.Top);

            if (deltaX < 35 && deltaY < 35) // теперь кость легче притягивается к цели
            {
                bone.Location = target.Location; // примагничиваем
                bone.BackColor = Color.LightGreen; // (пока оставим временно зеленым для теста)

                // Проверяем, собраны ли ВСЕ кости
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
