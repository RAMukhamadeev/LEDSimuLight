using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    partial class FormAbout
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormAbout));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.pictureBox1 = new PictureBox();
            this.button1 = new Button();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new Point(508, 81);
            this.label1.Margin = new Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(452, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название программы: LEDSimuLight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new Point(508, 138);
            this.label2.Margin = new Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(170, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Версия: 1.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new Point(508, 192);
            this.label3.Margin = new Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(443, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Авторские права: Мухамадеев Р. А.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(60, 81);
            this.pictureBox1.Margin = new Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(394, 340);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new Point(622, 362);
            this.button1.Margin = new Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new Size(190, 60);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new SizeF(12F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1016, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.Load += new EventHandler(this.about_Load);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Button button1;

    }
}