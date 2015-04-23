using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public static class LedLibrary
    {
        public static double
            Wavelength = 473;
        public static string
            ActiveMaterial = "i-GaN";
        public static bool
            IsAsyncCalculation = false;
        public static int
          StepOfCursor = 5,
          CountOfThread = 4,
          FrameSensor = 20,
          BigStep = 100,
          LittleStep = 50,
          MeshDensityCoeff = 1,
          PrecKoeff = 1,
          W,
          H,
          HMaxMicr = 10,
          WMaxMicr = 10,
          Border,
          RealW,
          RealH,
          SensMat = 6,
          CountOfQuants = 100000,
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
        public static readonly List<Material> Materials = new List<Material>();
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

        public class Material
        {
            public Material(String type, String name, double fraction, double absorption, double reflection, double r, double g, double b)
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

        static int Sqr(int x)
        {
            return x * x;
        }

        public static int Dist(Point p1, Point p2)
        {
            return Sqr(p2.X - p1.X) + Sqr(p2.Y - p1.Y);
        }

        public static int FromMicrX(double x)
        {
            return (int) ((x*BigStep) + Border);
        }

        public static int FromMicrY(double y)
        {
            return (int)((y * BigStep) + Border);
        }

        public static double ToMicrX(int x)
        {
            return (double)(x - Border) / BigStep;
        }

        public static double ToMicrY(int y)
        {
            return (double)(y - Border) / BigStep;
        }

        /// <summary>
        /// Считывает структуру из файла
        /// </summary>
        /// <param name="path"></param>
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

            int x = 0, y = 0;
            long length = dataIn.BaseStream.Length;
            while (dataIn.BaseStream.Position != length)
            {
                int temp = dataIn.ReadInt32();
                if (temp == '\n')
                {
                    y++;
                    x = 0;
                }
                else
                {
                    Mas[x, y] = temp;
                    x++;
                }
            }

            dataIn.Close();
        }

        /// <summary>
        /// Записывает текущую структуру в файл
        /// </summary>
        /// <param name="path"></param>
        public static void SaveToBinFile(String path)
        {
            BinaryWriter dataOut;

            int endOfLine = '\n';

            try
            {
                dataOut = new BinaryWriter(new FileStream(path, FileMode.Create));
            }
            catch (IOException exc)
            {
                MessageBox.Show("Не удалось записать в файл " + exc.Message, "Ошибка");
                return;
            }
            for (int y = 0; y <= H; y++)
            {
                for (int x = 0; x <= W; x++)
                    dataOut.Write(Mas[x, y]);
                dataOut.Write(endOfLine);
            }
            dataOut.Close();
        }

        public static void InitVariables(int w, int h)
        {
            RealH = h;
            RealW = w;

            Border = h / 15;
            Border = (Border/StepOfCursor)*StepOfCursor;

            H = RealH - Border * 2;
            //H = (H/StepOfCursor)*StepOfCursor;

            W = RealW - Border * 2;
            //W = (W/StepOfCursor)*StepOfCursor;

            SideSector = (int)(((Math.PI * (H/2 + W/2)) / 180) * DiscreteAngle);
            Mas = new int[RealW + 1, RealH + 1];
            CircleBright = new int[1 + 180 / DiscreteAngle];
            LeftBright = new int[1 + (RealH / 2) / SideSector];
            RightBright = new int[1 + (RealH / 2) / SideSector];
            FloorBright = new int[1 + RealW / SideSector];
        }

        static string GetMaterialValueOfField(string str)
        {
            return str.Substring(str.IndexOf(':') + 2);
        }

        static void AddMaterial(List<string> mas, int pos)
        {
            string type, name;
            double fraction, absorbtion, reflection, r, g, b;
            try
            {
                type = GetMaterialValueOfField(mas[++pos]);
                name = GetMaterialValueOfField(mas[++pos]);
                fraction = Double.Parse(GetMaterialValueOfField(mas[++pos]));
                absorbtion = Double.Parse(GetMaterialValueOfField(mas[++pos]));
                reflection = Double.Parse(GetMaterialValueOfField(mas[++pos]));
                r = Double.Parse(GetMaterialValueOfField(mas[++pos]));
                g = Double.Parse(GetMaterialValueOfField(mas[++pos]));
                b = Double.Parse(GetMaterialValueOfField(mas[++pos]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Не удалось считать один материал {0}"), ex.Message);
                return;
            }

            Material curr = new Material(type, name, fraction, absorbtion, reflection, r, g, b);
            Materials.Add(curr);
        }

        public static void LoadMaterialsDb(string path)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            Materials.Clear();

            for (int i = 0; i < lines.Count; i++)
                if (lines[i] == "@New material@")
                    AddMaterial(lines, i);
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
            DrawLine(g, LedLibrary.Border, LedLibrary.Border, LedLibrary.Border, LedLibrary.RealH - LedLibrary.Border);
            DrawLine(g, LedLibrary.Border, LedLibrary.RealH - LedLibrary.Border, LedLibrary.RealW - LedLibrary.Border, LedLibrary.RealH - LedLibrary.Border);
            DrawLine(g, LedLibrary.RealW - LedLibrary.Border, LedLibrary.RealH - LedLibrary.Border, LedLibrary.RealW - LedLibrary.Border, LedLibrary.Border);
            DrawLine(g, LedLibrary.RealW - LedLibrary.Border, LedLibrary.Border, LedLibrary.Border, LedLibrary.Border);
        }

        public static void PrintText(Graphics g, int x, int y, string text, int size = 9)
        {
            g.DrawString(text, new Font("Arial", size), Brushes.Black, new PointF(x, LedLibrary.RealH - y));

        }

        public static void DrawLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(BlackPen, x1, LedLibrary.RealH - y1, x2, LedLibrary.RealH - y2);
        }

        public static void DrawLine(Graphics g, int x1, int y1, int x2, int y2, Color col)
        {
            g.DrawLine(new Pen(col, 1), x1, LedLibrary.RealH - y1, x2, LedLibrary.RealH - y2);
        }

        public static void DrawPoint(Graphics g, int x, int y)
        {
            g.DrawLine(BlackPen, x, LedLibrary.RealH - y, x, LedLibrary.RealH - y + 1);
        }

        public static void DrawPoint(Graphics g, int x, int y, Color col)
        {
            g.DrawLine(new Pen(col, 1), x, LedLibrary.RealH - y, x, LedLibrary.RealH - y + 1);
            g.DrawLine(new Pen(col, 1), x - 1, LedLibrary.RealH - y, x - 1, LedLibrary.RealH - y + 1);
        }

        public static void DrawCross(Graphics g, int x, int y, int l, int w)
        {
            Pen currPen = new Pen(Color.Black, w);
            g.DrawLine(currPen, x - l, LedLibrary.RealH - y, x + l, LedLibrary.RealH - y);
            g.DrawLine(currPen, x, (LedLibrary.RealH - y) - l, x, (LedLibrary.RealH - y) + l);
        }

        public static void DrawCross(Graphics g, int x, int y, int l, int w, Color col)
        {
            Pen currPen = new Pen(col, w);
            g.DrawLine(currPen, x - l, LedLibrary.RealH - y, x + l, LedLibrary.RealH - y);
            g.DrawLine(currPen, x, (LedLibrary.RealH - y) - l, x, (LedLibrary.RealH - y) + l);
        }

        public static void DrawCircle(Graphics g, int x, int y)
        {
            g.FillEllipse(Brushes.Red, x - 4, LedLibrary.RealH - y - 4, 8, 8);
        }

        private static void CreateMark(Graphics g)  // метки на осях
        {
            // вспомогательный коэффициент для отступов
            int microOffset = LedLibrary.H / 100;

            // крупные горизонтальные метки
            int currLevelX = LedLibrary.Border;
            int dimensionX = 0;
            while (currLevelX <= LedLibrary.Border + LedLibrary.W)
            {
                DrawLine(g, currLevelX, LedLibrary.Border - microOffset, currLevelX, LedLibrary.Border + microOffset);
                DrawLine(g, currLevelX, LedLibrary.Border + LedLibrary.H - microOffset, currLevelX, LedLibrary.Border + LedLibrary.H + microOffset);

                string mark = (dimensionX++).ToString();
                PrintText(g, currLevelX - microOffset, LedLibrary.Border - 2*microOffset, mark);

                currLevelX += LedLibrary.BigStep;
            }

            // крупные вертикальные метки
            int currLevelY = LedLibrary.Border;
            int dimensionY = 0;
            while (currLevelY <= LedLibrary.Border + LedLibrary.H)
            {
                DrawLine(g, LedLibrary.Border - microOffset, currLevelY, LedLibrary.Border + microOffset, currLevelY);
                DrawLine(g, LedLibrary.Border + LedLibrary.W - microOffset, currLevelY, LedLibrary.Border + LedLibrary.W + microOffset, currLevelY);

                string mark = (dimensionY++).ToString();
                PrintText(g, LedLibrary.Border - (int)(4.5 * microOffset), currLevelY + (int)(1.5 * microOffset), mark);

                currLevelY += LedLibrary.BigStep;
            }

            // новый отступ
            int microOffset2 = LedLibrary.H / 200;

            // маленькие горизонтальные метки
            currLevelX = LedLibrary.Border;
            while (currLevelX <= LedLibrary.Border + LedLibrary.W)
            {
                DrawLine(g, currLevelX, LedLibrary.Border - microOffset2, currLevelX, LedLibrary.Border + microOffset2);
                DrawLine(g, currLevelX, LedLibrary.Border + LedLibrary.H - microOffset2, currLevelX, LedLibrary.Border + LedLibrary.H + microOffset2);
                currLevelX += LedLibrary.LittleStep;
            }

            // маленькие вертикальные метки
            currLevelY = LedLibrary.Border;
            while (currLevelY <= LedLibrary.Border + LedLibrary.H)
            {
                DrawLine(g, LedLibrary.Border - microOffset2, currLevelY, LedLibrary.Border + microOffset2, currLevelY);
                DrawLine(g, LedLibrary.Border + LedLibrary.W - microOffset2, currLevelY, LedLibrary.Border + LedLibrary.W + microOffset2, currLevelY);
                currLevelY += LedLibrary.LittleStep;
            }
        }

        private static void CreatePoints(Graphics g)  // точки в области
        {
            int numStepY = LedLibrary.H / LedLibrary.BigStep;
            int numStepX = LedLibrary.W / LedLibrary.BigStep;
            for (int i = 0; i <= numStepX; i++)
                for (int j = 0; j <= numStepY; j++)
                    DrawCross(g, + LedLibrary.Border + i * LedLibrary.BigStep, LedLibrary.Border + j * LedLibrary.BigStep, 4, 1);

            int newStep = LedLibrary.BigStep / 4;
            numStepY = LedLibrary.H / newStep;
            numStepX = LedLibrary.W / newStep;
            for (int i = 0; i <= numStepX; i++)
                for (int j = 0; j <= numStepY; j++)
                    DrawCross(g, LedLibrary.Border + i * newStep, LedLibrary.Border + j * newStep, 1, 1);
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
            if (LedLibrary.Mas == null)
                return;

            xl = Math.Max(0, xl);
            yd = Math.Max(0, yd);
            xr = Math.Min(LedLibrary.RealW, xr);
            yu = Math.Min(LedLibrary.RealH, yu);

            for (int y = yd; y <= yu; y++)
            {
                int x = xl;
                while (x <= xr)
                {
                    int x1 = x;
                    int col0 = LedLibrary.Mas[x, y];

                    while (x <= LedLibrary.RealW && col0 == LedLibrary.Mas[x, y])
                        x++;
                    DrawLine(g, x1, y, x, y, Color.FromArgb( (int)(LedLibrary.Materials[col0].R*255), (int)(LedLibrary.Materials[col0].G*255), (int)(LedLibrary.Materials[col0].B*255)));
                }
            }
        }

        public static void DrawRainbow(Graphics g)
        {
            int koeff = 2,
                y0 = LedLibrary.Border + LedLibrary.H,
                textOffsetY = 5 * koeff,
                textSize = 7,
                rainbowWidht = 8,
                xPer = (LedLibrary.RealW - LedLibrary.Border / 2) - 39;
            PrintText(g, xPer, y0 + textOffsetY, "100%", textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(255, (int) (255*i/(50.0*koeff)), 0);
                DrawLine(g, LedLibrary.RealW - LedLibrary.Border, y0 - i, LedLibrary.RealW - LedLibrary.Border + rainbowWidht, y0 - i, col);
            }
            y0 -= 50 * koeff;
            PrintText(g, xPer, y0 + textOffsetY, "75%", textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb( (int) (255 * (50 * koeff - i) / (50.0 * koeff)) ,255, 0);
                DrawLine(g, LedLibrary.RealW - LedLibrary.Border, y0 - i, LedLibrary.RealW - LedLibrary.Border + rainbowWidht, y0 - i, col);
            }
            y0 -= 50 * koeff;
            PrintText(g, xPer, y0 + textOffsetY, "50%", textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(0, 255, (int)(255 * i / (50.0 * koeff)));
                DrawLine(g, LedLibrary.RealW - LedLibrary.Border, y0 - i, LedLibrary.RealW - LedLibrary.Border + rainbowWidht, y0 - i, col);
            }
            y0 -= 50 * koeff;
            PrintText(g, xPer, y0 + textOffsetY, "25%", textSize);
            for (int i = 0; i <= 50 * koeff; i++)
            {
                Color col = Color.FromArgb(0, (int)(255 * (50 * koeff - i) / (50.0 * koeff)), 255);
                DrawLine(g, LedLibrary.RealW - LedLibrary.Border, y0 - i, LedLibrary.RealW - LedLibrary.Border + rainbowWidht, y0 - i, col);
            }
            y0 -= 50 * koeff;
            PrintText(g, xPer, y0 + textOffsetY, "0%", textSize);
        }

        static void DrawHalfEllipse(Graphics g, int x0, int y0, double a, double b)
        {
            for (int y = y0; y <= LedLibrary.RealH; y++)
                for (int x = 0; x <= LedLibrary.RealW; x++)
                {
                    double koeff = Math.Pow((x - x0)/a, 2) + Math.Pow((y - y0)/b, 2);
                    if (Math.Abs(koeff - 1) < 1.7e-3)
                        DrawPoint(g, x, y);
                }
        }

        public static void DrawSensors(Graphics g)
        {
            DrawLine(g, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor, LedLibrary.FrameSensor + LedLibrary.Border);
            DrawLine(g, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.Border + LedLibrary.H / 2);
            DrawLine(g, LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor, LedLibrary.FrameSensor + LedLibrary.Border, LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor, LedLibrary.Border + LedLibrary.H / 2);

            int x0 = LedLibrary.Border + LedLibrary.W / 2,
                y0 = LedLibrary.Border + LedLibrary.H / 2;

            double a = x0 - LedLibrary.Border;
            double b = LedLibrary.RealH - y0 - LedLibrary.Border;

            DrawHalfEllipse(g, x0, y0, a, b);
            DrawHalfEllipse(g, x0, y0, a - LedLibrary.FrameSensor, b - LedLibrary.FrameSensor);
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
            int center = 90 / LedLibrary.DiscreteAngle;
            LedLibrary.CircleBright[center] = (LedLibrary.CircleBright[center - 1] + LedLibrary.CircleBright[center + 1]) / 2;
            LedLibrary.CircleBright[0] = LedLibrary.CircleBright[1];
            LedLibrary.CircleBright[LedLibrary.CircleBright.Length - 1] = LedLibrary.CircleBright[LedLibrary.CircleBright.Length - 2];
            LedLibrary.LeftBright[LedLibrary.LeftBright.Length - 1] = LedLibrary.LeftBright[LedLibrary.LeftBright.Length - 2];
            LedLibrary.RightBright[LedLibrary.RightBright.Length - 1] = LedLibrary.RightBright[LedLibrary.RightBright.Length - 2];

            int nonZeroPointLeft = LedLibrary.FloorBright[1 + (LedLibrary.Border + LedLibrary.FrameSensor) / LedLibrary.SideSector];
            for (int i = 0; i <= LedLibrary.Border + LedLibrary.FrameSensor; i++)
                LedLibrary.FloorBright[i / LedLibrary.SideSector] = nonZeroPointLeft;

            int nonZeroPointRight = LedLibrary.FloorBright[-1 + (LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor) / LedLibrary.SideSector];
            for (int i = LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor; i <= LedLibrary.Border + LedLibrary.W + LedLibrary.SideSector; i++)
                LedLibrary.FloorBright[i / LedLibrary.SideSector] = nonZeroPointRight;

            // усреднение значений сенсоров
            LedLibrary.CircleBright = GetAverageMas(LedLibrary.CircleBright);
            LedLibrary.LeftBright = GetAverageMas(LedLibrary.LeftBright);
            LedLibrary.RightBright = GetAverageMas(LedLibrary.RightBright);
            LedLibrary.FloorBright = GetAverageMas(LedLibrary.FloorBright);

            // поиск минимума и максимума
            int max = 0, min = Int32.MaxValue;
            foreach (int curr in LedLibrary.CircleBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            foreach (int curr in LedLibrary.LeftBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }

            foreach (int curr in LedLibrary.RightBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            foreach (int curr in LedLibrary.FloorBright)
            {
                if (max < curr)
                    max = curr;
                if (min > curr)
                    min = curr;
            }
            double sigma = max - min;
            if (sigma == 0)
                sigma = 1;

            int x0 = LedLibrary.Border + LedLibrary.W / 2,
                y0 = LedLibrary.Border + LedLibrary.H / 2;
            double a = x0 - LedLibrary.Border,
                   b = LedLibrary.RealH - y0 - LedLibrary.Border;

            for (int x = LedLibrary.Border; x <= LedLibrary.W + LedLibrary.Border; x++)
                for (int y = LedLibrary.Border; y <= LedLibrary.H + LedLibrary.Border; y++)
                {
                    int dx = x - x0;
                    int dy = y - y0;

                    double koeff1 = Math.Pow((x - x0) / a, 2) + Math.Pow((y - y0) / b, 2);
                    double koeff2 = Math.Pow((x - x0) / (a - LedLibrary.FrameSensor), 2) + Math.Pow((y - y0) / (b - LedLibrary.FrameSensor), 2);

                    if (y >= LedLibrary.Border + LedLibrary.H / 2 && koeff1 < 1 && koeff2 > 1)
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

                        int num = alpha / LedLibrary.DiscreteAngle;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)LedLibrary.CircleBright[num] - min) / sigma;
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
                    if (y <= LedLibrary.Border + LedLibrary.H / 2 && x < LedLibrary.Border + LedLibrary.FrameSensor)
                    {
                        int num = y / LedLibrary.SideSector;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)LedLibrary.LeftBright[num] - min) / sigma;
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
                    if (y <= LedLibrary.Border + LedLibrary.H / 2 && x > LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor)
                    {
                        int num = y / LedLibrary.SideSector;   // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)LedLibrary.RightBright[num] - min) / sigma;
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
                    if (y < LedLibrary.Border + LedLibrary.FrameSensor)
                    {
                        int num = x / LedLibrary.SideSector;  // вычисляем сектор
                        double koef = 0,
                               colk = 0;

                        koef = 4 * ( (double)LedLibrary.FloorBright[num] - min) / sigma;
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

        public static void DrawSegment(Graphics g, int click, LedLibrary.Point[] masPoints)
        {
            for (int i = 1; i <= click; i++)
                DrawCross(g, masPoints[i].X, masPoints[i].Y, 10, 3);
            for (int i = 2; i <= click; i++)
                DrawLine(g, masPoints[i].X, masPoints[i].Y, masPoints[i - 1].X, masPoints[i - 1].Y);
        }
    }
}

