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
    public partial class simulating : Form
    {
        point[] active = new point[var.W * var.H]; // здесь внимательно! может быть переполнение
        int num_act = 0, stack_size = 0, xs = 0, ys = 0, back_track = 1;
      //  int[] dx = {1, -1, 0, 0, 1, 1, -1, -1};
      //  int[] dy = {0,  0, 1,-1, 1,-1,  1, -1};
        report win_report;
        String[] messages = new String[1000];
        int n_mess = 0, step = 2;
        Random rnd = new Random();
        bool isLucky = false;

        public simulating()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            this.KeyPreview = true;
        }
        private class point
        {
            public int x, y;
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private int sqr(int x)
        {
            return x * x;
        }

        private void insert_sensor_material()
        {
            int temp = 0,
                koeff = var.prec_koeff,
                x0 = (var.W) / 2,
                y0 = (var.H) / 2,
                R = (var.picH / 2) - var.border - var.frame_sensor + 5,
                limit = (int) ( R / Math.Sqrt(2) ),
                sens = var.sens_mat;
            x0 = x0 - koeff;

            for (int y = y0; y <= y0 + limit; y++)
            {
                temp = (int) Math.Sqrt(sqr(R) - sqr(y - y0));
                int x = x0 + temp;
                var.mas[x, y] = sens;
                var.mas[x - 1, y] = sens;
                var.mas[x - 2, y] = sens;
                var.mas[x - 3, y] = sens;
                var.mas[x - 4, y] = sens;
                x = x0 - temp;
                var.mas[x, y] = sens;
                var.mas[x + 1, y] = sens;
                var.mas[x + 2, y] = sens;
                var.mas[x + 3, y] = sens;
                var.mas[x + 4, y] = sens;
            }
            for (int x = x0 - limit; x <= x0 + limit; x++)
            {
                int y = y0 + (int) Math.Sqrt(sqr(R) - sqr(x - x0));
                var.mas[x, y] = 6;
                var.mas[x, y - 1] = sens;
                var.mas[x, y - 2] = sens;
                var.mas[x, y - 3] = sens;
                var.mas[x, y - 4] = sens;
            }
            var.mas[x0, y0 + R - 5] = sens;

            for (int y = var.frame_sensor - 5; y <= var.H / 2; y++)
            {
                for (int x = var.frame_sensor - 5; x < var.frame_sensor; x++)
                    var.mas[x, y] = sens;
                for (int x = var.W - var.frame_sensor; x < var.W - var.frame_sensor + 5; x++)
                    var.mas[x, y] = sens;
            }
            for (int y = var.frame_sensor - 5; y < var.frame_sensor; y++)
                for (int x = var.frame_sensor - 5; x <= var.W - var.frame_sensor + 4; x++)
                    var.mas[x, y] = sens;

        }

        private void InitializeVar()
        {
            var.quant_absorbed = 0;
            var.quants_back = 0;
            var.quants_front = 0;
            var.quants_left = 0;
            var.quants_out = 0;
            var.quants_right = 0;
            var.quantum_eff = 0;
            var.bad_quants = 0;

            for (int i = 0; i < 180 / var.div_of_light_circ; i++)
                var.circle_bright[i] = 0;
            for (int i = 0; i < 1 + var.H / (2 * var.side_sector); i++)
            {
                var.left_bright[i] = 0;
                var.right_bright[i] = 0;
            }
            for (int i = 0; i < 1 + var.W / var.side_sector; i++)
                var.floor_bright[i] = 0;
        }

        private void simulating_Load(object sender, EventArgs e)
        {
            insert_sensor_material();
            OpenGLm.projectionInit();
            OpenGLm.lineDrawPic(0, var.W, 0, var.H);
            OpenGLm.drawSensors();
            OpenGLm.drawRainbow();
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();

            detecting_active_layer(4); // i - GaN в базе под номером 4
            InitializeVar();

            makeLegend();
            panel4.Refresh();
        }

        private void detecting_active_layer(int num) // в дальнейшем массив
        {
            for (int x = 0; x <= var.W; x++)
                for (int y = 0; y <= var.H; y++)
                    if (var.mas[x, y] == num)
                        active[num_act++] = new point(x, y);
        }

        private double sqr(double x)
        {
            return x * x;
        }

        private void addMaterial(int n, int code, double r, double g, double b)
        {
            switch (n)
            {
                case 1:
                    Col1.BackColor = Color.FromArgb( (int)(r * 255), (int) (g*255), (int) (b*255) );
                    elem1.Text = var.materials[code].name;
                    Col1.Visible = true;
                    elem1.Visible = true;
                    break;
                case 2:
                    Col2.BackColor = Color.FromArgb( (int)(r * 255), (int) (g*255), (int) (b*255) );
                    elem2.Text = var.materials[code].name;
                    Col2.Visible = true;
                    elem2.Visible = true;
                    break;
                case 3:
                    Col3.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem3.Text = var.materials[code].name;
                    Col3.Visible = true;
                    elem3.Visible = true;
                    break;
                case 4:
                    Col4.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem4.Text = var.materials[code].name;
                    Col4.Visible = true;
                    elem4.Visible = true;
                    break;
                case 5:
                    Col5.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem5.Text = var.materials[code].name;
                    Col5.Visible = true;
                    elem5.Visible = true;
                    break;
                case 6:
                    Col6.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem6.Text = var.materials[code].name;
                    Col6.Visible = true;
                    elem6.Visible = true;
                    break;
                case 7:
                    Col7.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem7.Text = var.materials[code].name;
                    Col7.Visible = true;
                    elem7.Visible = true;
                    break;
                case 8:
                    Col8.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem8.Text = var.materials[code].name;
                    Col8.Visible = true;
                    elem8.Visible = true;
                    break;
                case 9:
                    Col9.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem9.Text = var.materials[code].name;
                    Col9.Visible = true;
                    elem9.Visible = true;
                    break;
            }
        }

        private void makeLegend()
        {
            bool[] used = new bool[100];
            used[var.sens_mat] = true; // сенсоры на легенде не нужны

            int count = 0;
            for (int x = 0; x <= var.W; x++)
                for (int y = var.H; y >= 0; y--)
                {
                    int code = var.mas[x, y];
                    if (!used[code])
                    {
                        count++;
                        used[code] = true;
                        addMaterial(count, code, var.materials[code].r, var.materials[code].g, var.materials[code].b);
                    }
                }
        }

        private void pushMessage(String s)
        {
            messages[n_mess] = (n_mess + 1).ToString() + ") " + s + " \n\r";
            n_mess++;
        }

        private string toDegree(double cur_angle)
        {
            double cur_angle_gr = Math.Floor(((cur_angle * 180) / Math.PI) * 100) / 100;
            return cur_angle_gr.ToString();
        }

        private bool absorbed(int code, int x, int y)
        {
            if (isLucky)
                return false;

            bool res;
            double l1 = (double) ( var.wMaxMicr * (x - xs) ) / var.W,
                   l2 = (double) ( var.hMaxMicr * (y - ys) ) / var.H,
                   len = Math.Sqrt(sqr(l1) + sqr(l2)),
                   transmission = 1 - var.materials[code].absorption,
                   alive_prob = Math.Pow(transmission, len),
                   abs_prob = 1 - alive_prob;
            if (rnd.NextDouble() <= abs_prob)
                res = true;
            else 
                res = false;
            return res;
        }

        private double rough_angle(int x, int y, int oldCode, int newCode) // x - x0, y - y0
        {
            double res = 0;

            int xl = x - 4 * var.prec_koeff, xr = x + 4 * var.prec_koeff;
            double yl = 0, yr = 0;
            int code0l = var.mas[xl, y], code0r = var.mas[xr, y], delta;

            delta = 0;
            while (code0l == var.mas[xl, Math.Max(y - delta, 0)] && code0l == var.mas[xl, Math.Min(y + delta, var.H)] && delta < var.H)
               delta++;
            if (code0l != var.mas[xl, Math.Max(y - delta, 0)])
                 yl = y - delta + 0.5;
            if (code0l != var.mas[xl, Math.Min(y + delta, var.H)])
                 yl = y + delta - 0.5;

             delta = 0;
             while (code0r == var.mas[xr, Math.Max(y - delta, 0)] && code0r == var.mas[xr, Math.Min(y + delta, var.H)] && delta < var.H)
                 delta++;
             if (code0r != var.mas[xr, Math.Max(y - delta, 0)])
                 yr = y - delta + 0.5;
             if (code0r != var.mas[xr, Math.Min(y + delta, var.H)])
                 yr = y + delta - 0.5;

             res = Math.Atan((double)(yr - yl) / (xr - xl));
             if (res < 0)
                res = res + Math.PI;

            return res;
        }

        private double calculate_fraction(double alpha, double beta, double n, double n1)
        {
            double res = 0;
            if (beta == 0)
            {
                if (alpha > Math.PI)
                    res = 2 * Math.PI - Math.Acos(n * Math.Cos(alpha) / n1);
                else
                    res = Math.Acos(n * Math.Cos(alpha) / n1);
            }
            if (beta == Math.PI / 2)
            {
                if (alpha >= 0 && alpha < Math.PI / 2)
                    res = Math.Asin(n * Math.Sin(alpha) / n1);
                if (alpha >= Math.PI / 2 && alpha < 3 * Math.PI / 2)
                    res = Math.PI - Math.Asin(n * Math.Sin(alpha) / n1);
                if (alpha >= 3 * Math.PI / 2 && alpha <= 2 * Math.PI)
                    res = 2 * Math.PI + Math.Asin(n * Math.Sin(alpha) / n1);
            }

            if (beta > 0 && beta < Math.PI / 2)
            {
                if (alpha >= 0 && alpha < Math.PI)
                    if (alpha < beta)
                        res = 2 * Math.PI + beta - Math.Acos(n * Math.Cos(alpha - beta) / n1);
                    else
                        res = beta + Math.Acos(n * Math.Cos(alpha - beta) / n1);
                if (alpha >= Math.PI && alpha <= 2 * Math.PI)
                    res = beta - Math.Acos(n * Math.Cos(alpha - beta) / n1);
            }
            if (beta > Math.PI / 2 && beta < Math.PI)
            {
                if (alpha >= 0 && alpha < Math.PI)
                    if (alpha > beta)
                        res = beta + Math.Acos(n * Math.Cos(alpha - beta) / n1);
                    else
                        res = beta - Math.Acos(n * Math.Cos(alpha - beta) / n1);
                if (alpha >= Math.PI && alpha <= 2 * Math.PI)
                    res = beta + Math.Acos(n * Math.Cos(alpha - beta) / n1);
            }

            return res;
        }

        private bool isReflection(double alpha, double beta, double n, double n1, int code)
        {
            bool res = false;
            if (beta == 0)
                res = (Math.Abs(Math.Cos(alpha)) >= n1 / n);
            if (beta == Math.PI / 2)
                res = (Math.Abs(Math.Sin(alpha)) >= n1 / n);
            if ((beta > 0 && beta < Math.PI / 2) || (beta > Math.PI / 2 && beta < Math.PI))
                res = (Math.Abs(Math.Cos(alpha - beta)) >= n1 / n);

            if (code == 9) // Зеркало
                res = true;
            return res;
        }

        private double calculate_reflection(double alpha, double beta)
        {
            double res = 0;
            if (beta == 0)
                res = 2 * Math.PI - alpha;
            if (beta == Math.PI / 2)
            {
                if (alpha < Math.PI)
                    res = Math.PI - alpha;
                if (alpha >= Math.PI && alpha <= 2 * Math.PI)
                    res = 3 * Math.PI - alpha;
            }
            if ((beta > 0 && beta < Math.PI / 2) || (beta > Math.PI / 2 && beta < Math.PI))
            {
                res = 2 * beta - alpha;
                if (res < 0)
                    res = res + 2 * Math.PI;
            }
            return res;
        }

        private void calc_sector(int x, int y)
        {
            int x0 = var.W / 2,
                y0 = var.H / 2,
                dx = x - x0,
                dy = y - y0;

            if (y > y0)
            {
                int alpha = 0;
                if (dx != 0)
                {
                    alpha = (int)((180.0 / Math.PI) * Math.Atan((double)(dy) / (double)(dx)));
                    if (alpha < 0)
                        alpha = 180 + alpha;
                }
                else
                    alpha = 90;

                int num = alpha / var.div_of_light_circ; // вычисляем сектор
                var.circle_bright[num]++;
                var.quants_front++;
            }
            else
            {
                int num = 0;
                if (x == 11)
                {
                    num = y / var.side_sector;
                    var.left_bright[num]++;
                    var.quants_left++;
                }
                else
                    if (y == 11)
                    {
                        num = x / var.side_sector;
                        var.floor_bright[num]++;
                        var.quants_back++;
                    }
                    else
                        if (x == 488)
                        {
                            num = y / var.side_sector;
                            var.right_bright[num]++;
                            var.quants_right++;
                        }
            }
        }

        private void debug_reemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {
            if (absorbed(code0, x, y))
            {
                var.quant_absorbed++;
                pushMessage("Квант поглотился в материале " + var.materials[code0].name);
                return;
            }
            else
            {
                xs = x;
                ys = y;
            }

            int code = var.mas[x, y];
            double n1 = var.materials[code].fraction,
                   n = var.materials[code0].fraction;

            if (var.mas[x, y] == var.sens_mat)
            {
                pushMessage("Квант захвачен сенсором.");
                calc_sector(x, y);
                return;
            }

            double beta = rough_angle(x0, y0, code0, code);

            if (isReflection(angle, beta, n, n1, code))
            {
                double new_alpha = calculate_reflection(angle, beta);
                pushMessage("Квант претерпел отражение от " + var.materials[code].name + "; угол стал равен " + toDegree(new_alpha) + " градусов.");
                debug_rayTracing(new_alpha, x0, y0);
            }
            else
            {
                double new_alpha = calculate_fraction(angle, beta, n, n1);
                pushMessage("Квант достиг " + var.materials[code].name + " и претерпел преломление; угол стал равен " + toDegree(new_alpha) + " градусов.");
                debug_rayTracing(new_alpha, x, y);
            }
        }

        private void reemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {

            if ( absorbed(code0, x, y) )
            {
                var.quant_absorbed++;
          //      pushMessage("Квант поглотился в материале " + var.materials[code0].name);
                return;
            }
            else
            {
                xs = x; 
                ys = y;
            }
            if (var.mas[x, y] == var.sens_mat)
            {
                calc_sector(x, y);
         //     pushMessage("Квант захвачен сенсором.");
                var.quants_out++;
                return;
            }


            int code = var.mas[x, y];
            double n1 = var.materials[code].fraction,
                   n = var.materials[code0].fraction;

            double beta = rough_angle(x0, y0, code0, code);

            if (isReflection(angle, beta, n, n1, code))
            {
                double new_alpha = calculate_reflection(angle, beta);
           //     pushMessage("Квант претерпел отражение от " + var.materials[code].name + "; угол стал равен " + toDegree(new_alpha) + " градусов.");
                rayTracing(new_alpha, x0, y0);
            }
            else
            {
                double new_alpha = calculate_fraction(angle, beta, n, n1);
            //    pushMessage("Квант достиг " + var.materials[code].name + " и претерпел преломление; угол стал равен " + toDegree(new_alpha) + " градусов.");
                rayTracing(new_alpha, x, y);
            }
        }

        private void put_vertex(int x, int y, char status)
        {
            int ost = 0,
                mod = 7 * var.prec_koeff;
            if (status == 'l' || status == 'r')
            {
                ost = x % (mod * 2);
                if (ost < mod)
                    Gl.glColor3d(0, 0, 0);
                else
                    Gl.glColor3d(1, 1, 0);
            }
            if (status == 'd' || status == 'u')
            {
                ost = y % (mod * 2);
                if (ost < mod)
                    Gl.glColor3d(0, 0, 0);
                else
                    Gl.glColor3d(1, 1, 0);
            }

            Gl.glVertex2i(x + var.border, y + var.border);
        }

        private void debug_moving_right(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_x = x;
            double shift = y;
            Gl.glBegin(Gl.GL_POINTS);
            while (code0 == var.mas[x, y] || (x - old_x) < step)
            {
                put_vertex(x, y, 'r');
                x++;
                shift += delta;
                y = (int) shift;
            }
            Gl.glEnd();

            x0 = x - 1;
            y0 = (int)(shift - delta);

            if (y < var.H && y > 0 && x < var.W && code0 != var.mas[x, y])
                debug_reemit(code0, x, y, x0, y0, angle, 'r');
        }

        private void moving_right(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_x = x;
            double shift = y;
            while (code0 == var.mas[x, y] || (x - old_x) < step)
            {
                x++;
                shift += delta;
                y = (int) shift;
            }

            x0 = x - 1;
            y0 = (int) (shift - delta);
            reemit(code0, x, y, x0, y0, angle, 'r');
        }

        private void debug_moving_left(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_x = x;
            double shift = y;
            Gl.glBegin(Gl.GL_POINTS);
            while (code0 == var.mas[x, y] || (old_x - x) < step)
            {
                put_vertex(x, y, 'l');
                x--;
                shift += delta;
                y = (int) shift;
            }
            Gl.glEnd();

            x0 = x + 1;
            y0 = (int) (shift - delta);

            debug_reemit(code0, x, y, x0, y0, angle, 'l');
        }

        private void moving_left(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_x = x;
            double shift = y;
            while (code0 == var.mas[x, y] || (old_x - x) < step)
            {
                x--;
                shift += delta;
                y = (int)shift;
            }
            x0 = x + 1;
            y0 = (int) (shift - delta);
            reemit(code0, x, y, x0, y0, angle, 'l');
        }

        private void debug_moving_up(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0;
            double shift = x;
            Gl.glBegin(Gl.GL_POINTS);
            while (code0 == var.mas[x, y])
            {
                put_vertex(x, y, 'u');
                y++;
                shift += delta;
                x = (int) shift;
            }
            Gl.glEnd();

            y0 = y - 1;
            x0 = (int) (shift - delta);

            debug_reemit(code0, x, y, x0, y0, angle, 'u');
        }

        private void moving_up(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_y = y;
            double shift = x;
            while (code0 == var.mas[x, y] || (y - old_y) < step)
            {
                y++;
                shift += delta;
                x = (int)shift;
            }
            y0 = y - 1;
            x0 = (int)(shift - delta);
            reemit(code0, x, y, x0, y0, angle, 'u');
        }

        private void debug_moving_down(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_y = y;
            double shift = x;
            Gl.glBegin(Gl.GL_POINTS);
            while (code0 == var.mas[x, y] || (old_y - y) < step)
            {
                put_vertex(x, y, 'd');
                y--;
                shift += delta;
                x = (int) shift;
            }
            Gl.glEnd();

            y0 = y + 1;
            x0 = (int) (shift - delta);
            debug_reemit(code0, x, y, x0, y0, angle, 'd');
        }

        private void moving_down(int x, int y, double delta, double angle)
        {
            int code0 = var.mas[x, y], x0, y0, old_y = y;
            double shift = x;
            while (code0 == var.mas[x, y] || (old_y - y) < step)
            {
                y--;
                shift += delta;
                x = (int) shift;
            }
            y0 = y + (back_track);
            x0 = (int)(shift - (back_track) * delta);
            reemit(code0, x, y, x0, y0, angle, 'd');
        }

        private void debug_rayTracing(double cur_angle, int x, int y)
        {
            if (stack_size >= 50)
            {
                pushMessage("Квант поглотился в материале " + var.materials[var.mas[x, y]].name);
                return;
            }
            else
                stack_size++; 

            while (cur_angle >= 2 * Math.PI)  // на всякий случай покрутим угол
                cur_angle = cur_angle - 2 * Math.PI;
            while (cur_angle < 0)
                cur_angle = cur_angle + 2 * Math.PI;

            if ((cur_angle <= Math.PI / 4) || (cur_angle >= 7 * Math.PI / 4)) // летим вправо
                debug_moving_right(x, y, Math.Tan(cur_angle), cur_angle);
            else
                if ((cur_angle >= 3 * Math.PI / 4) && (cur_angle <= 5 * Math.PI / 4)) // летим влево
                    debug_moving_left(x, y, -Math.Tan(cur_angle), cur_angle);
                else
                    if ((cur_angle > Math.PI / 4) && (cur_angle < 3 * Math.PI / 4)) // летим вверх
                        debug_moving_up(x, y, 1.0 / Math.Tan(cur_angle), cur_angle);
                    else
                        if ((cur_angle > 5 * Math.PI / 4) && (cur_angle < 7 * Math.PI / 4)) // летим вниз
                            debug_moving_down(x, y, -1.0 / Math.Tan(cur_angle), cur_angle);
        }

        private void toFile()
        {
            FileStream fout;
            try
            {
                fout = new FileStream("test.txt", FileMode.Append);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "Неудается открыть файл");
                return;
            }
            StreamWriter st_out = new StreamWriter(fout);

            for (int i = 0; i < n_mess; i++)
            {
                st_out.WriteLine(messages[i]);
            }
            st_out.WriteLine();
            st_out.WriteLine();
            st_out.WriteLine();
            st_out.Close();
            fout.Close();
        }

        private void rayTracing(double cur_angle, int x, int y)
        {
            if (stack_size >= 100)
            {
                var.bad_quants++;
          //      Gl.glVertex2i(x + var.border, y + var.border);
          //      Gl.glVertex2i(x + var.border - 1, y + var.border);
        //        Gl.glVertex2i(x + var.border + 1, y + var.border);
         //       Gl.glVertex2i(x + var.border, y + var.border + 1);
         //       Gl.glVertex2i(x + var.border, y + var.border - 1);
               // toFile();
                releaseQuant();

                return;
            }
            else
                stack_size++; 

            while (cur_angle >= 2 * Math.PI)  // на всякий случай покрутим угол
                cur_angle = cur_angle - 2 * Math.PI;
            while (cur_angle < 0)
                cur_angle = cur_angle + 2 * Math.PI;

            if ((cur_angle <= Math.PI / 4) || (cur_angle >= 7 * Math.PI / 4)) // летим вправо
            {
                moving_right(x, y, Math.Tan(cur_angle), cur_angle);
                return;
            }
            else
                if ((cur_angle >= 3 * Math.PI / 4) && (cur_angle <= 5 * Math.PI / 4)) // летим влево
                {
                    moving_left(x, y, -Math.Tan(cur_angle), cur_angle);
                    return;
                }
                else
                    if ((cur_angle > Math.PI / 4) && (cur_angle < 3 * Math.PI / 4)) // летим вверх
                    {
                        moving_up(x, y, 1.0 / Math.Tan(cur_angle), cur_angle);
                        return;
                    }
                    else
                        if ((cur_angle > 5 * Math.PI / 4) && (cur_angle < 7 * Math.PI / 4)) // летим вниз
                        {
                            moving_down(x, y, -1.0 / Math.Tan(cur_angle), cur_angle);
                            return;
                        }
        }

        private void debug_emitting_quants(int count)
        {
            OpenGLm.lineDrawPic(0, var.W, 0, var.H);
            OpenGLm.drawSensors();
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr); 

            double cur_angle;
            n_mess = 0;

            for (int i = 1; i <= count; i++)
            {
                int r = rnd.Next(num_act);
                int x = active[r].x, y = active[r].y, code = var.mas[x, y];
                xs = x; ys = y;
                OpenGLm.explosion(var.border + x, var.border + y); // эффект

                cur_angle = 2 * Math.PI * rnd.NextDouble();
                pushMessage("Квант возник в точке с координатой X = " + ( (double) (x) / (var.W / var.wMaxMicr) ).ToString() + " мкм; Y = " + ( (double) (y) / (var.H / var.hMaxMicr) ).ToString() + " мкм в " + var.materials[code].name + ".");
                pushMessage("Начальный угол равен = " + toDegree(cur_angle) + " градусов.");
                
                stack_size = 0;
                debug_rayTracing(cur_angle, x, y);
                label4.Text = i.ToString();
                panel2.Refresh();
            }
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void releaseQuant()
        {
            int r = rnd.Next(num_act);
            int x = active[r].x, y = active[r].y, code = var.mas[x, y];
            double cur_angle = 2 * Math.PI * rnd.NextDouble();
            xs = x; ys = y;
            n_mess = 0;

            pushMessage("Квант возник в точке с координатой X = " + ((double)(x) / (var.W / var.wMaxMicr)).ToString() + " мкм; Y = " + ((double)(y) / (var.H / var.hMaxMicr)).ToString() + " мкм в " + var.materials[code].name + ".");
            pushMessage("Начальный угол равен = " + toDegree(cur_angle) + " градусов.");

            stack_size = 0;
            rayTracing(cur_angle, x, y);
        } 

        private void emitting_quants(int count)
        {
            double eff_show = 0;
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3d(0, 0, 0);

            for (int i = 1; i <= count; i++)
            {
                releaseQuant();
              
                if (i % 1000 == 0)
                {
                    var.quantum_eff = (double) (var.quants_out) / i;
                    eff_show = Math.Floor(var.quantum_eff * 1000000) / 1000000;
                    label4.Text = i.ToString(); // выпущено квантов в данный момент
                    label12.Text = var.quants_out.ToString();
                    label13.Text = var.quants_front.ToString();
                    label16.Text = var.quant_absorbed.ToString();
                    label15.Text = eff_show.ToString();
                    label18.Text = var.quants_back.ToString();
                    label20.Text = var.quants_left.ToString();
                    label22.Text = var.quants_right.ToString();
                    panel2.Refresh();

                    Application.DoEvents();
                }
            }
     //       Gl.glEnd();
    //        Gl.glFlush();
    //        AnT.Invalidate();
   //         Form.ActiveForm.Refresh();
        }

        private void трассировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debug_emitting_quants(1);
        }

        private void начатьМоделированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emitting_quants(300000);
            MessageBox.Show(var.bad_quants.ToString());
        }

        private void simulating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space)
                debug_emitting_quants(1);
        }

        private void показатьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win_report = new report();
            for (int i = 0; i < n_mess; i++)
                win_report.toMessBox(messages[i]);
            win_report.Show();
        }

        private void показатьРаспределениеСветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGLm.drawLightDistribution();
            AnT.Invalidate();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X - Form.ActiveForm.Location.X - 390,
                y = 622 - MousePosition.Y + Form.ActiveForm.Location.Y;
            label8.Text = x.ToString();         // X
            label9.Text = y.ToString();         // Y
        }

        private void одиночныйКвантToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win_report = new report();

            OpenGLm.lineDrawPic(0, var.W, 0, var.H);
            OpenGLm.drawSensors();
            OpenGLm.set_mesh(var.wMaxMicr, var.hMaxMicr);
            AnT.Invalidate();
            double cur_angle;
            int code;
            n_mess = 0;
            isLucky = true;

            cur_angle = Math.PI * 200  / 180;
            int x = (int)(50 * 5), y = (int)(50 * 6);

            xs = x; ys = y;
            code = var.mas[x, y];
            pushMessage("Квант возник в точке с координатой X = " + ((double)(x) / (var.W / var.wMaxMicr)).ToString() + " мкм; Y = " + ((double)(y) / (var.H / var.hMaxMicr)).ToString() + " мкм в " + var.materials[code].name + ".");
            pushMessage("Начальный угол равен = " + toDegree(cur_angle) + " градусов.");
            stack_size = 0;
            OpenGLm.explosion(var.border + x, var.border + y); // эффект
            debug_rayTracing(cur_angle, x, y);

            AnT.Invalidate();
        }

    }
}
