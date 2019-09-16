using System.Collections.Generic;

namespace Universe
{
    public class SystemOfBody
    {
        public const double GravitationalConstant = 6.6743E-11;

        public SystemOfBody()
        {
            Bodies = new List<IAstronomicalObject>();
        }

        public List<IAstronomicalObject> Bodies { get; protected set; }

        public int Count => Bodies.Count;

        public IAstronomicalObject this[int index]
        {
            get
            {
                if (Count == 0 || index < 0 || index >= Count)
                    return null;
                return Bodies[index];
            }
        }

        public void AddBody(IAstronomicalObject obj)
        {
            if (obj == null)
                return;
            Bodies.Add(obj);
        }

        public void DoStep()
        {
            Interaction();
            Move();
        }

        public double AttractivePower(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var length = Position.Distance(obj1.Position, obj2.Position);
            var power = GravitationalConstant * (obj1.Mass / length) * (obj2.Mass / length); // (mass/length) ???
            return power;
        }

        public Position MassCenter()
        {
            double dx = 0;
            double dy = 0;
            double dm = 0;
            for (int i = 0; i < Count; i++)
            {
                dx += Bodies[i].Position.X * Bodies[i].Mass;
                dy += Bodies[i].Position.Y * Bodies[i].Mass;
                dm += Bodies[i].Mass;
            }
            dx = dx / dm;
            dy = dy / dm;
            return new Position(dx, dy);
        }

        public SpeedVector MassSpeedVector()
        {
            double dx = 0;
            double dy = 0;
            double dm = 0;
            for (int i = 0; i < Count; i++)
            {
                dx += Bodies[i].SpeedVector.ProjectionOnX * Bodies[i].Mass;
                dy += Bodies[i].SpeedVector.ProjectionOnY * Bodies[i].Mass;
                dm += Bodies[i].Mass;
            }
            dx = dx / dm;
            dy = dy / dm;
            return new SpeedVector(dx, dy);
        }

        private void Move()
        {
            foreach (var body in Bodies)
                body.Move();
        }

        private void Interaction()
        {
            //if (Count < 2)
            //    return;
            for (int i = 0; i < Count - 1; i++)
                for (int j = 1; j < Count; j++)
                    ChangeAccelerationVectors(Bodies[i], Bodies[j]);
        }

        private void ChangeAccelerationVectors(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var normalVector = NormalVectorFromFirstToSecondBody(obj1, obj2);
            var power = AttractivePower(obj1, obj2);
            var dx = normalVector.ProjectionOnX * power;
            var dy = normalVector.ProjectionOnY * power;
            obj1.SpeedVector.Add(dx / obj1.Mass, dy / obj1.Mass);
            obj1.SpeedVector.Add( - dx / obj2.Mass, - dy / obj2.Mass);
        }

        private SpeedVector NormalVectorFromFirstToSecondBody(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var dx = obj2.Position.X - obj1.Position.X;
            var dy = obj2.Position.Y - obj1.Position.Y;
            var length = Position.Distance(obj1.Position, obj2.Position);
            var nv = new SpeedVector(dx / length, dy / length);
            return nv;
        }
    }
}
