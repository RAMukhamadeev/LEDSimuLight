using System;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormAddMaterial : Form
    {
        public FormAddMaterial()
        {
            InitializeComponent();
        }

        private void FormAddMaterial_Load(object sender, EventArgs e)
        {

        }

        void SaveNewMaterial()
        {
            double reflection, absorbtion, fraction, r, g, b;

            if (tbAbsorbtion.Name == "")
            {
                MessageBox.Show("Не введено имя материала!");
                return;
            }

            try
            {
                reflection = Double.Parse(tbReflection.Text);
                absorbtion = Double.Parse(tbAbsorbtion.Text);
                fraction = Double.Parse(tbFraction.Text);
                r = Double.Parse(tbColorR.Text);
                g = Double.Parse(tbColorG.Text);
                b = Double.Parse(tbColorB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("проверьте правильность введенных данных {0}", ex.Message));
                return;
            }

            LedLibrary.Material curr = new LedLibrary.Material(cbType.Text, tbName.Text, fraction, absorbtion,
                reflection, r, g, b);
            LedLibrary.Materials.Add(curr);

            // обновляем таблицу
            if (FormDatabase.Instance != null)
                FormDatabase.Instance.LoadDatabase();

            // удаляем старые записи
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is ComboBox)
                    control.Text = "";
            }
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
           SaveNewMaterial();
        }
    }
}
