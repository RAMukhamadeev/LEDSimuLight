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
            lblQuantumEfficiency.Text = Var.QuantumEff.ToString("00.0000 %");
            lblCountOfAbsorbed.Text = Var.QuantAbsorbed.ToString();
            lblCountOfOut.Text = Var.QuantsOut.ToString();

            lblCountOfUp.Text = Var.QuantsFront.ToString();
            lblCountOfLeft.Text = Var.QuantsLeft.ToString();
            lblCountOfRight.Text = Var.QuantsRight.ToString();
            lblCountOfDown.Text = Var.QuantsBack.ToString();            
        }

        private void FormSimulatingInfo_Load(object sender, EventArgs e)
        {
            Instance = this;
            SetInfoFromVar();
            SetCountOfQuants("<none>");
        }
    }
}
