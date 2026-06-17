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
            this.mainMenuForm1 = new Bone_By_Bone.MainMenuForm();
            this.levelSekectForm1 = new Bone_By_Bone.LevelSekectForm();
            this.gameForm1 = new Bone_By_Bone.GameForm();
            this.formSetting1 = new Bone_By_Bone.FormSetting();
            this.SuspendLayout();
            // 
            // mainMenuForm1
            // 
            this.mainMenuForm1.Location = new System.Drawing.Point(31, 12);
            this.mainMenuForm1.Name = "mainMenuForm1";
            this.mainMenuForm1.Size = new System.Drawing.Size(546, 444);
            this.mainMenuForm1.TabIndex = 0;
            // 
            // levelSekectForm1
            // 
            this.levelSekectForm1.Location = new System.Drawing.Point(7, -11);
            this.levelSekectForm1.Name = "levelSekectForm1";
            this.levelSekectForm1.Size = new System.Drawing.Size(570, 535);
            this.levelSekectForm1.TabIndex = 1;
            // 
            // gameForm1
            // 
            this.gameForm1.Location = new System.Drawing.Point(7, -20);
            this.gameForm1.Name = "gameForm1";
            this.gameForm1.Size = new System.Drawing.Size(719, 544);
            this.gameForm1.TabIndex = 2;
            // 
            // formSetting1
            // 
            this.formSetting1.Location = new System.Drawing.Point(-1, -11);
            this.formSetting1.Name = "formSetting1";
            this.formSetting1.Size = new System.Drawing.Size(705, 525);
            this.formSetting1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 468);
            this.Controls.Add(this.mainMenuForm1);
            this.Controls.Add(this.levelSekectForm1);
            this.Controls.Add(this.formSetting1);
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
        private FormSetting formSetting1;
    }
}

