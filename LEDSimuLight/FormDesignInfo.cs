using System;
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

        public void SetCoordinates(string x, string y)
        {
            lblShowX.Text = x;
            lblShowY.Text = y;
        }

        private void FormDesignInfo_Load(object sender, EventArgs e)
        {
            Instance = this;
        }
    }
}
