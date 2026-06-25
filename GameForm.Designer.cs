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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.activetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonbuter)).BeginInit();
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
            this.pausePanel.BackgroundImage = global::Bone_By_Bone.Properties.Resources.menu;
            this.pausePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pausePanel.Enabled = false;
            this.pausePanel.Location = new System.Drawing.Point(659, 249);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(639, 598);
            this.pausePanel.TabIndex = 18;
            this.pausePanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1200);
            this.panel1.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bone_By_Bone.Properties.Resources.gamemenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pausePanel);
            this.Controls.Add(this.buttonbuter);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMistakes);
            this.Controls.Add(this.activetime);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Size = new System.Drawing.Size(1920, 1200);
            ((System.ComponentModel.ISupportInitialize)(this.activetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonbuter)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
    }
}
