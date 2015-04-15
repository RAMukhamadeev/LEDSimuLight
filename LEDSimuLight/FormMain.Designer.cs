using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьТекущийПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDesign = new System.Windows.Forms.PictureBox();
            this.pbSimulating = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbStatistics = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStripMain.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.проектированиеToolStripMenuItem,
            this.моделированиеToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1666, 45);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(95, 41);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(203, 42);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // проектированиеToolStripMenuItem
            // 
            this.проектированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПроектToolStripMenuItem});
            this.проектированиеToolStripMenuItem.Name = "проектированиеToolStripMenuItem";
            this.проектированиеToolStripMenuItem.Size = new System.Drawing.Size(252, 41);
            this.проектированиеToolStripMenuItem.Text = "Проектирование";
            // 
            // новыйПроектToolStripMenuItem
            // 
            this.новыйПроектToolStripMenuItem.Name = "новыйПроектToolStripMenuItem";
            this.новыйПроектToolStripMenuItem.Size = new System.Drawing.Size(280, 42);
            this.новыйПроектToolStripMenuItem.Text = "Новый проект";
            this.новыйПроектToolStripMenuItem.Click += new System.EventHandler(this.новыйПроектToolStripMenuItem_Click);
            // 
            // моделированиеToolStripMenuItem
            // 
            this.моделированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьТекущийПроектToolStripMenuItem});
            this.моделированиеToolStripMenuItem.Name = "моделированиеToolStripMenuItem";
            this.моделированиеToolStripMenuItem.Size = new System.Drawing.Size(246, 41);
            this.моделированиеToolStripMenuItem.Text = "Моделирование";
            // 
            // открытьТекущийПроектToolStripMenuItem
            // 
            this.открытьТекущийПроектToolStripMenuItem.Name = "открытьТекущийПроектToolStripMenuItem";
            this.открытьТекущийПроектToolStripMenuItem.Size = new System.Drawing.Size(425, 42);
            this.открытьТекущийПроектToolStripMenuItem.Text = "Открыть текущий проект";
            this.открытьТекущийПроектToolStripMenuItem.Click += new System.EventHandler(this.открытьТекущийПроектToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(122, 41);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(237, 42);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(137, 41);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(269, 42);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(269, 42);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click_1);
            // 
            // pbDesign
            // 
            this.pbDesign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDesign.Image = global::LEDSimuLight.Properties.Resources.design;
            this.pbDesign.Location = new System.Drawing.Point(54, 94);
            this.pbDesign.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbDesign.Name = "pbDesign";
            this.pbDesign.Size = new System.Drawing.Size(340, 340);
            this.pbDesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDesign.TabIndex = 4;
            this.pbDesign.TabStop = false;
            this.pbDesign.Click += new System.EventHandler(this.pbDesign_Click);
            // 
            // pbSimulating
            // 
            this.pbSimulating.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSimulating.Image = global::LEDSimuLight.Properties.Resources.simulating;
            this.pbSimulating.Location = new System.Drawing.Point(452, 94);
            this.pbSimulating.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbSimulating.Name = "pbSimulating";
            this.pbSimulating.Size = new System.Drawing.Size(340, 340);
            this.pbSimulating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSimulating.TabIndex = 5;
            this.pbSimulating.TabStop = false;
            this.pbSimulating.Click += new System.EventHandler(this.pbSimulating_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSettings.Image = global::LEDSimuLight.Properties.Resources.settings;
            this.pbSettings.Location = new System.Drawing.Point(856, 94);
            this.pbSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(340, 340);
            this.pbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSettings.TabIndex = 6;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            // 
            // pbStatistics
            // 
            this.pbStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStatistics.Image = global::LEDSimuLight.Properties.Resources.activityMonitor;
            this.pbStatistics.Location = new System.Drawing.Point(1264, 94);
            this.pbStatistics.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbStatistics.Name = "pbStatistics";
            this.pbStatistics.Size = new System.Drawing.Size(340, 340);
            this.pbStatistics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatistics.TabIndex = 7;
            this.pbStatistics.TabStop = false;
            this.pbStatistics.Click += new System.EventHandler(this.pbStatistics_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(66, 460);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 57);
            this.label1.TabIndex = 8;
            this.label1.Text = "Проектирование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(477, 460);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 57);
            this.label2.TabIndex = 9;
            this.label2.Text = "Моделирование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(916, 460);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 57);
            this.label3.TabIndex = 10;
            this.label3.Text = "Настройки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(1306, 460);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 57);
            this.label4.TabIndex = 11;
            this.label4.Text = "Статистика";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1666, 542);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbStatistics);
            this.Controls.Add(this.pbSettings);
            this.Controls.Add(this.pbSimulating);
            this.Controls.Add(this.pbDesign);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(96, 46, 96, 46);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEDSimuLight";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private ToolStripMenuItem сервисToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private PictureBox pbDesign;
        private PictureBox pbSimulating;
        private PictureBox pbSettings;
        private PictureBox pbStatistics;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ToolStripMenuItem проектированиеToolStripMenuItem;
        private ToolStripMenuItem новыйПроектToolStripMenuItem;
        private ToolStripMenuItem моделированиеToolStripMenuItem;
        private ToolStripMenuItem открытьТекущийПроектToolStripMenuItem;
        private ToolStripMenuItem помощьToolStripMenuItem;
    }
}

