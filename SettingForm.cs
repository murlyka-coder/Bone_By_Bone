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
    public partial class SettingForm : UserControl
    {
        public event EventHandler BackClicked;
        private bool soundOn = true;

        public SettingForm()
        {
            InitializeComponent();
        }


        private void buttonplay1_Click(object sender, EventArgs e)
        {
            soundOn = false;
            buttonplay1.Visible = false;
            buttonplay2.Visible = true;

        }

        private void buttonplay2_Click(object sender, EventArgs e)
        {
            soundOn = true;
            buttonplay2.Visible = false;
            buttonplay1.Visible = true;
        }


        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }


        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonlevelnormal1_Click(object sender, EventArgs e)
        {

        }


        private void buttonsend2_MouseEnter(object sender, EventArgs e)
        {
            play1.Image = Properties.Resources.buttonsend2;
        }

        private void buttonsend1_MouseLeave(object sender, EventArgs e)
        {
            play1.Image = Properties.Resources.buttonsend1;
        }


        private void buttonsend3_MouseDown(object sender, MouseEventArgs e)
        {
            play1.Image = Properties.Resources.buttonsend3;

        }

        private void buttonsend4_MouseUp(object sender, MouseEventArgs e)
        {
            play1.Image = Properties.Resources.buttonsend2;

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

        private void buttonplay1_MouseEnter(object sender, EventArgs e)
        {
            buttonplay1.Image = Properties.Resources.buttonmusicplay2;
        }

        private void buttonplay1_MouseLeave(object sender, EventArgs e)
        {
            buttonplay1.Image = Properties.Resources.buttonmusicplay1;
        }


        private void buttonplay1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonplay1.Image = Properties.Resources.buttonmusicplay3;

        }

        private void buttonplay2_MouseEnter(object sender, EventArgs e)
        {
            buttonplay2.Image = Properties.Resources.buttonmusicplay2;
        }

        private void buttonplay2_MouseLeave(object sender, EventArgs e)
        {
            buttonplay2.Image = Properties.Resources.buttonmusicplay1;
        }


        private void buttonplay2_MouseDown(object sender, MouseEventArgs e)
        {
            buttonplay2.Image = Properties.Resources.buttonmusicplay3;

        }


    }
}
