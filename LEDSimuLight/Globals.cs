using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace LEDSimuLight
{
    public static class Var
    {
        public class Point
        {
            public int X, Y;
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public static void OpenBinFile(String path)
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

            for (int x = 0; x <= W; x++)
                for (int y = 0; y <= H; y++)
                {
                    Mas[x, y] = dataIn.ReadInt32();
                }

            dataIn.Close();
        }

        public static void SaveToBinFile(String NameFile)
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
            for (int x = 0; x <= W; x++)
                for (int y = 0; y <= H; y++)
                    dataOut.Write(Mas[x, y]);
            dataOut.Close();
        }

        public class MaterialsArray
        {
            public MaterialsArray(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
            {
                Type = type;
                Name = name;
                Fraction = fraction;
                Absorption = absorption;
                Reflection = reflection;
                R = r;
                G = g;
                B = b;
            }
            public string Name, Type;
            public double Fraction, Reflection, Absorption, R, G, B;
        }

        public static bool OnceInitGl = false;
        public static int[,] Mas;
        public static int
            PrecKoeff = 1,
            W,
            H,
            HMaxMicr = 10,
            WMaxMicr = 10,
            NumOfMatr = 0,
            Border,
            PicW,
            PicH,
            FrameSensor = 12 * PrecKoeff,
            SensMat = 6,
            QuantsOut = 0,
            QuantAbsorbed = 0,
            QuantsFront = 0,
            QuantsBack = 0,
            QuantsLeft = 0,
            QuantsRight = 0,
            DivOfLightCirc = 1,
            BadQuants = 0,
            SideSector;
        public static double QuantumEff = 0;

        public static MaterialsArray[] Materials;
        public static int[] CircleBright, LeftBright, RightBright, FloorBright;
    }
    public static class OpenGLm
    {
        public static void InitGl()
        {
            if (!Var.OnceInitGl)
                Var.OnceInitGl = true;
            else
                return; // проверяем чтобы инициализация была один раз
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
        }

        public static void ProjectionInit()
        {
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, Var.PicW, 0.0, Var.PicH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, 600, 600);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }

        private static void CreateFrame(Graphics g)  // рисуем рамку
        {
            Pen currPen = new Pen(Color.Black, 2);

            g.DrawLine(currPen, Var.Border, Var.Border, Var.Border, Var.PicH - Var.Border);
            g.DrawLine(currPen, Var.Border, Var.PicH - Var.Border, Var.PicW - Var.Border, Var.PicH - Var.Border);
            g.DrawLine(currPen, Var.PicW - Var.Border, Var.PicH - Var.Border, Var.PicW - Var.Border, Var.Border);
            g.DrawLine(currPen, Var.PicW - Var.Border, Var.Border, Var.Border, Var.Border);

            g.Flush();
        }

        static void PrintText(int x, int y, string text, Graphics g = null)
        {
            g.DrawString(text, new Font("Arial", 9), Brushes.Black, new PointF(x, y));
            g.Flush();
        }

        private static void CreateMark(int maxW, int maxH, Graphics g)  // метки на осях
        {
            Pen currPen = new Pen(Color.Black, 2);

            int koeff = Var.PrecKoeff,
                h = 5*koeff,
                div = 10;
            for (int i = 0; i <= div; i++) // крупнык метки на осях
            {
                g.DrawLine(currPen, Var.Border + i * (Var.W / div), Var.Border - h, Var.Border + i * (Var.W / div), Var.Border + h);
                PrintText(Var.Border + i * (Var.W / div) - 5 * koeff, Var.Border - h - 15 * koeff, (i * maxW / (double) div).ToString(), g); // подписи к меткам

                g.DrawLine(currPen, Var.Border + i * (Var.W / div), (Var.PicH - Var.Border) - h, Var.Border + i * (Var.W / div), (Var.PicH - Var.Border) + h);
                g.DrawLine(currPen, (Var.PicH - Var.Border) - h, Var.Border + i * (Var.H / div), (Var.PicH - Var.Border) + h, Var.Border + i * (Var.H / div));

                g.DrawLine(currPen, Var.Border - h, Var.Border + i * (Var.H / div), Var.Border + h, Var.Border + i * (Var.H / div));
                PrintText(Var.Border - h - 30 * koeff, Var.Border + i * (Var.H / div) - 5 * koeff, (i * maxH / (double)div).ToString(), g); // подписи к меткам
            }

            //int hl = 2 * koeff; // маленькие метки на осях
            //for (int i = 0; i <= 20; i++)
            //{
            //    Gl.glBegin(Gl.GL_LINE_STRIP);   // нижняя ось Х
            //    Gl.glVertex2d(Var.Border + i * (Var.W / 20), Var.Border - hl);
            //    Gl.glVertex2d(Var.Border + i * (Var.W / 20), Var.Border + hl);
            //    Gl.glEnd();

            //    Gl.glBegin(Gl.GL_LINE_STRIP);   // верхняя ось Х
            //    Gl.glVertex2d(Var.Border + i * (Var.W / 20), (Var.PicH - Var.Border) - hl);
            //    Gl.glVertex2d(Var.Border + i * (Var.W / 20), (Var.PicH - Var.Border) + hl);
            //    Gl.glEnd();

            //    Gl.glBegin(Gl.GL_LINE_STRIP);   // правая ось Y
            //    Gl.glVertex2d((Var.PicH - Var.Border) - hl, Var.Border + i * (Var.H / 20));
            //    Gl.glVertex2d((Var.PicH - Var.Border) + hl, Var.Border + i * (Var.H / 20));
            //    Gl.glEnd();

            //    Gl.glBegin(Gl.GL_LINE_STRIP);   // левая ось Y
            //    Gl.glVertex2d(Var.Border - hl, Var.Border + i * (Var.H / 20));
            //    Gl.glVertex2d(Var.Border + hl, Var.Border + i * (Var.H / 20));
            //    Gl.glEnd();
            //}
            //Gl.glFlush();
        }

        private static void PutFive(int x, int y)
        {
            Gl.glVertex2i(x, y);
            Gl.glVertex2i(x - 1, y);
            Gl.glVertex2i(x, y - 1);
            Gl.glVertex2i(x + 1, y);
            Gl.glVertex2i(x, y + 1);
        }

        private static void CreatePoints(int numStep)  // точки в области
        {
            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_POINTS); // старт режима рисования точек
            for (int i = 0; i <= numStep; i++)
            {
                for (int j = 0; j <= numStep; j++)
                {
                    Gl.glVertex2i(i * (Var.W / numStep) + Var.Border, j * (Var.H / numStep) + Var.Border);
                }
            }

            numStep = 20;

            for (int i = 0; i <= numStep; i++)
            {
                for (int j = 0; j <= numStep; j++)
                {
                    PutFive(i * (Var.W / numStep) + Var.Border, j * (Var.H / numStep) + Var.Border);
                }
            }
            Gl.glEnd();
            Gl.glFlush();
        }

        public static void SetMesh(int w, int h, Graphics g = null)
        {
            CreateFrame(g);
            CreateMark(w, h, g);
            //CreatePoints(100);
        }

        /// <summary>
        /// Метод рисует на Bitmap содержимое файла линиями
        /// </summary>
        /// <param name="xl"></param>
        /// <param name="xr"></param>
        /// <param name="yd"></param>
        /// <param name="yu"></param>
        public static void LineDrawPic(int xl, int xr, int yd, int yu)
        {
            xl = Math.Max(0, xl);
            yd = Math.Max(0, yd);
            xr = Math.Min(Var.W, xr);
            yu = Math.Min(Var.H, yu);

            for (int y = yd; y <= yu; y++)
            {
                int x = xl;
                while (x <= xr)
                {
                    int x1 = x;
                    int col0 = Var.Mas[x, y];
                    Gl.glColor3d(Var.Materials[col0].R, Var.Materials[col0].G, Var.Materials[col0].B);

                    while (x <= Var.W && col0 == Var.Mas[x, y])
                        x++;

                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex2d(x1 + Var.Border, y + Var.Border);
                    Gl.glVertex2d(x + Var.Border, y + Var.Border);
                    Gl.glEnd();
                }
            }
            Gl.glFlush();
        }

        static void DrawLine(int x0, int y0, int x, int y)
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(x0 + Var.Border, y0 + Var.Border);
            Gl.glVertex2d(x + Var.Border, y + Var.Border);
            Gl.glEnd();
            Gl.glFlush();
        }

        private static int Sqr(int x)
        {
            return x * x;
        }

        private static void Circle(int x0, int y0, double r, double col1, double col2, double col3)
        {
            Gl.glColor3d(col1, col2, col3);
            Gl.glBegin(Gl.GL_POINTS);
            for (int x = x0 - (int)r; x <= x0 + (int)r; x++)
            {
                int y1 = y0 - (int)(Math.Sqrt(r * r - Sqr(x - x0))),
                    y2 = y0 + (int)(Math.Sqrt(r * r - Sqr(x - x0)));
                Gl.glVertex2d(x, y1);
                Gl.glVertex2d(x, y2);
            }
            for (int y = y0 - (int)r; y <= y0 + (int)r; y++)
            {
                int x1 = x0 - (int)(Math.Sqrt(r * r - Sqr(y - y0))),
                    x2 = x0 + (int)(Math.Sqrt(r * r - Sqr(y - y0)));
                Gl.glVertex2d(x1, y);
                Gl.glVertex2d(x2, y);
            }
            Gl.glEnd();
        }

        private static void Condition(int x, int y, double t)
        {
            double r = 0;

            while (r <= 3)
            {
                double own = (r / 3) * 2 * Math.PI;
                Circle(x, y, r, 1, Math.Sin(t), Math.Sin(t - own));
                r = r + 1;
            }
            Gl.glFlush();
            if (Form.ActiveForm != null)
                Form.ActiveForm.Refresh();
        }

        public static void Explosion(int x, int y)
        {
            double t = 0;
            while (t <= 3 * Math.PI)
            {
                Condition(x, y, t);
                t = t + Math.PI / 4;
            }
        }

        public static void DrawRainbow()
        {
            int koeff = Var.PrecKoeff,
                y0 = (Var.PicH / 2) + 50 * koeff,
                xPer = (Var.PicW - Var.Border / 2) - 12 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(xPer, y0 - 5 * koeff, "100%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(1.0, i / (50.0 * koeff), 0);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(Var.PicW - Var.Border, y0 + i);
                Gl.glVertex2d(Var.PicW - Var.Border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(xPer, y0 - 5 * koeff, "75%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d((50 * koeff - i) / (50.0 * koeff), 1.0, 0);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(Var.PicW - Var.Border, y0 + i);
                Gl.glVertex2d(Var.PicW - Var.Border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(xPer, y0 - 5 * koeff, "50%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(0, 1, i / (50.0 * koeff));
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(Var.PicW - Var.Border, y0 + i);
                Gl.glVertex2d(Var.PicW - Var.Border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(xPer, y0 - 5 * koeff, "25%");
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Gl.glColor3d(0, (50 * koeff - i) / (50.0 * koeff), 1);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex2d(Var.PicW - Var.Border, y0 + i);
                Gl.glVertex2d(Var.PicW - Var.Border + 10 * koeff, y0 + i);
                Gl.glEnd();
            }
            y0 += 50 * koeff;
            Gl.glColor3d(0, 0, 0);
            PrintText(xPer, y0 - 5 * koeff, "0%");
            Gl.glFlush();
        }

        static void DrawHalfCircle(int x0, int y0, int R)
        {
            int limit = (int)(R / Math.Sqrt(2));
            Gl.glBegin(Gl.GL_POINTS);
            for (int y = y0; y <= y0 + limit; y++)
            {
                int temp = (int)Math.Sqrt(Sqr(R) - Sqr(y - y0));
                int x = x0 + temp;
                Gl.glVertex2i(x, y);
                x = x0 - temp;
                Gl.glVertex2i(x, y);
            }
            for (int x = x0 - limit; x <= x0 + limit; x++)
            {
                int y = y0 + (int)Math.Sqrt(Sqr(R) - Sqr(x - x0));
                Gl.glVertex2i(x, y);
            }
            Gl.glEnd();
        }

        public static void DrawSensors()
        {
            int frame = Var.FrameSensor;
            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(Var.Border + frame, Var.Border + frame);
            Gl.glVertex2d(Var.PicW - Var.Border - frame, Var.Border + frame);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(Var.Border + frame, Var.Border + frame);
            Gl.glVertex2d(Var.Border + frame, Var.Border + Var.H / 2);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(Var.Border + frame, Var.Border + frame);
            Gl.glVertex2d(Var.Border + frame, Var.Border + Var.H / 2);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(Var.PicW - Var.Border - frame, Var.Border + frame);
            Gl.glVertex2d(Var.PicW - Var.Border - frame, Var.Border + Var.H / 2);
            Gl.glEnd();

            int x0 = Var.PicW / 2,
                y0 = Var.PicH / 2,
                r1 = Var.H / 2 - frame,
                r2 = Var.H / 2;
            x0 = x0 - Var.PrecKoeff; // поправка на погрешность

            DrawHalfCircle(x0, y0, r1);
            DrawHalfCircle(x0, y0, r2);

            Gl.glFlush();
        }

        static void PutPix(int x, int y)
        {
            Gl.glVertex2i(x + Var.Border, y + Var.Border);
        }

        private static int AverageByThree(int[] massive, int min, int max, int num)
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

        public static void DrawLightDistribution()
        {
            int x0 = Var.W / 2,
                y0 = Var.H / 2;
            int r1 = Sqr(Var.H / 2 - Var.FrameSensor),
                r2 = Sqr(Var.H / 2);
            x0--;

            int center = 180 / (2 * Var.DivOfLightCirc); // этот блок кода - интерполяция для проблемных сенсоров
            Var.CircleBright[center] = (Var.CircleBright[center - 1] + Var.CircleBright[center + 1]) / 2;
            Var.CircleBright[0] = Var.CircleBright[1];
            Var.CircleBright[center * 2 - 1] = Var.CircleBright[center * 2 - 2];

            int max = 0, min = 100000000, curr = 0;
            for (int i = 0; i < 180 / Var.DivOfLightCirc; i++)
            {
                curr = AverageByThree(Var.CircleBright, 0, -1 + (180 / Var.DivOfLightCirc), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= Var.H / (2 * Var.SideSector); i++)
            {
                curr = AverageByThree(Var.LeftBright, 0, Var.H / (2 * Var.SideSector), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= Var.H / (2 * Var.SideSector); i++)
            {
                curr = AverageByThree(Var.RightBright, 0, Var.H / (2 * Var.SideSector), i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            for (int i = 0; i <= Var.W / Var.SideSector; i++)
            {
                curr = AverageByThree(Var.FloorBright, 0, Var.W / Var.SideSector, i);
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }

            double sigma = max - min;

            Gl.glBegin(Gl.GL_POINTS);
            for (int x = 0; x <= Var.W; x++)
                for (int y = 0; y <= Var.H; y++)
                {
                    int dx = x - x0;
                    int dy = y - y0;
                    int square = Sqr(x - x0) + Sqr(y - y0);
                    if (y > Var.H / 2 && square >= r1 && square < r2)
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

                        int num = alpha / Var.DivOfLightCirc;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + AverageByThree(Var.CircleBright, 0, -1 + (180 / Var.DivOfLightCirc), num)) / sigma;

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
                        PutPix(x, y);
                    }
                    if (y <= Var.H / 2 && y > 0 && x < Var.FrameSensor - 1)
                    {
                        int num = y / Var.SideSector;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + AverageByThree(Var.LeftBright, 0, Var.H / (2 * Var.SideSector), num)) / sigma;

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
                        PutPix(x, y);
                    }
                    if (y <= Var.H / 2 && y > 0 && x > Var.W - Var.FrameSensor - 1 && x < Var.W - 1)
                    {
                        int num = y / Var.SideSector;   // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + AverageByThree(Var.RightBright, 0, Var.H / (2 * Var.SideSector), num)) / sigma;

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
                        PutPix(x, y);
                    }
                    if (y < Var.FrameSensor && y > 0 && x < Var.W - 1)
                    {
                        int num = x / Var.SideSector;  // вычисляем сектор
                        double koef = 0,
                               col = 0;

                        koef = 4.0 * (-min + AverageByThree(Var.FloorBright, 0, Var.W / Var.SideSector, num)) / sigma;

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
                        PutPix(x, y);
                    }
                }

            Gl.glEnd();
            Gl.glFlush();
        }

        static bool InField(int x, int y)
        {
            return x >= 0 && x <= Var.W && y >= 0 && y <= Var.H;
        }

        public static void DrawCross(int x, int y)
        {
            Gl.glColor3d(1, 0, 0);
            Gl.glBegin(Gl.GL_POINTS);

            for (int i = x - Var.PrecKoeff * 5; i <= x + Var.PrecKoeff * 5; i++)
            {
                if (InField(i, y)) PutPix(i, y);
            }
            for (int i = y - Var.PrecKoeff * 5; i <= y + Var.PrecKoeff * 5; i++)
            {
                if (InField(x, i)) PutPix(x, i);
            }

            Gl.glEnd();
            Gl.glFlush();
        }

        public static void DrawSegment(int click, Var.Point[] masPoints)
        {
            for (int i = 1; i <= click; i++)
            {
                DrawCross(masPoints[i].X, masPoints[i].Y);
            }
            for (int i = 2; i <= click; i++)
                DrawLine(masPoints[i].X, masPoints[i].Y, masPoints[i - 1].X, masPoints[i - 1].Y);
        }
    }
}

