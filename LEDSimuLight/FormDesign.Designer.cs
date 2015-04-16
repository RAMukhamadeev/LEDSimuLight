namespace LEDSimuLight
{
    partial class FormDesign
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDesign));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьИнформационнуюПанельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьРельефToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.многоугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рельефToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьМатериалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьФигуруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПоследнююТочкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьТекущуюФигуруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПоследнююФигуруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDesignOfLed = new System.Windows.Forms.PictureBox();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesignOfLed)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.создатьРельефToolStripMenuItem,
            this.выбратьМатериалToolStripMenuItem,
            this.редактироватьФигуруToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(681, 24);
            this.menuStripMain.TabIndex = 5;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьИнформационнуюПанельToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // показатьИнформационнуюПанельToolStripMenuItem
            // 
            this.показатьИнформационнуюПанельToolStripMenuItem.Name = "показатьИнформационнуюПанельToolStripMenuItem";
            this.показатьИнформационнуюПанельToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.показатьИнформационнуюПанельToolStripMenuItem.Text = "Показать информационную панель";
            this.показатьИнформационнуюПанельToolStripMenuItem.Click += new System.EventHandler(this.показатьИнформационнуюПанельToolStripMenuItem_Click);
            // 
            // создатьРельефToolStripMenuItem
            // 
            this.создатьРельефToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.многоугольникToolStripMenuItem,
            this.рельефToolStripMenuItem});
            this.создатьРельефToolStripMenuItem.Name = "создатьРельефToolStripMenuItem";
            this.создатьРельефToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.создатьРельефToolStripMenuItem.Text = "Выбрать фигуру";
            // 
            // многоугольникToolStripMenuItem
            // 
            this.многоугольникToolStripMenuItem.Name = "многоугольникToolStripMenuItem";
            this.многоугольникToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.многоугольникToolStripMenuItem.Text = "Выпуклый многоугольник";
            this.многоугольникToolStripMenuItem.Click += new System.EventHandler(this.многоугольникToolStripMenuItem_Click);
            // 
            // рельефToolStripMenuItem
            // 
            this.рельефToolStripMenuItem.Name = "рельефToolStripMenuItem";
            this.рельефToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.рельефToolStripMenuItem.Text = "Окружность";
            this.рельефToolStripMenuItem.Click += new System.EventHandler(this.рельефToolStripMenuItem_Click);
            // 
            // выбратьМатериалToolStripMenuItem
            // 
            this.выбратьМатериалToolStripMenuItem.Name = "выбратьМатериалToolStripMenuItem";
            this.выбратьМатериалToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.выбратьМатериалToolStripMenuItem.Text = "Выбрать материал";
            // 
            // редактироватьФигуруToolStripMenuItem
            // 
            this.редактироватьФигуруToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьПоследнююТочкуToolStripMenuItem,
            this.удалитьТекущуюФигуруToolStripMenuItem,
            this.удалитьПоследнююФигуруToolStripMenuItem});
            this.редактироватьФигуруToolStripMenuItem.Name = "редактироватьФигуруToolStripMenuItem";
            this.редактироватьФигуруToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.редактироватьФигуруToolStripMenuItem.Text = "Редактирование";
            // 
            // удалитьПоследнююТочкуToolStripMenuItem
            // 
            this.удалитьПоследнююТочкуToolStripMenuItem.Name = "удалитьПоследнююТочкуToolStripMenuItem";
            this.удалитьПоследнююТочкуToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.удалитьПоследнююТочкуToolStripMenuItem.Text = "Удалить последнюю точку";
            this.удалитьПоследнююТочкуToolStripMenuItem.Click += new System.EventHandler(this.удалитьПоследнююТочкуToolStripMenuItem_Click);
            // 
            // удалитьТекущуюФигуруToolStripMenuItem
            // 
            this.удалитьТекущуюФигуруToolStripMenuItem.Name = "удалитьТекущуюФигуруToolStripMenuItem";
            this.удалитьТекущуюФигуруToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.удалитьТекущуюФигуруToolStripMenuItem.Text = "Удалить текущую фигуру";
            this.удалитьТекущуюФигуруToolStripMenuItem.Click += new System.EventHandler(this.удалитьТекущуюФигуруToolStripMenuItem_Click);
            // 
            // удалитьПоследнююФигуруToolStripMenuItem
            // 
            this.удалитьПоследнююФигуруToolStripMenuItem.Name = "удалитьПоследнююФигуруToolStripMenuItem";
            this.удалитьПоследнююФигуруToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.удалитьПоследнююФигуруToolStripMenuItem.Text = "Удалить последнюю фигуру";
            this.удалитьПоследнююФигуруToolStripMenuItem.Click += new System.EventHandler(this.удалитьПоследнююФигуруToolStripMenuItem_Click);
            // 
            // pbDesignOfLed
            // 
            this.pbDesignOfLed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDesignOfLed.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pbDesignOfLed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbDesignOfLed.Location = new System.Drawing.Point(0, 22);
            this.pbDesignOfLed.Margin = new System.Windows.Forms.Padding(2);
            this.pbDesignOfLed.Name = "pbDesignOfLed";
            this.pbDesignOfLed.Size = new System.Drawing.Size(696, 485);
            this.pbDesignOfLed.TabIndex = 8;
            this.pbDesignOfLed.TabStop = false;
            this.pbDesignOfLed.Click += new System.EventHandler(this.pbDesignOfLed_Click);
            this.pbDesignOfLed.MouseEnter += new System.EventHandler(this.pbDesignOfLed_MouseEnter);
            this.pbDesignOfLed.MouseLeave += new System.EventHandler(this.pbDesignOfLed_MouseLeave);
            this.pbDesignOfLed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDesignOfLed_MouseMove);
            this.pbDesignOfLed.Resize += new System.EventHandler(this.pbDesignOfLed_Resize);
            // 
            // FormDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(681, 503);
            this.Controls.Add(this.pbDesignOfLed);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конструирование светодиода";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDesign_FormClosed);
            this.Load += new System.EventHandler(this.design_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesignOfLed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьРельефToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рельефToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem многоугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьФигуруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьПоследнююФигуруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьМатериалToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbDesignOfLed;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьИнформационнуюПанельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьТекущуюФигуруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьПоследнююТочкуToolStripMenuItem;

    }
}