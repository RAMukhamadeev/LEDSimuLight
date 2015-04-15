using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            controlLabel.Text = Var.Materials[code].Name;
            controlLabel.Visible = true;
        }

        private void FormLegend_Load(object sender, EventArgs e)
        {
            Instance = this;
        }
    }
}
