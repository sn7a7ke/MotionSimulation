using System.Collections.Generic;
using System.Linq;

namespace Universe
{
    public class SystemOfBody
    {
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
                        Collison(Bodies[i], Bodies[j]);
                        return true;
                    }
                }
            return false;
        }

        public static bool CheckCollision(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var distance = Position.Distance(obj1.Position, obj2.Position);
            var twoRadiusSum = obj1.Radius + obj2.Radius;
            return distance < twoRadiusSum;
        }

        private void Collison(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var after = CollisonProcess.Run(obj1, obj2);
            if (after.Item1 == null)
                RemoveBody(obj1);
            else
                ReplaceBody(obj1, after.Item1);
            if (after.Item2 == null)
                RemoveBody(obj2);
            else
                ReplaceBody(obj2, after.Item2);
        }

        private void ReplaceBody(IAstronomicalObject oldObj, IAstronomicalObject newObj)
        {
            var index = Bodies.IndexOf(Bodies.First(n => n.Name == oldObj.Name));
            Bodies[index] = newObj;
        }
    }
}
