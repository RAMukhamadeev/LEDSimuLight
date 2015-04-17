namespace LEDSimuLight
{
    partial class FormAddMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddMaterial));
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbColorB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbColorG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbColorR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbReflection = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAbsorbtion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFraction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSave
            // 
            this.pbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(215, 470);
            this.pbSave.Margin = new System.Windows.Forms.Padding(4);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(235, 230);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 17;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 392);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 39);
            this.label8.TabIndex = 16;
            this.label8.Text = "B - компонента :";
            // 
            // tbColorB
            // 
            this.tbColorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbColorB.Location = new System.Drawing.Point(420, 390);
            this.tbColorB.Margin = new System.Windows.Forms.Padding(4);
            this.tbColorB.Name = "tbColorB";
            this.tbColorB.Size = new System.Drawing.Size(221, 44);
            this.tbColorB.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 339);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 39);
            this.label7.TabIndex = 14;
            this.label7.Text = "G - компонента :";
            // 
            // tbColorG
            // 
            this.tbColorG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbColorG.Location = new System.Drawing.Point(420, 338);
            this.tbColorG.Margin = new System.Windows.Forms.Padding(4);
            this.tbColorG.Name = "tbColorG";
            this.tbColorG.Size = new System.Drawing.Size(221, 44);
            this.tbColorG.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 39);
            this.label6.TabIndex = 12;
            this.label6.Text = "R - компонента :";
            // 
            // tbColorR
            // 
            this.tbColorR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbColorR.Location = new System.Drawing.Point(420, 286);
            this.tbColorR.Margin = new System.Windows.Forms.Padding(4);
            this.tbColorR.Name = "tbColorR";
            this.tbColorR.Size = new System.Drawing.Size(221, 44);
            this.tbColorR.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Коэфф. отражения :";
            // 
            // tbReflection
            // 
            this.tbReflection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbReflection.Location = new System.Drawing.Point(420, 234);
            this.tbReflection.Margin = new System.Windows.Forms.Padding(4);
            this.tbReflection.Name = "tbReflection";
            this.tbReflection.Size = new System.Drawing.Size(221, 44);
            this.tbReflection.TabIndex = 9;
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Substrate",
            "Thin film",
            "Contact",
            "Other",
            "Sensor",
            "Mirror"});
            this.cbType.Location = new System.Drawing.Point(420, 77);
            this.cbType.Margin = new System.Windows.Forms.Padding(4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(221, 45);
            this.cbType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэфф. поглощения :";
            // 
            // tbAbsorbtion
            // 
            this.tbAbsorbtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAbsorbtion.Location = new System.Drawing.Point(420, 182);
            this.tbAbsorbtion.Margin = new System.Windows.Forms.Padding(4);
            this.tbAbsorbtion.Name = "tbAbsorbtion";
            this.tbAbsorbtion.Size = new System.Drawing.Size(221, 44);
            this.tbAbsorbtion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пок. преломления :";
            // 
            // tbFraction
            // 
            this.tbFraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFraction.Location = new System.Drawing.Point(420, 130);
            this.tbFraction.Margin = new System.Windows.Forms.Padding(4);
            this.tbFraction.Name = "tbFraction";
            this.tbFraction.Size = new System.Drawing.Size(221, 44);
            this.tbFraction.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Категория :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название :";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(420, 25);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(221, 44);
            this.tbName.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(250, 704);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 54);
            this.label9.TabIndex = 18;
            this.label9.Text = "Добавить";
            // 
            // FormAddMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(678, 773);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbColorB);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbColorG);
            this.Controls.Add(this.tbFraction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbColorR);
            this.Controls.Add(this.tbAbsorbtion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbReflection);
            this.Controls.Add(this.cbType);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAddMaterial";
            this.Text = "Добавление материала";
            this.Load += new System.EventHandler(this.FormAddMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbColorB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbColorG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbColorR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbReflection;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAbsorbtion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFraction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label9;
    }
}