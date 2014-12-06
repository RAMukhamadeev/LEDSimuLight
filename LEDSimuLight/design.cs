using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Glb;
using System.IO;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace LEDSimuLight
{
    public partial class design : Form
    {
        private class line
        {
            public line(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public double a, b, c;
        }

        var.point currPoint = new var.point(0, 0);
        var.point[] masPoints = new var.point[100];
        line[] lines = new line[100];
        String material = "", shape = "";

        int click = 0, old_click = 0;

        public design()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void design_Load(object sender, EventArgs e)
        {
            OpenGLm.projectionInit();
            OpenGLm.lineDrawPic(0, var.W, 0, var.H);
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void draw_right_angle_rect(int y1, int y2, int x2, int x3, int col)
        {
            for (int i = y1; i <= y2; i++)
                for (int j = x2; j <= x3; j++)
                    var.mas[j, i] = col;
        }

        private int getX(double x)
        {
            int res = (int) ((x / var.wMaxMicr) * var.W);
            return res;
        }

        private int getY(double y)
        {
            int res = (int) ((y / var.hMaxMicr) * var.H);
            return res;
        }

        private line makeLine(double x0, double y0, double x1, double y1)
        {
            line res = new line(y1 - y0, x0 - x1, x0*(y0 - y1) + y0*(x1 - x0) );
            return res;
        }

        private bool pointIn(int x, int y, int click)
        {
            bool plus = false, minus = false;
            double sign;

            for (int i = 1; i <= click; i++)
            {
                sign = lines[i].a * x + lines[i].b * y + lines[i].c;
                if (sign < 0)
                    minus = true;
                if (sign > 0)
                    plus = true;
            }

            if ((plus && !minus) || (!plus && minus))
                return true;
            else
                return false;
        }

        private void removePolygon()
        {
            for (int i = 1; i < old_click; i++) // делаем массив линий
                lines[i] = makeLine(masPoints[i].x, masPoints[i].y, masPoints[i + 1].x, masPoints[i + 1].y);
            lines[old_click] = makeLine(masPoints[old_click].x, masPoints[old_click].y, masPoints[1].x, masPoints[1].y);

            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                    if (pointIn(x, y, old_click))
                        var.mas[x, y] = 0;

            OpenGLm.lineDrawPic(0, var.W, 0, var.H); // рисуем на экране
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();

            old_click = 0;
        }

        private void drawPolygon(int code)
        {
            try
            {
            //    x1 = getX( Convert.ToDouble(X1.Text) );
            //    x2 = getX( Convert.ToDouble(X2.Text) );
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно, пожалуйста, будьте внимательнее!", "Ошибочка вышла");
                return;
            }


            for (int i = 1; i < click; i++) // делаем массив линий
                lines[i] = makeLine(masPoints[i].x, masPoints[i].y, masPoints[i + 1].x, masPoints[i + 1].y);
            lines[click] = makeLine(masPoints[click].x, masPoints[click].y, masPoints[1].x, masPoints[1].y);

            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                    if (pointIn(x, y, click))
                        var.mas[x, y] = code;

            OpenGLm.lineDrawPic(0, var.W, 0, var.H); // рисуем на экране
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();

            old_click = click;
            click = 0;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Конструкция светодиода (*.LED)|*.LED";
            saveFileDialog1.FileName = "Конструкция светодиода";
            DialogResult drs = saveFileDialog1.ShowDialog();
            if (drs == DialogResult.OK)
                var.save_to_bin_file(saveFileDialog1.FileName);
        }

        private int getMouseX()
        {
            return  MousePosition.X - Form.ActiveForm.Location.X - 388;
        }
        private int getMouseY()
        {
            return 621 - MousePosition.Y + Form.ActiveForm.Location.Y;
        }

        private void makePolygon(int code)
        {
            click++;
            masPoints[click] = new var.point(currPoint.x, currPoint.y);
            X1.Text = toMicr(currPoint.x).ToString();
            Y1.Text = toMicr(currPoint.y).ToString();

            if (click >= 3 && masPoints[1].x == currPoint.x && masPoints[1].y == currPoint.y)
                drawPolygon(code);
        }

        private void removeCircle()
        {
            int quad_R = dist(masPoints[1], masPoints[2]),
                R = (int)Math.Sqrt(quad_R);

            var.point p = new var.point(0, 0);

            for (int x = masPoints[1].x - R; x <= masPoints[1].x + R; x++)
                for (int y = masPoints[1].y - R; y <= masPoints[1].y + R; y++)
                {
                    p.x = x; p.y = y;
                    if (dist(masPoints[1], p) <= quad_R)
                        var.mas[x, y] = 0;
                }


            OpenGLm.lineDrawPic(0, var.W, 0, var.H); // рисуем на экране
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();

            old_click = 0;
        }

        private void drawCircle(int code)
        {
            int quad_R = dist(masPoints[1], masPoints[2]),
                R = (int) Math.Sqrt(quad_R);

            var.point p = new var.point(0, 0);

            for (int x = Math.Max(masPoints[1].x - R, 0); x <= Math.Min(masPoints[1].x + R, var.W); x++)
                for (int y = Math.Max(masPoints[1].y - R, 0); y <= Math.Min(masPoints[1].y + R, var.H); y++)
                {
                    p.x = x; p.y = y;
                    if (dist(masPoints[1], p) <= quad_R)
                        var.mas[x, y] = code;
                }


            OpenGLm.lineDrawPic(0, var.W, 0, var.H); // рисуем на экране
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();
            old_click = click;
            click = 0;    
        }

        private void makeCircle(int code)
        {
            click++;
            masPoints[click] = new var.point(currPoint.x, currPoint.y);
            X1.Text = toMicr(currPoint.x).ToString();
            Y1.Text = toMicr(currPoint.y).ToString();

            if (click == 2)
            {
                drawCircle(code);
            }
        }

        private void AnT_Click(object sender, EventArgs e)
        {
            int code = 0;
            for (int i = 0; i < var.num_of_matr; i++)
                if (var.materials[i].name == material)
                    code = i;
            if (shape == "Многоугольник")
                makePolygon(code);
            if (shape == "Окружность")
                makeCircle(code);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Конструкция светодиода (*.LED)|*.LED";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "*.LED")
            {
                var.open_bin_file(openFileDialog1.FileName);
                OpenGLm.lineDrawPic(0, var.W, 0, var.H);
                OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
                AnT.Invalidate();
            }
        }

        private int sqr(int x)
        {
            return x * x;
        }

        private int dist(var.point p1, var.point p2)
        {
            return sqr(p2.x - p1.x) + sqr(p2.y - p1.y);
        }

        private double toMicr(int x)
        {
            return x / 50.0;
        }

        private void putCross(var.point p, int x1, int x2, int y1, int y2)
        {
            OpenGLm.lineDrawPic(nowX1 - 50 * var.prec_koeff, nowX1 + 50 * var.prec_koeff, nowY1 - 50 * var.prec_koeff, nowY1 + 50 * var.prec_koeff);
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            OpenGLm.drawSegment(click, masPoints);
            OpenGLm.drawCross(p.x, p.y);
            AnT.Invalidate();

            label6.Text = toMicr(p.x).ToString() + " мкм";
            label7.Text = toMicr(p.y).ToString() + " мкм";
            panel3.Refresh();
        }

        private void siToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "Si";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void al2O3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "Al2O3";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void gaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "GaN";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void inGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "InGaN";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void iGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "i-GaN";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void металлическийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "металлический контакт";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void отражательБрэггаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "отражатель Брэгга";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void pGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "p-GaN";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void nGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "n-GaN";

            label15.Text = material;
            panel_input.Refresh();
        }

        int nowX1 = 0, nowY1 = 0, count = 0;

        private void linkToVertex(int step)
        {
            var.point[] masPoint = new var.point[4];
            int x1 = (getMouseX() / step) * step,
                y1 = (getMouseY() / step) * step,
                x2 = x1 + step,
                y2 = y1 + step;
            var.point curr = new var.point(x1, y1);

            if (nowX1 != x1 || nowY1 != y1)
            {
                count = 0;
                nowX1 = x1;
                nowY1 = y1;
            }
            else
            {
                count++;
                if (count < 3)
                    return;
            }

            masPoint[0] = new var.point(x1, y1);
            masPoint[1] = new var.point(x1, y2);
            masPoint[2] = new var.point(x2, y2);
            masPoint[3] = new var.point(x2, y1);

            int min = 1000000, min_pos = -1;
            for (int i = 0; i < 4; i++)
            {
                int d = dist(curr, masPoint[i]);
                if (d < min)
                {
                    min = d;
                    min_pos = i;
                }
            }

            if (dist(masPoint[min_pos], curr) < dist(currPoint, curr))
            {
                putCross(masPoint[min_pos], x1 - 10*step, x2 + 10*step, y1 - 10*step, y2 + 10*step);
                currPoint = new var.point(masPoint[min_pos].x, masPoint[min_pos].y);
            }
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            int x = getMouseX(),
                y = getMouseY();

            if (x > 0 && x < var.W && y > 0 && y < var.H)
               linkToVertex(var.W / 100);
        }

        private void пустотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "Пустота";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void рельефToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = "Окружность";
            label11.Text = shape;
        }

        private void siO2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "SiO2";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void iTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            material = "ITO";

            label15.Text = material;
            panel_input.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void многоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = "Многоугольник";
            label11.Text = shape;
        }

        private void удалитьПоследнююФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (old_click == 2)
                removeCircle();
            if (old_click > 2)
                removePolygon();
        }

    }
}
