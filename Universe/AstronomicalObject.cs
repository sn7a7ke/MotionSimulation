using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    /// <summary>
    /// Time - seconds, Distance - kilometers
    /// </summary>
    public class AstronomicalObject : IAstronomicalObject
    {
        public string Name { get; set; }
        public double Mass { get; set; }
        public double Radius { get; set; }

        public Position Position { get; set; }

        public SpeedVector SpeedVector { get; set; }


        public void Move()
        {
            Position.X += SpeedVector.ProjectionOnX;
            Position.Y += SpeedVector.ProjectionOnY;
        }
    }
}
