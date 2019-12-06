using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Universe;

namespace MotionSimulation
{
    public class Canvas
    {
        private Scale _scale;
        private int _width;
        private int _height;
        private Point _offsetCenter;

        public int Width { get; set; }
        public int Height { get; set; }
        public Pen Pen { get; private set; }
        public Bitmap MainBmp { get; private set; }
        public Graphics Graph { get; private set; }

        public SystemOfBody SystemOfBody { get; private set; }
        public Scale Scale { get; set; }
        public Point Center { get; set; }
        public int MinBodySize { get; set; } = 2;
        public Color EdgeColor { get; set; } = Color.FromArgb(255, 0, 255, 255);
        public Color CenterColor { get; set; } = Color.FromArgb(255, 0, 0, 255);

        public int SecondsFromStart { get; private set; }
        public int QtyPositions { get; set; }
        public bool ShowTraces { get; set; } = true;

        private int _bodyWithTraces;
        public int BodyWithTraces
        {
            get => _bodyWithTraces;
            set
            {
                if (value < 0 || value >= SystemOfBody.Count)
                    throw new ArgumentOutOfRangeException(nameof(value));
                if (value != _bodyWithTraces)
                {
                    _traces.Clear();
                    _bodyWithTraces = value;
                }
            }
        }

        private readonly Traces<Position> _traces;

        public Canvas(int width, int height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Sizes of canvas must be positive");
            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Sizes of canvas must be positive");
            Width = width;
            Height = height;
            SystemOfBody = new SystemOfBody();

            Scale = GetEstimateScale();
            _scale = Scale;
            Pen = new Pen(EdgeColor);
            //MainBmp = new Bitmap(Width, Height);
            //Graph = Graphics.FromImage(MainBmp);
            Clear();
            SecondsFromStart = 0;
            QtyPositions = 500;
            _traces = new Traces<Position>(QtyPositions);
        }

        public void AddBody(IAstronomicalObject obj)
        {
            if (obj != null)
                SystemOfBody.AddBody(obj);
            _traces.Clear();
            BodyWithTraces = SystemOfBody.Count - 1;
        }


        public void DoStep()
        {
            SecondsFromStart += _scale.Time;
            _scale = Scale;
            for (int i = 0; i < _scale.Time; i++)
                if (SystemOfBody.DoStep())
                    Bang();
            _traces.Add(SystemOfBody[BodyWithTraces]?.Position?.Clone());
        }

        public void Refresh()
        {
            Clear();
            MoveCenterTo();
            for (int i = 0; i < SystemOfBody.Count; i++)
                DrawBody(SystemOfBody[i]);
            if (ShowTraces)
                DrawTraces();
        }

        private void DrawBody(IAstronomicalObject obj)
        {
            Rectangle myRectangle = GetSquare(obj);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(myRectangle);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = CenterColor;
            Color[] colors = { EdgeColor };
            brush.SurroundColors = colors;
            Graph.FillEllipse(brush, myRectangle);
            Graph.DrawEllipse(Pen, myRectangle);
            path.Dispose();
            brush.Dispose();
        }

        private void DrawTraces()
        {
            var points = PositionsToScreenDots(_traces.GetAll());
            if (points.Length > 1)
                Graph.DrawCurve(Pen, points);
        }

        private Rectangle GetSquare(IAstronomicalObject obj)
        {
            var size = (int)(2 * _scale.Radius * obj.Radius / _scale.Length);
            if (size < MinBodySize)
                size = MinBodySize;
            var leftTop = obj.Position.Clone();
            leftTop.Shift(-obj.Radius, -obj.Radius);
            var dot = PositionToScreenDot(leftTop);
            return new Rectangle(dot.X, dot.Y, size, size);
        }

        private Point[] PositionsToScreenDots(Position[] positions)
        {
            Point[] points = new Point[positions.Length];
            for (int i = 0; i < positions.Length; i++)
                points[i] = PositionToScreenDot(positions[i]);
            return points;
        }

        private Point PositionToScreenDot(Position position)
        {
            var X = (int)(position.X / _scale.Length) + _offsetCenter.X;
            var Y = (int)(position.Y / _scale.Length) + _offsetCenter.Y;
            return new Point(X, Y);
        }

        private void Clear()
        {
            _scale = Scale;
            _width = Width;
            _height = Height;

            MainBmp = new Bitmap(_width, _height);
            Graph = Graphics.FromImage(MainBmp);
        }

        public Scale GetEstimateScale()
        {
            return new Scale(1E6, 60 * 60, 1);
        }

        public Point MoveCenterTo()
        {
            return MoveCenterTo(_width / 2, _height / 2);
        }
        public Point MoveCenterTo(int x, int y)
        {
            Position massCenter = SystemOfBody.MassCenter();
            var dx = x - (int)(massCenter.X / _scale.Length);
            var dy = y - (int)(massCenter.Y / _scale.Length);
            _offsetCenter = new Point(dx, dy);
            return _offsetCenter;
        }

        public bool IsAbandoned(IAstronomicalObject bigObj, IAstronomicalObject smallObj)
        {
            var secondSpeed = Gravity.SecondSpaceVelocity(bigObj, smallObj);
            var check = smallObj.SpeedVector.Speed >= secondSpeed;
            if (check)
                Abandoned();
            return check;
        }

        private void Bang()
        {
            PlayWavFile("Bang.wav");
        }

        private void Abandoned()
        {
            PlayWavFile("Funeral.wav");
        }

        private static void PlayWavFile(string wav)
        {
            if (!File.Exists(wav))
                return;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.SoundLocation = wav;
            sp.Load();
            sp.Play();
            sp.Dispose();
        }
    }
}
