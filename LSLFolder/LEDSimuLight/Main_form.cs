using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Glb;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace LEDSimuLight
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about win_about = new about();
            win_about.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            design win_design = new design();
            win_design.Show();
        }

        private void set_variables()
        {
            var.mas = new int[var.W + 1, var.H + 1];
            var.materials = new var.materials_array[100];
            var.circle_bright = new int[180 / var.div_of_light_circ];
            var.left_bright = new int[1 + var.H / (2 * var.side_sector)];
            var.right_bright = new int[1 + var.H / (2 * var.side_sector)];
            var.floor_bright = new int[1 + var.W / var.side_sector];
        }

        private void set_base()
        {
            // public materials_array(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
            var.materials[var.num_of_matr] = new var.materials_array("Undefined", "воздух", 1, 0, 0, 1.0, 1.0, 1.0); //  0
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Substrate", "Al2O3", 1.6, 0.01, 0, 0.6196, 0.8549, 0.9294); // 1 0,3
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "n-GaN", 2.5, 0.25, 0, 0.6588, 0.1765, 0.9490); // 2 0,1
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "InGaN", 2.5, 0.01, 0, 0.2902, 0.9490, 0.1765); // 3 0,01
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "i-GaN", 2.5, 0.1, 0, 0.7921, 0.7921, 1);  // 4 0,35
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Contact", "металлический контакт", 1, 1, 0, 0.7765, 0.7765, 0.0); // 5 1,0
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Sensors", "сенсор", 1, 1, 0, 1, 1, 1); // 6
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "GaN", 2.5, 0.2, 0, 0.9490, 0.6353, 0.9568); // 7 0,3
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "p-GaN", 2.5, 0.1, 0, 0.7490, 0.9765, 0.4078); // 8 0,1
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Mirror", "отражатель Брэгга", 1, 0.2, 0, 0.4235, 0.6353, 0.09); // 9 0,1
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "SiO2", 1.43, 0.01, 0, 0.1608, 0.0274, 0.6196); // 10 0,01
            var.num_of_matr++;
            var.materials[var.num_of_matr] = new var.materials_array("Thin film", "ITO", 1.9, 0.01, 0, 0.8745, 0.9843, 0.2667); // 11 0,01
            var.num_of_matr++;
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            set_variables();
            set_base(); // временно
            OpenGLm.InitGL();
           // var.open_bin_file("D:/Конструкция светодиода без рельефа.LED");
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings win_set = new settings();
            win_set.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            simulating sim_win = new simulating();
            sim_win.Show();
        }
    }
}

namespace Glb
{
    public static class var
    {
        public class point
        {
            public int x, y;
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void open_bin_file(String path)
        {
            BinaryReader dataIn;
            try
            {
                dataIn = new BinaryReader(new FileStream(path, FileMode.Open));
            }
            catch (IOException exc)
            {
                MessageBox.Show("Не удалось открыть файл..." + exc.Message, "Error");
                return;
            }

            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                {
                    var.mas[x, y] = dataIn.ReadInt32();
                }

            dataIn.Close();
        }

        public static void save_to_bin_file(String NameFile)
        {
            BinaryWriter dataOut;

            try // Запись в файл
            {
                dataOut = new BinaryWriter(new FileStream(NameFile, FileMode.Create));
            }
            catch (IOException exc)
            {
                MessageBox.Show("Не удалось записать в файл " + exc.Message, "Ошибка");
                return;
            }
            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                    dataOut.Write(var.mas[x, y]);
            dataOut.Close();
        }

        public class materials_array
        {
            public materials_array(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
            {
                this.type = type;
                this.name = name;
                this.fraction = fraction;
                this.absorption = absorption;
                this.reflection = reflection;
                this.r = r;
                this.g = g;
                this.b = b;
            }
            public String name, type;
            public double fraction, reflection, absorption, r, g, b;
        }
        
        public static bool onceInitGL = false;
        public static int[,] mas;
        public static int
            prec_koeff = 1,
            W = 500 * prec_koeff,
            H = 500 * prec_koeff,
            hMaxMicr = 10,
            wMaxMicr = 10,
            num_of_matr = 0,
            border = 50 * prec_koeff,
            picW = 600 * prec_koeff, picH = 600 * prec_koeff,
            frame_sensor = 12 * prec_koeff,
            sens_mat = 6,
            quants_out = 0,
            quant_absorbed = 0,
            quants_front = 0,
            quants_back = 0,
            quants_left = 0,
            quants_right = 0,
            div_of_light_circ = 1,
            bad_quants = 0,
            side_sector = (int) ( (var.W / var.wMaxMicr) * div_of_light_circ * Math.PI * (var.hMaxMicr / 2) / 180 );
        public static double quantum_eff = 0;

