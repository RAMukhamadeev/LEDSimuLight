using System;
using System.Drawing;
using System.Windows.Forms;

namespace LEDSimuLight
{
    public partial class FormDesign : Form
    {
        /// <summary>
        /// текущая точка под курсором
        /// </summary>
        readonly LedLibrary.Point _currPoint = new LedLibrary.Point(0, 0);
        /// <summary>
        /// массив хранит точки текущей отрисовываемой пользователем фигуры
        /// </summary>
        readonly LedLibrary.Point[] _masPoints = new LedLibrary.Point[100];

        readonly Line[] _lines = new Line[100];
        string _material = "", _shape = "";
        int _click, _oldClick;

        private Graphics _graphicsDesignOfLed;

        private Bitmap _bmpDesignOfLed,
            _bmpOriginalPicture;

        private class Line
        {
            public Line(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }
            public readonly double A, B, C;
        }

        public FormDesign()
        {
            InitializeComponent();
        }

        void PreparePictureForView()
        {
            LedLibrary.InitVariables(pbDesignOfLed.Width, pbDesignOfLed.Height);
            RedrawPicture();
            pbDesignOfLed.Image = _bmpDesignOfLed;
        }

        void LoadMaterialToMenu()
        {
            ToolStripItemCollection tsic = выбратьМатериалToolStripMenuItem.DropDownItems;

            int pos = 0;
            foreach (var next in LedLibrary.Materials)
            {
                tsic.Add(next.Name);
                tsic[pos++].Click += MaterialItem_Click;
            }
        }

        private void MaterialItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            _material = tsmi.Text;
            if (FormDesignInfo.Instance != null)
                FormDesignInfo.Instance.SetMaterial(_material);
        }

        private void design_Load(object sender, EventArgs e)
        {
            PreparePictureForView();
            LoadMaterialToMenu();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null) ActiveForm.Close();
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

            for (int x = 0; x <= LedLibrary.W; x++)
                for (int y = 0; y <= LedLibrary.H; y++)
                    if (PointIn(x, y, _oldClick))
                        LedLibrary.Mas[x, y] = 0;

