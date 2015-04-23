using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormDesignInstruments : Form
    {
        public static FormDesignInstruments Instance { get; private set; }

        public FormDesignInstruments()
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

        private void trbMove_Scroll(object sender, EventArgs e)
        {
            lblMoveValue.Text = String.Format("Сдвиг: {0} px", trbMove.Value);
        }

        private void pbUp_Click(object sender, EventArgs e)
        {
            if (FormDesign.Instance != null)
                FormDesign.Instance.MoveVertical(trbMove.Value);
        }

        private void pbDown_Click(object sender, EventArgs e)
        {
            if (FormDesign.Instance != null)
                FormDesign.Instance.MoveVertical(-trbMove.Value);
        }

        private void pbLeft_Click(object sender, EventArgs e)
        {
            if (FormDesign.Instance != null)
                FormDesign.Instance.MoveGorizontal(-trbMove.Value);
        }

        private void pbRight_Click(object sender, EventArgs e)
        {
            if (FormDesign.Instance != null)
            {
                if (rbWholeStructure.Checked)
                    FormDesign.Instance.MoveGorizontal(trbMove.Value);
                if (rbLastShape.Checked)
                {
                    FormDesign.Instance.DrawGorizontalMovedCircle(trbMove.Value);
                }
            }
        }
    }
}
