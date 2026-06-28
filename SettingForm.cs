using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Bone_By_Bone
{
    public partial class SettingForm : UserControl
    {
        public event EventHandler BackClicked;

        public SettingForm()
        {
            InitializeComponent();
        }

        // Вызывать при каждом появлении формы — синхронизирует UI
        public void SyncUI()
        {
            buttonplay1.Visible = AudioSettings.MusicOn;
            buttonstop1.Visible = !AudioSettings.MusicOn;

            buttonplay2.Visible = AudioSettings.SoundOn;
            buttonstop2.Visible = !AudioSettings.SoundOn;
        }

        private void buttonplay1_Click(object sender, EventArgs e)
        {
            AudioSettings.SetMusic(false);
            buttonplay1.Visible = false;
            buttonstop1.Visible = true;
        }

        private void buttonstop1_Click(object sender, EventArgs e)
        {
            AudioSettings.SetMusic(true);
            buttonstop1.Visible = false;
            buttonplay1.Visible = true;
        }

        private void buttonplay2_Click(object sender, EventArgs e)
        {
            AudioSettings.SetSound(false);
            buttonplay2.Visible = false;
            buttonstop2.Visible = true;
        }

        private void buttonstop2_Click(object sender, EventArgs e)
        {
            AudioSettings.SetSound(true);
            buttonstop2.Visible = false;
            buttonplay2.Visible = true;
        }

        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            // Проверяем, написал ли пользователь отзыв
            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Пожалуйста, введите текст отзыва перед отправкой.", "Внимание");
                return;
            }

            // Ваши данные для отправки
            string fromAddress = "slobanova070@gmail.com";
            string fromPassword = "mzhihchsupynsmnq"; // Пароль приложения
            string toAddress = "slobanova070@gmail.com";


            try
            {
                // Создаем письмо
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = "Новый отзыв: Bone by Bone";
                mail.Body = $"Пользователь оставил отзыв:\n\n{txtFeedback.Text}";

                // Настраиваем SMTP-сервер Google
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);

                // Отправляем
                smtp.Send(mail);

                MessageBox.Show("Спасибо за отзыв! Он успешно отправлен.", "Успех");
                txtFeedback.Clear(); // Очищаем поле после отправки
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось отправить отзыв. Ошибка: " + ex.Message, "Ошибка");
            }
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

        private void buttonstop1_MouseEnter(object sender, EventArgs e)
        {
            buttonstop1.Image = Properties.Resources.buttonmusicstop2;
        }

        private void buttonstop1_MouseLeave(object sender, EventArgs e)
        {
            buttonstop1.Image = Properties.Resources.buttonmusicstop1;
        }


        private void buttonstop1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonstop1.Image = Properties.Resources.buttonmusicstop3;

        }

        private void buttonstop2_MouseEnter(object sender, EventArgs e)
        {
            buttonstop2.Image = Properties.Resources.buttonmusicstop2;
        }

        private void buttonstop2_MouseLeave(object sender, EventArgs e)
        {
            buttonstop2.Image = Properties.Resources.buttonmusicstop1;
        }


        private void buttonstop2_MouseDown(object sender, MouseEventArgs e)
        {
            buttonstop2.Image = Properties.Resources.buttonmusicstop3;

        }




    }
}
