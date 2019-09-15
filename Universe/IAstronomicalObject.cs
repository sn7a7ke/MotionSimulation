namespace Universe
{
    public interface IAstronomicalObject
    {
        string Name { get; }

        double Mass { get; }

        double Radius { get; }

        Position Position { get; }

        SpeedVector SpeedVector { get; }

        void Move();
    }
}