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
    public partial class LevelSekectForm : UserControl
    {

        public event EventHandler BackToMenuClicked;

        public LevelSekectForm()
        {
            InitializeComponent();
        }

        public event EventHandler<int> LevelSelected;

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 1);
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 2);
        }

        private void btnLevel3_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 3);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }


        private void buttonlevelnormal1_MouseEnter(object sender, EventArgs e)
        {
            buttonlevelnormal1.Image = Properties.Resources.buttonlevellight1;
        }

        private void buttonlevelnormal1_MouseLeave(object sender, EventArgs e)
        {
            buttonlevelnormal1.Image = Properties.Resources.buttonlevelnormal1;
        }


        private void buttonlevelnormal1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonlevelnormal1.Image = Properties.Resources.buttonlevelpress1;

        }

        private void buttonlevelnormal2_MouseEnter(object sender, EventArgs e)
        {
            buttonlevelnormal2.Image = Properties.Resources.buttonlevellight2;
        }

        private void buttonlevelnormal2_MouseLeave(object sender, EventArgs e)
        {
            buttonlevelnormal2.Image = Properties.Resources.buttonlevelnormal2;
        }


        private void buttonlevelnormal2_MouseDown(object sender, MouseEventArgs e)
        {
            buttonlevelnormal2.Image = Properties.Resources.buttonlevelpress2;

        }

        private void buttonlevelnormal3_MouseEnter(object sender, EventArgs e)
        {
            buttonlevelnormal3.Image = Properties.Resources.buttonlevellight3;
        }

        private void buttonlevelnormal3_MouseLeave(object sender, EventArgs e)
        {
            buttonlevelnormal3.Image = Properties.Resources.buttonlevelnormal3;
        }


        private void buttonlevelnormal3_MouseDown(object sender, MouseEventArgs e)
        {
            buttonlevelnormal3.Image = Properties.Resources.buttonlevelpress3;

        }


        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.Image = Properties.Resources.buttonlevelnazadlight;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.Image = Properties.Resources.buttonlevelnazadnormal;
        }


        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnBack.Image = Properties.Resources.buttonlevelnazadpress;

        }


    }
}
