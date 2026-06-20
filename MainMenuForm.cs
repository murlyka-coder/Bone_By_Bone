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
        public event EventHandler ExitClicked;

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

        private void button3_Click(object sender, EventArgs e)
        {
            ExitClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.buttonlight1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.buttonnormal1;
        }


        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Image = Properties.Resources.buttonpress1;

        }



        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.buttonlight2;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.buttonnormal2;
        }


        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.buttonpress2;

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.buttonlight3;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.buttonnormal3;
        }


        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.buttonpress3;

        }



    }
}
