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
            this.panelDock = new System.Windows.Forms.Panel();
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(11, 27);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 13);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Время: 0 сек.";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBackToMenu.Location = new System.Drawing.Point(209, 12);
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
            this.lblMistakes.Location = new System.Drawing.Point(11, 12);
            this.lblMistakes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMistakes.Name = "lblMistakes";
            this.lblMistakes.Size = new System.Drawing.Size(59, 13);
            this.lblMistakes.TabIndex = 2;
            this.lblMistakes.Text = "Ошибки: 0";
            // 
            // TimerGame
            // 
            this.TimerGame.Interval = 1000;
            this.TimerGame.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelDock
            // 
            this.panelDock.BackColor = System.Drawing.Color.SandyBrown;
            this.panelDock.Location = new System.Drawing.Point(0, 252);
            this.panelDock.Margin = new System.Windows.Forms.Padding(2);
            this.panelDock.Name = "panelDock";
            this.panelDock.Size = new System.Drawing.Size(682, 167);
            this.panelDock.TabIndex = 5;
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.BurlyWood;
            this.panelGame.Controls.Add(this.btnBackToMenu);
            this.panelGame.Controls.Add(this.lblTime);
            this.panelGame.Controls.Add(this.lblMistakes);
            this.panelGame.Controls.Add(this.panelDock);
            this.panelGame.Location = new System.Drawing.Point(18, 62);
            this.panelGame.Margin = new System.Windows.Forms.Padding(2);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(682, 421);
            this.panelGame.TabIndex = 3;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGame);
            this.Name = "GameForm";
            this.Size = new System.Drawing.Size(719, 544);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Label lblMistakes;
        private System.Windows.Forms.Timer TimerGame;
        private System.Windows.Forms.Panel panelDock;
        private System.Windows.Forms.Panel panelGame;
    }
}
