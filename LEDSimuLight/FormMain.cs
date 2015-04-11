using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            KeyPreview = true;
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout winAbout = new FormAbout();
            winAbout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDesign winDesign = new FormDesign();
            winDesign.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings winSet = new FormSettings();
            winSet.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSimulating simWin = new FormSimulating();
            simWin.Show();
        }
    }
}