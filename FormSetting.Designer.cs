namespace Bone_By_Bone
{
    partial class FormSetting
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
            this.btnFromSettings = new System.Windows.Forms.Button();
            this.btnSendFeedback = new System.Windows.Forms.Button();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPlayMusic = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFromSettings
            // 
            this.btnFromSettings.Location = new System.Drawing.Point(275, 325);
            this.btnFromSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnFromSettings.Name = "btnFromSettings";
            this.btnFromSettings.Size = new System.Drawing.Size(98, 19);
            this.btnFromSettings.TabIndex = 5;
            this.btnFromSettings.Text = "Назад";
            this.btnFromSettings.UseVisualStyleBackColor = true;
            this.btnFromSettings.Click += new System.EventHandler(this.btnFromSettings_Click);
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.Location = new System.Drawing.Point(387, 178);
            this.btnSendFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Size = new System.Drawing.Size(66, 71);
            this.btnSendFeedback.TabIndex = 4;
            this.btnSendFeedback.Text = "Отправить отзыв";
            this.btnSendFeedback.UseVisualStyleBackColor = true;
            this.btnSendFeedback.Click += new System.EventHandler(this.btnSendFeedback_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Location = new System.Drawing.Point(195, 178);
            this.txtFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(179, 71);
            this.txtFeedback.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(206, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Обратная связь (Напишите нам)";
            // 
            // chkPlayMusic
            // 
            this.chkPlayMusic.AutoSize = true;
            this.chkPlayMusic.Checked = true;
            this.chkPlayMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlayMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkPlayMusic.Location = new System.Drawing.Point(224, 85);
            this.chkPlayMusic.Margin = new System.Windows.Forms.Padding(2);
            this.chkPlayMusic.Name = "chkPlayMusic";
            this.chkPlayMusic.Size = new System.Drawing.Size(205, 21);
            this.chkPlayMusic.TabIndex = 1;
            this.chkPlayMusic.Text = "Включить фоновую музыку";
            this.chkPlayMusic.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(226, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Настройки игры";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(590, 58);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(90, 33);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.MediumPurple;
            this.panelSettings.Controls.Add(this.btnFromSettings);
            this.panelSettings.Controls.Add(this.btnSendFeedback);
            this.panelSettings.Controls.Add(this.txtFeedback);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.chkPlayMusic);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Location = new System.Drawing.Point(7, 52);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(2);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(682, 421);
            this.panelSettings.TabIndex = 11;
            this.panelSettings.Visible = false;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.panelSettings);
            this.Name = "FormSetting";
            this.Size = new System.Drawing.Size(696, 525);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFromSettings;
        private System.Windows.Forms.Button btnSendFeedback;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPlayMusic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panelSettings;
    }
}
