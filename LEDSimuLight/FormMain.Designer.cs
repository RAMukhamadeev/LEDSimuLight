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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
            this.btnConstruct = new Button();
            this.btnSimulating = new Button();
            this.menuStrip1 = new MenuStrip();
            this.файлToolStripMenuItem = new ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new ToolStripMenuItem();
            this.сервисToolStripMenuItem = new ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new ToolStripMenuItem();
            this.справкаToolStripMenuItem = new ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConstruct
            // 
            this.btnConstruct.Location = new Point(78, 85);
            this.btnConstruct.Margin = new Padding(6, 6, 6, 6);
            this.btnConstruct.Name = "btnConstruct";
            this.btnConstruct.Size = new Size(300, 90);
            this.btnConstruct.TabIndex = 0;
            this.btnConstruct.Text = "Конструирование светодиода";
            this.btnConstruct.UseVisualStyleBackColor = true;
            this.btnConstruct.Click += new EventHandler(this.button1_Click);
            // 
            // btnSimulating
            // 
            this.btnSimulating.Location = new Point(486, 85);
            this.btnSimulating.Margin = new Padding(6, 6, 6, 6);
            this.btnSimulating.Name = "btnSimulating";
            this.btnSimulating.Size = new Size(300, 90);
            this.btnSimulating.TabIndex = 1;
            this.btnSimulating.Text = "Моделирование распределения света";
            this.btnSimulating.UseVisualStyleBackColor = true;
            this.btnSimulating.Click += new EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new Size(874, 44);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new Size(83, 36);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new Size(180, 36);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.настройкаToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new Size(107, 36);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new Size(208, 36);
            this.настройкаToolStripMenuItem.Text = "Настройки";
            this.настройкаToolStripMenuItem.Click += new EventHandler(this.настройкаToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new Size(119, 36);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new Size(239, 36);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new SizeF(12F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(874, 238);
            this.Controls.Add(this.btnSimulating);
            this.Controls.Add(this.btnConstruct);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "LEDSimuLight";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConstruct;
        private Button btnSimulating;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
        private ToolStripMenuItem сервисToolStripMenuItem;
        private ToolStripMenuItem настройкаToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