            _oldClick = 0;
        }

        private void DrawPolygon(int code)
        {
            // создаем массив линий
            for (int i = 1; i < _click; i++)
                _lines[i] = MakeLine(_masPoints[i].X, _masPoints[i].Y, _masPoints[i + 1].X, _masPoints[i + 1].Y);
            _lines[_click] = MakeLine(_masPoints[_click].X, _masPoints[_click].Y, _masPoints[1].X, _masPoints[1].Y);

            for (int x = LedLibrary.Border; x <= LedLibrary.RealW - LedLibrary.Border; x++)
                for (int y = LedLibrary.Border; y <= LedLibrary.RealH - LedLibrary.Border; y++)
                    if (PointIn(x, y, _click))
                        LedLibrary.Mas[x, y] = code;

            _oldClick = _click;
            _click = 0;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Конструкция светодиода (*.LED)|*.LED";
            svf.FileName = "Конструкция светодиода";
            DialogResult drs = svf.ShowDialog();
            if (drs == DialogResult.OK)
                LedLibrary.SaveToBinFile(svf.FileName);
        }

        private void MakePolygon(int code)
        {
            _click++;
            _masPoints[_click] = new LedLibrary.Point(_currPoint.X, _currPoint.Y);

            if (_click >= 3 && _masPoints[1].X == _currPoint.X && _masPoints[1].Y == _currPoint.Y)
                DrawPolygon(code);
        }

        private void RemoveCircle()
        {
            int quadR = LedLibrary.Dist(_masPoints[1], _masPoints[2]),
                r = (int)Math.Sqrt(quadR);

            LedLibrary.Point p = new LedLibrary.Point(0, 0);

            for (int x = _masPoints[1].X - r; x <= _masPoints[1].X + r; x++)
                for (int y = _masPoints[1].Y - r; y <= _masPoints[1].Y + r; y++)
                {
                    p.X = x; p.Y = y;
                    if (LedLibrary.Dist(_masPoints[1], p) <= quadR)
                        LedLibrary.Mas[x, y] = 0;
                }

            _oldClick = 0;
        }

        private void DrawCircle(int code)
        {
            int quadR = LedLibrary.Dist(_masPoints[1], _masPoints[2]),
                r = (int) Math.Sqrt(quadR);

            LedLibrary.Point p = new LedLibrary.Point(0, 0);

            for (int x = Math.Max(_masPoints[1].X - r, LedLibrary.Border); x <= Math.Min(_masPoints[1].X + r, LedLibrary.RealW - LedLibrary.Border); x++)
                for (int y = Math.Max(_masPoints[1].Y - r, LedLibrary.Border); y <= Math.Min(_masPoints[1].Y + r, LedLibrary.RealH - LedLibrary.Border); y++)
                {
                    p.X = x; p.Y = y;
                    if (LedLibrary.Dist(_masPoints[1], p) <= quadR)
                        LedLibrary.Mas[x, y] = code;
                }

            _oldClick = _click;
            _click = 0;    
        }

        private void MakeCircle(int code)
        {
            _click++;
            _masPoints[_click] = new LedLibrary.Point(_currPoint.X, _currPoint.Y);

            if (_click == 2)
            {
                DrawCircle(code);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Конструкция светодиода (*.LED)|*.LED";
            ofd.ShowDialog();
            if (ofd.FileName != "*.LED" && ofd.FileName != "")
            {
                LedLibrary.OpenBinFile(ofd.FileName);
                RedrawPicture();
            }
        }

        private LedLibrary.Point NearestPoint(int x, int y)
        {
            const int step = 2;

            LedLibrary.Point[] masPoint = new LedLibrary.Point[4];
            int x1 = (x / step) * step,
                y1 = (y / step) * step,
                x2 = x1 + step,
                y2 = y1 + step;

            masPoint[0] = new LedLibrary.Point(x1, y1);
            masPoint[1] = new LedLibrary.Point(x1, y2);
            masPoint[2] = new LedLibrary.Point(x2, y2);
            masPoint[3] = new LedLibrary.Point(x2, y1);

            int min = Int32.MaxValue, minPos = -1;
            LedLibrary.Point curr = new LedLibrary.Point(x1, y1);
            for (int i = 0; i < 4; i++)
            {
                int d = LedLibrary.Dist(curr, masPoint[i]);
                if (d < min)
                {
                    min = d;
                    minPos = i;
                }
            }

            LedLibrary.Point res = new LedLibrary.Point(masPoint[minPos].X, masPoint[minPos].Y);
            return res;
        }

        private void RedrawPicture()
        {
            if (_bmpDesignOfLed == null)
            {
                _bmpDesignOfLed = new Bitmap(pbDesignOfLed.Width, pbDesignOfLed.Height);
                _graphicsDesignOfLed = Graphics.FromImage(_bmpDesignOfLed);   
            }

            _graphicsDesignOfLed.Clear(Color.White);
            OpenGLm.LineDrawPic(_graphicsDesignOfLed, 0, LedLibrary.RealW, 0, LedLibrary.RealH);
            OpenGLm.SetMesh(_graphicsDesignOfLed);
            OpenGLm.DrawSegment(_graphicsDesignOfLed, _click, _masPoints);

            _bmpOriginalPicture = (Bitmap) _bmpDesignOfLed.Clone();
        }

        private void рельефToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shape = "Окружность";
            if (FormDesignInfo.Instance != null) 
                FormDesignInfo.Instance.SetShape(_shape);
        }

        private void многоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shape = "Многоугольник";
            if (FormDesignInfo.Instance != null) 
                FormDesignInfo.Instance.SetShape(_shape);
        }

        private void удалитьПоследнююФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_oldClick == 2)
                RemoveCircle();
            if (_oldClick > 2)
                RemovePolygon();
            RedrawPicture();
            pbDesignOfLed.Image = _bmpDesignOfLed;
        }

        void RemoveSprite(int x, int y)
        {
            y = LedLibrary.RealH - y;
            int delta = 15;
            for (int i = x - delta; i <= x + delta; i++)
                for (int j = y - delta; j <= y + delta; j++)
                    if (i >= 0 && j >= 0 && i < _bmpOriginalPicture.Width && j < _bmpOriginalPicture.Height)
                        _bmpDesignOfLed.SetPixel(i, j, _bmpOriginalPicture.GetPixel(i, j));
        }

        private void pbDesignOfLed_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X,
                y = LedLibrary.RealH - e.Y;
            LedLibrary.Point min = NearestPoint(x, y);
            if (min.X == _currPoint.X && min.Y == _currPoint.Y)
                return;

            RemoveSprite(_currPoint.X, _currPoint.Y);
            OpenGLm.DrawCross(_graphicsDesignOfLed, min.X, min.Y, 15, 3);
            _currPoint.X = min.X;
            _currPoint.Y = min.Y;

            if (FormDesignInfo.Instance != null)
                FormDesignInfo.Instance.SetCoordinates(LedLibrary.ToMicrX(min.X) + " мкм", LedLibrary.ToMicrY(min.Y) + " мкм");

            pbDesignOfLed.Image = _bmpDesignOfLed;
        }

        private void pbDesignOfLed_Click(object sender, EventArgs e)
        {
            int code = 0;
            for (int i = 0; i < LedLibrary.Materials.Count; i++)
                if (LedLibrary.Materials[i].Name == _material)
                    code = i;

            if (_shape == "Многоугольник")
                MakePolygon(code);
            if (_shape == "Окружность")
                MakeCircle(code);

            RedrawPicture();
            pbDesignOfLed.Image = _bmpDesignOfLed;
        }



        //private void siToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "Si";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void al2O3ToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "Al2O3";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void gaNToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "GaN";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void inGaNToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "InGaN";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void iGaNToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "i-GaN";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void pGaNToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "p-GaN";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void nGaNToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "n-GaN";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void iTOToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "ITO";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void металлическийКонтактToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    _material = "металлический контакт";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void отражательБрэггаToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    _material = "отражатель Брэгга";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        //private void вакуумToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    _material = "Пустота";
        //    if (FormDesignInfo.Instance != null) 
        //        FormDesignInfo.Instance.SetMaterial(_material);
        //}

        private void pbDesignOfLed_Resize(object sender, EventArgs e)
        {
        }

        private void pbDesignOfLed_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void pbDesignOfLed_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
            RemoveSprite(_currPoint.X, LedLibrary.RealH - _currPoint.Y);
            pbDesignOfLed.Image = _bmpDesignOfLed;

            if (FormDesignInfo.Instance != null)
                FormDesignInfo.Instance.SetCoordinates("none", "none");
        }

        private void показатьИнформационнуюПанельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDesignInfo formDesignInfo = new FormDesignInfo();
            formDesignInfo.Show();
            if (_material != "")
                formDesignInfo.SetMaterial(_material);
            if (_shape != "") 
                formDesignInfo.SetShape(_shape);
        }

        private void FormDesign_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormDesignInfo.Instance != null)
                FormDesignInfo.Instance.Close();
        }

        private void удалитьТекущуюФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _click; i++)
                _masPoints[i] = new LedLibrary.Point(0, 0);
            _click = 0;

            RedrawPicture();
        }

        private void удалитьПоследнююТочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _masPoints[_click] = new LedLibrary.Point(0, 0);
            _click--;
            RedrawPicture();
        }
    }
}
