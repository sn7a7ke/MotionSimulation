using System;
using System.Drawing;
using Universe;

namespace MotionSimulation
{
    public class Canvas
    {
        private Scale _scale;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public Pen Pen { get; private set; }
        public Bitmap MainBmp { get; private set; }
        public Graphics Graph { get; private set; }

        public SystemOfBody SystemOfBody { get; private set; }
        public Scale Scale { get; set; }
        public Point Center { get; set; }

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
            var center = SystemOfBody.MassCenter();
            Center = new Point((int)(center.X / _scale.Length), (int)(center.Y / _scale.Length));
            Pen = new Pen(Color.White);
            MainBmp = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(MainBmp);
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
            Graph.DrawEllipse(Pen, GetSquare(obj));
        }

        private Rectangle GetSquare(IAstronomicalObject obj)
        {
            var leftTopX = (int)((obj.Position.X - obj.Radius) / _scale.Length);
            var leftTopY = (int)((obj.Position.Y - obj.Radius) / _scale.Length);
            var size = (int)(2 * _scale.Radius * obj.Radius / _scale.Length);
            if (size < 1)
                size = 1;
            return new Rectangle(leftTopX, leftTopY, size, size);
        }

        private void Clear()
        {
            Graph.Clear(Color.Black);
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
