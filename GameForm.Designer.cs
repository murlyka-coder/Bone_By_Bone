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
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 66);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 13);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Время: 0 сек.";
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBackToMenu.Location = new System.Drawing.Point(239, 63);
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
            this.lblMistakes.Location = new System.Drawing.Point(12, 48);
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
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.lblMistakes);
            this.Name = "GameForm";
            this.Size = new System.Drawing.Size(1920, 1080);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Label lblMistakes;
        private System.Windows.Forms.Timer TimerGame;
    }
}
