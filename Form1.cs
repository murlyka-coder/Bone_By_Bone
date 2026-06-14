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
        private string previousPanel = "menu";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
    }
}
