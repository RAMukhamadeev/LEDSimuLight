using System;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormLegend : Form
    {
        public static FormLegend Instance { get; private set; }

        public FormLegend()
        {
            InitializeComponent();
        }

        public void SetMaterial(int n, Color col, int code)
        {
            Control controlButton = Controls["col" + n];
            controlButton.BackColor = col;
            controlButton.Visible = true;

            Control controlLabel = Controls["elem" + n];
            controlLabel.Text = LedLibrary.Materials[code].Name;
            controlLabel.Visible = true;
        }

        private void FormLegend_Load(object sender, EventArgs e)
        {
            Instance = this;
        }
    }
}
