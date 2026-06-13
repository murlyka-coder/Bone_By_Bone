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
    public partial class Form1 : Form
    {
        private int secondsPassed = 0; // количество прошедших секунд
        private bool isDragging = false; // тащим ли мы кость прямо сейчас?
        private Point startPoint;        // точка, за которую мы зажали кость
        private List<PictureBox> activeBones = new List<PictureBox>();
        private List<PictureBox> activeTargets = new List<PictureBox>();
        private int mistakesCount = 0; // количество ошибок
        private int selectedLevel = 1; // какой уровень сейчас выбран?
        LevelConfig levelConfig = new LevelConfig();


        // Метод удаления костей с экрана при возврате в меню
        private void ClearActiveLevel()
        {
            foreach (var b in activeBones) panelGame.Controls.Remove(b);
            foreach (var t in activeTargets) panelGame.Controls.Remove(t);
            activeBones.Clear();
            activeTargets.Clear();
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
                timerGame.Stop();

                int stars = 3;
                int timeFor3Stars = selectedLevel == 1 ? 15 : (selectedLevel == 2 ? 10 : 6);
                int timeFor2Stars = selectedLevel == 1 ? 30 : (selectedLevel == 2 ? 20 : 12);

                if (secondsPassed >= timeFor2Stars || mistakesCount > 3) stars = 1;
                else if (secondsPassed >= timeFor3Stars || mistakesCount > 1) stars = 2;

                string starRating = new string('★', stars) + new string('☆', 3 - stars);
                MessageBox.Show($"Уровень пройден!\n\nВремя: {secondsPassed} сек.\nОшибок: {mistakesCount}\nОценка: {starRating}", "Победа!");

                btnBackToMenu.Visible = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Скрываем главное меню
            label1.Visible = false;
            button1.Visible = false;

            // Показываем панель выбора уровней
            panelLevelSelect.Visible = true;
        }

        private void StartLevel(int level)
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

            panelLevelSelect.Visible = false;
            panelGame.Visible = true;
            timerGame.Start();
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

        private void timerGame_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblTime.Text = "Время: " + secondsPassed + " сек";
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            button1.Visible = true;
            panelGame.Visible = false;
            btnBackToMenu.Visible = false;

            // Очищаем динамические кости и цели с экрана
            ClearActiveLevel();

            secondsPassed = 0;
            mistakesCount = 0;

            lblTime.Text = "Время: 0 сек";
            lblMistakes.Text = "Ошибки: 0";
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            StartLevel(1);
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            StartLevel(2);
        }

        private void btnLevel3_Click(object sender, EventArgs e)
        {
            StartLevel(3);
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
