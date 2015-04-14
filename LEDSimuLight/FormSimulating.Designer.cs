using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    partial class FormSimulating
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimulating));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.трассировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьМоделированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.одиночныйКвантToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетОМоделированииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьРаспределениеСветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSimulatingOfLed = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.elem9 = new System.Windows.Forms.Label();
            this.Col9 = new System.Windows.Forms.Button();
            this.elem8 = new System.Windows.Forms.Label();
            this.Col8 = new System.Windows.Forms.Button();
            this.elem7 = new System.Windows.Forms.Label();
            this.Col7 = new System.Windows.Forms.Button();
            this.elem6 = new System.Windows.Forms.Label();
            this.Col6 = new System.Windows.Forms.Button();
            this.elem5 = new System.Windows.Forms.Label();
            this.Col5 = new System.Windows.Forms.Button();
            this.elem4 = new System.Windows.Forms.Label();
            this.Col4 = new System.Windows.Forms.Button();
            this.elem3 = new System.Windows.Forms.Label();
            this.Col3 = new System.Windows.Forms.Button();
            this.elem2 = new System.Windows.Forms.Label();
            this.Col2 = new System.Windows.Forms.Button();
            this.elem1 = new System.Windows.Forms.Label();
            this.Col1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulatingOfLed)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.моделированиеToolStripMenuItem,
            this.отчетОМоделированииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // моделированиеToolStripMenuItem
            // 
            this.моделированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.трассировкаToolStripMenuItem,
            this.начатьМоделированиеToolStripMenuItem,
            this.одиночныйКвантToolStripMenuItem});
            this.моделированиеToolStripMenuItem.Name = "моделированиеToolStripMenuItem";
            this.моделированиеToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.моделированиеToolStripMenuItem.Text = "Моделирование";
            // 
            // трассировкаToolStripMenuItem
            // 
            this.трассировкаToolStripMenuItem.Name = "трассировкаToolStripMenuItem";
            this.трассировкаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.трассировкаToolStripMenuItem.Text = "Трассировка";
            this.трассировкаToolStripMenuItem.Click += new System.EventHandler(this.трассировкаToolStripMenuItem_Click);
            // 
            // начатьМоделированиеToolStripMenuItem
            // 
            this.начатьМоделированиеToolStripMenuItem.Name = "начатьМоделированиеToolStripMenuItem";
            this.начатьМоделированиеToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.начатьМоделированиеToolStripMenuItem.Text = "Запуск моделирования";
            this.начатьМоделированиеToolStripMenuItem.Click += new System.EventHandler(this.начатьМоделированиеToolStripMenuItem_Click);
            // 
            // одиночныйКвантToolStripMenuItem
            // 
            this.одиночныйКвантToolStripMenuItem.Name = "одиночныйКвантToolStripMenuItem";
            this.одиночныйКвантToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.одиночныйКвантToolStripMenuItem.Text = "Одиночный квант";
            this.одиночныйКвантToolStripMenuItem.Click += new System.EventHandler(this.одиночныйКвантToolStripMenuItem_Click);
            // 
            // отчетОМоделированииToolStripMenuItem
            // 
            this.отчетОМоделированииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьОтчетToolStripMenuItem,
            this.показатьРаспределениеСветаToolStripMenuItem});
            this.отчетОМоделированииToolStripMenuItem.Name = "отчетОМоделированииToolStripMenuItem";
            this.отчетОМоделированииToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчетОМоделированииToolStripMenuItem.Text = "Отчет";
            // 
            // показатьОтчетToolStripMenuItem
            // 
            this.показатьОтчетToolStripMenuItem.Name = "показатьОтчетToolStripMenuItem";
            this.показатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.показатьОтчетToolStripMenuItem.Text = "Показать отчет";
            this.показатьОтчетToolStripMenuItem.Click += new System.EventHandler(this.показатьОтчетToolStripMenuItem_Click);
            // 
            // показатьРаспределениеСветаToolStripMenuItem
            // 
            this.показатьРаспределениеСветаToolStripMenuItem.Name = "показатьРаспределениеСветаToolStripMenuItem";
            this.показатьРаспределениеСветаToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.показатьРаспределениеСветаToolStripMenuItem.Text = "Показать распределение света";
            this.показатьРаспределениеСветаToolStripMenuItem.Click += new System.EventHandler(this.показатьРаспределениеСветаToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbSimulatingOfLed);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(246, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 623);
            this.panel1.TabIndex = 4;
            // 
            // pbSimulatingOfLed
            // 
            this.pbSimulatingOfLed.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pbSimulatingOfLed.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSimulatingOfLed.Location = new System.Drawing.Point(105, 20);
            this.pbSimulatingOfLed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbSimulatingOfLed.Name = "pbSimulatingOfLed";
            this.pbSimulatingOfLed.Size = new System.Drawing.Size(550, 550);
            this.pbSimulatingOfLed.TabIndex = 9;
            this.pbSimulatingOfLed.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y, мкм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(357, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "X, мкм";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(21, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 252);
            this.panel2.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(72, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 16);
            this.label22.TabIndex = 17;
            this.label22.Text = "none";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(3, 152);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 16);
            this.label23.TabIndex = 16;
            this.label23.Text = "Вправо :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(72, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 16);
            this.label20.TabIndex = 15;
            this.label20.Text = "none";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(3, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 16);
            this.label21.TabIndex = 14;
            this.label21.Text = "Влево :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(72, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 16);
            this.label18.TabIndex = 13;
            this.label18.Text = "none";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(3, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 16);
            this.label19.TabIndex = 12;
            this.label19.Text = "Вниз :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(121, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = "none";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(3, 182);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 16);
            this.label17.TabIndex = 10;
            this.label17.Text = "Поглотилось :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(3, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "none";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "2D квантовый выход:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(72, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "none";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(72, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "none";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Вверх :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(2, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Вышло :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "none";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Квантов рассчитано :";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.elem9);
            this.panel4.Controls.Add(this.Col9);
            this.panel4.Controls.Add(this.elem8);
            this.panel4.Controls.Add(this.Col8);
            this.panel4.Controls.Add(this.elem7);
            this.panel4.Controls.Add(this.Col7);
            this.panel4.Controls.Add(this.elem6);
            this.panel4.Controls.Add(this.Col6);
            this.panel4.Controls.Add(this.elem5);
            this.panel4.Controls.Add(this.Col5);
            this.panel4.Controls.Add(this.elem4);
            this.panel4.Controls.Add(this.Col4);
            this.panel4.Controls.Add(this.elem3);
            this.panel4.Controls.Add(this.Col3);
            this.panel4.Controls.Add(this.elem2);
            this.panel4.Controls.Add(this.Col2);
            this.panel4.Controls.Add(this.elem1);
            this.panel4.Controls.Add(this.Col1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(21, 301);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 286);
            this.panel4.TabIndex = 7;
            // 
            // elem9
            // 
            this.elem9.AutoSize = true;
            this.elem9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem9.Location = new System.Drawing.Point(55, 255);
            this.elem9.Name = "elem9";
            this.elem9.Size = new System.Drawing.Size(39, 15);
            this.elem9.TabIndex = 19;
            this.elem9.Text = "none";
            this.elem9.Visible = false;
            // 
            // Col9
            // 
            this.Col9.Location = new System.Drawing.Point(5, 252);
            this.Col9.Name = "Col9";
            this.Col9.Size = new System.Drawing.Size(44, 22);
            this.Col9.TabIndex = 18;
            this.Col9.UseVisualStyleBackColor = true;
            this.Col9.Visible = false;
            // 
            // elem8
            // 
            this.elem8.AutoSize = true;
            this.elem8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem8.Location = new System.Drawing.Point(56, 225);
            this.elem8.Name = "elem8";
            this.elem8.Size = new System.Drawing.Size(39, 15);
            this.elem8.TabIndex = 17;
            this.elem8.Text = "none";
            this.elem8.Visible = false;
            // 
            // Col8
            // 
            this.Col8.Location = new System.Drawing.Point(6, 222);
            this.Col8.Name = "Col8";
            this.Col8.Size = new System.Drawing.Size(44, 22);
            this.Col8.TabIndex = 16;
            this.Col8.UseVisualStyleBackColor = true;
            this.Col8.Visible = false;
            // 
            // elem7
            // 
            this.elem7.AutoSize = true;
            this.elem7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem7.Location = new System.Drawing.Point(56, 198);
            this.elem7.Name = "elem7";
            this.elem7.Size = new System.Drawing.Size(39, 15);
            this.elem7.TabIndex = 15;
            this.elem7.Text = "none";
            this.elem7.Visible = false;
            // 
            // Col7
            // 
            this.Col7.Location = new System.Drawing.Point(6, 195);
            this.Col7.Name = "Col7";
            this.Col7.Size = new System.Drawing.Size(44, 22);
            this.Col7.TabIndex = 14;
            this.Col7.UseVisualStyleBackColor = true;
            this.Col7.Visible = false;
            // 
            // elem6
            // 
            this.elem6.AutoSize = true;
            this.elem6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem6.Location = new System.Drawing.Point(56, 170);
            this.elem6.Name = "elem6";
            this.elem6.Size = new System.Drawing.Size(39, 15);
            this.elem6.TabIndex = 13;
            this.elem6.Text = "none";
            this.elem6.Visible = false;
            // 
            // Col6
            // 
            this.Col6.Location = new System.Drawing.Point(6, 168);
            this.Col6.Name = "Col6";
            this.Col6.Size = new System.Drawing.Size(44, 22);
            this.Col6.TabIndex = 12;
            this.Col6.UseVisualStyleBackColor = true;
            this.Col6.Visible = false;
            // 
            // elem5
            // 
            this.elem5.AutoSize = true;
            this.elem5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem5.Location = new System.Drawing.Point(56, 142);
            this.elem5.Name = "elem5";
            this.elem5.Size = new System.Drawing.Size(39, 15);
            this.elem5.TabIndex = 11;
            this.elem5.Text = "none";
            this.elem5.Visible = false;
            // 
            // Col5
            // 
            this.Col5.Location = new System.Drawing.Point(6, 140);
            this.Col5.Name = "Col5";
            this.Col5.Size = new System.Drawing.Size(44, 22);
            this.Col5.TabIndex = 10;
            this.Col5.UseVisualStyleBackColor = true;
            this.Col5.Visible = false;
            // 
            // elem4
            // 
            this.elem4.AutoSize = true;
            this.elem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem4.Location = new System.Drawing.Point(56, 114);
            this.elem4.Name = "elem4";
            this.elem4.Size = new System.Drawing.Size(39, 15);
            this.elem4.TabIndex = 9;
            this.elem4.Text = "none";
            this.elem4.Visible = false;
            // 
            // Col4
            // 
            this.Col4.Location = new System.Drawing.Point(6, 112);
            this.Col4.Name = "Col4";
            this.Col4.Size = new System.Drawing.Size(44, 22);
            this.Col4.TabIndex = 8;
            this.Col4.UseVisualStyleBackColor = true;
            this.Col4.Visible = false;
            // 
            // elem3
            // 
            this.elem3.AutoSize = true;
            this.elem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem3.Location = new System.Drawing.Point(56, 86);
            this.elem3.Name = "elem3";
            this.elem3.Size = new System.Drawing.Size(39, 15);
            this.elem3.TabIndex = 7;
            this.elem3.Text = "none";
            this.elem3.Visible = false;
            // 
            // Col3
            // 
            this.Col3.Location = new System.Drawing.Point(6, 84);
            this.Col3.Name = "Col3";
            this.Col3.Size = new System.Drawing.Size(44, 22);
            this.Col3.TabIndex = 6;
            this.Col3.UseVisualStyleBackColor = true;
            this.Col3.Visible = false;
            // 
            // elem2
            // 
            this.elem2.AutoSize = true;
            this.elem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem2.Location = new System.Drawing.Point(56, 58);
            this.elem2.Name = "elem2";
            this.elem2.Size = new System.Drawing.Size(39, 15);
            this.elem2.TabIndex = 5;
            this.elem2.Text = "none";
            this.elem2.Visible = false;
            // 
            // Col2
            // 
            this.Col2.Location = new System.Drawing.Point(6, 56);
            this.Col2.Name = "Col2";
            this.Col2.Size = new System.Drawing.Size(44, 22);
            this.Col2.TabIndex = 4;
            this.Col2.UseVisualStyleBackColor = true;
            this.Col2.Visible = false;
            // 
            // elem1
            // 
            this.elem1.AutoSize = true;
            this.elem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elem1.Location = new System.Drawing.Point(56, 31);
            this.elem1.Name = "elem1";
            this.elem1.Size = new System.Drawing.Size(39, 15);
            this.elem1.TabIndex = 3;
            this.elem1.Text = "none";
            this.elem1.Visible = false;
            // 
            // Col1
            // 
            this.Col1.Location = new System.Drawing.Point(6, 28);
            this.Col1.Name = "Col1";
            this.Col1.Size = new System.Drawing.Size(44, 22);
            this.Col1.TabIndex = 2;
            this.Col1.UseVisualStyleBackColor = true;
            this.Col1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(67, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Легенда :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(21, 604);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 50);
            this.panel3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(47, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "none";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(46, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "none";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Y :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(15, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "X :";
            // 
            // FormSimulating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(958, 667);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSimulating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование распределения света";
            this.Load += new System.EventHandler(this.simulating_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.simulating_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulatingOfLed)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private Label label5;
        private Label elem1;
        private Button Col1;
        private Label elem7;
        private Button Col7;
        private Label elem6;
        private Button Col6;
        private Label elem5;
        private Button Col5;
        private Label elem4;
        private Button Col4;
        private Label elem3;
        private Button Col3;
        private Label elem2;
        private Button Col2;
        private ToolStripMenuItem моделированиеToolStripMenuItem;
        private ToolStripMenuItem трассировкаToolStripMenuItem;
        private ToolStripMenuItem начатьМоделированиеToolStripMenuItem;
        private Panel panel3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label elem9;
        private Button Col9;
        private Label elem8;
        private Button Col8;
        private ToolStripMenuItem отчетОМоделированииToolStripMenuItem;
        private ToolStripMenuItem показатьОтчетToolStripMenuItem;
        private ToolStripMenuItem показатьРаспределениеСветаToolStripMenuItem;
        private ToolStripMenuItem одиночныйКвантToolStripMenuItem;
        private Label label4;
        private Label label3;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label15;
        private Label label14;
        private Label label16;
        private Label label17;
        private Label label22;
        private Label label23;
        private Label label20;
        private Label label21;
        private Label label18;
        private Label label19;
        private PictureBox pbSimulatingOfLed;
    }
}