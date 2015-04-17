using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LEDSimuLight
{
    public partial class FormEfficiencyGraph : Form
    {
        public static FormEfficiencyGraph Instance { get; private set; }

        private DateTime _startTime;
        private bool _firstRequest = true;

        public FormEfficiencyGraph()
        {
            InitializeComponent();
        }

        private void FormEfficiencyGraph_Load(object sender, EventArgs e)
        {
            Instance = this;

            chartQuantumEfficiency.Series[0].Name = "Внешний квантовый выход";
            chartQuantumEfficiency.ChartAreas[0].AxisX.Minimum = 0;
            chartQuantumEfficiency.ChartAreas[0].AxisY.Minimum = 0;
            chartQuantumEfficiency.ChartAreas[0].AxisY.Maximum = 1;
            chartQuantumEfficiency.ChartAreas[0].AxisY.Interval = 0.1;
            chartQuantumEfficiency.ChartAreas[0].AxisX.Interval = 1;
            chartQuantumEfficiency.ChartAreas[0].AxisX.Title = "Время, сек";

            chartQuantumEfficiency.Series[0].Points.AddXY(0, 0);
        }

        public void SetPoint()
        {
            // первый вызов
            if (_firstRequest)
            {
                _startTime = DateTime.Now;
                _firstRequest = false;
            }

            TimeSpan ts = DateTime.Now - _startTime;
            double time = ts.TotalMilliseconds / 1000.0;
            double efficiency = LedLibrary.QuantumEff;

            chartQuantumEfficiency.Series[0].Points.AddXY(time, efficiency);
        }

        private void chartQuantumEfficiency_Click(object sender, EventArgs e)
        {

        }
    }
}
