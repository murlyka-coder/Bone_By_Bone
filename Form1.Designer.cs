using System.Windows.Forms;

namespace Bone_By_Bone
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.mainMenuForm1 = new Bone_By_Bone.MainMenuForm();
            this.levelSekectForm1 = new Bone_By_Bone.LevelSekectForm();
            this.settingForm1 = new Bone_By_Bone.SettingForm();
            this.gameForm1 = new Bone_By_Bone.GameForm();
            this.SuspendLayout();
            // 
            // mainMenuForm1
            // 
            this.mainMenuForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuForm1.Name = "mainMenuForm1";
            this.mainMenuForm1.TabIndex = 0;
            // 
            // levelSekectForm1
            // 
            this.levelSekectForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSekectForm1.Name = "levelSekectForm1";
            this.levelSekectForm1.TabIndex = 1;
            this.levelSekectForm1.Visible = false;
            // 
            // settingForm1
            // 
            this.settingForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingForm1.Name = "settingForm1";
            this.settingForm1.TabIndex = 3;
            this.settingForm1.Visible = false;
            // 
            // gameForm1
            //
            this.gameForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameForm1.Name = "gameForm1";
            this.gameForm1.TabIndex = 2;
            this.gameForm1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.mainMenuForm1);
            this.Controls.Add(this.levelSekectForm1);
            this.Controls.Add(this.settingForm1);
            this.Controls.Add(this.gameForm1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenuForm mainMenuForm1;
        private LevelSekectForm levelSekectForm1;
        private GameForm gameForm1;
        private SettingForm settingForm1;
    }
}

