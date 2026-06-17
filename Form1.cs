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
        }

        private void MainMenu_StartGameClicked(object sender, EventArgs e)
        {
            mainMenuForm1.Visible = false;
            levelSekectForm1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}