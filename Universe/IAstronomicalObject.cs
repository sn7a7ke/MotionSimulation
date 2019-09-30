namespace Universe
{
    public interface IAstronomicalObject
    {
        double Mass { get; set; }

        string Name { get; set; }

        Position Position { get; set; }

        double Radius { get; set; }

        SpeedVector SpeedVector { get; set; }

        void Move();
    }
}