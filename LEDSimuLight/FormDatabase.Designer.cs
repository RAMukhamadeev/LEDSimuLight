namespace LEDSimuLight
{
    partial class FormDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabase));
            this.dgvDatabase = new System.Windows.Forms.DataGridView();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйМатериалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbAddMaterial = new System.Windows.Forms.PictureBox();
            this.pbOpenDatabase = new System.Windows.Forms.PictureBox();
            this.pbSaveDatabase = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).BeginInit();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveDatabase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatabase
            // 
            this.dgvDatabase.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabase.Location = new System.Drawing.Point(24, 60);
            this.dgvDatabase.Margin = new System.Windows.Forms.Padding(6);
            this.dgvDatabase.Name = "dgvDatabase";
            this.dgvDatabase.Size = new System.Drawing.Size(1956, 669);
            this.dgvDatabase.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.материалToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStripMain.Size = new System.Drawing.Size(2000, 44);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(83, 36);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(206, 36);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(206, 36);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(206, 36);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйМатериалToolStripMenuItem});
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(137, 36);
            this.материалToolStripMenuItem.Text = "Материал";
            // 
            // новыйМатериалToolStripMenuItem
            // 
            this.новыйМатериалToolStripMenuItem.Name = "новыйМатериалToolStripMenuItem";
            this.новыйМатериалToolStripMenuItem.Size = new System.Drawing.Size(277, 36);
            this.новыйМатериалToolStripMenuItem.Text = "Новый материал";
            this.новыйМатериалToolStripMenuItem.Click += new System.EventHandler(this.новыйМатериалToolStripMenuItem_Click);
            // 
            // pbExit
            // 
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(1354, 741);
            this.pbExit.Margin = new System.Windows.Forms.Padding(6);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(260, 242);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExit.TabIndex = 6;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbAddMaterial
            // 
            this.pbAddMaterial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddMaterial.Image = ((System.Drawing.Image)(resources.GetObject("pbAddMaterial.Image")));
            this.pbAddMaterial.Location = new System.Drawing.Point(364, 741);
            this.pbAddMaterial.Margin = new System.Windows.Forms.Padding(6);
            this.pbAddMaterial.Name = "pbAddMaterial";
            this.pbAddMaterial.Size = new System.Drawing.Size(260, 242);
            this.pbAddMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddMaterial.TabIndex = 5;
            this.pbAddMaterial.TabStop = false;
            this.pbAddMaterial.Click += new System.EventHandler(this.pbAddMaterial_Click);
            // 
            // pbOpenDatabase
            // 
            this.pbOpenDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenDatabase.Image = ((System.Drawing.Image)(resources.GetObject("pbOpenDatabase.Image")));
            this.pbOpenDatabase.Location = new System.Drawing.Point(690, 741);
            this.pbOpenDatabase.Margin = new System.Windows.Forms.Padding(6);
            this.pbOpenDatabase.Name = "pbOpenDatabase";
            this.pbOpenDatabase.Size = new System.Drawing.Size(260, 242);
            this.pbOpenDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOpenDatabase.TabIndex = 4;
            this.pbOpenDatabase.TabStop = false;
            this.pbOpenDatabase.Click += new System.EventHandler(this.pbOpenDatabase_Click);
            // 
            // pbSaveDatabase
            // 
            this.pbSaveDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSaveDatabase.Image = ((System.Drawing.Image)(resources.GetObject("pbSaveDatabase.Image")));
            this.pbSaveDatabase.Location = new System.Drawing.Point(1018, 741);
            this.pbSaveDatabase.Margin = new System.Windows.Forms.Padding(6);
            this.pbSaveDatabase.Name = "pbSaveDatabase";
            this.pbSaveDatabase.Size = new System.Drawing.Size(260, 242);
            this.pbSaveDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSaveDatabase.TabIndex = 3;
            this.pbSaveDatabase.TabStop = false;
            this.pbSaveDatabase.Click += new System.EventHandler(this.pbSaveDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(408, 1001);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 54);
            this.label1.TabIndex = 9;
            this.label1.Text = "Добавить";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(730, 1001);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 54);
            this.label2.TabIndex = 10;
            this.label2.Text = "Открыть";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(1044, 1001);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 54);
            this.label3.TabIndex = 11;
            this.label3.Text = "Сохранить";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(1424, 1001);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 54);
            this.label4.TabIndex = 12;
            this.label4.Text = "Выход";
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2000, 1080);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbAddMaterial);
            this.Controls.Add(this.pbOpenDatabase);
            this.Controls.Add(this.pbSaveDatabase);
            this.Controls.Add(this.dgvDatabase);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormDatabase";
            this.Text = "База данных с материалами светодиодов";
            this.Load += new System.EventHandler(this.FormDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveDatabase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbSaveDatabase;
        private System.Windows.Forms.ToolStripMenuItem материалToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйМатериалToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbOpenDatabase;
        private System.Windows.Forms.PictureBox pbAddMaterial;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}