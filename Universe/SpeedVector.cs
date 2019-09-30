using System;

namespace Universe
{
    public class SpeedVector
    {
        public SpeedVector(double x, double y)
        {
            ProjectionOnX = x;
            ProjectionOnY = y;
        }

        public double ProjectionOnX { get; set; }

        public double ProjectionOnY { get; set; }

        public double Speed => Length(ProjectionOnX, ProjectionOnY);

        public SpeedVector Add(SpeedVector sv)
        {
            Add(sv.ProjectionOnX, sv.ProjectionOnY);
            return this;
        }

        public SpeedVector Add(double dx, double dy)
        {
            ProjectionOnX += dx;
            ProjectionOnY += dy;
            return this;
        }

        public SpeedVector Multiply(double koef)
        {
            ProjectionOnX *= koef;
            ProjectionOnY *= koef;
            return this;
        }

        public static SpeedVector operator +(SpeedVector vec1, SpeedVector vec2)
        {
            return new SpeedVector(vec1.ProjectionOnX + vec2.ProjectionOnX, vec1.ProjectionOnY + vec2.ProjectionOnY);
        }

        public static SpeedVector operator *(SpeedVector vec1, double koef)
        {
            return new SpeedVector(vec1.ProjectionOnX * koef, vec1.ProjectionOnY * koef);
        }

        public static SpeedVector operator *(double koef, SpeedVector vec1)
        {
            return vec1 * koef;
        }

        public static double Length(double x, double y) => Math.Sqrt(x * x + y * y);
    }
}
