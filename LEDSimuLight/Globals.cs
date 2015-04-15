using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public static class Var
    {
        public static int
          PrecKoeff = 1,
          BigStep,
          LittleStep,
          W,
          H,
          HMaxMicr = 10,
          WMaxMicr = 10,
          NumOfMatr,
          Border,
          RealW,
          RealH,
          FrameSensor = 0,
          SensMat = 6,
          QuantsOut = 0,
          QuantAbsorbed = 0,
          QuantsFront = 0,
          QuantsBack = 0,
          QuantsLeft = 0,
          QuantsRight = 0,
          DiscreteAngle = 1,
          BadQuants = 0,
          SideSector;
        public static double QuantumEff = 0;
        public static int[,] Mas;
        public static MaterialsArray[] Materials;
        public static int[] CircleBright, LeftBright, RightBright, FloorBright;

        public class Point
        {
            public int X, Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
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

        public static void InitVariables(int w, int h)
        {
            RealH = h;
            RealW = w;
            Border = h / 15;
            FrameSensor = 20;
            BigStep = 100;
            LittleStep = 50;
            H = RealH - Border * 2;
            W = RealW - Border * 2;
            SideSector = (int)(((Math.PI * H / 2) / 180) * DiscreteAngle);
            Mas = new int[RealW + 1, RealH + 1];
            CircleBright = new int[1 + 180 / DiscreteAngle];
            LeftBright = new int[1 + (RealH / 2) / SideSector];
            RightBright = new int[1 + (RealH / 2) / SideSector];
            FloorBright = new int[1 + RealW / SideSector];

            SetMaterialDb(); // временно
        }

        static void SetMaterialDb()
        {
            Materials = new MaterialsArray[100];
            NumOfMatr = 0;
            // public materials_array(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
            Materials[NumOfMatr] = new MaterialsArray("Undefined", "воздух", 1, 0, 0, 0.92, 0.92, 0.92); //  0
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Substrate", "Al2O3", 1.6, 0.01, 0, 0.6196, 0.8549, 0.9294); // 1 0,3
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "n-GaN", 2.5, 0.25, 0, 0.6588, 0.1765, 0.9490); // 2 0,1
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "InGaN", 2.5, 0.01, 0, 0.2902, 0.9490, 0.1765); // 3 0,01
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "i-GaN", 2.5, 0.1, 0, 0.7921, 0.7921, 1);  // 4 0,35
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Contact", "металлический контакт", 1, 1, 0, 0.7765, 0.7765, 0.0); // 5 1,0
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Sensors", "сенсор", 1, 1, 0, 0, 0, 1); // 6
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "GaN", 2.5, 0.2, 0, 0.9490, 0.6353, 0.9568); // 7 0,3
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "p-GaN", 2.5, 0.1, 0, 0.7490, 0.9765, 0.4078); // 8 0,1
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Mirror", "отражатель Брэгга", 1, 0.2, 0, 0.4235, 0.6353, 0.09); // 9 0,1
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "SiO2", 1.43, 0.01, 0, 0.1608, 0.0274, 0.6196); // 10 0,01
            NumOfMatr++;
            Materials[NumOfMatr] = new MaterialsArray("Thin film", "ITO", 1.9, 0.01, 0, 0.8745, 0.9843, 0.2667); // 11 0,01
            NumOfMatr++;
        }
    }

    public static class OpenGLm
    {
        private static readonly Pen BlackPen = new Pen(Color.Black, 1);

        /// <summary>
        /// Рисует рамку
        /// </summary>
        /// <param name="g"></param>
        private static void CreateFrame(Graphics g)
        {
            DrawLine(g, Var.Border, Var.Border, Var.Border, Var.RealH - Var.Border);
            DrawLine(g, Var.Border, Var.RealH - Var.Border, Var.RealW - Var.Border, Var.RealH - Var.Border);
            DrawLine(g, Var.RealW - Var.Border, Var.RealH - Var.Border, Var.RealW - Var.Border, Var.Border);
            DrawLine(g, Var.RealW - Var.Border, Var.Border, Var.Border, Var.Border);
        }

        public static void PrintText(Graphics g, int x, int y, string text, int size = 9)
        {
            g.DrawString(text, new Font("Arial", size), Brushes.Black, new PointF(x, Var.RealH - y));

        }

        public static void DrawLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(BlackPen, x1, Var.RealH - y1, x2, Var.RealH - y2);
        }

        public static void DrawLine(Graphics g, int x1, int y1, int x2, int y2, Color col)
        {
            g.DrawLine(new Pen(col, 1), x1, Var.RealH - y1, x2, Var.RealH - y2);
        }

        public static void DrawPoint(Graphics g, int x, int y)
        {
            g.DrawLine(BlackPen, x, Var.RealH - y, x, Var.RealH - y + 1);
        }

        public static void DrawPoint(Graphics g, int x, int y, Color col)
        {
            g.DrawLine(new Pen(col, 1), x, Var.RealH - y, x, Var.RealH - y + 1);
            g.DrawLine(new Pen(col, 1), x - 1, Var.RealH - y, x - 1, Var.RealH - y + 1);
        }

        public static void DrawCross(Graphics g, int x, int y, int l, int w)
        {
            Pen currPen = new Pen(Color.Black, w);
            g.DrawLine(currPen, x - l, Var.RealH - y, x + l, Var.RealH - y);
            g.DrawLine(currPen, x, (Var.RealH - y) - l, x, (Var.RealH - y) + l);
        }

        private static void CreateMark(Graphics g)  // метки на осях
        {
            // вспомогательный коэффициент для отступов
            int microOffset = Var.H / 100;

            // крупные горизонтальные метки
            int currLevelX = Var.Border;
            int dimensionX = 0;
            while (currLevelX <= Var.Border + Var.W)
            {
                DrawLine(g, currLevelX, Var.Border - microOffset, currLevelX, Var.Border + microOffset);
                DrawLine(g, currLevelX, Var.Border + Var.H - microOffset, currLevelX, Var.Border + Var.H + microOffset);

                string mark = (dimensionX++).ToString();
                PrintText(g, currLevelX - microOffset, Var.Border - 2*microOffset, mark);

                currLevelX += Var.BigStep;
            }

            // крупные вертикальные метки
            int currLevelY = Var.Border;
            int dimensionY = 0;
            while (currLevelY <= Var.Border + Var.H)
            {
                DrawLine(g, Var.Border - microOffset, currLevelY, Var.Border + microOffset, currLevelY);
                DrawLine(g, Var.Border + Var.W - microOffset, currLevelY, Var.Border + Var.W + microOffset, currLevelY);

                string mark = (dimensionY++).ToString();
                PrintText(g, Var.Border - (int)(4.5 * microOffset), currLevelY + (int)(1.5 * microOffset), mark);

                currLevelY += Var.BigStep;
            }

            // новый отступ
            int microOffset2 = Var.H / 200;

            // маленькие горизонтальные метки
            currLevelX = Var.Border;
            while (currLevelX <= Var.Border + Var.W)
            {
                DrawLine(g, currLevelX, Var.Border - microOffset2, currLevelX, Var.Border + microOffset2);
                DrawLine(g, currLevelX, Var.Border + Var.H - microOffset2, currLevelX, Var.Border + Var.H + microOffset2);
                currLevelX += Var.LittleStep;
            }

            // маленькие вертикальные метки
            currLevelY = Var.Border;
            while (currLevelY <= Var.Border + Var.H)
            {
                DrawLine(g, Var.Border - microOffset2, currLevelY, Var.Border + microOffset2, currLevelY);
                DrawLine(g, Var.Border + Var.W - microOffset2, currLevelY, Var.Border + Var.W + microOffset2, currLevelY);
                currLevelY += Var.LittleStep;
            }
        }

        private static void CreatePoints(Graphics g)  // точки в области
        {
            int numStepY = Var.H / Var.BigStep;
            int numStepX = Var.W / Var.BigStep;
            for (int i = 0; i <= numStepX; i++)
                for (int j = 0; j <= numStepY; j++)
                    DrawCross(g, + Var.Border + i * Var.BigStep, Var.Border + j * Var.BigStep, 4, 1);

            int newStep = Var.BigStep / 4;
            numStepY = Var.H / newStep;
            numStepX = Var.W / newStep;
            for (int i = 0; i <= numStepX; i++)
                for (int j = 0; j <= numStepY; j++)
                    DrawCross(g, Var.Border + i * newStep, Var.Border + j * newStep, 1, 1);
        }

        public static void SetMesh(Graphics g)
        {
            CreateFrame(g);
            CreateMark(g);
            CreatePoints(g);
        }

        /// <summary>
        /// Метод рисует на Bitmap содержимое файла линиями
        /// </summary>
        /// <param name="g"></param>
        /// <param name="xl"></param>
        /// <param name="xr"></param>
        /// <param name="yd"></param>
        /// <param name="yu"></param>
        public static void LineDrawPic(Graphics g, int xl, int xr, int yd, int yu)
        {
            xl = Math.Max(0, xl);
            yd = Math.Max(0, yd);
            xr = Math.Min(Var.RealW, xr);
            yu = Math.Min(Var.RealH, yu);

            for (int y = yd; y <= yu; y++)
            {
                int x = xl;
                while (x <= xr)
                {
                    int x1 = x;
                    int col0 = Var.Mas[x, y];

                    while (x <= Var.RealW && col0 == Var.Mas[x, y])
                        x++;
                    DrawLine(g, x1, y, x, y, Color.FromArgb( (int)(Var.Materials[col0].R*255), (int)(Var.Materials[col0].G*255), (int)(Var.Materials[col0].B*255)));
                }
            }
        }

        private static int Sqr(int x)
        {
            return x * x;
        }

        private static void Circle(Graphics g, int x0, int y0, double r, double col1, double col2, double col3)
        {
            for (int x = x0 - (int)r; x <= x0 + (int)r; x++)
            {
                int y1 = y0 - (int)(Math.Sqrt(r * r - Sqr(x - x0))),
                    y2 = y0 + (int)(Math.Sqrt(r * r - Sqr(x - x0)));
                DrawPoint(g, x, y1);
                DrawPoint(g, x, y2);
            }
            for (int y = y0 - (int)r; y <= y0 + (int)r; y++)
            {
                int x1 = x0 - (int)(Math.Sqrt(r * r - Sqr(y - y0))),
                    x2 = x0 + (int)(Math.Sqrt(r * r - Sqr(y - y0)));
                DrawPoint(g, x1, y);
                DrawPoint(g, x2, y);
            }
        }

        private static void Condition(Graphics g, int x, int y, double t)
        {
            double r = 0;

            while (r <= 3)
            {
                double own = (r / 3) * 2 * Math.PI;
                Circle(g, x, y, r, 1, Math.Sin(t), Math.Sin(t - own));
                r = r + 1;
            }
            if (Form.ActiveForm != null)
                Form.ActiveForm.Refresh();
        }

        public static void Explosion(Graphics g, int x, int y)
        {
            double t = 0;
            while (t <= 3 * Math.PI)
            {
                Condition(g, x, y, t);
                t = t + Math.PI / 4;
            }
        }

        public static void DrawRainbow(Graphics g)
        {
            int koeff = 2,
                y0 = (Var.RealH / 2),
                textOffsetY = 5 * koeff,
                textSize = 5,
                xPer = (Var.RealW - Var.Border / 2) - 15*koeff;
            //PrintText(xPer, y0 + textOffsetY, "100%", g, textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(255, (int) (255*i/(50.0*koeff)), 0);
                DrawLine(g, Var.RealW - Var.Border, y0 + i, Var.RealW - Var.Border + 10 * koeff, y0 + i, col);
            }
            y0 += 50 * koeff;
            //PrintText(xPer, y0 + textOffsetY, "75%", g, textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb( (int) (255 * (50 * koeff - i) / (50.0 * koeff)) ,255, 0);
                DrawLine(g, Var.RealW - Var.Border, y0 + i, Var.RealW - Var.Border + 10 * koeff, y0 + i, col);
            }
            y0 += 50 * koeff;
            //PrintText(xPer, y0 + textOffsetY, "50%", g, textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(0, 255, (int)(255 * i / (50.0 * koeff)));
                DrawLine(g, Var.RealW - Var.Border, y0 + i, Var.RealW - Var.Border + 10 * koeff, y0 + i, col);
            }
            y0 += 50 * koeff;
            //PrintText(xPer, y0 + textOffsetY, "25%", g, textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(0, (int)(255 * (50 * koeff - i) / (50.0 * koeff)), 255);
                DrawLine(g, Var.RealW - Var.Border, y0 + i, Var.RealW - Var.Border + 10 * koeff, y0 + i, col);
            }
            y0 += 50 * koeff;
            //PrintText(xPer, y0 + textOffsetY, "0%", g, textSize);
        }

        static void DrawHalfCircle(Graphics g, int x0, int y0, int r)
        {
            int limit = (int)(r / Math.Sqrt(2));
            for (int y = y0; y <= y0 + limit; y++)
            {
                int temp = (int)Math.Sqrt(Sqr(r) - Sqr(y - y0));
                int x = x0 + temp;
                DrawPoint(g, x, y);
                x = x0 - temp;
                DrawPoint(g, x, y);
            }
            for (int x = x0 - limit; x <= x0 + limit; x++)
            {
                int y = y0 + (int)Math.Sqrt(Sqr(r) - Sqr(x - x0));
                DrawPoint(g, x, y);
            }
        }

        public static void DrawSensors(Graphics g)
        {
            DrawLine(g, Var.FrameSensor + Var.Border, Var.FrameSensor + Var.Border, Var.Border + Var.W - Var.FrameSensor, Var.FrameSensor + Var.Border);
            DrawLine(g, Var.FrameSensor + Var.Border, Var.FrameSensor + Var.Border, Var.FrameSensor + Var.Border, Var.Border + Var.H / 2);
            DrawLine(g, Var.Border + Var.W - Var.FrameSensor, Var.FrameSensor + Var.Border, Var.Border + Var.W - Var.FrameSensor, Var.Border + Var.H / 2);

            int x0 = Var.Border + Var.W / 2,
                y0 = Var.Border + Var.H / 2,
                r1 = Var.H / 2 - Var.FrameSensor,
                r2 = Var.H / 2;

            DrawHalfCircle(g, x0, y0, r1);
            DrawHalfCircle(g, x0, y0, r2);
        }

        static int[] GetAverageMas(int[] inputMas)
        {
            int len = inputMas.Length;
            int[] temp = new int[len];

            temp[0] = (inputMas[0] + inputMas[1]) / 2;
            temp[len - 1] = (inputMas[len - 1] + inputMas[len - 2]) / 2;
            for (int i = 1; i < len - 1; i++)
            {
                temp[i] = (inputMas[i] + inputMas[i - 1] + inputMas[i + 1]) / 3;
            }
            return temp;
        }

        public static void DrawLightDistribution(Graphics g)
        {
            // этот блок кода - интерполяция для проблемных сенсоров
            int center = 90 / Var.DiscreteAngle; 
            Var.CircleBright[center] = (Var.CircleBright[center - 1] + Var.CircleBright[center + 1]) / 2;
            Var.CircleBright[0] = Var.CircleBright[1];
            Var.CircleBright[Var.CircleBright.Length - 1] = Var.CircleBright[Var.CircleBright.Length - 2];
            Var.LeftBright[Var.LeftBright.Length - 1] = Var.LeftBright[Var.LeftBright.Length - 2];
            Var.RightBright[Var.RightBright.Length - 1] = Var.RightBright[Var.RightBright.Length - 2];

            int nonZeroPointLeft = Var.FloorBright[1 + (Var.Border + Var.FrameSensor) / Var.SideSector];
            for (int i = 0; i <= Var.Border + Var.FrameSensor; i++)
                Var.FloorBright[i / Var.SideSector] = nonZeroPointLeft;

            int nonZeroPointRight = Var.FloorBright[-1 + (Var.Border + Var.W - Var.FrameSensor) / Var.SideSector];
            for (int i = Var.Border + Var.W - Var.FrameSensor; i <= Var.Border + Var.W + Var.SideSector; i++)
                Var.FloorBright[i / Var.SideSector] = nonZeroPointRight;

            // усреднение значений сенсоров
            Var.CircleBright = GetAverageMas(Var.CircleBright);
            Var.LeftBright = GetAverageMas(Var.LeftBright);
            Var.RightBright = GetAverageMas(Var.RightBright);
            Var.FloorBright = GetAverageMas(Var.FloorBright);

            // поиск минимума и максимума
            int max = 0, min = Int32.MaxValue;
            foreach (int curr in Var.CircleBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            foreach (int curr in Var.LeftBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }

            foreach (int curr in Var.RightBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            foreach (int curr in Var.FloorBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            double sigma = max - min;
            if (sigma == 0)
                sigma = 1;

            int x0 = Var.Border + Var.W / 2,
                y0 = Var.Border + Var.H / 2;
            int r1 = Sqr(Var.H / 2 - Var.FrameSensor),
                r2 = Sqr(Var.H / 2);
            for (int x = Var.Border; x <= Var.W + Var.Border; x++)
                for (int y = Var.Border; y <= Var.H + Var.Border; y++)
                {
                    int dx = x - x0;
                    int dy = y - y0;
                    int square = Sqr(x - x0) + Sqr(y - y0);
                    if (y > Var.Border + Var.H / 2 && square >= r1 && square < r2)
                    {
                        int alpha = 0;
                        if (dx != 0)
                        {
                            alpha = (int)((180.0 / Math.PI) * Math.Atan(dy / (double)(dx)));
                            if (alpha < 0)
                                alpha = 180 + alpha;
                        }
                        else
                            alpha = 90;

                        int num = alpha / Var.DiscreteAngle;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)Var.CircleBright[num] - min) / sigma;
                        colk = koef - Math.Floor(koef);

                        Color col = Color.Blue;
                        if (koef >= 0 && koef < 1)
                            col = Color.FromArgb(0, (int) (colk*255), 255);
                        if (koef >= 1 && koef < 2)
                            col = Color.FromArgb(0, 255, (int) ((1 - colk)*255));
                        if (koef >= 2 && koef < 3)
                            col = Color.FromArgb( (int) (colk*255), 255, 0);
                        if (koef >= 3 && koef < 4)
                            col = Color.FromArgb(255, (int) ((1 - colk)*255), 0);
                        if (koef == 4)
                            col = Color.FromArgb(255, 0, 0);
                        DrawPoint(g, x, y, col);
                    }
                    if (y <= Var.Border + Var.H / 2 && x < Var.Border + Var.FrameSensor)
                    {
                        int num = y / Var.SideSector;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)Var.LeftBright[num] - min) / sigma;
                        colk = koef - Math.Floor(koef);

                        Color col = Color.Blue;
                        if (koef >= 0 && koef < 1)
                            col = Color.FromArgb(0, (int)(colk * 255), 255);
                        if (koef >= 1 && koef < 2)
                            col = Color.FromArgb(0, 255, (int)((1 - colk) * 255));
                        if (koef >= 2 && koef < 3)
                            col = Color.FromArgb((int)(colk * 255), 255, 0);
                        if (koef >= 3 && koef < 4)
                            col = Color.FromArgb(255, (int)((1 - colk) * 255), 0);
                        if (koef == 4)
                            col = Color.FromArgb(255, 0, 0);
                        DrawPoint(g, x, y, col);
                    }
                    if (y <= Var.Border + Var.H / 2 && x > Var.Border + Var.W - Var.FrameSensor)
                    {
                        int num = y / Var.SideSector;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)Var.RightBright[num] - min) / sigma;
                        colk = koef - Math.Floor(koef);

                        Color col = Color.Blue;
                        if (koef >= 0 && koef < 1)
                            col = Color.FromArgb(0, (int)(colk * 255), 255);
                        if (koef >= 1 && koef < 2)
                            col = Color.FromArgb(0, 255, (int)((1 - colk) * 255));
                        if (koef >= 2 && koef < 3)
                            col = Color.FromArgb((int)(colk * 255), 255, 0);
                        if (koef >= 3 && koef < 4)
                            col = Color.FromArgb(255, (int)((1 - colk) * 255), 0);
                        if (koef == 4)
                            col = Color.FromArgb(255, 0, 0);
                        DrawPoint(g, x, y, col);
                    }
                    if (y < Var.Border + Var.FrameSensor)
                    {
                        int num = x / Var.SideSector;  // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)Var.FloorBright[num] - min) / sigma;
                        colk = koef - Math.Floor(koef);

                        Color col = Color.Blue;
                        if (koef >= 0 && koef < 1)
                            col = Color.FromArgb(0, (int)(colk * 255), 255);
                        if (koef >= 1 && koef < 2)
                            col = Color.FromArgb(0, 255, (int)((1 - colk) * 255));
                        if (koef >= 2 && koef < 3)
                            col = Color.FromArgb((int)(colk * 255), 255, 0);
                        if (koef >= 3 && koef < 4)
                            col = Color.FromArgb(255, (int)((1 - colk) * 255), 0);
                        if (koef == 4)
                            col = Color.FromArgb(255, 0, 0);
                        DrawPoint(g, x, y, col);
                    }
                }
        }

        public static void DrawSegment(Graphics g, int click, Var.Point[] masPoints)
        {
            for (int i = 1; i <= click; i++)
                DrawCross(g, masPoints[i].X, masPoints[i].Y, 10, 3);
            for (int i = 2; i <= click; i++)
                DrawLine(g, masPoints[i].X, masPoints[i].Y, masPoints[i - 1].X, masPoints[i - 1].Y);
        }
    }
}

