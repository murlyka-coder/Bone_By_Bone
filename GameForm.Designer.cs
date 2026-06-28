namespace Bone_By_Bone
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.lblMistakes = new System.Windows.Forms.Label();
            this.TimerGame = new System.Windows.Forms.Timer(this.components);
            this.activetime = new System.Windows.Forms.PictureBox();
            this.buttonbuter = new System.Windows.Forms.PictureBox();
            this.pausePanel = new System.Windows.Forms.Panel();
            this.btnResume = new System.Windows.Forms.PictureBox();
            this.btnPauseSettings = new System.Windows.Forms.PictureBox();
            this.btnEndGame = new System.Windows.Forms.PictureBox();
            this.inGameButtonStop1 = new System.Windows.Forms.PictureBox();
            this.inGameButtonStop2 = new System.Windows.Forms.PictureBox();
            this.inGameButtonPlay2 = new System.Windows.Forms.PictureBox();
            this.inGameBack = new System.Windows.Forms.PictureBox();
            this.inGameSend = new System.Windows.Forms.PictureBox();
            this.inGameTxtFeedback = new System.Windows.Forms.TextBox();
            this.inGameButtonPlay1 = new System.Windows.Forms.PictureBox();
            this.inGameSettingsPanel = new System.Windows.Forms.Panel();
            this.btnLevelComplete = new System.Windows.Forms.PictureBox();
            this.victoryPanel = new System.Windows.Forms.Panel();
            this.lblVictoryMistakes = new System.Windows.Forms.Label();
            this.lblVictoryTime = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.activetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonbuter)).BeginInit();
            this.pausePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnResume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEndGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonStop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonStop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonPlay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonPlay1)).BeginInit();
            this.inGameSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLevelComplete)).BeginInit();
            this.victoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Comic Sans MS", 20.44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(39)))), ((int)(((byte)(21)))));
            this.lblTime.Location = new System.Drawing.Point(132, 68);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 39);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "1";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBackToMenu.Location = new System.Drawing.Point(1037, 197);
            this.btnBackToMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(115, 19);
            this.btnBackToMenu.TabIndex = 4;
            this.btnBackToMenu.Text = "В главное меню";
            this.btnBackToMenu.UseVisualStyleBackColor = false;
            this.btnBackToMenu.Visible = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // lblMistakes
            // 
            this.lblMistakes.AutoSize = true;
            this.lblMistakes.BackColor = System.Drawing.Color.Transparent;
            this.lblMistakes.Font = new System.Drawing.Font("Comic Sans MS", 20.44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMistakes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(39)))), ((int)(((byte)(21)))));
            this.lblMistakes.Location = new System.Drawing.Point(159, 29);
            this.lblMistakes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMistakes.Name = "lblMistakes";
            this.lblMistakes.Size = new System.Drawing.Size(34, 39);
            this.lblMistakes.TabIndex = 2;
            this.lblMistakes.Text = "0";
            // 
            // TimerGame
            // 
            this.TimerGame.Interval = 1000;
            this.TimerGame.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // activetime
            // 
            this.activetime.BackColor = System.Drawing.Color.Transparent;
            this.activetime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activetime.Image = global::Bone_By_Bone.Properties.Resources.activegametime;
            this.activetime.Location = new System.Drawing.Point(3, 3);
            this.activetime.Name = "activetime";
            this.activetime.Size = new System.Drawing.Size(287, 145);
            this.activetime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.activetime.TabIndex = 13;
            this.activetime.TabStop = false;
            // 
            // buttonbuter
            // 
            this.buttonbuter.BackColor = System.Drawing.Color.Transparent;
            this.buttonbuter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonbuter.Image = global::Bone_By_Bone.Properties.Resources.buttonbuternormal;
            this.buttonbuter.Location = new System.Drawing.Point(1789, 29);
            this.buttonbuter.Name = "buttonbuter";
            this.buttonbuter.Size = new System.Drawing.Size(102, 96);
            this.buttonbuter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonbuter.TabIndex = 17;
            this.buttonbuter.TabStop = false;
            this.buttonbuter.Click += new System.EventHandler(this.buttonbuter_Click);
            this.buttonbuter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonbuter_MouseDown);
            this.buttonbuter.MouseEnter += new System.EventHandler(this.buttonbuter_MouseEnter);
            this.buttonbuter.MouseLeave += new System.EventHandler(this.buttonbuter_MouseLeave);
            // 
            // pausePanel
            // 
            this.pausePanel.BackColor = System.Drawing.Color.Transparent;
            this.pausePanel.BackgroundImage = global::Bone_By_Bone.Properties.Resources.pauzepanel;
            this.pausePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pausePanel.Controls.Add(this.btnResume);
            this.pausePanel.Controls.Add(this.btnPauseSettings);
            this.pausePanel.Controls.Add(this.btnEndGame);
            this.pausePanel.Location = new System.Drawing.Point(655, 212);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(677, 633);
            this.pausePanel.TabIndex = 18;
            this.pausePanel.Visible = false;
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.Transparent;
            this.btnResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResume.Image = global::Bone_By_Bone.Properties.Resources.buttongo1;
            this.btnResume.Location = new System.Drawing.Point(212, 175);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(254, 105);
            this.btnResume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnResume.TabIndex = 21;
            this.btnResume.TabStop = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            this.btnResume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnResume_MouseDown);
            this.btnResume.MouseEnter += new System.EventHandler(this.btnResume_MouseEnter);
            this.btnResume.MouseLeave += new System.EventHandler(this.btnResume_MouseLeave);
            // 
            // btnPauseSettings
            // 
            this.btnPauseSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPauseSettings.Image = global::Bone_By_Bone.Properties.Resources.buttonnormal2;
            this.btnPauseSettings.Location = new System.Drawing.Point(212, 299);
            this.btnPauseSettings.Name = "btnPauseSettings";
            this.btnPauseSettings.Size = new System.Drawing.Size(254, 105);
            this.btnPauseSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPauseSettings.TabIndex = 20;
            this.btnPauseSettings.TabStop = false;
            this.btnPauseSettings.Click += new System.EventHandler(this.btnPauseSettings_Click);
            this.btnPauseSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPauseSettings_MouseDown);
            this.btnPauseSettings.MouseEnter += new System.EventHandler(this.btnPauseSettings_MouseEnter);
            this.btnPauseSettings.MouseLeave += new System.EventHandler(this.btnPauseSettings_MouseLeave);
            // 
            // btnEndGame
            // 
            this.btnEndGame.BackColor = System.Drawing.Color.Transparent;
            this.btnEndGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEndGame.Image = global::Bone_By_Bone.Properties.Resources.buttonend1;
            this.btnEndGame.Location = new System.Drawing.Point(212, 421);
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Size = new System.Drawing.Size(254, 104);
            this.btnEndGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEndGame.TabIndex = 19;
            this.btnEndGame.TabStop = false;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click_1);
            this.btnEndGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEndGame_MouseDown);
            this.btnEndGame.MouseEnter += new System.EventHandler(this.btnEndGame_MouseEnter);
            this.btnEndGame.MouseLeave += new System.EventHandler(this.btnEndGame_MouseLeave);
            // 
            // inGameButtonStop1
            // 
            this.inGameButtonStop1.BackColor = System.Drawing.Color.Transparent;
            this.inGameButtonStop1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameButtonStop1.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicstop1;
            this.inGameButtonStop1.Location = new System.Drawing.Point(62, 140);
            this.inGameButtonStop1.Name = "inGameButtonStop1";
            this.inGameButtonStop1.Size = new System.Drawing.Size(76, 84);
            this.inGameButtonStop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameButtonStop1.TabIndex = 27;
            this.inGameButtonStop1.TabStop = false;
            this.inGameButtonStop1.Click += new System.EventHandler(this.inGameButtonStop1_Click);
            this.inGameButtonStop1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameButtonStop1_MouseDown);
            this.inGameButtonStop1.MouseEnter += new System.EventHandler(this.inGameButtonStop1_MouseEnter);
            this.inGameButtonStop1.MouseLeave += new System.EventHandler(this.inGameButtonStop1_MouseLeave);
            // 
            // inGameButtonStop2
            // 
            this.inGameButtonStop2.BackColor = System.Drawing.Color.Transparent;
            this.inGameButtonStop2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameButtonStop2.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicstop1;
            this.inGameButtonStop2.Location = new System.Drawing.Point(61, 237);
            this.inGameButtonStop2.Name = "inGameButtonStop2";
            this.inGameButtonStop2.Size = new System.Drawing.Size(76, 84);
            this.inGameButtonStop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameButtonStop2.TabIndex = 26;
            this.inGameButtonStop2.TabStop = false;
            this.inGameButtonStop2.Click += new System.EventHandler(this.inGameButtonStop2_Click);
            this.inGameButtonStop2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameButtonStop2_MouseDown);
            this.inGameButtonStop2.MouseLeave += new System.EventHandler(this.inGameButtonStop2_MouseLeave);
            this.inGameButtonStop2.MouseHover += new System.EventHandler(this.inGameButtonStop2_MouseLeave);
            // 
            // inGameButtonPlay2
            // 
            this.inGameButtonPlay2.BackColor = System.Drawing.Color.Transparent;
            this.inGameButtonPlay2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameButtonPlay2.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicplay1;
            this.inGameButtonPlay2.Location = new System.Drawing.Point(62, 237);
            this.inGameButtonPlay2.Name = "inGameButtonPlay2";
            this.inGameButtonPlay2.Size = new System.Drawing.Size(76, 84);
            this.inGameButtonPlay2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameButtonPlay2.TabIndex = 22;
            this.inGameButtonPlay2.TabStop = false;
            this.inGameButtonPlay2.Click += new System.EventHandler(this.inGameButtonPlay2_Click);
            this.inGameButtonPlay2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameButtonPlay2_MouseDown);
            this.inGameButtonPlay2.MouseEnter += new System.EventHandler(this.inGameButtonPlay2_MouseEnter);
            this.inGameButtonPlay2.MouseLeave += new System.EventHandler(this.inGameButtonPlay2_MouseLeave);
            // 
            // inGameBack
            // 
            this.inGameBack.BackColor = System.Drawing.Color.Transparent;
            this.inGameBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameBack.Image = global::Bone_By_Bone.Properties.Resources.buttonlevelnazadnormal;
            this.inGameBack.Location = new System.Drawing.Point(258, 484);
            this.inGameBack.Name = "inGameBack";
            this.inGameBack.Size = new System.Drawing.Size(153, 84);
            this.inGameBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameBack.TabIndex = 25;
            this.inGameBack.TabStop = false;
            this.inGameBack.Click += new System.EventHandler(this.inGameBack_Click);
            this.inGameBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameBack_MouseDown);
            this.inGameBack.MouseEnter += new System.EventHandler(this.inGameBack_MouseEnter);
            this.inGameBack.MouseLeave += new System.EventHandler(this.inGameBack_MouseLeave);
            // 
            // inGameSend
            // 
            this.inGameSend.BackColor = System.Drawing.Color.Transparent;
            this.inGameSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameSend.Image = global::Bone_By_Bone.Properties.Resources.buttonsend1;
            this.inGameSend.Location = new System.Drawing.Point(523, 352);
            this.inGameSend.Name = "inGameSend";
            this.inGameSend.Size = new System.Drawing.Size(87, 128);
            this.inGameSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameSend.TabIndex = 24;
            this.inGameSend.TabStop = false;
            this.inGameSend.Click += new System.EventHandler(this.inGameSend_Click);
            this.inGameSend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameSend_MouseDown);
            this.inGameSend.MouseEnter += new System.EventHandler(this.inGameSend_MouseEnter);
            this.inGameSend.MouseLeave += new System.EventHandler(this.inGameSend_MouseLeave);
            // 
            // inGameTxtFeedback
            // 
            this.inGameTxtFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(191)))), ((int)(((byte)(130)))));
            this.inGameTxtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inGameTxtFeedback.Location = new System.Drawing.Point(79, 367);
            this.inGameTxtFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.inGameTxtFeedback.Multiline = true;
            this.inGameTxtFeedback.Name = "inGameTxtFeedback";
            this.inGameTxtFeedback.Size = new System.Drawing.Size(423, 102);
            this.inGameTxtFeedback.TabIndex = 20;
            // 
            // inGameButtonPlay1
            // 
            this.inGameButtonPlay1.BackColor = System.Drawing.Color.Transparent;
            this.inGameButtonPlay1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inGameButtonPlay1.Image = global::Bone_By_Bone.Properties.Resources.buttonmusicplay1;
            this.inGameButtonPlay1.Location = new System.Drawing.Point(62, 140);
            this.inGameButtonPlay1.Name = "inGameButtonPlay1";
            this.inGameButtonPlay1.Size = new System.Drawing.Size(76, 84);
            this.inGameButtonPlay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inGameButtonPlay1.TabIndex = 23;
            this.inGameButtonPlay1.TabStop = false;
            this.inGameButtonPlay1.Click += new System.EventHandler(this.inGameButtonPlay1_Click);
            this.inGameButtonPlay1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inGameButtonPlay1_MouseDown);
            this.inGameButtonPlay1.MouseEnter += new System.EventHandler(this.inGameButtonPlay1_MouseEnter);
            this.inGameButtonPlay1.MouseLeave += new System.EventHandler(this.inGameButtonPlay1_MouseLeave);
            // 
            // inGameSettingsPanel
            // 
            this.inGameSettingsPanel.BackColor = System.Drawing.Color.Transparent;
            this.inGameSettingsPanel.BackgroundImage = global::Bone_By_Bone.Properties.Resources.settingscreenpanelpause;
            this.inGameSettingsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.inGameSettingsPanel.Controls.Add(this.inGameTxtFeedback);
            this.inGameSettingsPanel.Controls.Add(this.inGameBack);
            this.inGameSettingsPanel.Controls.Add(this.inGameSend);
            this.inGameSettingsPanel.Controls.Add(this.inGameButtonPlay1);
            this.inGameSettingsPanel.Controls.Add(this.inGameButtonPlay2);
            this.inGameSettingsPanel.Controls.Add(this.inGameButtonStop1);
            this.inGameSettingsPanel.Controls.Add(this.inGameButtonStop2);
            this.inGameSettingsPanel.Location = new System.Drawing.Point(655, 215);
            this.inGameSettingsPanel.Name = "inGameSettingsPanel";
            this.inGameSettingsPanel.Size = new System.Drawing.Size(674, 633);
            this.inGameSettingsPanel.TabIndex = 26;
            this.inGameSettingsPanel.Visible = false;
            // 
            // btnLevelComplete
            // 
            this.btnLevelComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnLevelComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLevelComplete.Image = global::Bone_By_Bone.Properties.Resources.buttonlevelcomp1;
            this.btnLevelComplete.Location = new System.Drawing.Point(206, 429);
            this.btnLevelComplete.Name = "btnLevelComplete";
            this.btnLevelComplete.Size = new System.Drawing.Size(267, 126);
            this.btnLevelComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLevelComplete.TabIndex = 29;
            this.btnLevelComplete.TabStop = false;
            this.btnLevelComplete.Click += new System.EventHandler(this.btnLevelComplete_Click);
            this.btnLevelComplete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLevelComplete_MouseDown);
            this.btnLevelComplete.MouseEnter += new System.EventHandler(this.btnLevelComplete_MouseEnter);
            this.btnLevelComplete.MouseLeave += new System.EventHandler(this.btnLevelComplete_MouseLeave);
            // 
            // victoryPanel
            // 
            this.victoryPanel.BackColor = System.Drawing.Color.Transparent;
            this.victoryPanel.BackgroundImage = global::Bone_By_Bone.Properties.Resources.pobeda1;
            this.victoryPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.victoryPanel.Controls.Add(this.btnLevelComplete);
            this.victoryPanel.Controls.Add(this.lblVictoryMistakes);
            this.victoryPanel.Controls.Add(this.lblVictoryTime);
            this.victoryPanel.Location = new System.Drawing.Point(649, 215);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(677, 633);
            this.victoryPanel.TabIndex = 22;
            this.victoryPanel.Visible = false;
            // 
            // lblVictoryMistakes
            // 
            this.lblVictoryMistakes.BackColor = System.Drawing.Color.Transparent;
            this.lblVictoryMistakes.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVictoryMistakes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(39)))), ((int)(((byte)(21)))));
            this.lblVictoryMistakes.Location = new System.Drawing.Point(279, 294);
            this.lblVictoryMistakes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVictoryMistakes.Name = "lblVictoryMistakes";
            this.lblVictoryMistakes.Size = new System.Drawing.Size(55, 66);
            this.lblVictoryMistakes.TabIndex = 32;
            this.lblVictoryMistakes.Text = "0";
            // 
            // lblVictoryTime
            // 
            this.lblVictoryTime.BackColor = System.Drawing.Color.Transparent;
            this.lblVictoryTime.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVictoryTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(39)))), ((int)(((byte)(21)))));
            this.lblVictoryTime.Location = new System.Drawing.Point(243, 360);
            this.lblVictoryTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVictoryTime.Name = "lblVictoryTime";
            this.lblVictoryTime.Size = new System.Drawing.Size(71, 66);
            this.lblVictoryTime.TabIndex = 31;
            this.lblVictoryTime.Text = "0";
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.Image = global::Bone_By_Bone.Properties.Resources.buttonsobr1;
            this.btnComplete.Location = new System.Drawing.Point(816, 832);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(306, 144);
            this.btnComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnComplete.TabIndex = 30;
            this.btnComplete.TabStop = false;
            this.btnComplete.Visible = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            this.btnComplete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnComplete_MouseDown);
            this.btnComplete.MouseEnter += new System.EventHandler(this.btnComplete_MouseEnter);
            this.btnComplete.MouseLeave += new System.EventHandler(this.btnComplete_MouseLeave);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bone_By_Bone.Properties.Resources.gamemenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.victoryPanel);
            this.Controls.Add(this.buttonbuter);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMistakes);
            this.Controls.Add(this.activetime);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.pausePanel);
            this.Controls.Add(this.inGameSettingsPanel);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Size = new System.Drawing.Size(1920, 1200);
            ((System.ComponentModel.ISupportInitialize)(this.activetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonbuter)).EndInit();
            this.pausePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnResume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEndGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonStop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonStop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonPlay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inGameButtonPlay1)).EndInit();
            this.inGameSettingsPanel.ResumeLayout(false);
            this.inGameSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLevelComplete)).EndInit();
            this.victoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Label lblMistakes;
        private System.Windows.Forms.Timer TimerGame;
        private System.Windows.Forms.PictureBox activetime;
        private System.Windows.Forms.PictureBox buttonbuter;
        private System.Windows.Forms.Panel pausePanel;
        private System.Windows.Forms.PictureBox btnResume;
        private System.Windows.Forms.PictureBox btnPauseSettings;
        private System.Windows.Forms.PictureBox btnEndGame;
        private System.Windows.Forms.PictureBox inGameButtonPlay2;
        private System.Windows.Forms.PictureBox inGameBack;
        private System.Windows.Forms.PictureBox inGameSend;
        private System.Windows.Forms.TextBox inGameTxtFeedback;
        private System.Windows.Forms.PictureBox inGameButtonPlay1;
        private System.Windows.Forms.PictureBox inGameButtonStop2;
        private System.Windows.Forms.PictureBox inGameButtonStop1;
        private System.Windows.Forms.Panel inGameSettingsPanel;
        private System.Windows.Forms.PictureBox btnLevelComplete;
        private System.Windows.Forms.Panel victoryPanel;
        private System.Windows.Forms.PictureBox btnComplete;
        private System.Windows.Forms.Label lblVictoryTime;
        private System.Windows.Forms.Label lblVictoryMistakes;
    }
}
