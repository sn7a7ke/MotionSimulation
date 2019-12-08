using System;

namespace Universe
{
    /// <summary>
    /// Time - seconds, Distance - meters
    /// </summary>
    public class AstronomicalObject : IAstronomicalObject
    {
        public AstronomicalObject(string name, double mass, double radius, Position position, SpeedVector speedVector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            if (mass <= 0)
                throw new ArgumentOutOfRangeException(nameof(mass), "Mass must be positive");
            Mass = mass;

            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive");
            Radius = radius;

            Position = position ?? throw new ArgumentNullException(nameof(position));

            SpeedVector = speedVector ?? throw new ArgumentNullException(nameof(speedVector));
        }

        public string Name { get; private set; }

        public double Mass { get; private set; }

        public double Radius { get; private set; }

        public Position Position { get; private set; }

        public SpeedVector SpeedVector { get; set; }

        public void Move()
        {
            Position.Shift(SpeedVector.ProjectionOnX, SpeedVector.ProjectionOnY);
        }

        public double GetDensity() => GetDensity(Mass, Radius);

        public static double GetDensity(double mass, double radius) => 3 * mass / (4000 * Math.PI * Math.Pow(radius, 3));

        public double Distance(IAstronomicalObject obj) => Position.Distance(obj.Position);
    }
}