        public static materials_array[] materials;
        public static int[] circle_bright, left_bright, right_bright, floor_bright;
    }
    public static class OpenGLm
    {
        public static void InitGL()
        {
            if (!var.onceInitGL)
                var.onceInitGL = true;
            else
                return; // проверяем чтобы инициализация была один раз
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
        }

        public static void projectionInit()
        {
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, var.picW, 0.0, var.picH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, 600, 600);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }

        private static void create_frame()  // рисуем рамку
        {
            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.border, var.border);
            Gl.glVertex2d(var.border, var.picH - var.border);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.border, var.picH - var.border);
            Gl.glVertex2d(var.picH - var.border, var.picH - var.border);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.picH - var.border, var.picH - var.border);
            Gl.glVertex2d(var.picH - var.border, var.border);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.picH - var.border, var.border);
            Gl.glVertex2d(var.border, var.border);
            Gl.glEnd();
            Gl.glFlush();
        }

        public static void PrintText(int x, int y, string text)
        {
            // устанавливаем позицию вывода растровых символов 
            // в переданных координатах x и y
            Gl.glRasterPos2d(x, y);
            for (int i = 0; i < text.Length; i++)
            {
                // визуализируем символ c, с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15. 
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, text[i]);
            }
        }

        private static void create_mark(int maxW, int maxH)  // метки на осях
        {
            Gl.glColor3d(0, 0, 0);
            int koeff = var.prec_koeff,
                h = 5 * koeff;
            for (int i = 0; i <= 10; i++) // крупнык метки на осях
            {
                Gl.glBegin(Gl.GL_LINE_STRIP);   // нижняя ось Х
                Gl.glVertex2d(var.border + i * (var.W / 10), var.border - h);
                Gl.glVertex2d(var.border + i * (var.W / 10), var.border + h);
                Gl.glEnd();
                PrintText(var.border + i * (var.W / 10) - 5 * koeff, var.border - h - 15 * koeff, (i * maxW / 10.0).ToString() ); // подписи к меткам

                Gl.glBegin(Gl.GL_LINE_STRIP);   // верхняя ось Х
                Gl.glVertex2d(var.border + i * (var.W / 10), (var.picH - var.border) - h);
                Gl.glVertex2d(var.border + i * (var.W / 10), (var.picH - var.border) + h);
                Gl.glEnd();

                Gl.glBegin(Gl.GL_LINE_STRIP);   // правая ось Y
                Gl.glVertex2d((var.picH - var.border) - h, var.border + i * (var.H / 10));
                Gl.glVertex2d((var.picH - var.border) + h, var.border + i * (var.H / 10));
                Gl.glEnd();

                Gl.glBegin(Gl.GL_LINE_STRIP);   // левая ось Y
                Gl.glVertex2d(var.border - h, var.border + i * (var.H / 10));
                Gl.glVertex2d(var.border + h, var.border + i * (var.H / 10));
                Gl.glEnd();
                PrintText(var.border - h - 30 * koeff, var.border + i * (var.H / 10) - 5 * koeff, (i * maxH / 10.0).ToString() ); // подписи к меткам
            }

            int hl = 2 * koeff; // маленькие метки на осях
            for (int i = 0; i <= 20; i++)
            {
                Gl.glBegin(Gl.GL_LINE_STRIP);   // нижняя ось Х
                Gl.glVertex2d(var.border + i * (var.W / 20), var.border - hl);
                Gl.glVertex2d(var.border + i * (var.W / 20), var.border + hl);
                Gl.glEnd();

                Gl.glBegin(Gl.GL_LINE_STRIP);   // верхняя ось Х
                Gl.glVertex2d(var.border + i * (var.W / 20), (var.picH - var.border) - hl);
                Gl.glVertex2d(var.border + i * (var.W / 20), (var.picH - var.border) + hl);
                Gl.glEnd();

                Gl.glBegin(Gl.GL_LINE_STRIP);   // правая ось Y
                Gl.glVertex2d((var.picH - var.border) - hl, var.border + i * (var.H / 20));
                Gl.glVertex2d((var.picH - var.border) + hl, var.border + i * (var.H / 20));
                Gl.glEnd();

                Gl.glBegin(Gl.GL_LINE_STRIP);   // левая ось Y
                Gl.glVertex2d(var.border - hl, var.border + i * (var.H / 20));
                Gl.glVertex2d(var.border + hl, var.border + i * (var.H / 20));
                Gl.glEnd();
            }
            Gl.glFlush();
        }

        private static void putFive(int x, int y)
        {
            Gl.glVertex2i(x, y);
            Gl.glVertex2i(x - 1, y);
            Gl.glVertex2i(x, y - 1);
            Gl.glVertex2i(x + 1, y);
            Gl.glVertex2i(x, y + 1);
        }

        private static void create_points(int num_step)  // точки в области
        {
            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_POINTS); // старт режима рисования точек
            for (int i = 0; i <= num_step; i++)
            {
                for (int j = 0; j <= num_step; j++)
                {
                    Gl.glVertex2i(i * (var.W / num_step) + var.border, j * (var.H / num_step) + var.border);
                }
            }

            num_step = 20;

            for (int i = 0; i <= num_step; i++)
            {
                for (int j = 0; j <= num_step; j++)
                {
                    putFive(i * (var.W / num_step) + var.border, j * (var.H / num_step) + var.border);
                }
            }
            Gl.glEnd();
            Gl.glFlush();
        }

        public static void set_mesh(int w, int h)
        {
            create_frame();
            create_mark(w, h);
            create_points(100);
        }

        public static void lineDrawPic(int xl, int xr, int yd, int yu) // faster
        {
            int x, x1 = 0, col0;

            xl = Math.Max(0, xl);
            yd = Math.Max(0, yd);
            xr = Math.Min(var.W, xr);
            yu = Math.Min(var.H, yu);

            for (int y = yd; y <= yu; y++)
            {
                x = xl;
                while (x <= xr)
                {
                    x1 = x;
                    col0 = var.mas[x, y];
                    Gl.glColor3d(var.materials[col0].r, var.materials[col0].g, var.materials[col0].b);

                    while (x <= var.W && col0 == var.mas[x, y])
                        x++;

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex2d(x1 + var.border, y + var.border);
                    Gl.glVertex2d(x + var.border, y + var.border);
                    Gl.glEnd();
                }
            }
            Gl.glFlush();
        }

        public static void drawLine(int x0, int y0, int x, int y)
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(x0 + var.border, y0 + var.border);
            Gl.glVertex2d(x + var.border, y + var.border);
            Gl.glEnd();
            Gl.glFlush();
        }

        private static int sqr(int x)
        {
            return x * x;
        }

        private static void circle(int x0, int y0, double R, double col1, double col2, double col3)
        {
            Gl.glColor3d(col1, col2, col3);
            Gl.glBegin(Gl.GL_POINTS);
            for (int x = x0 - (int)R; x <= x0 + (int)R; x++)
            {
                int y1 = y0 - (int)(Math.Sqrt(R * R - sqr(x - x0))),
                    y2 = y0 + (int)(Math.Sqrt(R * R - sqr(x - x0)));
                Gl.glVertex2d(x, y1);
                Gl.glVertex2d(x, y2);
            }
            for (int y = y0 - (int)R; y <= y0 + (int)R; y++)
            {
                int x1 = x0 - (int)(Math.Sqrt(R * R - sqr(y - y0))),
                    x2 = x0 + (int)(Math.Sqrt(R * R - sqr(y - y0)));
                Gl.glVertex2d(x1, y);
                Gl.glVertex2d(x2, y);
            }
            Gl.glEnd();
        }

        private static void condition(int x, int y, double t)
        {
            double R = 0;

            while (R <= 3)
            {
                double own = (R / 3) * 2 * Math.PI;
                circle(x, y, R, 1, Math.Sin(t), Math.Sin(t - own));
                R = R + 1;
            }
            Gl.glFlush();
            Form.ActiveForm.Refresh();
        }

        public static void explosion(int x, int y)
        {
            double t = 0;
            while (t <= 3 * Math.PI)
            {
                condition(x, y, t);
                t = t + Math.PI / 4;
            }
        }

        public static void drawRainbow()
        {
            int koeff = var.prec_koeff,
                y0 = (var.picH / 2) + 50 * koeff,
                x_per = (var.picW - var.border / 2) - 12 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(x_per, y0 - 5 * koeff, "100%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(1.0, i / (50.0 * koeff), 0);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(var.picW - var.border, y0 + i);
                Gl.glVertex2d(var.picW - var.border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(x_per, y0 - 5 * koeff, "75%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d( (50 * koeff - i) / (50.0 * koeff), 1.0, 0);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(var.picW - var.border, y0 + i);
                Gl.glVertex2d(var.picW - var.border + 10*koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(x_per, y0 - 5 * koeff, "50%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(0, 1, i / (50.0 * koeff) );
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(var.picW - var.border, y0 + i);
                Gl.glVertex2d(var.picW - var.border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(x_per, y0 - 5 * koeff, "25%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(0, (50 * koeff - i) / (50.0 * koeff), 1);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(var.picW - var.border, y0 + i);
                Gl.glVertex2d(var.picW - var.border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(x_per, y0 - 5 * koeff, "0%");
            Gl.glFlush();
        }

        public static void draw_half_circle(int x0, int y0, int R)
        {
            int temp = 0,
                limit = (int)(R / Math.Sqrt(2));
            Gl.glBegin(Gl.GL_POINTS);
            for (int y = y0; y <= y0 + limit; y++)
            {
                temp = (int)Math.Sqrt(sqr(R) - sqr(y - y0));
                int x = x0 + temp;
                Gl.glVertex2i(x, y);
                x = x0 - temp;
                Gl.glVertex2i(x, y);
            }
            for (int x = x0 - limit; x <= x0 + limit; x++)
            {
                int y = y0 + (int)Math.Sqrt(sqr(R) - sqr(x - x0));
                Gl.glVertex2i(x, y);
            }
            Gl.glEnd();
        }

        public static void drawSensors()
        {
            int frame = var.frame_sensor;
            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.border + frame, var.border + frame);
            Gl.glVertex2d(var.picW - var.border - frame, var.border + frame);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.border + frame, var.border + frame);
            Gl.glVertex2d(var.border + frame, var.border + var.H / 2);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.border + frame, var.border + frame);
            Gl.glVertex2d(var.border + frame, var.border + var.H / 2);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(var.picW - var.border - frame, var.border + frame);
            Gl.glVertex2d(var.picW - var.border - frame, var.border + var.H / 2);
            Gl.glEnd();

            int x0 = var.picW / 2,
                y0 = var.picH / 2,
                R1 = var.H / 2 - frame,
                R2 = var.H / 2;
            x0 = x0 - var.prec_koeff; // поправка на погрешность

            draw_half_circle(x0, y0, R1);
            draw_half_circle(x0, y0, R2);

            Gl.glFlush();
        }

        public static void putPix(int x, int y)
        {
            Gl.glVertex2i(x + var.border, y + var.border);
        }

        private static int average_by_three(int[] massive, int min, int max, int num)
        {
            int res = 0;
            if (num == min)
                res = (massive[num] + massive[num + 1]) / 2;
            else
                if (num == max)
                    res = (massive[num] + massive[num - 1]) / 2;
                else
                    res = (massive[num] + massive[num - 1] + massive[num + 1]) / 3;

            return res;
        }

        public static void drawLightDistribution()
        {
            int x0 = var.W / 2,
                y0 = var.H / 2,
                dx = 0,
                dy = 0;
            int R1 = sqr(var.H / 2 - var.frame_sensor),
                R2 = sqr(var.H / 2);
            x0--;

            int center = 180 / (2 * var.div_of_light_circ); // этот блок кода - интерполяция для проблемных сенсоров
            var.circle_bright[center] = (var.circle_bright[center - 1] + var.circle_bright[center + 1]) / 2;
            var.circle_bright[0] = var.circle_bright[1];
            var.circle_bright[center*2 - 1] = var.circle_bright[center*2 - 2];

            int max = 0, min = 100000000, curr = 0;
            for (int i = 0; i < 180 / var.div_of_light_circ; i++)
            {
                curr = average_by_three(var.circle_bright, 0, -1 + (180 / var.div_of_light_circ), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= var.H / ( 2 * var.side_sector ); i++)
            {
                curr = average_by_three(var.left_bright, 0, var.H / (2 * var.side_sector), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= var.H / ( 2 * var.side_sector ); i++)
            {
                curr = average_by_three(var.right_bright, 0, var.H / (2 * var.side_sector), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= var.W / var.side_sector; i++)
            {
                curr = average_by_three(var.floor_bright, 0, var.W / var.side_sector, i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }

            double sigma = max - min;

            Gl.glBegin(Gl.GL_POINTS);
            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                {
                    dx = x - x0;
                    dy = y - y0;
                    int square = sqr(x - x0) + sqr(y - y0);
                    if (y > var.H / 2 && square >= R1 && square < R2)
                    {
                        int alpha = 0;
                        if (dx != 0)
                        {
                            alpha = (int)((180.0 / Math.PI) * Math.Atan( (double) (dy) / (double) (dx) ));
                            if (alpha < 0)
                                alpha = 180 + alpha;
                        }
                        else
                            alpha = 90;

                        int num = alpha / var.div_of_light_circ;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + average_by_three(var.circle_bright, 0, -1 + (180 / var.div_of_light_circ), num)) / sigma;
                     
                      //  koef = 4.0 * ( -min + var.circle_bright[num] ) / sigma;
                        col = koef - Math.Floor(koef);

                        if (koef >= 0 && koef < 1)
                            Gl.glColor3d(0, col, 1);
                        if (koef >= 1 && koef < 2)
                            Gl.glColor3d(0, 1, 1 - col);
                        if (koef >= 2 && koef < 3)
                            Gl.glColor3d(col, 1, 0);
                        if (koef >= 3 && koef <= 4)
                            if (koef == 4)
                                Gl.glColor3d(1, 0, 0);
                            else
                                Gl.glColor3d(1, 1 - col, 0);
                        putPix(x, y);
                    }
                    if (y <= var.H / 2 && y > 0 && x < var.frame_sensor - 1)
                    {
                        int num = y / var.side_sector;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * ( -min + average_by_three(var.left_bright, 0, var.H / (2 * var.side_sector), num) ) / sigma;
                       
                   //   koef = 4.0 * (var.left_bright[num] - min) / sigma;
                        col = koef - Math.Floor(koef);

                        if (koef >= 0 && koef < 1)
                            Gl.glColor3d(0, col, 1);
                        if (koef >= 1 && koef < 2)
                            Gl.glColor3d(0, 1, 1 - col);
                        if (koef >= 2 && koef < 3)
                            Gl.glColor3d(col, 1, 0);
                        if (koef >= 3 && koef <= 4)
                            if (koef == 4)
                                Gl.glColor3d(1, 0, 0);
                            else
                                Gl.glColor3d(1, 1 - col, 0);
                        putPix(x, y);
                    }
                    if (y <= var.H / 2 && y > 0 && x > var.W - var.frame_sensor - 1 && x < var.W - 1)
                    {
                        int num = y / var.side_sector;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + average_by_three(var.right_bright, 0, var.H / (2 * var.side_sector), num)) / sigma;
                
                        //   koef = 4.0 * (var.right_bright[num] - min) / sigma;
                        col = koef - Math.Floor(koef);

                        if (koef >= 0 && koef < 1)
                            Gl.glColor3d(0, col, 1);
                        if (koef >= 1 && koef < 2)
                            Gl.glColor3d(0, 1, 1 - col);
                        if (koef >= 2 && koef < 3)
                            Gl.glColor3d(col, 1, 0);
                        if (koef >= 3 && koef <= 4)
                            if (koef == 4)
                                Gl.glColor3d(1, 0, 0);
                            else
                                Gl.glColor3d(1, 1 - col, 0);
                        putPix(x, y);
                    }
                    if (y < var.frame_sensor && y > 0 && x < var.W - 1)
                    {
                        int num = x / var.side_sector;  // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + average_by_three(var.floor_bright, 0, var.W / var.side_sector, num) ) / sigma;
    
                    //  koef = 4.0 * (var.floor_bright[num] - min) / sigma,
                        col = koef - Math.Floor(koef);

                        if (koef >= 0 && koef < 1)
                            Gl.glColor3d(0, col, 1);
                        if (koef >= 1 && koef < 2)
                            Gl.glColor3d(0, 1, 1 - col);
                        if (koef >= 2 && koef < 3)
                            Gl.glColor3d(col, 1, 0);
                        if (koef >= 3 && koef <= 4)
                            if (koef == 4)
                                Gl.glColor3d(1, 0, 0);
                            else
                                Gl.glColor3d(1, 1 - col, 0);
                        putPix(x, y);
                    }
                }

            Gl.glEnd();
            Gl.glFlush();
        }

        public static bool inField(int x, int y)
        {
            return x >= 0 && x <= var.W && y >= 0 && y <= var.H;
        }

        public static void drawCross(int x, int y)
        {
            Gl.glColor3d(1, 0, 0);
            Gl.glBegin(Gl.GL_POINTS);

            for (int i = x - var.prec_koeff * 5; i <= x + var.prec_koeff * 5; i++)
            {
                if (inField(i, y)) putPix(i, y);
            }
            for (int i = y - var.prec_koeff * 5; i <= y + var.prec_koeff * 5; i++)
            {
                if (inField(x, i)) putPix(x, i);
            }

            Gl.glEnd();
            Gl.glFlush();
        }

        public static void drawSegment(int click, var.point[] masPoints)
        {
            for (int i = 1; i <= click; i++)
            {
                drawCross(masPoints[i].x, masPoints[i].y);
            }
            for (int i = 2; i <= click; i++)
                OpenGLm.drawLine(masPoints[i].x, masPoints[i].y, masPoints[i - 1].x, masPoints[i - 1].y);
        }
    }
}
