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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbChoseActive = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPixDensity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rbNano = new System.Windows.Forms.RadioButton();
            this.rbMicro = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbMeshDensity = new System.Windows.Forms.TrackBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbMeshDensity = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trbWavelength = new System.Windows.Forms.TrackBar();
            this.pbWavelength = new System.Windows.Forms.PictureBox();
            this.tbWavelength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbCountOfQuants = new System.Windows.Forms.TrackBar();
            this.cbCountOfQuants = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMeshDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbWavelength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelength)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountOfQuants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(14, 1258);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(692, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки внешнего вида";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(423, 247);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 40);
            this.textBox4.TabIndex = 71;
            this.textBox4.Text = "0,5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(29, 247);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(352, 39);
            this.label11.TabIndex = 70;
            this.label11.Text = "Коэфф. отн. выс. сенс.  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(556, 186);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 39);
            this.label9.TabIndex = 69;
            this.label9.Text = "px";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(423, 186);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 40);
            this.textBox3.TabIndex = 68;
            this.textBox3.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(29, 186);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(375, 39);
            this.label10.TabIndex = 67;
            this.label10.Text = "Дист. между доп. метк. :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(556, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 39);
            this.label7.TabIndex = 66;
            this.label7.Text = "px";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(423, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 40);
            this.textBox2.TabIndex = 65;
            this.textBox2.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(29, 127);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(371, 39);
            this.label8.TabIndex = 64;
            this.label8.Text = "Дист. между осн. метк. :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(552, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 39);
            this.label6.TabIndex = 63;
            this.label6.Text = "px";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(423, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 40);
            this.textBox1.TabIndex = 62;
            this.textBox1.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(29, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 39);
            this.label5.TabIndex = 61;
            this.label5.Text = "Отступ :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(14, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(692, 1238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки моделирования";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbChoseActive);
            this.groupBox7.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(9, 1074);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(666, 139);
            this.groupBox7.TabIndex = 64;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Выбор материала активного слоя";
            // 
            // cbChoseActive
            // 
            this.cbChoseActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChoseActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbChoseActive.FormattingEnabled = true;
            this.cbChoseActive.Location = new System.Drawing.Point(36, 66);
            this.cbChoseActive.Name = "cbChoseActive";
            this.cbChoseActive.Size = new System.Drawing.Size(465, 41);
            this.cbChoseActive.TabIndex = 0;
            this.cbChoseActive.SelectedIndexChanged += new System.EventHandler(this.cbChoseActive_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.cbPixDensity);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.pictureBox3);
            this.groupBox6.Controls.Add(this.rbNano);
            this.groupBox6.Controls.Add(this.rbMicro);
            this.groupBox6.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(9, 844);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(666, 224);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Размерность осей и координат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(280, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 39);
            this.label3.TabIndex = 62;
            this.label3.Text = "мкм";
            // 
            // cbPixDensity
            // 
            this.cbPixDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPixDensity.FormattingEnabled = true;
            this.cbPixDensity.Items.AddRange(new object[] {
            "0,01",
            "0,1",
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "100"});
            this.cbPixDensity.Location = new System.Drawing.Point(160, 135);
            this.cbPixDensity.Name = "cbPixDensity";
            this.cbPixDensity.Size = new System.Drawing.Size(111, 41);
            this.cbPixDensity.TabIndex = 2;
            this.cbPixDensity.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "100 px = ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(392, 67);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(244, 118);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 61;
            this.pictureBox3.TabStop = false;
            // 
            // rbNano
            // 
            this.rbNano.AutoSize = true;
            this.rbNano.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNano.Location = new System.Drawing.Point(172, 67);
            this.rbNano.Name = "rbNano";
            this.rbNano.Size = new System.Drawing.Size(81, 43);
            this.rbNano.TabIndex = 56;
            this.rbNano.Text = "нм";
            this.rbNano.UseVisualStyleBackColor = true;
            // 
            // rbMicro
            // 
            this.rbMicro.AutoSize = true;
            this.rbMicro.Checked = true;
            this.rbMicro.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMicro.Location = new System.Drawing.Point(36, 67);
            this.rbMicro.Name = "rbMicro";
            this.rbMicro.Size = new System.Drawing.Size(102, 43);
            this.rbMicro.TabIndex = 0;
            this.rbMicro.TabStop = true;
            this.rbMicro.Text = "мкм";
            this.rbMicro.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbMeshDensity);
            this.groupBox5.Controls.Add(this.pictureBox2);
            this.groupBox5.Controls.Add(this.cbMeshDensity);
            this.groupBox5.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(9, 583);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(666, 255);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Коэффициент плотности расчетной сетки";
            // 
            // tbMeshDensity
            // 
            this.tbMeshDensity.Location = new System.Drawing.Point(28, 135);
            this.tbMeshDensity.Minimum = 1;
            this.tbMeshDensity.Name = "tbMeshDensity";
            this.tbMeshDensity.Size = new System.Drawing.Size(320, 90);
            this.tbMeshDensity.TabIndex = 63;
            this.tbMeshDensity.Value = 1;
            this.tbMeshDensity.Scroll += new System.EventHandler(this.tbMeshDensity_Scroll);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(392, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(244, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // cbMeshDensity
            // 
            this.cbMeshDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMeshDensity.FormattingEnabled = true;
            this.cbMeshDensity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMeshDensity.Location = new System.Drawing.Point(28, 66);
            this.cbMeshDensity.Name = "cbMeshDensity";
            this.cbMeshDensity.Size = new System.Drawing.Size(139, 41);
            this.cbMeshDensity.TabIndex = 0;
            this.cbMeshDensity.Text = "1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trbWavelength);
            this.groupBox4.Controls.Add(this.pbWavelength);
            this.groupBox4.Controls.Add(this.tbWavelength);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(9, 321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(666, 256);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Длина волны излучения";
            // 
            // trbWavelength
            // 
            this.trbWavelength.Location = new System.Drawing.Point(28, 138);
            this.trbWavelength.Maximum = 1000;
            this.trbWavelength.Minimum = 100;
            this.trbWavelength.Name = "trbWavelength";
            this.trbWavelength.Size = new System.Drawing.Size(320, 90);
            this.trbWavelength.TabIndex = 62;
            this.trbWavelength.Value = 100;
            this.trbWavelength.Scroll += new System.EventHandler(this.trbWavelength_Scroll);
            // 
            // pbWavelength
            // 
            this.pbWavelength.Image = ((System.Drawing.Image)(resources.GetObject("pbWavelength.Image")));
            this.pbWavelength.Location = new System.Drawing.Point(392, 76);
            this.pbWavelength.Name = "pbWavelength";
            this.pbWavelength.Size = new System.Drawing.Size(244, 146);
            this.pbWavelength.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWavelength.TabIndex = 61;
            this.pbWavelength.TabStop = false;
            // 
            // tbWavelength
            // 
            this.tbWavelength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWavelength.Location = new System.Drawing.Point(28, 68);
            this.tbWavelength.Name = "tbWavelength";
            this.tbWavelength.Size = new System.Drawing.Size(150, 40);
            this.tbWavelength.TabIndex = 0;
            this.tbWavelength.Text = "473";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(196, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 39);
            this.label4.TabIndex = 53;
            this.label4.Text = "нм";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbCountOfQuants);
            this.groupBox3.Controls.Add(this.cbCountOfQuants);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(9, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(666, 253);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество моделируемых квантов";
            // 
            // tbCountOfQuants
            // 
            this.tbCountOfQuants.Location = new System.Drawing.Point(28, 132);
            this.tbCountOfQuants.Maximum = 5000;
            this.tbCountOfQuants.Minimum = 100;
            this.tbCountOfQuants.Name = "tbCountOfQuants";
            this.tbCountOfQuants.Size = new System.Drawing.Size(320, 90);
            this.tbCountOfQuants.TabIndex = 61;
            this.tbCountOfQuants.Value = 100;
            this.tbCountOfQuants.Scroll += new System.EventHandler(this.tbCountOfQuants_Scroll);
            // 
            // cbCountOfQuants
            // 
            this.cbCountOfQuants.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCountOfQuants.FormattingEnabled = true;
            this.cbCountOfQuants.Items.AddRange(new object[] {
            "300",
            "500",
            "1000",
            "2000",
            "3000",
            "5000"});
            this.cbCountOfQuants.Location = new System.Drawing.Point(28, 66);
            this.cbCountOfQuants.Name = "cbCountOfQuants";
            this.cbCountOfQuants.Size = new System.Drawing.Size(150, 41);
            this.cbCountOfQuants.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(211, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 39);
            this.label1.TabIndex = 60;
            this.label1.Text = "тысяч";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(392, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 880);
            this.panel1.TabIndex = 2;
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStripMain.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(792, 47);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьНастройкиToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(98, 43);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьНастройкиToolStripMenuItem
            // 
            this.сохранитьНастройкиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьНастройкиToolStripMenuItem.Image")));
            this.сохранитьНастройкиToolStripMenuItem.Name = "сохранитьНастройкиToolStripMenuItem";
            this.сохранитьНастройкиToolStripMenuItem.Size = new System.Drawing.Size(409, 44);
            this.сохранитьНастройкиToolStripMenuItem.Text = "Сохранить настройки";
            this.сохранитьНастройкиToolStripMenuItem.Click += new System.EventHandler(this.сохранитьНастройкиToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(409, 44);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(792, 986);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(96, 46, 96, 46);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMeshDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbWavelength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWavelength)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountOfQuants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
        private TextBox tbWavelength;
        private ComboBox cbMeshDensity;
        private Label label4;
        private RadioButton rbNano;
        private RadioButton rbMicro;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label1;
        private PictureBox pictureBox1;
        private ComboBox cbCountOfQuants;
        private PictureBox pbWavelength;
        private GroupBox groupBox5;
        private PictureBox pictureBox2;
        private GroupBox groupBox6;
        private PictureBox pictureBox3;
        private ComboBox cbPixDensity;
        private Label label2;
        private Label label3;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private Label label9;
        private TextBox textBox3;
        private Label label10;
        private Label label7;
        private TextBox textBox2;
        private Label label8;
        private TextBox textBox4;
        private Label label11;
        private TrackBar tbCountOfQuants;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьНастройкиToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private TrackBar tbMeshDensity;
        private TrackBar trbWavelength;
        private GroupBox groupBox7;
        private ComboBox cbChoseActive;
    }
}