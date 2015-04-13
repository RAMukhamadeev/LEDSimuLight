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
                r = (Var.H / 2) - Var.FrameSensor + 5,
                limit = (int) ( r / Math.Sqrt(2) ),
                sens = Var.SensMat;

            for (int y = y0; y <= y0 + limit; y++)
            {
                int temp = (int) Math.Sqrt(Sqr(r) - Sqr(y - y0));
                int x = x0 + temp;
                Var.Mas[x, y] = sens;
                Var.Mas[x - 1, y] = sens;
                Var.Mas[x - 2, y] = sens;
                Var.Mas[x - 3, y] = sens;
                Var.Mas[x - 4, y] = sens;
                x = x0 - temp;
                Var.Mas[x, y] = sens;
                Var.Mas[x + 1, y] = sens;
                Var.Mas[x + 2, y] = sens;
                Var.Mas[x + 3, y] = sens;
                Var.Mas[x + 4, y] = sens;
            }
            for (int x = x0 - limit; x <= x0 + limit; x++)
            {
                int y = y0 + (int) Math.Sqrt(Sqr(r) - Sqr(x - x0));
                Var.Mas[x, y] = sens;
                Var.Mas[x, y - 1] = sens;
                Var.Mas[x, y - 2] = sens;
                Var.Mas[x, y - 3] = sens;
                Var.Mas[x, y - 4] = sens;
            }
            Var.Mas[x0, y0 + r - 5] = sens;

            for (int y = Var.Border + Var.FrameSensor - 5; y <= Var.Border + Var.H / 2; y++)
            {
                for (int x = Var.Border + Var.FrameSensor - 5; x < Var.Border + Var.FrameSensor; x++)
                    Var.Mas[x, y] = sens;
                for (int x = Var.Border + Var.W - Var.FrameSensor; x < Var.Border + Var.W - Var.FrameSensor + 5; x++)
                    Var.Mas[x, y] = sens;
            }
            for (int y = Var.Border + Var.FrameSensor - 5; y < Var.Border + Var.FrameSensor; y++)
                for (int x = Var.Border + Var.FrameSensor - 5; x <= Var.Border + Var.W - Var.FrameSensor + 4; x++)
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
        }

        private void simulating_Load(object sender, EventArgs e)
        {
            _bmpSimulatingOfLed = new Bitmap(pbSimulatingOfLed.Width, pbSimulatingOfLed.Height);
            _graphicsSimulatingOfLed = Graphics.FromImage(_bmpSimulatingOfLed);

            InsertSensorMaterial();
            OpenGLm.LineDrawPic(_graphicsSimulatingOfLed, 0, Var.RealW, 0, Var.RealH);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.DrawRainbow(_graphicsSimulatingOfLed);
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsSimulatingOfLed);
            pbSimulatingOfLed.Image = _bmpSimulatingOfLed;

            DetectingActiveLayer(4); // i - GaN в базе под номером 4
            InitializeVar();
            MakeLegend();
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
            switch (n)
            {
                case 1:
                    Col1.BackColor = Color.FromArgb( (int)(r * 255), (int) (g*255), (int) (b*255) );
                    elem1.Text = Var.Materials[code].Name;
                    Col1.Visible = true;
                    elem1.Visible = true;
                    break;
                case 2:
                    Col2.BackColor = Color.FromArgb( (int)(r * 255), (int) (g*255), (int) (b*255) );
                    elem2.Text = Var.Materials[code].Name;
                    Col2.Visible = true;
                    elem2.Visible = true;
                    break;
                case 3:
                    Col3.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem3.Text = Var.Materials[code].Name;
                    Col3.Visible = true;
                    elem3.Visible = true;
                    break;
                case 4:
                    Col4.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem4.Text = Var.Materials[code].Name;
                    Col4.Visible = true;
                    elem4.Visible = true;
                    break;
                case 5:
                    Col5.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem5.Text = Var.Materials[code].Name;
                    Col5.Visible = true;
                    elem5.Visible = true;
                    break;
                case 6:
                    Col6.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem6.Text = Var.Materials[code].Name;
                    Col6.Visible = true;
                    elem6.Visible = true;
                    break;
                case 7:
                    Col7.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem7.Text = Var.Materials[code].Name;
                    Col7.Visible = true;
                    elem7.Visible = true;
                    break;
                case 8:
                    Col8.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem8.Text = Var.Materials[code].Name;
                    Col8.Visible = true;
                    elem8.Visible = true;
                    break;
                case 9:
                    Col9.BackColor = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
                    elem9.Text = Var.Materials[code].Name;
                    Col9.Visible = true;
                    elem9.Visible = true;
                    break;
            }
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

            if (y > y0)
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
                if (x <= Var.Border + Var.FrameSensor)
                {
                    num = y / Var.SideSector;
                    Var.LeftBright[num]++;
                    Var.QuantsLeft++;
                }
                else
                    if (y <= Var.Border + Var.FrameSensor)
                    {
                        num = x / Var.SideSector;
                        Var.FloorBright[num]++;
                        Var.QuantsBack++;
                    }
                    else
                        if (x >= Var.W + Var.Border - Var.FrameSensor)
                        {
                            num = y / Var.SideSector;
                            Var.RightBright[num]++;
                            Var.QuantsRight++;
                        }
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
          //      pushMessage("Квант поглотился в материале " + var.materials[code0].name);
                return;
            }
            _xs = x; 
            _ys = y;
            if (Var.Mas[x, y] == Var.SensMat)
            {
                CalcSector(x, y);
         //     pushMessage("Квант захвачен сенсором.");
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
           //     pushMessage("Квант претерпел отражение от " + var.materials[code].name + "; угол стал равен " + toDegree(new_alpha) + " градусов.");
                RayTracing(newAlpha, x0, y0);
            }
            else
            {
                double newAlpha = CalculateFraction(angle, beta, n, n1);
            //    pushMessage("Квант достиг " + var.materials[code].name + " и претерпел преломление; угол стал равен " + toDegree(new_alpha) + " градусов.");
                RayTracing(newAlpha, x, y);
            }
        }

        private void PutVertex(int x, int y, char status)
        {
            int ost = 0,
                mod = 7 * Var.PrecKoeff;
            Color col = Color.Black;
            if (status == 'l' || status == 'r')
            {
                ost = x % (mod * 2);
                if (ost < mod)
                    col = Color.Black;
                else
                    col = Color.Yellow;
            }
            if (status == 'd' || status == 'u')
            {
                ost = y % (mod * 2);
                if (ost < mod)
                    col = Color.Black;
                else
                    col = Color.Yellow;
            }

            OpenGLm.DrawPoint(_graphicsSimulatingOfLed, x, y);
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
            if (_stackSize >= 50)
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
            //OpenGLm.LineDrawPic(0, Var.W, 0, Var.H);
            //OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            //OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsSimulatingOfLed);

            _nMess = 0;

            for (int i = 1; i <= count; i++)
            {
                int r = _rnd.Next(_numAct);
                int x = _active[r].X, y = _active[r].Y, code = Var.Mas[x, y];
                _xs = x; _ys = y;
                OpenGLm.Explosion(_graphicsSimulatingOfLed, x, y); // эффект

                double curAngle = 2 * Math.PI * _rnd.NextDouble();
                PushMessage("Квант возник в точке с координатой X = " + ( (double) (x) / (Var.W / Var.WMaxMicr) ) + " мкм; Y = " + ( (double) (y) / (Var.H / Var.HMaxMicr) ) + " мкм в " + Var.Materials[code].Name + ".");
                PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");
                
                _stackSize = 0;
                DebugRayTracing(curAngle, x, y);
                label4.Text = i.ToString();
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
                    double effShow = Math.Floor(Var.QuantumEff * 1000000) / 1000000;
                    label4.Text = i.ToString(); // выпущено квантов в данный момент
                    label12.Text = Var.QuantsOut.ToString();
                    label13.Text = Var.QuantsFront.ToString();
                    label16.Text = Var.QuantAbsorbed.ToString();
                    label15.Text = effShow.ToString();
                    label18.Text = Var.QuantsBack.ToString();
                    label20.Text = Var.QuantsLeft.ToString();
                    label22.Text = Var.QuantsRight.ToString();
                    panel2.Refresh();

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
            MessageBox.Show(Var.BadQuants.ToString());
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

        private void одиночныйКвантToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _winReport = new FormReport();

            //OpenGLm.LineDrawPic(0, Var.W, 0, Var.H);
            OpenGLm.DrawSensors(_graphicsSimulatingOfLed);
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsSimulatingOfLed);
            _nMess = 0;
            _isLucky = true;

            double curAngle = Math.PI*200/180;
            int x = 50*5, y = 50*6;

            _xs = x;
            _ys = y;
            int code = Var.Mas[x, y];
            PushMessage("Квант возник в точке с координатой X = " + ((double) (x)/(Var.W/Var.WMaxMicr)) + " мкм; Y = " +
                        ((double) (y)/(Var.H/Var.HMaxMicr)) + " мкм в " + Var.Materials[code].Name + ".");
            PushMessage("Начальный угол равен = " + ToDegree(curAngle) + " градусов.");
            _stackSize = 0;
            OpenGLm.Explosion(_graphicsSimulatingOfLed, x, y); // эффект
            DebugRayTracing(curAngle, x, y);
        }

    }
}
