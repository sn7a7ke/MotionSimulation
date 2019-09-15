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

        public static double Distance(Position pos1, Position pos2)
        {
            var dx = pos1.X - pos2.X;
            var dy = pos1.Y - pos2.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);
            return length;
        }
    }
}
