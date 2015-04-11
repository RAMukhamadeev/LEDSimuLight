using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}
