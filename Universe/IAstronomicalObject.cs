namespace Universe
{
    public interface IAstronomicalObject
    {
        double Mass { get; }
        string Name { get; }
        Position Position { get; }
        double Radius { get; }
        SpeedVector SpeedVector { get; }

        void Move();
    }
}