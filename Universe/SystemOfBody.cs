using System;
using System.Collections.Generic;

namespace Universe
{
    public class SystemOfBody
    {
        public ICollison CollisonProcess { get; set; }

        public SystemOfBody()
        {
            Bodies = new List<IAstronomicalObject>();
            CollisonProcess = new SimplyCollision();
            LastCollision = null;
        }

        public List<IAstronomicalObject> Bodies { get; protected set; }

        public int Count => Bodies.Count;

        public Position LastCollision { get; set; }

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
            if (obj != null)
                Bodies.Add(obj);
        }

        public void RemoveBody(IAstronomicalObject obj)
        {
            if (obj == null)
                return;
            Bodies.Remove(obj);
        }

        public bool DoStep()
        {
            Interaction();
            Move();
            return CheckCollision();
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
                Bodies[i].Position.Shift(dx, dy);
        }

        public Vector MassSpeedVector()
        {
            double dx = 0;
            double dy = 0;
            double dm = 0;
            for (int i = 0; i < Count; i++)
            {
                dx += Bodies[i].SpeedVector.X * Bodies[i].Mass;
                dy += Bodies[i].SpeedVector.Y * Bodies[i].Mass;
                dm += Bodies[i].Mass;
            }
            dx = dx / dm;
            dy = dy / dm;
            return new Vector(dx, dy);
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
                    Gravity.ChangeAccelerationVectors(Bodies[i], Bodies[j]);
        }

        private bool CheckCollision()
        {
            // ========= ONLY ONE COLLISION!!! =========
            for (int i = 0; i < Count - 1; i++)
                for (int j = i + 1; j < Count; j++)
                {
                    if (CheckCollision(Bodies[i], Bodies[j]))
                    {
                        SetLastColision(Bodies[i], Bodies[j]);
                        Collison(Bodies[i], Bodies[j]);
                        return true;
                    }
                }
            return false;
        }

        public bool CheckCollision(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var distance = obj1.Distance(obj2);
            return distance < (obj1.Radius + obj2.Radius);
        }

        private void SetLastColision(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var distance = obj1.Distance(obj2);
            var normal = Gravity.NormalVectorFromFirstToSecondBody(obj2, obj1);
            var distanceToIntersection = (Math.Sqrt(obj2.Radius) + Math.Sqrt(distance) - Math.Sqrt(obj1.Radius)) / (2 * distance);
            var shiftToIntersection = normal * distanceToIntersection;
            LastCollision = obj2.Position.Clone();
            LastCollision.Shift(shiftToIntersection.X, shiftToIntersection.Y);
        }

        private void Collison(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var after = CollisonProcess.Run(obj1, obj2);
            Bodies.Remove(obj1);
            Bodies.Remove(obj2);
            Bodies.AddRange(after);
        }
    }
}
