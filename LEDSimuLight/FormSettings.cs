using System;
using System.Linq;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void сохранитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countOfQuants, meshDensity;
            double wavelength;
            try
            {
                countOfQuants = Int32.Parse(cbCountOfQuants.Text) * 1000;
                wavelength = Double.Parse(tbWavelength.Text);
                meshDensity = Int32.Parse(cbMeshDensity.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных!\nНастройки не сохранены!");
                return;
            }

            LedLibrary.CountOfQuants = countOfQuants;
            LedLibrary.Wavelength = wavelength;
            LedLibrary.MeshDensityCoeff = meshDensity;

            MessageBox.Show("Настройки сохранены успешно!");
        }

        private void trbWavelength_Scroll(object sender, EventArgs e)
        {
            tbWavelength.Text = trbWavelength.Value.ToString();
        }

        private void tbMeshDensity_Scroll(object sender, EventArgs e)
        {
            cbMeshDensity.Text = tbMeshDensity.Value.ToString();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            tbCountOfQuants.Value = LedLibrary.CountOfQuants / 1000;
            cbCountOfQuants.Text = (LedLibrary.CountOfQuants/1000).ToString();

            trbWavelength.Value = (int) LedLibrary.Wavelength;
            tbWavelength.Text = LedLibrary.Wavelength.ToString();

            tbMeshDensity.Value = LedLibrary.MeshDensityCoeff;
            cbMeshDensity.Text = LedLibrary.MeshDensityCoeff.ToString();

            foreach (var next in LedLibrary.Materials)
            {
                cbChoseActive.Items.Add(next.Name);
            }
            cbChoseActive.Text = LedLibrary.ActiveMaterial;
        }

        private void tbCountOfQuants_Scroll(object sender, EventArgs e)
        {
            cbCountOfQuants.Text = tbCountOfQuants.Value.ToString();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbChoseActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            LedLibrary.ActiveMaterial = cbChoseActive.Text;
        }
    }
}
