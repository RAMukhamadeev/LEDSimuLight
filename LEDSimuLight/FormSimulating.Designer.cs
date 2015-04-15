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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.трассировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьМоделированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЛегендуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьИнформационнуюПанельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетОМоделированииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьРаспределениеСветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbSimulatingOfLed = new System.Windows.Forms.PictureBox();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulatingOfLed)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.моделированиеToolStripMenuItem,
            this.видToolStripMenuItem,
            this.отчетОМоделированииToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStripMain.Size = new System.Drawing.Size(1904, 46);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(83, 38);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(180, 36);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // моделированиеToolStripMenuItem
            // 
            this.моделированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.трассировкаToolStripMenuItem,
            this.начатьМоделированиеToolStripMenuItem});
            this.моделированиеToolStripMenuItem.Name = "моделированиеToolStripMenuItem";
            this.моделированиеToolStripMenuItem.Size = new System.Drawing.Size(210, 38);
            this.моделированиеToolStripMenuItem.Text = "Моделирование";
            // 
            // трассировкаToolStripMenuItem
            // 
            this.трассировкаToolStripMenuItem.Name = "трассировкаToolStripMenuItem";
            this.трассировкаToolStripMenuItem.Size = new System.Drawing.Size(348, 36);
            this.трассировкаToolStripMenuItem.Text = "Трассировка";
            this.трассировкаToolStripMenuItem.Click += new System.EventHandler(this.трассировкаToolStripMenuItem_Click);
            // 
            // начатьМоделированиеToolStripMenuItem
            // 
            this.начатьМоделированиеToolStripMenuItem.Name = "начатьМоделированиеToolStripMenuItem";
            this.начатьМоделированиеToolStripMenuItem.Size = new System.Drawing.Size(348, 36);
            this.начатьМоделированиеToolStripMenuItem.Text = "Запуск моделирования";
            this.начатьМоделированиеToolStripMenuItem.Click += new System.EventHandler(this.начатьМоделированиеToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьЛегендуToolStripMenuItem,
            this.показатьИнформационнуюПанельToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(68, 38);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // показатьЛегендуToolStripMenuItem
            // 
            this.показатьЛегендуToolStripMenuItem.Name = "показатьЛегендуToolStripMenuItem";
            this.показатьЛегендуToolStripMenuItem.Size = new System.Drawing.Size(485, 36);
            this.показатьЛегендуToolStripMenuItem.Text = "Показать легенду";
            this.показатьЛегендуToolStripMenuItem.Click += new System.EventHandler(this.показатьЛегендуToolStripMenuItem_Click);
            // 
            // показатьИнформационнуюПанельToolStripMenuItem
            // 
            this.показатьИнформационнуюПанельToolStripMenuItem.Name = "показатьИнформационнуюПанельToolStripMenuItem";
            this.показатьИнформационнуюПанельToolStripMenuItem.Size = new System.Drawing.Size(485, 36);
            this.показатьИнформационнуюПанельToolStripMenuItem.Text = "Показать информационную панель";
            this.показатьИнформационнуюПанельToolStripMenuItem.Click += new System.EventHandler(this.показатьИнформационнуюПанельToolStripMenuItem_Click);
            // 
            // отчетОМоделированииToolStripMenuItem
            // 
            this.отчетОМоделированииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьОтчетToolStripMenuItem,
            this.показатьРаспределениеСветаToolStripMenuItem});
            this.отчетОМоделированииToolStripMenuItem.Name = "отчетОМоделированииToolStripMenuItem";
            this.отчетОМоделированииToolStripMenuItem.Size = new System.Drawing.Size(92, 38);
            this.отчетОМоделированииToolStripMenuItem.Text = "Отчет";
            // 
            // показатьОтчетToolStripMenuItem
            // 
            this.показатьОтчетToolStripMenuItem.Name = "показатьОтчетToolStripMenuItem";
            this.показатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(434, 36);
            this.показатьОтчетToolStripMenuItem.Text = "Показать отчет";
            this.показатьОтчетToolStripMenuItem.Click += new System.EventHandler(this.показатьОтчетToolStripMenuItem_Click);
            // 
            // показатьРаспределениеСветаToolStripMenuItem
            // 
            this.показатьРаспределениеСветаToolStripMenuItem.Name = "показатьРаспределениеСветаToolStripMenuItem";
            this.показатьРаспределениеСветаToolStripMenuItem.Size = new System.Drawing.Size(434, 36);
            this.показатьРаспределениеСветаToolStripMenuItem.Text = "Показать распределение света";
            this.показатьРаспределениеСветаToolStripMenuItem.Click += new System.EventHandler(this.показатьРаспределениеСветаToolStripMenuItem_Click);
            // 
            // pbSimulatingOfLed
            // 
            this.pbSimulatingOfLed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSimulatingOfLed.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pbSimulatingOfLed.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSimulatingOfLed.Location = new System.Drawing.Point(1, 41);
            this.pbSimulatingOfLed.Margin = new System.Windows.Forms.Padding(4);
            this.pbSimulatingOfLed.Name = "pbSimulatingOfLed";
            this.pbSimulatingOfLed.Size = new System.Drawing.Size(1900, 938);
            this.pbSimulatingOfLed.TabIndex = 9;
            this.pbSimulatingOfLed.TabStop = false;
            this.pbSimulatingOfLed.Click += new System.EventHandler(this.pbSimulatingOfLed_Click);
            // 
            // FormSimulating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 986);
            this.Controls.Add(this.pbSimulatingOfLed);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormSimulating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование распределения света";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSimulating_FormClosed);
            this.Load += new System.EventHandler(this.simulating_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.simulating_KeyPress);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulatingOfLed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private ToolStripMenuItem моделированиеToolStripMenuItem;
        private ToolStripMenuItem трассировкаToolStripMenuItem;
        private ToolStripMenuItem начатьМоделированиеToolStripMenuItem;
        private ToolStripMenuItem отчетОМоделированииToolStripMenuItem;
        private ToolStripMenuItem показатьОтчетToolStripMenuItem;
        private ToolStripMenuItem показатьРаспределениеСветаToolStripMenuItem;
        private PictureBox pbSimulatingOfLed;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem показатьЛегендуToolStripMenuItem;
        private ToolStripMenuItem показатьИнформационнуюПанельToolStripMenuItem;
    }
}