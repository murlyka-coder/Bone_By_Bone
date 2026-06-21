namespace Bone_By_Bone
{
    partial class SettingForm
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonplay1 = new System.Windows.Forms.PictureBox();
            this.buttonplay2 = new System.Windows.Forms.PictureBox();
            this.play1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.play1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFeedback
            // 
            this.txtFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(191)))), ((int)(((byte)(130)))));
            this.txtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeedback.Location = new System.Drawing.Point(691, 634);
            this.txtFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(443, 112);
            this.txtFeedback.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Bone_By_Bone.Properties.Resources.settingscreenpanel;
            this.pictureBox1.Location = new System.Drawing.Point(588, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(742, 748);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // buttonplay1
            // 
            this.buttonplay1.BackColor = System.Drawing.Color.Transparent;
            this.buttonplay1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonplay1.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicplay1;
            this.buttonplay1.Location = new System.Drawing.Point(679, 384);
            this.buttonplay1.Name = "buttonplay1";
            this.buttonplay1.Size = new System.Drawing.Size(76, 84);
            this.buttonplay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonplay1.TabIndex = 16;
            this.buttonplay1.TabStop = false;
            this.buttonplay1.Click += new System.EventHandler(this.buttonplay1_Click);
            this.buttonplay1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonplay1_MouseDown);
            this.buttonplay1.MouseEnter += new System.EventHandler(this.buttonplay1_MouseEnter);
            this.buttonplay1.MouseLeave += new System.EventHandler(this.buttonplay1_MouseLeave);
            // 
            // buttonplay2
            // 
            this.buttonplay2.BackColor = System.Drawing.Color.Transparent;
            this.buttonplay2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonplay2.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicplay1;
            this.buttonplay2.Location = new System.Drawing.Point(679, 491);
            this.buttonplay2.Name = "buttonplay2";
            this.buttonplay2.Size = new System.Drawing.Size(76, 84);
            this.buttonplay2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonplay2.TabIndex = 17;
            this.buttonplay2.TabStop = false;
            this.buttonplay2.Click += new System.EventHandler(this.buttonplay2_Click);
            this.buttonplay2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonplay2_MouseDown);
            this.buttonplay2.MouseEnter += new System.EventHandler(this.buttonplay2_MouseEnter);
            this.buttonplay2.MouseLeave += new System.EventHandler(this.buttonplay2_MouseLeave);
            // 
            // play1
            // 
            this.play1.BackColor = System.Drawing.Color.Transparent;
            this.play1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play1.Image = global::Bone_By_Bone.Properties.Resources.buttonsend1;
            this.play1.Location = new System.Drawing.Point(1157, 628);
            this.play1.Name = "play1";
            this.play1.Size = new System.Drawing.Size(87, 128);
            this.play1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.play1.TabIndex = 18;
            this.play1.TabStop = false;
            this.play1.Click += new System.EventHandler(this.btnSendFeedback_Click);
            this.play1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonsend3_MouseDown);
            this.play1.MouseEnter += new System.EventHandler(this.buttonsend2_MouseEnter);
            this.play1.MouseLeave += new System.EventHandler(this.buttonsend1_MouseLeave);
            this.play1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonsend4_MouseUp);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Image = global::Bone_By_Bone.Properties.Resources.buttonlevelnazadnormal;
            this.btnBack.Location = new System.Drawing.Point(883, 770);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(153, 84);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack.TabIndex = 19;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnFromSettings_Click);
            this.btnBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseDown);
            this.btnBack.MouseEnter += new System.EventHandler(this.btnBack_MouseEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.btnBack_MouseLeave);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bone_By_Bone.Properties.Resources.settingscreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.play1);
            this.Controls.Add(this.buttonplay2);
            this.Controls.Add(this.buttonplay1);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "SettingForm";
            this.Size = new System.Drawing.Size(1920, 1200);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.play1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox buttonplay1;
        private System.Windows.Forms.PictureBox buttonplay2;
        private System.Windows.Forms.PictureBox play1;
        private System.Windows.Forms.PictureBox btnBack;
    }
}
