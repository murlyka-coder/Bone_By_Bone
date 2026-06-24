using System;
using System.Windows.Forms;
using System.Media;

namespace Bone_By_Bone
{
    public partial class Form1 : Form
    {
        private string previousPanel = "menu";
        private int selectedLevel = 1;
        private SoundPlayer musicPlayer;

        public Form1()
        {
            InitializeComponent();

            // Инициализируем плеер нашей музыкой из ресурсов
            musicPlayer = new SoundPlayer(Properties.Resources.bg_music);

            // Автоматически запускаем музыку по кругу при старте игры
            try
            {
                musicPlayer.PlayLooping();
            }
            catch { /* Если файл не найден или поврежден, игра не вылетит */ }

            mainMenuForm1.StartGameClicked += MainMenu_StartGameClicked;
            mainMenuForm1.SettingsClicked += (s, e) => OpenSettings();
            settingForm1.BackClicked += SettingsForm1_BackClicked;
            levelSekectForm1.LevelSelected += LevelSekectForm1_LevelSelected;
            gameForm1.BackToMenuClicked += GameForm1_BackToMenuClicked;
            mainMenuForm1.ExitClicked += MainMenu_ExitClicked;
            levelSekectForm1.BackToMenuClicked += LevelSekectForm1_BackToMenuClicked;

            // ПОДПИСЫВАЕМСЯ НА СОБЫТИЕ ВКЛЮЧЕНИЯ/ВЫКЛЮЧЕНИЯ МУЗЫКИ
            settingForm1.MusicToggled += SettingForm1_MusicToggled;
        }

        private void MainMenu_StartGameClicked(object sender, EventArgs e)
        {
            mainMenuForm1.Visible = false;
            levelSekectForm1.Visible = true;
        }

        private void LevelSekectForm1_LevelSelected(object sender, int level)
        {
            selectedLevel = level;
            levelSekectForm1.Visible = false;
            gameForm1.Visible = true;
            gameForm1.StartLevel(level);
        }

        private void GameForm1_BackToMenuClicked(object sender, EventArgs e)
        {
            gameForm1.Visible = false;
            mainMenuForm1.Visible = true;
        }

        private void LevelSekectForm1_BackToMenuClicked(object sender, EventArgs e)
        {
            levelSekectForm1.Visible = false;
            mainMenuForm1.Visible = true;
        }


        private void OpenSettings()
        {
            if (gameForm1.Visible) previousPanel = "game";
            else if (levelSekectForm1.Visible) previousPanel = "levels";
            else previousPanel = "menu";

            mainMenuForm1.Visible = false;
            levelSekectForm1.Visible = false;
            gameForm1.Visible = false;
            settingForm1.Visible = true;
        }

        private void SettingsForm1_BackClicked(object sender, EventArgs e)
        {
            settingForm1.Visible = false;

            if (previousPanel == "game") gameForm1.Visible = true;
            else if (previousPanel == "levels") levelSekectForm1.Visible = true;
            else mainMenuForm1.Visible = true;
        }

        private void MainMenu_ExitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SettingForm1_MusicToggled(object sender, bool isEnabled)
        {
            try
            {
                if (isEnabled)
                {
                    musicPlayer.PlayLooping(); // Включаем музыку по кругу
                }
                else
                {
                    musicPlayer.Stop(); // Полностью останавливаем музыку
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка воспроизведения музыки: " + ex.Message);
            }
        }
    }
}