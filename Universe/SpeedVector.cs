﻿using System;

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

        public void Add(SpeedVector sv)
        {
            Add(sv.ProjectionOnX, sv.ProjectionOnY);
        }

        public void Add(double dx, double dy)
        {
            ProjectionOnX += dx;
            ProjectionOnY += dy;
        }

        public static double Length(double x, double y) => Math.Sqrt(x * x + y * y);
    }
}