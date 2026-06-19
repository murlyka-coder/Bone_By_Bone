namespace Bone_By_Bone
{
    partial class LevelSekectForm
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
            this.btnLevel3 = new System.Windows.Forms.Button();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.btnLevel1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLevel3
            // 
            this.btnLevel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel3.Location = new System.Drawing.Point(199, 253);
            this.btnLevel3.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(150, 41);
            this.btnLevel3.TabIndex = 2;
            this.btnLevel3.Text = "Уровень 3";
            this.btnLevel3.UseVisualStyleBackColor = false;
            this.btnLevel3.Click += new System.EventHandler(this.btnLevel3_Click);
            // 
            // btnLevel2
            // 
            this.btnLevel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel2.Location = new System.Drawing.Point(199, 193);
            this.btnLevel2.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(150, 41);
            this.btnLevel2.TabIndex = 1;
            this.btnLevel2.Text = "Уровень 2";
            this.btnLevel2.UseVisualStyleBackColor = false;
            this.btnLevel2.Click += new System.EventHandler(this.btnLevel2_Click);
            // 
            // btnLevel1
            // 
            this.btnLevel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel1.Location = new System.Drawing.Point(199, 128);
            this.btnLevel1.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(150, 41);
            this.btnLevel1.TabIndex = 0;
            this.btnLevel1.Text = "Уровень 1";
            this.btnLevel1.UseVisualStyleBackColor = false;
            this.btnLevel1.Click += new System.EventHandler(this.btnLevel1_Click);
            // 
            // LevelSekectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bone_By_Bone.Properties.Resources.levelselect;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnLevel3);
            this.Controls.Add(this.btnLevel2);
            this.Controls.Add(this.btnLevel1);
            this.DoubleBuffered = true;
            this.Name = "LevelSekectForm";
            this.Size = new System.Drawing.Size(1920, 1080);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel1;
    }
}
