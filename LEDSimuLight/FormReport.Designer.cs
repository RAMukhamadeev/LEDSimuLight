using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    partial class FormReport
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormReport));
            this.MessageTextBox = new RichTextBox();
            this.SuspendLayout();
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.MessageTextBox.Location = new Point(24, 23);
            this.MessageTextBox.Margin = new Padding(6, 6, 6, 6);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.Size = new Size(1372, 517);
            this.MessageTextBox.TabIndex = 0;
            this.MessageTextBox.Text = "";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new SizeF(12F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1424, 567);
            this.Controls.Add(this.MessageTextBox);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new Padding(6, 6, 6, 6);
            this.Name = "FormReport";
            this.Text = "Отчет";
            this.Load += new EventHandler(this.report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox MessageTextBox;
    }
}