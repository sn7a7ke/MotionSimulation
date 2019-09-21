using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionSimulation
{
    public class Scale
    {
        public double Length { get; set; }
        public int Time { get; set; }
        public double Radius { get; set; }

        public Scale(double length, int time, double radius = 1)
        {
            Length = length;
            Time = time;
            Radius = radius;
        }
    }
}
