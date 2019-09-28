using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Universe
{
    public class SystemOfBody
    {
        public const double GravitationalConstant = 6.6743E-11;
        public ICollison CollisonProcess { get; set; }

        public SystemOfBody()
        {
            Bodies = new List<IAstronomicalObject>();
            CollisonProcess = new SimplyCollision();
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
            CheckCollision();
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

        public void TransferMassCenter(double x, double y)
        {
            Position massCenter = MassCenter();
            var dx = x - massCenter.X;
            var dy = y - massCenter.Y;
            for (int i = 0; i < Count; i++)
            {
                Bodies[i].Position.X += dx;
                Bodies[i].Position.Y += dy;
            }
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
            for (int i = 0; i < Count - 1; i++)
                for (int j = i + 1; j < Count; j++)
                    ChangeAccelerationVectors(Bodies[i], Bodies[j]);
        }

        private void ChangeAccelerationVectors(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var normalVector = NormalVectorFromFirstToSecondBody(obj1, obj2);
            var length = Position.Distance(obj1.Position, obj2.Position);
            var lengthSquare = length * length;
            var power1 = GravitationalConstant * obj2.Mass / lengthSquare;
            var power2 = -GravitationalConstant * obj1.Mass / lengthSquare;
            obj1.SpeedVector.Add(power1 * normalVector.ProjectionOnX, power1 * normalVector.ProjectionOnY);
            obj2.SpeedVector.Add(power2 * normalVector.ProjectionOnX, power2 * normalVector.ProjectionOnY);
        }

        private SpeedVector NormalVectorFromFirstToSecondBody(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var dx = obj2.Position.X - obj1.Position.X;
            var dy = obj2.Position.Y - obj1.Position.Y;
            var length = Position.Distance(obj1.Position, obj2.Position);
            var nv = new SpeedVector(dx / length, dy / length);
            return nv;
        }

        private bool CheckCollision()
        {
            // ========= ONLY ONE COLLISION!!! =========
            for (int i = 0; i < Count - 1; i++)
                for (int j = i + 1; j < Count; j++)
                {
                    if (IsCollision(Bodies[i], Bodies[j]))
                    {
                        Collison(Bodies[i], Bodies[j]);
                        return true;
                    }
                }
            return false;
        }

        public bool IsCollision(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var distance = Position.Distance(obj1.Position, obj2.Position);
            var twoRadiusSum = obj1.Radius + obj2.Radius;
            return distance < twoRadiusSum;
        }

        private void Collison(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            Bang();

            var after = CollisonProcess.Run(obj1, obj2);
            if (after.Item1 == null)
                Bodies.Remove(obj1);
            else
                Bodies[Bodies.IndexOf(Bodies.Where(n => n.Name == obj1.Name).FirstOrDefault())] = after.Item1;
            if (after.Item2 == null)
                Bodies.Remove(obj2);
            else
                Bodies[Bodies.IndexOf(Bodies.Where(n => n.Name == obj2.Name).FirstOrDefault())] = after.Item2;
        }

        private void Bang()
        {
            var wav = "Bang.wav";
            if (!File.Exists(wav))
                return;            
            System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer();
            sp2.SoundLocation = wav;
            sp2.Load();
            sp2.Play();
        }
    }
}
