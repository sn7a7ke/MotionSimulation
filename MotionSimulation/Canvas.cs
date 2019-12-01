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

        public Canvas(int width, int height, SystemOfBody systemOfBody)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Sizes of canvas must be positive");
            Width = width;
            Height = height;
            SystemOfBody = systemOfBody ?? throw new ArgumentNullException(nameof(systemOfBody));

            Scale = GetEstimateScale();
            _scale = Scale;
            Pen = new Pen(EdgeColor);
            //MainBmp = new Bitmap(Width, Height);
            //Graph = Graphics.FromImage(MainBmp);
            Clear();
            SecondsFromStart = 0;
        }

        public void DoStep()
        {
            SecondsFromStart += _scale.Time;
            _scale = Scale;
            for (int i = 0; i < _scale.Time; i++)
                if (SystemOfBody.DoStep())
                    Bang();
            Refresh();
        }

        public void Refresh()
        {
            Clear();
            MoveCenterTo();
            for (int i = 0; i < SystemOfBody.Count; i++)
                DrawBody(SystemOfBody[i]);
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
