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
            this.buttonlevelnormal1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buttonlevelnormal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // buttonlevelnormal1
            // 
            this.buttonlevelnormal1.BackColor = System.Drawing.Color.Transparent;
            this.buttonlevelnormal1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonlevelnormal1.Image = global::Bone_By_Bone.Properties.Resources.buttonlevelnormal1;
            this.buttonlevelnormal1.Location = new System.Drawing.Point(694, 350);
            this.buttonlevelnormal1.Name = "buttonlevelnormal1";
            this.buttonlevelnormal1.Size = new System.Drawing.Size(130, 130);
            this.buttonlevelnormal1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonlevelnormal1.TabIndex = 15;
            this.buttonlevelnormal1.TabStop = false;
            this.buttonlevelnormal1.Click += new System.EventHandler(this.btnLevel1_Click);
            this.buttonlevelnormal1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonlevelnormal1_MouseDown);
            this.buttonlevelnormal1.MouseEnter += new System.EventHandler(this.buttonlevelnormal1_MouseEnter);
            this.buttonlevelnormal1.MouseLeave += new System.EventHandler(this.buttonlevelnormal1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Bone_By_Bone.Properties.Resources.lvlcelect;
            this.pictureBox1.Location = new System.Drawing.Point(608, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // LevelSekectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bone_By_Bone.Properties.Resources.levelselect;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonlevelnormal1);
            this.Controls.Add(this.btnLevel3);
            this.Controls.Add(this.btnLevel2);
            this.DoubleBuffered = true;
            this.Name = "LevelSekectForm";
            this.Size = new System.Drawing.Size(1920, 1203);
            ((System.ComponentModel.ISupportInitialize)(this.buttonlevelnormal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.PictureBox buttonlevelnormal1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
