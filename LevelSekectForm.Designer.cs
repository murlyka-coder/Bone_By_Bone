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
            this.panelLevelSelect = new System.Windows.Forms.Panel();
            this.panelLevelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLevel3
            // 
            this.btnLevel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel3.Location = new System.Drawing.Point(188, 162);
            this.btnLevel3.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel3.Name = "btnLevel3";
            this.btnLevel3.Size = new System.Drawing.Size(150, 41);
            this.btnLevel3.TabIndex = 2;
            this.btnLevel3.Text = "Уровень 3";
            this.btnLevel3.UseVisualStyleBackColor = false;
            // 
            // btnLevel2
            // 
            this.btnLevel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel2.Location = new System.Drawing.Point(188, 106);
            this.btnLevel2.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(150, 41);
            this.btnLevel2.TabIndex = 1;
            this.btnLevel2.Text = "Уровень 2";
            this.btnLevel2.UseVisualStyleBackColor = false;
            // 
            // btnLevel1
            // 
            this.btnLevel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLevel1.Location = new System.Drawing.Point(188, 49);
            this.btnLevel1.Margin = new System.Windows.Forms.Padding(2);
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.Size = new System.Drawing.Size(150, 41);
            this.btnLevel1.TabIndex = 0;
            this.btnLevel1.Text = "Уровень 1";
            this.btnLevel1.UseVisualStyleBackColor = false;
            // 
            // panelLevelSelect
            // 
            this.panelLevelSelect.BackColor = System.Drawing.Color.MediumPurple;
            this.panelLevelSelect.Controls.Add(this.btnLevel3);
            this.panelLevelSelect.Controls.Add(this.btnLevel2);
            this.panelLevelSelect.Controls.Add(this.btnLevel1);
            this.panelLevelSelect.Location = new System.Drawing.Point(2, 109);
            this.panelLevelSelect.Margin = new System.Windows.Forms.Padding(2);
            this.panelLevelSelect.Name = "panelLevelSelect";
            this.panelLevelSelect.Size = new System.Drawing.Size(693, 306);
            this.panelLevelSelect.TabIndex = 7;
            this.panelLevelSelect.Visible = false;
            // 
            // LevelSekectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLevelSelect);
            this.Name = "LevelSekectForm";
            this.Size = new System.Drawing.Size(697, 535);
            this.panelLevelSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLevel3;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Button btnLevel1;
        private System.Windows.Forms.Panel panelLevelSelect;
    }
}
