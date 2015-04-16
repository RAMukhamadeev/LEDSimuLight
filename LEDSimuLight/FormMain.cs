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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings winSet = new FormSettings();
            winSet.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbDesign_Click(object sender, EventArgs e)
        {
            FormDesign winDesign = new FormDesign();
            winDesign.Show();
        }

        private void pbSimulating_Click(object sender, EventArgs e)
        {
            FormSimulating simWin = new FormSimulating();
            simWin.Show();
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            FormSettings winSet = new FormSettings();
            winSet.Show();
        }

        private void pbStatistics_Click(object sender, EventArgs e)
        {

        }

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDesign winDesign = new FormDesign();
            winDesign.Show();
        }

        private void открытьТекущийПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSimulating simWin = new FormSimulating();
            simWin.Show();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LedLibrary.LoadMaterialsDb(ofd.FileName);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LedLibrary.LoadMaterialsDb("LedMaterials.db");
        }

        private void pbDatabase_Click(object sender, EventArgs e)
        {
            FormDatabase formDatabase = new FormDatabase();
            formDatabase.Show();
        }
    }
}