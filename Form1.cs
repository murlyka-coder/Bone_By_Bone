using System;
using System.Windows.Forms;

namespace Bone_By_Bone
{
    public partial class Form1 : Form
    {
        private string previousPanel = "menu";

        public Form1()
        {
            InitializeComponent();
            mainMenuForm1.StartGameClicked += MainMenu_StartGameClicked;
            mainMenuForm1.SettingsClicked += (s, e) => OpenSettings();
            settingForm1.BackClicked += SettingsForm1_BackClicked;


        }

        private void MainMenu_StartGameClicked(object sender, EventArgs e)
        {
            mainMenuForm1.Visible = false;
            levelSekectForm1.Visible = true;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}