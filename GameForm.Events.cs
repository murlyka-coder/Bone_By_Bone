using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bone_By_Bone
{
    public partial class GameForm
    {

        private void GameForm_Load(object sender, EventArgs e)
        {
            overlayPanel = new TransparentPanel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.Visible = false;
            this.Controls.Add(overlayPanel);

            this.Controls.Remove(pausePanel);
            pausePanel.Location = new Point(
                (overlayPanel.Width - pausePanel.Width) / 2,
                (overlayPanel.Height - pausePanel.Height) / 2);
            overlayPanel.Controls.Add(pausePanel);
            pausePanel.Visible = true;



            this.Controls.Remove(victoryPanel);
            victoryPanel.Location = new Point(
                (overlayPanel.Width - victoryPanel.Width) / 2,
                (overlayPanel.Height - victoryPanel.Height) / 2);
            overlayPanel.Controls.Add(victoryPanel);
            victoryPanel.Visible = false;

            this.Controls.Remove(inGameSettingsPanel);
            inGameSettingsPanel.Location = new Point(
                (overlayPanel.Width - inGameSettingsPanel.Width) / 2,
                (overlayPanel.Height - inGameSettingsPanel.Height) / 2);
            overlayPanel.Controls.Add(inGameSettingsPanel);
            inGameSettingsPanel.Visible = false;
        }

        private void btnLevelComplete_MouseEnter(object sender, EventArgs e)
        {
            btnLevelComplete.Image = Properties.Resources.buttonlevelcomp2;
        }

        private void btnLevelComplete_MouseLeave(object sender, EventArgs e)
        {
            btnLevelComplete.Image = Properties.Resources.buttonlevelcomp1;
        }

        private void btnLevelComplete_MouseDown(object sender, MouseEventArgs e)
        {
            btnLevelComplete.Image = Properties.Resources.buttonlevelcomp3;
        }

        private void btnLevelComplete_Click(object sender, EventArgs e)
        {
            ClearLevel();
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnComplete_MouseEnter(object sender, EventArgs e)
        {
            btnComplete.Image = Properties.Resources.buttonsobr2;
        }

        private void btnComplete_MouseLeave(object sender, EventArgs e)
        {
            btnComplete.Image = Properties.Resources.buttonsobr1;
        }

        private void btnComplete_MouseDown(object sender, MouseEventArgs e)
        {
            btnComplete.Image = Properties.Resources.buttonsobr3;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            btnComplete.Visible = false;  // было btnLevelComplete
            ShowVictory();
        }




        private void pbVictoryBg_Click(object sender, EventArgs e)
        {

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
            lblTime.Text = "" + secondsPassed + "";
        }

        private void buttonbuter_Click(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void buttonbuter_MouseEnter(object sender, EventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuterlight;
        }

        private void buttonbuter_MouseLeave(object sender, EventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuternormal;
        }

        private void buttonbuter_MouseDown(object sender, MouseEventArgs e)
        {
            buttonbuter.Image = Properties.Resources.buttonbuterpress;
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ClearLevel();
            secondsPassed = 0;
            mistakesCount = 0;
            lblTime.Text = "0";
            lblMistakes.Text = "0";
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void btnResume_MouseEnter(object sender, EventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo2;
        }

        private void btnResume_MouseLeave(object sender, EventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo1;
        }

        private void btnResume_MouseDown(object sender, MouseEventArgs e)
        {
            btnResume.Image = Properties.Resources.buttongo3;
        }

        private void btnEndGame_Click_1(object sender, EventArgs e)
        {
            ClearLevel();
            BackToMenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEndGame_MouseEnter(object sender, EventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend2;
        }

        private void btnEndGame_MouseLeave(object sender, EventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend1;
        }

        private void btnEndGame_MouseDown(object sender, MouseEventArgs e)
        {
            btnEndGame.Image = Properties.Resources.buttonend3;
        }

        // ===== НАСТРОЙКИ ИЗ ПАУЗЫ =====
        private void btnPauseSettings_Click(object sender, EventArgs e)
        {
            SyncInGameSettingsUI();
            pausePanel.Visible = false;
            inGameSettingsPanel.Visible = true;
        }

        private void btnPauseSettings_MouseEnter(object sender, EventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonlight2;
        }

        private void btnPauseSettings_MouseLeave(object sender, EventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonnormal2;
        }

        private void btnPauseSettings_MouseDown(object sender, MouseEventArgs e)
        {
            btnPauseSettings.Image = Properties.Resources.buttonpress2;
        }

        private void SyncInGameSettingsUI()
        {
            inGameButtonPlay1.Visible = AudioSettings.MusicOn;
            inGameButtonStop1.Visible = !AudioSettings.MusicOn;

            inGameButtonPlay2.Visible = AudioSettings.SoundOn;
            inGameButtonStop2.Visible = !AudioSettings.SoundOn;
        }

        private void inGameButtonPlay1_Click(object sender, EventArgs e)
        {
            AudioSettings.SetMusic(false);
            inGameButtonPlay1.Visible = false;
            inGameButtonStop1.Visible = true;
        }

        private void inGameButtonStop1_Click(object sender, EventArgs e)
        {
            AudioSettings.SetMusic(true);
            inGameButtonStop1.Visible = false;
            inGameButtonPlay1.Visible = true;
        }

        private void inGameButtonPlay2_Click(object sender, EventArgs e)
        {
            AudioSettings.SetSound(false);
            inGameButtonPlay2.Visible = false;
            inGameButtonStop2.Visible = true;
        }

        private void inGameButtonStop2_Click(object sender, EventArgs e)
        {
            AudioSettings.SetSound(true);
            inGameButtonStop2.Visible = false;
            inGameButtonPlay2.Visible = true;
        }

        private void inGameButtonPlay1_MouseEnter(object sender, EventArgs e)
        {
            inGameButtonPlay1.Image = Properties.Resources.buttonmusicplay2;
        }

        private void inGameButtonPlay1_MouseLeave(object sender, EventArgs e)
        {
            inGameButtonPlay1.Image = Properties.Resources.buttonmusicplay1;
        }

        private void inGameButtonPlay1_MouseDown(object sender, MouseEventArgs e)
        {
            inGameButtonPlay1.Image = Properties.Resources.buttonmusicplay3;
        }

        private void inGameButtonPlay2_MouseEnter(object sender, EventArgs e)
        {
            inGameButtonPlay2.Image = Properties.Resources.buttonmusicplay2;
        }

        private void inGameButtonPlay2_MouseLeave(object sender, EventArgs e)
        {
            inGameButtonPlay2.Image = Properties.Resources.buttonmusicplay1;
        }

        private void inGameButtonPlay2_MouseDown(object sender, MouseEventArgs e)
        {
            inGameButtonPlay2.Image = Properties.Resources.buttonmusicplay3;
        }

        private void inGameButtonStop1_MouseEnter(object sender, EventArgs e)
        {
            inGameButtonStop1.Image = Properties.Resources.buttonmusicstop2;
        }

        private void inGameButtonStop1_MouseLeave(object sender, EventArgs e)
        {
            inGameButtonStop1.Image = Properties.Resources.buttonmusicstop1;
        }

        private void inGameButtonStop1_MouseDown(object sender, MouseEventArgs e)
        {
            inGameButtonStop1.Image = Properties.Resources.buttonmusicstop3;
        }

        private void inGameButtonStop2_MouseEnter(object sender, EventArgs e)
        {
            inGameButtonStop2.Image = Properties.Resources.buttonmusicstop2;
        }

        private void inGameButtonStop2_MouseLeave(object sender, EventArgs e)
        {
            inGameButtonStop2.Image = Properties.Resources.buttonmusicstop1;
        }

        private void inGameButtonStop2_MouseDown(object sender, MouseEventArgs e)
        {
            inGameButtonStop2.Image = Properties.Resources.buttonmusicstop3;
        }

        private void inGameBack_Click(object sender, EventArgs e)
        {
            inGameSettingsPanel.Visible = false;
            pausePanel.Visible = true;
        }

        private void inGameBack_MouseEnter(object sender, EventArgs e)
        {
            inGameBack.Image = Properties.Resources.buttonlevelnazadlight;
        }

        private void inGameBack_MouseLeave(object sender, EventArgs e)
        {
            inGameBack.Image = Properties.Resources.buttonlevelnazadnormal;
        }

        private void inGameBack_MouseDown(object sender, MouseEventArgs e)
        {
            inGameBack.Image = Properties.Resources.buttonlevelnazadpress;
        }

        private void inGameSend_Click(object sender, EventArgs e)
        {
            inGameTxtFeedback.Clear();
        }

        private void inGameSend_MouseEnter(object sender, EventArgs e)
        {
            inGameSend.Image = Properties.Resources.buttonsend2;
        }

        private void inGameSend_MouseLeave(object sender, EventArgs e)
        {
            inGameSend.Image = Properties.Resources.buttonsend1;
        }

        private void inGameSend_MouseDown(object sender, MouseEventArgs e)
        {
            inGameSend.Image = Properties.Resources.buttonsend3;
        }

        private void inGameSend_MouseUp(object sender, MouseEventArgs e)
        {
            inGameSend.Image = Properties.Resources.buttonsend2;
        }

    }

    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            this.BackColor = Color.Transparent;
        }
    }
}