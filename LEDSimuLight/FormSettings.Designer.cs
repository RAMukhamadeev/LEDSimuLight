using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    partial class FormSettings
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSettings));
            this.panel1 = new Panel();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.panel2 = new Panel();
            this.textBox2 = new TextBox();
            this.label2 = new Label();
            this.panel3 = new Panel();
            this.textBox3 = new TextBox();
            this.label3 = new Label();
            this.button1 = new Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(26, 33);
            this.panel1.Margin = new Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(706, 65);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new Point(574, 12);
            this.textBox1.Margin = new Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 35);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new Point(26, 17);
            this.label1.Margin = new Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(292, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициент точности";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new Point(24, 112);
            this.panel2.Margin = new Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(708, 67);
            this.panel2.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new Point(576, 13);
            this.textBox2.Margin = new Padding(6, 6, 6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(102, 35);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "480";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new Point(30, 19);
            this.label2.Margin = new Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(378, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Длина воны излучения СД (нм)";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new Point(24, 192);
            this.panel3.Margin = new Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(708, 67);
            this.panel3.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new Point(528, 13);
            this.textBox3.Margin = new Padding(6, 6, 6, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(150, 35);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "10000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new Point(30, 19);
            this.label3.Margin = new Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(431, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Количество моделируемых квантов";
            // 
            // button1
            // 
            this.button1.Location = new Point(316, 385);
            this.button1.Margin = new Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new Size(150, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "Готово";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new SizeF(12F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(758, 488);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Настройки";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Panel panel2;
        private TextBox textBox2;
        private Label label2;
        private Panel panel3;
        private TextBox textBox3;
        private Label label3;
        private Button button1;
    }
}