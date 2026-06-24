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
        public event EventHandler<bool> MusicToggled; // Событие: true - включить, false - выключить
        private bool soundOn = true;

        public SettingForm()
        {
            InitializeComponent();

            // Так как при старте всё включено, показываем кнопки "ВКЛ" (buttonplay)
            buttonplay1.Visible = true;
            buttonstop1.Visible = false;

            buttonplay2.Visible = true;
            buttonstop2.Visible = false;
        }


        private void buttonplay1_Click(object sender, EventArgs e)
        {
            // Кликнули по активной кнопке -> выключаем музыку
            soundOn = false;
            buttonplay1.Visible = false;
            buttonstop1.Visible = true;

            // Сигнал в Form1: выключить
            MusicToggled?.Invoke(this, false);
        }

        private void buttonstop1_Click(object sender, EventArgs e)
        {
            // Кликнули по выключенной кнопке -> включаем музыку
            soundOn = true;
            buttonstop1.Visible = false;
            buttonplay1.Visible = true;

            // Сигнал в Form1: включить
            MusicToggled?.Invoke(this, true);
        }

        private void buttonplay2_Click(object sender, EventArgs e)
        {
            // Выключаем звуковые эффекты
            soundOn = false;
            buttonplay2.Visible = false;
            buttonstop2.Visible = true;
        }

        private void buttonstop2_Click(object sender, EventArgs e)
        {
            // Включаем звуковые эффекты
            soundOn = true;
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

            // Ввела свою почту
            string fromAddress = "slobanova070@gmail.com";

            // Вставьте сюда 16-значный пароль приложения Google (без пробелов)
            string fromPassword = "mzhihchsupynsmnq";

            // Впишите сюда почту, на которую вы хотите ПОЛУЧАТЬ отзывы (можно ту же самую Gmail)
            string toAddress = "slobanova070@gmail.com";

            try
            {
                // Создаем само письмо
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = "Новый отзыв: Bone by Bone";
                mail.Body = $"Пользователь оставил отзыв:\n\n{txtFeedback.Text}";

                // Настраиваем подключение к SMTP-серверу Google (Gmail)
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);

                // Отправляем письмо в фоновом режиме
                smtp.Send(mail);

                // Сообщаем игроку об успешной отправке
                MessageBox.Show("Спасибо за отзыв! Он успешно отправлен.", "Успех");
                txtFeedback.Clear(); // Очищаем поле ввода отзыва
            }
            catch (Exception ex)
            {
                // Если что-то пошло не так (например, нет интернета или ошибка в пароле)
                MessageBox.Show("Не удалось отправить отзыв автоматически. Ошибка: " + ex.Message, "Ошибка");
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
