namespace Universe
{
    public interface IAstronomicalObject
    {
        string Name { get; }

        double Mass { get; }

        double Radius { get; }

        Position Position { get; }

        Vector SpeedVector { get; set; }

        void Move();

        double GetDensity();

        double Distance(IAstronomicalObject obj);
    }
}