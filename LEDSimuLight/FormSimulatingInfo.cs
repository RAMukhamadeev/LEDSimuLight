using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSimulatingInfo : Form
    {
        public static FormSimulatingInfo Instance { get; private set; }

        private int _currCount = 0;

        public FormSimulatingInfo()
        {
            InitializeComponent();
        }

        public void SetCountOfQuants(int value)
        {
            lblCountOfQuants.Text = RepresentationOfQuants(value);
            _currCount = value;
        }

        string RepresentationOfQuants(int x)
        {
            return (x/1000.0).ToString("0.00") + " тысяч";
        }

        public void SetInfoFromVar()
        {
            lblQuantumEfficiency.Text = LedLibrary.QuantumEff.ToString("0.0000 %");
            lblCountOfAbsorbed.Text = RepresentationOfQuants(LedLibrary.QuantAbsorbed);
            lblCountOfOut.Text = RepresentationOfQuants(LedLibrary.QuantsOut);

            lblCountOfUp.Text = RepresentationOfQuants(LedLibrary.QuantsFront);
            lblCountOfLeft.Text = RepresentationOfQuants(LedLibrary.QuantsLeft);
            lblCountOfRight.Text = RepresentationOfQuants(LedLibrary.QuantsRight);
            lblCountOfDown.Text = RepresentationOfQuants(LedLibrary.QuantsBack);
            lblSummaryQuants.Text = RepresentationOfQuants(LedLibrary.CountOfQuants);

            double procent = (double)(_currCount)/LedLibrary.CountOfQuants;
            lblProgress.Text = String.Format("Прогресс: {0:0.00 %} выполнения", procent);
            pbProgress.Value = (int)(1000*procent);
        }

        private void FormSimulatingInfo_Load(object sender, EventArgs e)
        {
            Instance = this;
            SetInfoFromVar();
            SetCountOfQuants(0);
        }
    }
}
