using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSimulating : Form
    {
        readonly LedLibrary.Point[] _active = new LedLibrary.Point[LedLibrary.W * LedLibrary.H]; // здесь внимательно! может быть переполнение
        int _numAct, _stackSize, _xs, _ys;
        private const int BackTrack = 1;
        FormReport _winReport;
        private const int Step = 2;

        readonly Random _rnd = new Random();
        readonly String[] _messages = new String[1000];
        int _nMess;
        bool _isLucky;

        private Bitmap _bmpSimulatingOfLed;
        private Graphics _graphicsSimulatingOfLed;

        public FormSimulating()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void InsertSensorMaterial()
        {
            int x0 = LedLibrary.Border + LedLibrary.W / 2,
                y0 = LedLibrary.Border + LedLibrary.H / 2,
                sens = LedLibrary.SensMat;

            double a = x0 - LedLibrary.Border;
            double b = LedLibrary.RealH - y0 - LedLibrary.Border;

            for (int y = y0; y <= LedLibrary.RealH; y++)
                for (int x = 0; x <= LedLibrary.RealW; x++)
                {
                    double koeff1 = Math.Pow((x - x0) / a, 2) + Math.Pow((y - y0) / b, 2);
                    double koeff2 = Math.Pow((x - x0) / (a - LedLibrary.FrameSensor), 2) + Math.Pow((y - y0) / (b - LedLibrary.FrameSensor), 2);
                    if (koeff1 < 1 && koeff2 > 1)
                        LedLibrary.Mas[x, y] = sens;
                }

            for (int y = LedLibrary.Border; y <= LedLibrary.Border + LedLibrary.H / 2; y++)
            {
                for (int x = LedLibrary.Border; x < LedLibrary.Border + LedLibrary.FrameSensor; x++)
                    LedLibrary.Mas[x, y] = sens;
                for (int x = LedLibrary.Border + LedLibrary.W - LedLibrary.FrameSensor; x < LedLibrary.Border + LedLibrary.W; x++)
                    LedLibrary.Mas[x, y] = sens;
            }
            for (int y = LedLibrary.Border; y < LedLibrary.Border + LedLibrary.FrameSensor; y++)
                for (int x = LedLibrary.Border; x <= LedLibrary.Border + LedLibrary.W; x++)
                    LedLibrary.Mas[x, y] = sens;
        }

        private static void InitializeVar()
        {
            LedLibrary.QuantAbsorbed = 0;
            LedLibrary.QuantsBack = 0;
            LedLibrary.QuantsFront = 0;
            LedLibrary.QuantsLeft = 0;
            LedLibrary.QuantsOut = 0;
            LedLibrary.QuantsRight = 0;
            LedLibrary.QuantumEff = 0;
            LedLibrary.BadQuants = 0;

            Array.Clear(LedLibrary.LeftBright, 0, LedLibrary.LeftBright.Length);
            Array.Clear(LedLibrary.RightBright, 0, LedLibrary.RightBright.Length);
            Array.Clear(LedLibrary.CircleBright, 0, LedLibrary.CircleBright.Length);
            Array.Clear(LedLibrary.FloorBright, 0, LedLibrary.FloorBright.Length);
        }

        private void simulating_Load(object sender, EventArgs e)
        {
            _bmpSimulatingOfLed = new Bitmap(pbSimulatingOfLed.Width, pbSimulatingOfLed.Height);
            _graphicsSimulatingOfLed = Graphics.FromImage(_bmpSimulatingOfLed);

            InsertSensorMaterial();
            OpenGLm.LineDrawPic(_graphicsSimulatingOfLed, 0, LedLibrary.RealW, 0, LedLibrary.RealH);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.DrawRainbow(_graphicsSimulatingOfLed);
            OpenGLm.SetMesh(_graphicsSimulatingOfLed);
            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;

            LedLibrary.Material activeMaterial =
                LedLibrary.Materials.Where(x => x.Name == LedLibrary.ActiveMaterial).FirstOrDefault();
            int activeCode = LedLibrary.Materials.IndexOf(activeMaterial);

            DetectingActiveLayer(activeCode); // i - GaN в базе под номером 4
            InitializeVar();
        }

        private void DetectingActiveLayer(int num) // в дальнейшем массив
        {
            for (int x = 0; x <= LedLibrary.W; x++)
                for (int y = 0; y <= LedLibrary.H; y++)
                    if (LedLibrary.Mas[x, y] == num)
                        _active[_numAct++] = new LedLibrary.Point(x, y);
        }

        private double Sqr(double x)
        {
            return x * x;
        }

        private void AddMaterial(int n, int code, double r, double g, double b)
        {

            if (FormLegend.Instance != null)
                FormLegend.Instance.SetMaterial(n, Color.FromArgb( (int) (255*r), (int) (255*g), (int) (255*b)), code);
        }

        private void MakeLegend()
        {
            bool[] used = new bool[100];
            used[LedLibrary.SensMat] = true; // сенсоры на легенде не нужны

            int count = 0;
            for (int x = 0; x <= LedLibrary.W; x++)
                for (int y = LedLibrary.H; y >= 0; y--)
                {
                    int code = LedLibrary.Mas[x, y];
                    if (!used[code])
                    {
                        count++;
                        used[code] = true;
                        AddMaterial(count, code, LedLibrary.Materials[code].R, LedLibrary.Materials[code].G, LedLibrary.Materials[code].B);
                    }
                }
        }

        private void PushMessage(String s)
        {
            _messages[_nMess] = (_nMess + 1) + ") " + s + " \n\r";
            _nMess++;
        }

        private string ToDegree(double curAngle)
        {
            double curAngleGr = Math.Floor(((curAngle * 180) / Math.PI) * 100) / 100;
            return curAngleGr.ToString();
        }

        private bool Absorbed(int code, int x, int y)
        {
            if (_isLucky)
                return false;

            double l1 = (double) ( LedLibrary.WMaxMicr * (x - _xs) ) / LedLibrary.W,
                   l2 = (double) ( LedLibrary.HMaxMicr * (y - _ys) ) / LedLibrary.H,
                   len = Math.Sqrt(Sqr(l1) + Sqr(l2)),
                   transmission = 1 - LedLibrary.Materials[code].Absorption,
                   aliveProb = Math.Pow(transmission, len),
                   absProb = 1 - aliveProb;
            return _rnd.NextDouble() <= absProb;
        }

        private double RoughAngle(int x, int y) // x - x0, y - y0
        {
            double res = 0;

            int xl = x - 4 * LedLibrary.PrecKoeff, xr = x + 4 * LedLibrary.PrecKoeff;
            double yl = 0, yr = 0;
            int code0L = LedLibrary.Mas[xl, y], code0R = LedLibrary.Mas[xr, y];

            int delta = 0;
            while (code0L == LedLibrary.Mas[xl, Math.Max(y - delta, 0)] && code0L == LedLibrary.Mas[xl, Math.Min(y + delta, LedLibrary.H)] && delta < LedLibrary.H)
               delta++;
            if (code0L != LedLibrary.Mas[xl, Math.Max(y - delta, 0)])
                 yl = y - delta + 0.5;
            if (code0L != LedLibrary.Mas[xl, Math.Min(y + delta, LedLibrary.H)])
                 yl = y + delta - 0.5;

             delta = 0;
             while (code0R == LedLibrary.Mas[xr, Math.Max(y - delta, 0)] && code0R == LedLibrary.Mas[xr, Math.Min(y + delta, LedLibrary.H)] && delta < LedLibrary.H)
                 delta++;
             if (code0R != LedLibrary.Mas[xr, Math.Max(y - delta, 0)])
                 yr = y - delta + 0.5;
             if (code0R != LedLibrary.Mas[xr, Math.Min(y + delta, LedLibrary.H)])
                 yr = y + delta - 0.5;

             res = Math.Atan((yr - yl) / (xr - xl));
             if (res < 0)
                res = res + Math.PI;

            return res;
        }

        private double CalculateFraction(double alpha, double beta, double n, double n1)
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

        private bool IsReflection(double alpha, double beta, double n, double n1, int code)
        {
            bool res = false;
            if (beta == 0)
                res = (Math.Abs(Math.Cos(alpha)) >= n1 / n);
            if (beta == Math.PI / 2)
                res = (Math.Abs(Math.Sin(alpha)) >= n1 / n);
            if ((beta > 0 && beta < Math.PI / 2) || (beta > Math.PI / 2 && beta < Math.PI))
                res = (Math.Abs(Math.Cos(alpha - beta)) >= n1 / n);

            // Зеркало
            if (LedLibrary.Materials[code].Type == "Mirror") 
                res = true;
            return res;
        }

        private double CalculateReflection(double alpha, double beta)
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

        private void CalcSector(int x, int y)
        {
            int x0 = LedLibrary.Border + LedLibrary.W / 2,
                y0 = LedLibrary.Border + LedLibrary.H / 2,
                dx = x - x0,
                dy = y - y0;
            int delta = 3;

            if (y >= y0)
            {
                int alpha;
                if (dx != 0)
                {
                    alpha = (int)((180.0 / Math.PI) * Math.Atan(dy / (double)(dx)));
                    if (alpha < 0)
                        alpha = 180 + alpha;
                }
                else
                    alpha = 90;

                int num = alpha / LedLibrary.DiscreteAngle; // вычисляем сектор
                LedLibrary.CircleBright[num]++;
                LedLibrary.QuantsFront++;
            }
            else
            {
                int num = 0;
                if (x <= LedLibrary.Border + LedLibrary.FrameSensor + delta)
                {
                    num = y / LedLibrary.SideSector;
                    LedLibrary.LeftBright[num]++;
                    LedLibrary.QuantsLeft++;
                }
                else
                    if (y <= LedLibrary.Border + LedLibrary.FrameSensor + delta)
                    {
                        num = x / LedLibrary.SideSector;
                        LedLibrary.FloorBright[num]++;
                        LedLibrary.QuantsBack++;
                    }
                    else
                        if (x >= LedLibrary.W + LedLibrary.Border - LedLibrary.FrameSensor - delta)
                        {
                            num = y / LedLibrary.SideSector;
                            LedLibrary.RightBright[num]++;
                            LedLibrary.QuantsRight++;
                        }
                        //else
                        //    MessageBox.Show("Не найден сектор!!!");
            }
        }

        private void DebugReemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {
            if (Absorbed(code0, x, y))
            {
                LedLibrary.QuantAbsorbed++;
                PushMessage("Квант поглотился в материале " + LedLibrary.Materials[code0].Name);
                return;
            }
            _xs = x;
            _ys = y;

            int code = LedLibrary.Mas[x, y];
            double n1 = LedLibrary.Materials[code].Fraction,
                   n = LedLibrary.Materials[code0].Fraction;

            if (LedLibrary.Mas[x, y] == LedLibrary.SensMat)
            {
                PushMessage("Квант захвачен сенсором.");
                CalcSector(x, y);
                return;
            }

            double beta = RoughAngle(x0, y0);

            if (IsReflection(angle, beta, n, n1, code))
            {
                double newAlpha = CalculateReflection(angle, beta);
                PushMessage("Квант претерпел отражение от " + LedLibrary.Materials[code].Name + "; угол стал равен " + ToDegree(newAlpha) + " градусов.");
                DebugRayTracing(newAlpha, x0, y0);
            }
            else
            {
                double newAlpha = CalculateFraction(angle, beta, n, n1);
                PushMessage("Квант достиг " + LedLibrary.Materials[code].Name + " и претерпел преломление; угол стал равен " + ToDegree(newAlpha) + " градусов.");
                DebugRayTracing(newAlpha, x, y);
            }
        }

        private void Reemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {

            if ( Absorbed(code0, x, y) )
            {
                LedLibrary.QuantAbsorbed++;
                return;
            }
            _xs = x; 
            _ys = y;
            if (LedLibrary.Mas[x, y] == LedLibrary.SensMat)
            {
                CalcSector(x, y);
                LedLibrary.QuantsOut++;
                return;
            }

            int code = LedLibrary.Mas[x, y];
            double n1 = LedLibrary.Materials[code].Fraction,
                   n = LedLibrary.Materials[code0].Fraction;

            double beta = RoughAngle(x0, y0);

            if (IsReflection(angle, beta, n, n1, code))
            {
                double newAlpha = CalculateReflection(angle, beta);
                RayTracing(newAlpha, x0, y0);
            }
            else
            {
                double newAlpha = CalculateFraction(angle, beta, n, n1);
                RayTracing(newAlpha, x, y);
            }
        }

        private void PutVertex(int x, int y, char status)
        {
            int mod = LedLibrary.H / 50;

            Color col = Color.Black;
            if (status == 'l' || status == 'r')
            {
                int ost = x % (mod * 2);
                col = ost < mod ? Color.Black : Color.Yellow;
            }
            if (status == 'd' || status == 'u')
            {
                int ost = y % (mod * 2);
                col = ost < mod ? Color.Black : Color.Yellow;
            }

            OpenGLm.DrawPoint(_graphicsSimulatingOfLed, x, y, col);
        }

        private void DebugMovingRight(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == LedLibrary.Mas[x, y] || (x - oldX) < Step)
            {
                PutVertex(x, y, 'r');
                x++;
                shift += delta;
                y = (int) shift;
            }

            int x0 = x - 1;
            int y0 = (int)(shift - delta);

            if (y < LedLibrary.H && y > 0 && x < LedLibrary.W && code0 != LedLibrary.Mas[x, y])
                DebugReemit(code0, x, y, x0, y0, angle, 'r');
        }

        private void MovingRight(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == LedLibrary.Mas[x, y] || (x - oldX) < Step)
            {
                x++;
                shift += delta;
                y = (int) shift;
            }

            int x0 = x - 1;
            int y0 = (int) (shift - delta);
            Reemit(code0, x, y, x0, y0, angle, 'r');
        }

        private void DebugMovingLeft(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldX = x;
            double shift = y;
             while (code0 == LedLibrary.Mas[x, y] || (oldX - x) < Step)
            {
                PutVertex(x, y, 'l');
                x--;
                shift += delta;
                y = (int) shift;
            }

            int x0 = x + 1;
            int y0 = (int) (shift - delta);

            DebugReemit(code0, x, y, x0, y0, angle, 'l');
        }

        private void MovingLeft(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == LedLibrary.Mas[x, y] || (oldX - x) < Step)
            {
                x--;
                shift += delta;
                y = (int)shift;
            }
            int x0 = x + 1;
            int y0 = (int) (shift - delta);
            Reemit(code0, x, y, x0, y0, angle, 'l');
        }

        private void DebugMovingUp(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y];
            double shift = x;
            while (code0 == LedLibrary.Mas[x, y])
            {
                PutVertex(x, y, 'u');
                y++;
                shift += delta;
                x = (int) shift;
            }

            int y0 = y - 1;
            int x0 = (int) (shift - delta);

            DebugReemit(code0, x, y, x0, y0, angle, 'u');
        }

        private void MovingUp(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == LedLibrary.Mas[x, y] || (y - oldY) < Step)
            {
                y++;
                shift += delta;
                x = (int)shift;
            }
            int y0 = y - 1;
            int x0 = (int)(shift - delta);
            Reemit(code0, x, y, x0, y0, angle, 'u');
        }

        private void DebugMovingDown(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == LedLibrary.Mas[x, y] || (oldY - y) < Step)
            {
                PutVertex(x, y, 'd');
                y--;
                shift += delta;
                x = (int) shift;
            }

            int y0 = y + 1;
            int x0 = (int) (shift - delta);
            DebugReemit(code0, x, y, x0, y0, angle, 'd');
        }

        private void MovingDown(int x, int y, double delta, double angle)
        {
            int code0 = LedLibrary.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == LedLibrary.Mas[x, y] || (oldY - y) < Step)
            {
                y--;
                shift += delta;
                x = (int) shift;
            }
            int y0 = y + (BackTrack);
            int x0 = (int)(shift - (BackTrack) * delta);
            Reemit(code0, x, y, x0, y0, angle, 'd');
        }

        private void DebugRayTracing(double curAngle, int x, int y)
        {
            if (_stackSize >= 75)
            {
                PushMessage("Квант поглотился в материале " + LedLibrary.Materials[LedLibrary.Mas[x, y]].Name);
                return;
            }
            _stackSize++;

            while (curAngle >= 2 * Math.PI)  // на всякий случай покрутим угол
                curAngle = curAngle - 2 * Math.PI;
            while (curAngle < 0)
                curAngle = curAngle + 2 * Math.PI;

            if ((curAngle <= Math.PI / 4) || (curAngle >= 7 * Math.PI / 4)) // летим вправо
                DebugMovingRight(x, y, Math.Tan(curAngle), curAngle);
            else
                if ((curAngle >= 3 * Math.PI / 4) && (curAngle <= 5 * Math.PI / 4)) // летим влево
                    DebugMovingLeft(x, y, -Math.Tan(curAngle), curAngle);
                else
                    if ((curAngle > Math.PI / 4) && (curAngle < 3 * Math.PI / 4)) // летим вверх
                        DebugMovingUp(x, y, 1.0 / Math.Tan(curAngle), curAngle);
                    else
                        if ((curAngle > 5 * Math.PI / 4) && (curAngle < 7 * Math.PI / 4)) // летим вниз
                            DebugMovingDown(x, y, -1.0 / Math.Tan(curAngle), curAngle);
        }

        private void ToFile()
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
            StreamWriter stOut = new StreamWriter(fout);

            for (int i = 0; i < _nMess; i++)
            {
                stOut.WriteLine(_messages[i]);
            }
            stOut.WriteLine();
            stOut.WriteLine();
            stOut.WriteLine();
            stOut.Close();
            fout.Close();
        }

        private void RayTracing(double curAngle, int x, int y)
        {
            if (_stackSize >= 50)
            {
                LedLibrary.BadQuants++;
                ReleaseQuant();

                return;
            }
            _stackSize++;

            while (curAngle >= 2 * Math.PI)  // на всякий случай покрутим угол
                curAngle = curAngle - 2 * Math.PI;
            while (curAngle < 0)
                curAngle = curAngle + 2 * Math.PI;

            if ((curAngle <= Math.PI / 4) || (curAngle >= 7 * Math.PI / 4)) // летим вправо
                MovingRight(x, y, Math.Tan(curAngle), curAngle);
            else
                if ((curAngle >= 3 * Math.PI / 4) && (curAngle <= 5 * Math.PI / 4)) // летим влево
                {
                    MovingLeft(x, y, -Math.Tan(curAngle), curAngle);
                }
                else
                    if ((curAngle > Math.PI / 4) && (curAngle < 3 * Math.PI / 4)) // летим вверх
                    {
                        MovingUp(x, y, 1.0 / Math.Tan(curAngle), curAngle);
                    }
                    else
                        if ((curAngle > 5 * Math.PI / 4) && (curAngle < 7 * Math.PI / 4)) // летим вниз
                        {
                            MovingDown(x, y, -1.0 / Math.Tan(curAngle), curAngle);
                        }
        }

        void RedrawPicture()
        {
            _graphicsSimulatingOfLed.Clear(Color.White);
            OpenGLm.LineDrawPic(_graphicsSimulatingOfLed, 0, LedLibrary.RealW, 0, LedLibrary.RealH);
            OpenGLm.SetMesh(_graphicsSimulatingOfLed);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.DrawRainbow(_graphicsSimulatingOfLed);
        }

        private void DebugEmittingQuants(int count)
        {
            if (_numAct == 0) return;

            RedrawPicture();

            _nMess = 0;

            for (int i = 1; i <= count; i++)
            {
                int r = _rnd.Next(_numAct);
                int x = _active[r].X, y = _active[r].Y, code = LedLibrary.Mas[x, y];
                _xs = x; _ys = y;
                OpenGLm.DrawCircle(_graphicsSimulatingOfLed, x, y); // эффект

                double curAngle = 2 * Math.PI * _rnd.NextDouble();
                PushMessage("Квант возник в точке с координатой X = " + ( (double) (x) / (LedLibrary.W / LedLibrary.WMaxMicr) ) + " мкм; Y = " + ( (double) (y) / (LedLibrary.H / LedLibrary.HMaxMicr) ) + " мкм в " + LedLibrary.Materials[code].Name + ".");
                PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");
                
                _stackSize = 0;
                DebugRayTracing(curAngle, x, y);
                
                if (FormSimulatingInfo.Instance != null)
                    FormSimulatingInfo.Instance.SetCountOfQuants(i);
            }

            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;
        }

        private void ReleaseQuant()
        {
            if (_numAct == 0)
                return;

            int r = _rnd.Next(_numAct);
            int x = _active[r].X, y = _active[r].Y;
            double curAngle = 2 * Math.PI * _rnd.NextDouble();
            _xs = x; _ys = y;
            _nMess = 0;

            //int code = LedLibrary.Mas[x, y];
            //PushMessage("Квант возник в точке с координатой X = " + ((double)(x) / (LedLibrary.W / LedLibrary.WMaxMicr)) + " мкм; Y = " + ((double)(y) / (LedLibrary.H / LedLibrary.HMaxMicr)) + " мкм в " + LedLibrary.Materials[code].Name + ".");
            //PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");

            _stackSize = 0;
            RayTracing(curAngle, x, y);
        } 

        private void EmittingQuants()
        {
            for (int i = 1; i <= LedLibrary.CountOfQuants / LedLibrary.CountOfThread; i++)
            {
                ReleaseQuant();
              
                if (!LedLibrary.IsAsyncCalculation && i % 1000 == 0)
                {
                    LedLibrary.QuantumEff = (double) (LedLibrary.QuantsOut) / i;

                    // выпущено квантов в данный момент
                    if (FormSimulatingInfo.Instance != null)
                        FormSimulatingInfo.Instance.SetCountOfQuants(i);

                    if (FormSimulatingInfo.Instance != null)
                        FormSimulatingInfo.Instance.SetInfoFromVar();

                    if (FormEfficiencyGraph.Instance != null)
                        FormEfficiencyGraph.Instance.SetPoint();

                    Application.DoEvents();
                }
            }
        }

        private void трассировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugEmittingQuants(1);
        }

        private void AsyncCalc()
        {
            Thread[] threads = new Thread[LedLibrary.CountOfThread];
            for (int i = 0; i < LedLibrary.CountOfThread; i++)
            {
                threads[i] = new Thread(EmittingQuants);
                threads[i].Start();
            }


            for (int i = 0; i < LedLibrary.CountOfThread; i++)
            {
                threads[i].Join();
            }

            LedLibrary.QuantumEff = (double)(LedLibrary.QuantsOut) / LedLibrary.CountOfQuants;
        }

        private void LineCalc()
        {
            LedLibrary.CountOfThread = 1;
            EmittingQuants();
        }

        private void начатьМоделированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime timeBefore = DateTime.Now;
            if (LedLibrary.IsAsyncCalculation)
                AsyncCalc();
            else
                LineCalc();
            DateTime timeAfter = DateTime.Now;

            TimeSpan delta = timeAfter - timeBefore;
            MessageBox.Show("Моделирование завершено! \nВремя моделирования: " + delta.TotalSeconds + " секунд.");
        }

        private void показатьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _winReport = new FormReport();
            for (int i = 0; i < _nMess; i++)
                _winReport.toMessBox(_messages[i]);
            _winReport.Show();
        }

        private void показатьРаспределениеСветаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RedrawPicture();
            OpenGLm.DrawLightDistribution(_graphicsSimulatingOfLed);
            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;
        }

        private void показатьЛегендуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLegend formLegend = new FormLegend();
            formLegend.Show();

            MakeLegend();
        }

        private void показатьИнформационнуюПанельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSimulatingInfo formSimulatingInfo = new FormSimulatingInfo();
            formSimulatingInfo.Show();
        }

        private void pbSimulatingOfLed_Click(object sender, EventArgs e)
        {

        }

        private void FormSimulating_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormLegend.Instance != null)
                FormLegend.Instance.Close();
            if (FormSimulatingInfo.Instance != null)
                FormSimulatingInfo.Instance.Close();
        }

        private void FormSimulating_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                DebugEmittingQuants(1);
        }

        private void зависимостьВнешнегоКвантовогоВыходаОтВремениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEfficiencyGraph formEfficiencyGraph = new FormEfficiencyGraph();
            formEfficiencyGraph.Show();
        }
    }
}
