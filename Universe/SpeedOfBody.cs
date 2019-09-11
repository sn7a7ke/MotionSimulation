using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    class SpeedOfBody
    {
        public SpeedOfBody(double x, double y)
        {
            DeltaX = x;
            DeltaY = y;
        }

        public double DeltaX { get; set; }

        public double DeltaY { get; set; }
    }
}
