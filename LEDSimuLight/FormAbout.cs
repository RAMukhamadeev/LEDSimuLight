using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void about_Load(object sender, EventArgs e)
        {

        }
    }
}
