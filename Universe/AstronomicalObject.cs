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
    class AstronomicalObject
    {
        public Position Position { get; protected set; }

        public double Mass { get; protected set; }

        public double Radius { get; protected set; }

        public SpeedOfBody Speed { get; protected set; }

        public string Name { get; protected set; }

        public void Move()
        {
            Position.X += Speed.DeltaX;
            Position.Y += Speed.DeltaY;
        }
    }
}
