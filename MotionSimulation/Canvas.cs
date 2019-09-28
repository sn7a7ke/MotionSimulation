using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Universe;

namespace MotionSimulation
{
    public class Canvas
    {
        private Scale _scale;
        private Image _originalImage;

        public int Width { get; private set; }
        public int Height { get; private set; }
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

        public Canvas(Image image, SystemOfBody systemOfBody)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            _originalImage = (Image)image.Clone();
            Width = _originalImage.Width;
            Height = _originalImage.Height;
            SystemOfBody = systemOfBody ?? throw new ArgumentNullException(nameof(systemOfBody));

            Scale = GetEstimateScale();
            _scale = Scale;
            var center = SystemOfBody.MassCenter();
            Center = new Point((int)(center.X / _scale.Length), (int)(center.Y / _scale.Length));
            Pen = new Pen(EdgeColor);
            Clear();
            SecondsFromStart = 0;
        }

        public void DoStep()
        {
            SecondsFromStart += _scale.Time;
            _scale = Scale;
            for (int i = 0; i < _scale.Time; i++)
                SystemOfBody.DoStep();
            Refresh();
        }

        public void Refresh()
        {
            Clear();
            _scale = Scale;
            TransferMassCenter(Center.X, Center.Y);
            for (int i = 0; i < SystemOfBody.Count; i++)
                DrawBody(SystemOfBody[i]);
        }

        private void DrawBody(IAstronomicalObject obj)
        {
            Rectangle myRectangle = GetSquare(obj);

            // Create a path that consists of a single ellipse.
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(myRectangle);
            // Use the path to construct a brush.
            PathGradientBrush brush = new PathGradientBrush(path);
            // Set the color at the center of the path to blue.
            brush.CenterColor = CenterColor;
            // Set the color along the entire boundary 
            // of the path to aqua.
            Color[] colors = { EdgeColor };
            brush.SurroundColors = colors;
            //brush.FocusScales = new PointF(0.5f, 0.5f);

            //SolidBrush brush = new SolidBrush(Color);

            Graph.FillEllipse(brush, myRectangle);
            Graph.DrawEllipse(Pen, myRectangle);
        }

        private Rectangle GetSquare(IAstronomicalObject obj)
        {
            var leftTopX = (int)((obj.Position.X - obj.Radius) / _scale.Length);
            var leftTopY = (int)((obj.Position.Y - obj.Radius) / _scale.Length);
            var size = (int)(2 * _scale.Radius * obj.Radius / _scale.Length);
            if (size < MinBodySize)
                size = MinBodySize;
            return new Rectangle(leftTopX, leftTopY, size, size);
        }

        private void Clear()
        {
            MainBmp = new Bitmap(_originalImage);
            Graph = Graphics.FromImage(MainBmp);
        }

        public Scale GetEstimateScale()
        {
            return new Scale(1E6, 60 * 60, 1);
        }

        public void TransferMassCenter()
        {
            Center = new Point(Width / 2, Height / 2);
            TransferMassCenter(Width / 2, Height / 2);
        }

        public void TransferMassCenter(int x, int y)
        {
            SystemOfBody.TransferMassCenter(x * _scale.Length, y * _scale.Length);
        }

        public Point GetCenter()
        {
            var speedVector = SystemOfBody.MassSpeedVector();
            var dx = speedVector.ProjectionOnX / _scale.Length;
            var dy = speedVector.ProjectionOnY / _scale.Length;
            var stepX = Width / dx;
            var stepY = Height / dy;

            if (stepX > stepY)
                return new Point(0, (int)((stepX - stepY) * dx / 2));
            else
                return new Point((int)((stepY - stepX) * dy / 2), 0);                
        }
    }
}
