using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace LEDSimuLight
{
    public partial class FormDatabase : Form
    {
        public static FormDatabase Instance { get; private set; }

        private readonly string[] _nameOfColumns =
        {
            "Название",
            "Тип",
            "Коэфф. преломления",
            "Коэфф. поглощения",
            "Коэфф. отражения",
            "R-comp",
            "G-comp",
            "B-comp"
        };

        public FormDatabase()
        {
            InitializeComponent();
        }

        void InitDgv()
        {
            dgvDatabase.ColumnCount = _nameOfColumns.Length;
            for (int i = 0; i < _nameOfColumns.Length; i++)
                dgvDatabase.Columns[i].Name = _nameOfColumns[i];

            dgvDatabase.Font = new Font("Microsoft Sans Serif", 10);
            dgvDatabase.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgvDatabase.BackgroundColor = SystemColors.Control;
            dgvDatabase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatabase.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDatabase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDatabase.BorderStyle = BorderStyle.None;
        }

        public void LoadDatabase()
        {
            dgvDatabase.Rows.Clear();
            foreach (LedLibrary.Material next in LedLibrary.Materials)
            {
                dgvDatabase.RowCount++;
                int pos = dgvDatabase.RowCount - 2;
                dgvDatabase.Rows[pos].Cells[0].Value = next.Name;
                dgvDatabase.Rows[pos].Cells[1].Value = next.Type;
                dgvDatabase.Rows[pos].Cells[2].Value = next.Fraction;
                dgvDatabase.Rows[pos].Cells[3].Value = next.Absorption;
                dgvDatabase.Rows[pos].Cells[4].Value = next.Reflection;
                dgvDatabase.Rows[pos].Cells[5].Value = next.R;
                dgvDatabase.Rows[pos].Cells[6].Value = next.G;
                dgvDatabase.Rows[pos].Cells[7].Value = next.B;
            }

            dgvDatabase.AutoResizeColumns();
        }

        private void FormDatabase_Load(object sender, EventArgs e)
        {
            Instance = this;

            InitDgv();
            LoadDatabase();
        }

        void SaveDatabase()
        {
             List<string> currentDb = new List<string>();

            for (int i = 0; i < dgvDatabase.RowCount - 1; i++)
            {
                currentDb.Add("@New material@");
                currentDb.Add("Type: " + dgvDatabase.Rows[i].Cells[1].Value);
                currentDb.Add("Name: " + dgvDatabase.Rows[i].Cells[0].Value);
                currentDb.Add("Fraction: " + dgvDatabase.Rows[i].Cells[2].Value);
                currentDb.Add("Absorbtion: " + dgvDatabase.Rows[i].Cells[3].Value);
                currentDb.Add("Reflection: " + dgvDatabase.Rows[i].Cells[4].Value);
                currentDb.Add("Color red: " + dgvDatabase.Rows[i].Cells[5].Value);
                currentDb.Add("Color green: " + dgvDatabase.Rows[i].Cells[6].Value);
                currentDb.Add("Color blue: " + dgvDatabase.Rows[i].Cells[7].Value);
                currentDb.Add("");
            }

            FileInfo fi = new FileInfo("LedMaterials.db");
            fi.Delete();
            File.WriteAllLines("LedMaterials.db", currentDb);
            LedLibrary.LoadMaterialsDb("LedMaterials.db");

            MessageBox.Show("База данных успешно обновлена!");
        }

        private void pbSaveDatabase_Click(object sender, EventArgs e)
        {
            SaveDatabase();
        }

        private void новыйМатериалToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMaterial formAddMaterial = new FormAddMaterial();
            formAddMaterial.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenDatabase()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LedLibrary.LoadMaterialsDb(ofd.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenDatabase();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDatabase();
        }

        private void pbOpenDatabase_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }

        private void pbAddMaterial_Click(object sender, EventArgs e)
        {
            FormAddMaterial formAddMaterial = new FormAddMaterial();
            formAddMaterial.Show();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
