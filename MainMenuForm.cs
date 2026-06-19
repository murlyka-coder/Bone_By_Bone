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
    public partial class MainMenuForm : UserControl
    {

        public event EventHandler StartGameClicked;
        public event EventHandler SettingsClicked;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGameClicked?.Invoke(this, EventArgs.Empty);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.buttonlight1;
            button1.BackColor = Color.Transparent;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.buttonnormal1;
            button1.BackColor = Color.Transparent;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.buttonpress1;
            button1.BackColor = Color.Transparent;
        }


    }
}
