using System;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormDesignInfo : Form
    {
        public static FormDesignInfo Instance { get; private set; }

        public FormDesignInfo()
        {
            InitializeComponent();
        }

        public void SetMaterial(string value)
        {
            lblMaterial.Text = value;
        }

        public void SetShape(string value)
        {
            lblShape.Text = value;
        }

        public void SetCoordinatesForFix(string x, string y)
        {
            tbXFix.Text = x;
            tbYFix.Text = y;
        }

        public void SetCoordinates(string x, string y)
        {
            lblShowX.Text = x;
            lblShowY.Text = y;
        }

        private void FormDesignInfo_Load(object sender, EventArgs e)
        {
            Instance = this;
        }

        private void pbFixCoordinates_Click(object sender, EventArgs e)
        {
            double x, y;
            try
            {
                x = Double.Parse(tbXFix.Text);
                y = Double.Parse(tbYFix.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных координат!");
                return;
            }

            if (FormDesign.Instance != null)
                FormDesign.Instance.SetFixedCoordinates(x, y);
        }
    }
}
