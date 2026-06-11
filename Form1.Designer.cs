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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelGame = new System.Windows.Forms.Panel();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMistakes = new System.Windows.Forms.Label();
            this.panelDock = new System.Windows.Forms.Panel();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.panelLevelSelect = new System.Windows.Forms.Panel();
            this.btnLevel3 = new System.Windows.Forms.Button();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.btnLevel1 = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPlayMusic = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnSendFeedback = new System.Windows.Forms.Button();
            this.btnFromSettings = new System.Windows.Forms.Button();
            this.panelGame.SuspendLayout();
            this.panelLevelSelect.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(327, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bone by Bone";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = " Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.BurlyWood;
            this.panelGame.Controls.Add(this.btnRestart);
            this.panelGame.Controls.Add(this.btnBackToMenu);
            this.panelGame.Controls.Add(this.lblTime);
            this.panelGame.Controls.Add(this.lblMistakes);
            this.panelGame.Controls.Add(this.panelDock);
            this.panelGame.Location = new System.Drawing.Point(12, 12);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(910, 450);
            this.panelGame.TabIndex = 2;
            this.panelGame.Visible = false;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBackToMenu.Location = new System.Drawing.Point(279, 15);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(153, 23);
            this.btnBackToMenu.TabIndex = 4;
            this.btnBackToMenu.Text = "В главное меню";
            this.btnBackToMenu.UseVisualStyleBackColor = false;
            this.btnBackToMenu.Visible = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(15, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(89, 16);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Время: 0 сек.";
            // 
            // lblMistakes
            // 
            this.lblMistakes.AutoSize = true;
            this.lblMistakes.Location = new System.Drawing.Point(15, 15);
            this.lblMistakes.Name = "lblMistakes";
            this.lblMistakes.Size = new System.Drawing.Size(70, 16);
            this.lblMistakes.TabIndex = 2;
            this.lblMistakes.Text = "Ошибки: 0";
            // 
            // panelDock
            // 
            this.panelDock.BackColor = System.Drawing.Color.SandyBrown;
            this.panelDock.Location = new System.Drawing.Point(0, 310);
            this.panelDock.Name = "panelDock";
            this.panelDock.Size = new System.Drawing.Size(910, 140);
            this.panelDock.TabIndex = 5;
            // 
            // timerGame
            // 
            this.timerGame.Interval = 1000;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // panelLevelSelect
            // 
            this.panelLevelSelect.BackColor = System.Drawing.Color.MediumPurple;
            this.panelLevelSelect.Controls.Add(this.btnLevel3);
            this.panelLevelSelect.Controls.Add(this.btnLevel2);
            this.panelLevelSelect.Controls.Add(this.btnLevel1);
            this.panelLevelSelect.Location = new System.Drawing.Point(12, 85);
            this.panelLevelSelect.Name = "panelLevelSelect";
            this.panelLevelSelect.Size = new System.Drawing.Size(910, 377);
            this.panelLevelSelect.TabIndex = 6;
            this.panelLevelSelect.Visible = false;
            // 
            // btnLevel3
            // 
            this.btnLevel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel3.Location = new System.Drawing.Point(250, 200);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(200, 50);
            this.btnLevel3.TabIndex = 2;
            this.btnLevel3.Text = "Уровень 3";
            this.btnLevel3.UseVisualStyleBackColor = false;
            this.btnLevel3.Click += new System.EventHandler(this.btnLevel3_Click);
            // 
            // btnLevel2
            // 
            this.btnLevel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel2.Location = new System.Drawing.Point(250, 130);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(200, 50);
            this.btnLevel2.TabIndex = 1;
            this.btnLevel2.Text = "Уровень 2";
            this.btnLevel2.UseVisualStyleBackColor = false;
            this.btnLevel2.Click += new System.EventHandler(this.btnLevel2_Click);
            // 
            // btnLevel1
            // 
            this.btnLevel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel1.Location = new System.Drawing.Point(250, 60);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(200, 50);
            this.btnLevel1.TabIndex = 0;
            this.btnLevel1.Text = "Уровень 1";
            this.btnLevel1.UseVisualStyleBackColor = false;
            this.btnLevel1.Click += new System.EventHandler(this.btnLevel1_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRestart.Location = new System.Drawing.Point(835, 5);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(65, 46);
            this.btnRestart.TabIndex = 6;
            this.btnRestart.Text = "Начать заново";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(790, 20);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 41);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
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
            this.panelSettings.Location = new System.Drawing.Point(12, 80);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(910, 450);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(301, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Настройки игры";
            // 
            // chkPlayMusic
            // 
            this.chkPlayMusic.AutoSize = true;
            this.chkPlayMusic.Checked = true;
            this.chkPlayMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlayMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkPlayMusic.Location = new System.Drawing.Point(298, 105);
            this.chkPlayMusic.Name = "chkPlayMusic";
            this.chkPlayMusic.Size = new System.Drawing.Size(260, 24);
            this.chkPlayMusic.TabIndex = 1;
            this.chkPlayMusic.Text = "Включить фоновую музыку";
            this.chkPlayMusic.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(274, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Обратная связь (Напишите нам)";
            // 
            // txtFeedback
            // 
            this.txtFeedback.Location = new System.Drawing.Point(260, 219);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(237, 87);
            this.txtFeedback.TabIndex = 3;
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.Location = new System.Drawing.Point(516, 219);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Size = new System.Drawing.Size(88, 87);
            this.btnSendFeedback.TabIndex = 4;
            this.btnSendFeedback.Text = "Отправить отзыв";
            this.btnSendFeedback.UseVisualStyleBackColor = true;
            // 
            // btnFromSettings
            // 
            this.btnFromSettings.Location = new System.Drawing.Point(367, 400);
            this.btnFromSettings.Name = "btnFromSettings";
            this.btnFromSettings.Size = new System.Drawing.Size(130, 23);
            this.btnFromSettings.TabIndex = 5;
            this.btnFromSettings.Text = "В главное меню";
            this.btnFromSettings.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 553);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelLevelSelect);
            this.Controls.Add(this.panelGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.panelLevelSelect.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label lblMistakes;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Panel panelLevelSelect;
        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Panel panelDock;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPlayMusic;
        private System.Windows.Forms.Button btnFromSettings;
        private System.Windows.Forms.Button btnSendFeedback;
        private System.Windows.Forms.TextBox txtFeedback;
    }
}

