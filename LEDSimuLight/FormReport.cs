using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        public void toMessBox(String s)
        {
            MessageTextBox.AppendText(s);
        }

        private void report_Load(object sender, EventArgs e)
        {
        }
    }
}
