using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universe;

namespace MotionSimulation
{
    class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Pen Pen { get; private set; }
        public Bitmap MainBmp { get; private set; }
        public Graphics Graph { get; private set; }

        public SystemOfBody SystemOfBody { get; set; }

        public Canvas(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Sizes of canvas must be positive");

            Width = width;
            Height = height;
            Pen = new Pen(Color.DarkRed);
            Clear();
        }

        public void Clear()
        {
            SystemOfBody = new SystemOfBody();
        }

        public void Refresh()
        {
            Draw();
            for (int i = 0; i < SystemOfBody.Count; i++)
                DrawBody(SystemOfBody[i]);
        }

        public void DrawBody(IAstronomicalObject obj)
        {
            Graph.DrawEllipse(Pen, GetSquare(obj));
        }

        private Rectangle GetSquare(IAstronomicalObject obj)
        {
            var leftTopX = (int)(obj.Position.X - obj.Radius);
            var leftTopY = (int)(obj.Position.Y - obj.Radius);
            var size = (int)(2 * obj.Radius);
            return new Rectangle(leftTopX, leftTopY, size, size);
        }

        private void Draw()
        {
            MainBmp = new Bitmap(Width, Height);
            Graph = Graphics.FromImage(MainBmp);
        }

    }
}
