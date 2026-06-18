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
            this.label3 = new System.Windows.Forms.Label();
            this.chkPlayMusic = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnSendFeedback = new System.Windows.Forms.Button();
            this.btnFromSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(208, 165);
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
            this.chkPlayMusic.Location = new System.Drawing.Point(226, 113);
            this.chkPlayMusic.Margin = new System.Windows.Forms.Padding(2);
            this.chkPlayMusic.Name = "chkPlayMusic";
            this.chkPlayMusic.Size = new System.Drawing.Size(205, 21);
            this.chkPlayMusic.TabIndex = 1;
            this.chkPlayMusic.Text = "Включить фоновую музыку";
            this.chkPlayMusic.UseVisualStyleBackColor = true;
            this.chkPlayMusic.CheckedChanged += new System.EventHandler(this.chkPlayMusic_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(243, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Настройки игры";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Location = new System.Drawing.Point(212, 201);
            this.txtFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(179, 71);
            this.txtFeedback.TabIndex = 3;
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.Location = new System.Drawing.Point(399, 201);
            this.btnSendFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Size = new System.Drawing.Size(66, 71);
            this.btnSendFeedback.TabIndex = 4;
            this.btnSendFeedback.Text = "Отправить отзыв";
            this.btnSendFeedback.UseVisualStyleBackColor = true;
            this.btnSendFeedback.Click += new System.EventHandler(this.btnSendFeedback_Click);
            // 
            // btnFromSettings
            // 
            this.btnFromSettings.Location = new System.Drawing.Point(275, 418);
            this.btnFromSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnFromSettings.Name = "btnFromSettings";
            this.btnFromSettings.Size = new System.Drawing.Size(98, 19);
            this.btnFromSettings.TabIndex = 5;
            this.btnFromSettings.Text = "Назад";
            this.btnFromSettings.UseVisualStyleBackColor = true;
            this.btnFromSettings.Click += new System.EventHandler(this.btnFromSettings_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFromSettings);
            this.Controls.Add(this.btnSendFeedback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.chkPlayMusic);
            this.Controls.Add(this.label3);
            this.Name = "SettingForm";
            this.Size = new System.Drawing.Size(696, 525);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPlayMusic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Button btnSendFeedback;
        private System.Windows.Forms.Button btnFromSettings;
    }
}
