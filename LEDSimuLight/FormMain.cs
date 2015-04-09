using System;
using System.IO;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace LEDSimuLight
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            this.KeyPreview = true;
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

        private void SetVariables()
        {
            Var.mas = new int[Var.W + 1, Var.H + 1];
            Var.Materials = new Var.MaterialsArray[100];
            Var.CircleBright = new int[180 / Var.DivOfLightCirc];
            Var.LeftBright = new int[1 + Var.H / (2 * Var.SideSector)];
            Var.RightBright = new int[1 + Var.H / (2 * Var.SideSector)];
            Var.FloorBright = new int[1 + Var.W / Var.SideSector];
        }

        private void SetBase()
        {
            // public materials_array(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Undefined", "воздух", 1, 0, 0, 1.0, 1.0, 1.0); //  0
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Substrate", "Al2O3", 1.6, 0.01, 0, 0.6196, 0.8549, 0.9294); // 1 0,3
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "n-GaN", 2.5, 0.25, 0, 0.6588, 0.1765, 0.9490); // 2 0,1
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "InGaN", 2.5, 0.01, 0, 0.2902, 0.9490, 0.1765); // 3 0,01
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "i-GaN", 2.5, 0.1, 0, 0.7921, 0.7921, 1);  // 4 0,35
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Contact", "металлический контакт", 1, 1, 0, 0.7765, 0.7765, 0.0); // 5 1,0
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Sensors", "сенсор", 1, 1, 0, 1, 1, 1); // 6
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "GaN", 2.5, 0.2, 0, 0.9490, 0.6353, 0.9568); // 7 0,3
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "p-GaN", 2.5, 0.1, 0, 0.7490, 0.9765, 0.4078); // 8 0,1
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Mirror", "отражатель Брэгга", 1, 0.2, 0, 0.4235, 0.6353, 0.09); // 9 0,1
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "SiO2", 1.43, 0.01, 0, 0.1608, 0.0274, 0.6196); // 10 0,01
            Var.NumOfMatr++;
            Var.Materials[Var.NumOfMatr] = new Var.MaterialsArray("Thin film", "ITO", 1.9, 0.01, 0, 0.8745, 0.9843, 0.2667); // 11 0,01
            Var.NumOfMatr++;
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            SetVariables();
            SetBase(); // временно
            OpenGLm.InitGl();
           // var.open_bin_file("D:/Конструкция светодиода без рельефа.LED");
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings win_set = new FormSettings();
            win_set.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSimulating sim_win = new FormSimulating();
            sim_win.Show();
        }
    }
}