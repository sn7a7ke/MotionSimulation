using System;

namespace Universe
{
    public class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Speed => Length(X, Y);

        public Vector Add(Vector vector)
        {
            Add(vector.X, vector.Y);
            return this;
        }

        public Vector Add(double dx, double dy)
        {
            X += dx;
            Y += dy;
            return this;
        }

        public static Vector operator +(Vector vec1, Vector vec2) => new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y);

        public static Vector operator *(Vector vec1, double koef) => new Vector(vec1.X * koef, vec1.Y * koef);

        public static Vector operator *(double koef, Vector vec1) => vec1 * koef;

        public static double Length(double x, double y) => Math.Sqrt(x * x + y * y);
    }
}
