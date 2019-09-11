using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    public class SystemOfBody
    {
        public const double GravitationalConstant = 0.000000000066743;

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
        public void Step()
        {
            Interaction();
            Move();
        }

        public double AttractivePower(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var length = Position.Distance(obj1.Position, obj2.Position);
            var power = GravitationalConstant * obj1.Mass * obj2.Mass / (length * length); // (mass/length) ???
            return power;
        }

        private void Move()
        {
            foreach (var body in Bodies)
                body.Move();
        }

        private void Interaction()
        {
            if (Count < 2)
                return;
            SpeedVector speedVector;
            SpeedVector reverseSpeedVector;
            for (int i = 0; i < Count - 1; i++)
                for (int j = 1; j < Count; j++)
                {
                    speedVector = AccelerationVector(Bodies[i], Bodies[j]);
                    Bodies[i].SpeedVector.Add(speedVector);
                    reverseSpeedVector = AccelerationVector(Bodies[j], Bodies[i]);
                    Bodies[j].SpeedVector.Add(speedVector);
                }
        }

        private SpeedVector AccelerationVector(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var normalVector = NormalVectorFromFirstToSecondBody(obj1, obj2);
            var power = AttractivePower(obj1, obj2);
            var dx = obj1.SpeedVector.ProjectionOnX * power / obj1.Mass;
            var dy = obj1.SpeedVector.ProjectionOnY * power / obj1.Mass;
            return new SpeedVector(dx, dy);
        }

        private SpeedVector NormalVectorFromFirstToSecondBody(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {

            var dx = obj1.Position.X - obj2.Position.X;
            var dy = obj1.Position.Y - obj2.Position.Y;
            var length = Position.Distance(obj1.Position, obj2.Position);
            var nv = new SpeedVector(dx / length, dy / length);
            return nv;
        }
    }
}
