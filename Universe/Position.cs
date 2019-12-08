using System;

namespace Universe
{
    public class Position
    {
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public void Shift(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public double Distance(Position pos) => Distance(this, pos);

        public static double Distance(Position pos1, Position pos2)
        {
            var dx = pos1.X - pos2.X;
            var dy = pos1.Y - pos2.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);
            return length;
        }

        public Position Clone() => new Position(X, Y);
    }
}
