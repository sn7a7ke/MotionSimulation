using System;
using System.Drawing;
using Universe;

namespace MotionSimulation
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Pen Pen { get; private set; }
        public Bitmap MainBmp { get; private set; }
        public Graphics Graph { get; private set; }

        public SystemOfBody SystemOfBody { get; private set; }
        public Scale Scale { get; set; }
        public Point Center { get; set; }

        public Canvas(int width, int height, SystemOfBody systemOfBody)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Sizes of canvas must be positive");
            Width = width;
            Height = height;
            SystemOfBody = systemOfBody ?? throw new ArgumentNullException(nameof(systemOfBody));

            Scale = GetEstimateScale();
            Center = GetCenter();
            Pen = new Pen(Color.DarkRed);
            Clear();
        }

        public void DoStep()
        {
            for (int i = 0; i < Scale.Time; i++)
                SystemOfBody.DoStep();
            Refresh();
        }

        public void Refresh()
        {
            Clear();
            for (int i = 0; i < SystemOfBody.Count; i++)
                DrawBody(SystemOfBody[i]);
        }

        public void DrawBody(IAstronomicalObject obj)
        {
            Graph.DrawEllipse(Pen, GetSquare(obj));
        }

        private Rectangle GetSquare(IAstronomicalObject obj)
        {
            var leftTopX = (int)((obj.Position.X - obj.Radius) / Scale.Length);
            var leftTopY = (int)((obj.Position.Y - obj.Radius) / Scale.Length);
            var size = (int)(2 * obj.Radius / Scale.Length);
            return new Rectangle(leftTopX, leftTopY, size, size);
        }

        private void Clear()
        {
            MainBmp = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(MainBmp);
        }

        public Scale GetEstimateScale()
        {
            return new Scale(1E6, 60*60);
        }

        public Point GetCenter()
        {
            int cX;
            int cY;
            var speedVector = SystemOfBody.MassSpeedVector();
            var dx = speedVector.ProjectionOnX / Scale.Length;
            var dy = speedVector.ProjectionOnY / Scale.Length;
            var center = SystemOfBody.MassCenter();
            var stepX = Width / dx;
            var stepY = Height / dy;

            if (stepX > stepY)
            {
                cX = 0;
                cY = (int)((stepX - stepY) * dx / 2);
            }
            else
            {
                cX = (int)((stepY - stepX) * dy / 2);
                cY = 0;
            }
            return new Point(cX, cY);
        }
    }
}
