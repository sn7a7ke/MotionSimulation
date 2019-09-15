using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionSimulation
{
    public class Scale
    {
        public double Length { get; private set; }
        public double Time { get; private set; }

        public Scale(double length, double time)
        {
            Length = length;
            Time = time;
        }
    }
}
