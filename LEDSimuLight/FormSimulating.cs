using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormSimulating : Form
    {
        readonly Var.Point[] _active = new Var.Point[Var.W * Var.H]; // здесь внимательно! может быть переполнение
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
            int x0 = Var.Border + Var.W / 2,
                y0 = Var.Border + Var.H / 2,
                sens = Var.SensMat;

            double a = x0 - Var.Border;
            double b = Var.RealH - y0 - Var.Border;

            for (int y = y0; y <= Var.RealH; y++)
                for (int x = 0; x <= Var.RealW; x++)
                {
                    double koeff1 = Math.Pow((x - x0) / a, 2) + Math.Pow((y - y0) / b, 2);
                    double koeff2 = Math.Pow((x - x0) / (a - Var.FrameSensor), 2) + Math.Pow((y - y0) / (b - Var.FrameSensor), 2);
                    if (koeff1 < 1 && koeff2 > 1)
                        Var.Mas[x, y] = sens;
                }

            for (int y = Var.Border; y <= Var.Border + Var.H / 2; y++)
            {
                for (int x = Var.Border; x < Var.Border + Var.FrameSensor; x++)
                    Var.Mas[x, y] = sens;
                for (int x = Var.Border + Var.W - Var.FrameSensor; x < Var.Border + Var.W; x++)
                    Var.Mas[x, y] = sens;
            }
            for (int y = Var.Border; y < Var.Border + Var.FrameSensor; y++)
                for (int x = Var.Border; x <= Var.Border + Var.W; x++)
                    Var.Mas[x, y] = sens;
        }

        private static void InitializeVar()
        {
            Var.QuantAbsorbed = 0;
            Var.QuantsBack = 0;
            Var.QuantsFront = 0;
            Var.QuantsLeft = 0;
            Var.QuantsOut = 0;
            Var.QuantsRight = 0;
            Var.QuantumEff = 0;
            Var.BadQuants = 0;

            Array.Clear(Var.LeftBright, 0, Var.LeftBright.Length);
            Array.Clear(Var.RightBright, 0, Var.RightBright.Length);
            Array.Clear(Var.CircleBright, 0, Var.CircleBright.Length);
            Array.Clear(Var.FloorBright, 0, Var.FloorBright.Length);
        }

        private void simulating_Load(object sender, EventArgs e)
        {
            _bmpSimulatingOfLed = new Bitmap(pbSimulatingOfLed.Width, pbSimulatingOfLed.Height);
            _graphicsSimulatingOfLed = Graphics.FromImage(_bmpSimulatingOfLed);

            InsertSensorMaterial();
            OpenGLm.LineDrawPic(_graphicsSimulatingOfLed, 0, Var.RealW, 0, Var.RealH);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.DrawRainbow(_graphicsSimulatingOfLed);
            OpenGLm.SetMesh(_graphicsSimulatingOfLed);
            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;

            DetectingActiveLayer(4); // i - GaN в базе под номером 4
            InitializeVar();
        }

        private void DetectingActiveLayer(int num) // в дальнейшем массив
        {
            for (int x = 0; x <= Var.W; x++)
                for (int y = 0; y <= Var.H; y++)
                    if (Var.Mas[x, y] == num)
                        _active[_numAct++] = new Var.Point(x, y);
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
            used[Var.SensMat] = true; // сенсоры на легенде не нужны

            int count = 0;
            for (int x = 0; x <= Var.W; x++)
                for (int y = Var.H; y >= 0; y--)
                {
                    int code = Var.Mas[x, y];
                    if (!used[code])
                    {
                        count++;
                        used[code] = true;
                        AddMaterial(count, code, Var.Materials[code].R, Var.Materials[code].G, Var.Materials[code].B);
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

            double l1 = (double) ( Var.WMaxMicr * (x - _xs) ) / Var.W,
                   l2 = (double) ( Var.HMaxMicr * (y - _ys) ) / Var.H,
                   len = Math.Sqrt(Sqr(l1) + Sqr(l2)),
                   transmission = 1 - Var.Materials[code].Absorption,
                   aliveProb = Math.Pow(transmission, len),
                   absProb = 1 - aliveProb;
            return _rnd.NextDouble() <= absProb;
        }

        private double RoughAngle(int x, int y) // x - x0, y - y0
        {
            double res = 0;

            int xl = x - 4 * Var.PrecKoeff, xr = x + 4 * Var.PrecKoeff;
            double yl = 0, yr = 0;
            int code0L = Var.Mas[xl, y], code0R = Var.Mas[xr, y];

            int delta = 0;
            while (code0L == Var.Mas[xl, Math.Max(y - delta, 0)] && code0L == Var.Mas[xl, Math.Min(y + delta, Var.H)] && delta < Var.H)
               delta++;
            if (code0L != Var.Mas[xl, Math.Max(y - delta, 0)])
                 yl = y - delta + 0.5;
            if (code0L != Var.Mas[xl, Math.Min(y + delta, Var.H)])
                 yl = y + delta - 0.5;

             delta = 0;
             while (code0R == Var.Mas[xr, Math.Max(y - delta, 0)] && code0R == Var.Mas[xr, Math.Min(y + delta, Var.H)] && delta < Var.H)
                 delta++;
             if (code0R != Var.Mas[xr, Math.Max(y - delta, 0)])
                 yr = y - delta + 0.5;
             if (code0R != Var.Mas[xr, Math.Min(y + delta, Var.H)])
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

            if (code == 9) // Зеркало
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
            int x0 = Var.Border + Var.W / 2,
                y0 = Var.Border + Var.H / 2,
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

                int num = alpha / Var.DiscreteAngle; // вычисляем сектор
                Var.CircleBright[num]++;
                Var.QuantsFront++;
            }
            else
            {
                int num = 0;
                if (x <= Var.Border + Var.FrameSensor + delta)
                {
                    num = y / Var.SideSector;
                    Var.LeftBright[num]++;
                    Var.QuantsLeft++;
                }
                else
                    if (y <= Var.Border + Var.FrameSensor + delta)
                    {
                        num = x / Var.SideSector;
                        Var.FloorBright[num]++;
                        Var.QuantsBack++;
                    }
                    else
                        if (x >= Var.W + Var.Border - Var.FrameSensor - delta)
                        {
                            num = y / Var.SideSector;
                            Var.RightBright[num]++;
                            Var.QuantsRight++;
                        }
                        //else
                        //    MessageBox.Show("Не найден сектор!!!");
            }
        }

        private void DebugReemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {
            if (Absorbed(code0, x, y))
            {
                Var.QuantAbsorbed++;
                PushMessage("Квант поглотился в материале " + Var.Materials[code0].Name);
                return;
            }
            _xs = x;
            _ys = y;

            int code = Var.Mas[x, y];
            double n1 = Var.Materials[code].Fraction,
                   n = Var.Materials[code0].Fraction;

            if (Var.Mas[x, y] == Var.SensMat)
            {
                PushMessage("Квант захвачен сенсором.");
                CalcSector(x, y);
                return;
            }

            double beta = RoughAngle(x0, y0);

            if (IsReflection(angle, beta, n, n1, code))
            {
                double newAlpha = CalculateReflection(angle, beta);
                PushMessage("Квант претерпел отражение от " + Var.Materials[code].Name + "; угол стал равен " + ToDegree(newAlpha) + " градусов.");
                DebugRayTracing(newAlpha, x0, y0);
            }
            else
            {
                double newAlpha = CalculateFraction(angle, beta, n, n1);
                PushMessage("Квант достиг " + Var.Materials[code].Name + " и претерпел преломление; угол стал равен " + ToDegree(newAlpha) + " градусов.");
                DebugRayTracing(newAlpha, x, y);
            }
        }

        private void Reemit(int code0, int x, int y, int x0, int y0, double angle, char vector)
        {

            if ( Absorbed(code0, x, y) )
            {
                Var.QuantAbsorbed++;
                return;
            }
            _xs = x; 
            _ys = y;
            if (Var.Mas[x, y] == Var.SensMat)
            {
                CalcSector(x, y);
                Var.QuantsOut++;
                return;
            }


            int code = Var.Mas[x, y];
            double n1 = Var.Materials[code].Fraction,
                   n = Var.Materials[code0].Fraction;

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
            int mod = Var.H / 50;

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
            int code0 = Var.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == Var.Mas[x, y] || (x - oldX) < Step)
            {
                PutVertex(x, y, 'r');
                x++;
                shift += delta;
                y = (int) shift;
            }

            int x0 = x - 1;
            int y0 = (int)(shift - delta);

            if (y < Var.H && y > 0 && x < Var.W && code0 != Var.Mas[x, y])
                DebugReemit(code0, x, y, x0, y0, angle, 'r');
        }

        private void MovingRight(int x, int y, double delta, double angle)
        {
            int code0 = Var.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == Var.Mas[x, y] || (x - oldX) < Step)
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
            int code0 = Var.Mas[x, y], oldX = x;
            double shift = y;
             while (code0 == Var.Mas[x, y] || (oldX - x) < Step)
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
            int code0 = Var.Mas[x, y], oldX = x;
            double shift = y;
            while (code0 == Var.Mas[x, y] || (oldX - x) < Step)
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
            int code0 = Var.Mas[x, y];
            double shift = x;
            while (code0 == Var.Mas[x, y])
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
            int code0 = Var.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == Var.Mas[x, y] || (y - oldY) < Step)
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
            int code0 = Var.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == Var.Mas[x, y] || (oldY - y) < Step)
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
            int code0 = Var.Mas[x, y], oldY = y;
            double shift = x;
            while (code0 == Var.Mas[x, y] || (oldY - y) < Step)
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
                PushMessage("Квант поглотился в материале " + Var.Materials[Var.Mas[x, y]].Name);
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
            if (_stackSize >= 100)
            {
                Var.BadQuants++;
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

        private void DebugEmittingQuants(int count)
        {
            _graphicsSimulatingOfLed.Clear(Color.White);
            OpenGLm.LineDrawPic(_graphicsSimulatingOfLed, 0, Var.RealW, 0, Var.RealH);
            OpenGLm.SetMesh(_graphicsSimulatingOfLed);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.DrawRainbow(_graphicsSimulatingOfLed);

            _nMess = 0;

            for (int i = 1; i <= count; i++)
            {
                int r = _rnd.Next(_numAct);
                int x = _active[r].X, y = _active[r].Y, code = Var.Mas[x, y];
                _xs = x; _ys = y;
                OpenGLm.DrawCircle(_graphicsSimulatingOfLed, x, y); // эффект

                double curAngle = 2 * Math.PI * _rnd.NextDouble();
                PushMessage("Квант возник в точке с координатой X = " + ( (double) (x) / (Var.W / Var.WMaxMicr) ) + " мкм; Y = " + ( (double) (y) / (Var.H / Var.HMaxMicr) ) + " мкм в " + Var.Materials[code].Name + ".");
                PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");
                
                _stackSize = 0;
                DebugRayTracing(curAngle, x, y);
                
                if (FormSimulatingInfo.Instance != null)
                    FormSimulatingInfo.Instance.SetCountOfQuants(i.ToString());
            }

            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;
        }

        private void ReleaseQuant()
        {
            int r = _rnd.Next(_numAct);
            int x = _active[r].X, y = _active[r].Y, code = Var.Mas[x, y];
            double curAngle = 2 * Math.PI * _rnd.NextDouble();
            _xs = x; _ys = y;
            _nMess = 0;

            PushMessage("Квант возник в точке с координатой X = " + ((double)(x) / (Var.W / Var.WMaxMicr)) + " мкм; Y = " + ((double)(y) / (Var.H / Var.HMaxMicr)) + " мкм в " + Var.Materials[code].Name + ".");
            PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");

            _stackSize = 0;
            RayTracing(curAngle, x, y);
        } 

        private void EmittingQuants(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                ReleaseQuant();
              
                if (i % 1000 == 0)
                {
                    Var.QuantumEff = (double) (Var.QuantsOut) / i;

                    // выпущено квантов в данный момент
                    if (FormSimulatingInfo.Instance != null)
                        FormSimulatingInfo.Instance.SetCountOfQuants(i.ToString());

                    if (FormSimulatingInfo.Instance != null)
                        FormSimulatingInfo.Instance.SetInfoFromVar();

                    Application.DoEvents();
                }
            }
        }

        private void трассировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugEmittingQuants(1);
        }

        private void начатьМоделированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmittingQuants(300000);
            //MessageBox.Show(Var.BadQuants.ToString());
        }

        private void simulating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space)
                DebugEmittingQuants(1);
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
    }
}
