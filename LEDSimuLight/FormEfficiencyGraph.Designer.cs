namespace LEDSimuLight
{
    partial class FormEfficiencyGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartQuantumEfficiency = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartQuantumEfficiency)).BeginInit();
            this.SuspendLayout();
            // 
            // chartQuantumEfficiency
            // 
            this.chartQuantumEfficiency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartQuantumEfficiency.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartQuantumEfficiency.Legends.Add(legend1);
            this.chartQuantumEfficiency.Location = new System.Drawing.Point(1, -2);
            this.chartQuantumEfficiency.Name = "chartQuantumEfficiency";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "QuantumEfficiency";
            series1.YValuesPerPoint = 4;
            this.chartQuantumEfficiency.Series.Add(series1);
            this.chartQuantumEfficiency.Size = new System.Drawing.Size(1197, 826);
            this.chartQuantumEfficiency.TabIndex = 0;
            this.chartQuantumEfficiency.Text = "chart1";
            this.chartQuantumEfficiency.Click += new System.EventHandler(this.chartQuantumEfficiency_Click);
            // 
            // FormEfficiencyGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 821);
            this.Controls.Add(this.chartQuantumEfficiency);
            this.Name = "FormEfficiencyGraph";
            this.Text = "FormEfficiencyGraph";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEfficiencyGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartQuantumEfficiency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartQuantumEfficiency;

    }
}