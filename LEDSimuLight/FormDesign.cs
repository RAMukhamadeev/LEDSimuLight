using System;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormDesign : Form
    {
        Var.Point _currPoint = new Var.Point(0, 0);
        readonly Var.Point[] _masPoints = new Var.Point[100];
        readonly Line[] _lines = new Line[100];
        string _material = "", _shape = "";
        int _click = 0, _oldClick = 0;

        private Graphics _graphicsDesignOfLed;
        private Bitmap _bmpDesignOfLed;

        private class Line
        {
            public Line(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }
            public double A, B, C;
        }

        public FormDesign()
        {
            InitializeComponent();
        }

        private void design_Load(object sender, EventArgs e)
        {
            _bmpDesignOfLed = new Bitmap(pbDesignOfLed.Width, pbDesignOfLed.Height);
            _graphicsDesignOfLed = Graphics.FromImage(_bmpDesignOfLed);
            
            Var.PicH = pbDesignOfLed.Height;
            Var.PicW = pbDesignOfLed.Width;
            Var.Border = 50;
            Var.H = Var.PicH - Var.Border * 2;
            Var.W = Var.PicW - Var.Border * 2;
            Var.SideSector = (int)((Var.W / Var.WMaxMicr) * Var.DivOfLightCirc * Math.PI * (Var.HMaxMicr / 2) / 180);

            //OpenGLm.LineDrawPic(0, Var.W, 0, Var.H);
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);

            pbDesignOfLed.Image = _bmpDesignOfLed;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void DrawRightAngleRect(int y1, int y2, int x2, int x3, int col)
        {
            for (int i = y1; i <= y2; i++)
                for (int j = x2; j <= x3; j++)
                    Var.Mas[j, i] = col;
        }

        private int GetX(double x)
        {
            int res = (int) ((x / Var.WMaxMicr) * Var.W);
            return res;
        }

        private int GetY(double y)
        {
            int res = (int) ((y / Var.HMaxMicr) * Var.H);
            return res;
        }

        private Line MakeLine(double x0, double y0, double x1, double y1)
        {
            Line res = new Line(y1 - y0, x0 - x1, x0*(y0 - y1) + y0*(x1 - x0) );
            return res;
        }

        private bool PointIn(int x, int y, int click)
        {
            bool plus = false, minus = false;

            for (int i = 1; i <= click; i++)
            {
                double sign = _lines[i].A * x + _lines[i].B * y + _lines[i].C;
                if (sign < 0)
                    minus = true;
                if (sign > 0)
                    plus = true;
            }

            if ((plus && !minus) || (!plus && minus))
                return true;
            return false;
        }

        private void RemovePolygon()
        {
            for (int i = 1; i < _oldClick; i++) // делаем массив линий
                _lines[i] = MakeLine(_masPoints[i].X, _masPoints[i].Y, _masPoints[i + 1].X, _masPoints[i + 1].Y);
            _lines[_oldClick] = MakeLine(_masPoints[_oldClick].X, _masPoints[_oldClick].Y, _masPoints[1].X, _masPoints[1].Y);

            for (int x = 0; x <= Var.W; x++)
                for (int y = 0; y <= Var.H; y++)
                    if (PointIn(x, y, _oldClick))
                        Var.Mas[x, y] = 0;

            OpenGLm.LineDrawPic(0, Var.W, 0, Var.H); // рисуем на экране
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);

            _oldClick = 0;
        }

        private void DrawPolygon(int code)
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


            for (int i = 1; i < _click; i++) // делаем массив линий
                _lines[i] = MakeLine(_masPoints[i].X, _masPoints[i].Y, _masPoints[i + 1].X, _masPoints[i + 1].Y);
            _lines[_click] = MakeLine(_masPoints[_click].X, _masPoints[_click].Y, _masPoints[1].X, _masPoints[1].Y);

            for (int x = 0; x <= Var.W; x++)
                for (int y = 0; y <= Var.H; y++)
                    if (PointIn(x, y, _click))
                        Var.Mas[x, y] = code;

            OpenGLm.LineDrawPic(0, Var.W, 0, Var.H); // рисуем на экране
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);

            _oldClick = _click;
            _click = 0;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Конструкция светодиода (*.LED)|*.LED";
            saveFileDialog1.FileName = "Конструкция светодиода";
            DialogResult drs = saveFileDialog1.ShowDialog();
            if (drs == DialogResult.OK)
                Var.SaveToBinFile(saveFileDialog1.FileName);
        }

        private int GetMouseX()
        {
            return  MousePosition.X - ActiveForm.Location.X - 388;
        }
        private int GetMouseY()
        {
            return 621 - MousePosition.Y + ActiveForm.Location.Y;
        }

        private void MakePolygon(int code)
        {
            _click++;
            _masPoints[_click] = new Var.Point(_currPoint.X, _currPoint.Y);
            X1.Text = ToMicr(_currPoint.X).ToString();
            Y1.Text = ToMicr(_currPoint.Y).ToString();

            if (_click >= 3 && _masPoints[1].X == _currPoint.X && _masPoints[1].Y == _currPoint.Y)
                DrawPolygon(code);
        }

        private void RemoveCircle()
        {
            int quadR = Dist(_masPoints[1], _masPoints[2]),
                r = (int)Math.Sqrt(quadR);

            Var.Point p = new Var.Point(0, 0);

            for (int x = _masPoints[1].X - r; x <= _masPoints[1].X + r; x++)
                for (int y = _masPoints[1].Y - r; y <= _masPoints[1].Y + r; y++)
                {
                    p.X = x; p.Y = y;
                    if (Dist(_masPoints[1], p) <= quadR)
                        Var.Mas[x, y] = 0;
                }


            OpenGLm.LineDrawPic(0, Var.W, 0, Var.H); // рисуем на экране
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);

            _oldClick = 0;
        }

        private void DrawCircle(int code)
        {
            int quadR = Dist(_masPoints[1], _masPoints[2]),
                r = (int) Math.Sqrt(quadR);

            Var.Point p = new Var.Point(0, 0);

            for (int x = Math.Max(_masPoints[1].X - r, 0); x <= Math.Min(_masPoints[1].X + r, Var.W); x++)
                for (int y = Math.Max(_masPoints[1].Y - r, 0); y <= Math.Min(_masPoints[1].Y + r, Var.H); y++)
                {
                    p.X = x; p.Y = y;
                    if (Dist(_masPoints[1], p) <= quadR)
                        Var.Mas[x, y] = code;
                }


            OpenGLm.LineDrawPic(0, Var.W, 0, Var.H); // рисуем на экране
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);
            _oldClick = _click;
            _click = 0;    
        }

        private void MakeCircle(int code)
        {
            _click++;
            _masPoints[_click] = new Var.Point(_currPoint.X, _currPoint.Y);
            X1.Text = ToMicr(_currPoint.X).ToString();
            Y1.Text = ToMicr(_currPoint.Y).ToString();

            if (_click == 2)
            {
                DrawCircle(code);
            }
        }

        private void AnT_Click(object sender, EventArgs e)
        {
            int code = 0;
            for (int i = 0; i < Var.NumOfMatr; i++)
                if (Var.Materials[i].Name == _material)
                    code = i;
            if (_shape == "Многоугольник")
                MakePolygon(code);
            if (_shape == "Окружность")
                MakeCircle(code);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Конструкция светодиода (*.LED)|*.LED";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "*.LED")
            {
                Var.OpenBinFile(openFileDialog1.FileName);
                OpenGLm.LineDrawPic(0, Var.W, 0, Var.H);
                OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);
            }
        }

        private static int Sqr(int x)
        {
            return x * x;
        }

        private int Dist(Var.Point p1, Var.Point p2)
        {
            return Sqr(p2.X - p1.X) + Sqr(p2.Y - p1.Y);
        }

        private double ToMicr(int x)
        {
            return x / 50.0;
        }

        private void PutCross(Var.Point p, int x1, int x2, int y1, int y2)
        {
            OpenGLm.LineDrawPic(_nowX1 - 50 * Var.PrecKoeff, _nowX1 + 50 * Var.PrecKoeff, _nowY1 - 50 * Var.PrecKoeff, _nowY1 + 50 * Var.PrecKoeff);
            OpenGLm.SetMesh(Var.WMaxMicr, Var.HMaxMicr, _graphicsDesignOfLed);
            OpenGLm.DrawSegment(_click, _masPoints);
            OpenGLm.DrawCross(p.X, p.Y);

            label6.Text = ToMicr(p.X).ToString() + " мкм";
            label7.Text = ToMicr(p.Y).ToString() + " мкм";
            panel3.Refresh();
        }

        private void siToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "Si";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void al2O3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "Al2O3";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void gaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "GaN";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void inGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "InGaN";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void iGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "i-GaN";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void металлическийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "металлический контакт";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void отражательБрэггаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "отражатель Брэгга";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void pGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "p-GaN";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void nGaNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "n-GaN";

            label15.Text = _material;
            panel_input.Refresh();
        }

        int _nowX1 = 0, _nowY1 = 0, _count = 0;

        private void LinkToVertex(int step)
        {
            Var.Point[] masPoint = new Var.Point[4];
            int x1 = (GetMouseX() / step) * step,
                y1 = (GetMouseY() / step) * step,
                x2 = x1 + step,
                y2 = y1 + step;
            Var.Point curr = new Var.Point(x1, y1);

            if (_nowX1 != x1 || _nowY1 != y1)
            {
                _count = 0;
                _nowX1 = x1;
                _nowY1 = y1;
            }
            else
            {
                _count++;
                if (_count < 3)
                    return;
            }

            masPoint[0] = new Var.Point(x1, y1);
            masPoint[1] = new Var.Point(x1, y2);
            masPoint[2] = new Var.Point(x2, y2);
            masPoint[3] = new Var.Point(x2, y1);

            int min = 1000000, minPos = -1;
            for (int i = 0; i < 4; i++)
            {
                int d = Dist(curr, masPoint[i]);
                if (d < min)
                {
                    min = d;
                    minPos = i;
                }
            }

            if (Dist(masPoint[minPos], curr) < Dist(_currPoint, curr))
            {
                PutCross(masPoint[minPos], x1 - 10*step, x2 + 10*step, y1 - 10*step, y2 + 10*step);
                _currPoint = new Var.Point(masPoint[minPos].X, masPoint[minPos].Y);
            }
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            int x = GetMouseX(),
                y = GetMouseY();

            if (x > 0 && x < Var.W && y > 0 && y < Var.H)
               LinkToVertex(Var.W / 100);
        }

        private void пустотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "Пустота";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void рельефToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shape = "Окружность";
            label11.Text = _shape;
        }

        private void siO2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "SiO2";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void iTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _material = "ITO";

            label15.Text = _material;
            panel_input.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void многоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shape = "Многоугольник";
            label11.Text = _shape;
        }

        private void удалитьПоследнююФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_oldClick == 2)
                RemoveCircle();
            if (_oldClick > 2)
                RemovePolygon();
        }

    }
}
