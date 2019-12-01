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
            Position.Shift(SpeedVector.ProjectionOnX, SpeedVector.ProjectionOnY);
        }
    }
}
