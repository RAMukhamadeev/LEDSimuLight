using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAbout winAbout = new FormAbout();
            winAbout.Show();
        }

        private void btnSimulating_Click(object sender, EventArgs e)
        {
            FormSimulating simWin = new FormSimulating();
            simWin.Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings winSet = new FormSettings();
            winSet.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConstruct_Click(object sender, EventArgs e)
        {
            FormDesign winDesign = new FormDesign();
            winDesign.Show();
        }
    }
}