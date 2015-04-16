using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSimulatingInfo : Form
    {
        public static FormSimulatingInfo Instance { get; private set; }

        public FormSimulatingInfo()
        {
            InitializeComponent();
        }

        public void SetCountOfQuants(string value)
        {
            lblCountOfQuants.Text = value;
        }

        public void SetInfoFromVar()
        {
            lblQuantumEfficiency.Text = LedLibrary.QuantumEff.ToString("00.0000 %");
            lblCountOfAbsorbed.Text = LedLibrary.QuantAbsorbed.ToString();
            lblCountOfOut.Text = LedLibrary.QuantsOut.ToString();

            lblCountOfUp.Text = LedLibrary.QuantsFront.ToString();
            lblCountOfLeft.Text = LedLibrary.QuantsLeft.ToString();
            lblCountOfRight.Text = LedLibrary.QuantsRight.ToString();
            lblCountOfDown.Text = LedLibrary.QuantsBack.ToString();            
        }

        private void FormSimulatingInfo_Load(object sender, EventArgs e)
        {
            Instance = this;
            SetInfoFromVar();
            SetCountOfQuants("<none>");
        }
    }
}
