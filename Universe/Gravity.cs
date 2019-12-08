using System;
using System.Collections.Generic;

namespace Universe
{
    public static class Gravity
    {
        public const double GravitationalConstant = 6.6743E-11;

        public static double FirstSpaceVelocity(IAstronomicalObject bigObj, IAstronomicalObject smallObj)
        {
            var distance = bigObj.Distance(smallObj);
            var firstSpeed = Math.Sqrt(GravitationalConstant * bigObj.Mass / distance);
            return firstSpeed;
        }

        public static double SecondSpaceVelocity(IAstronomicalObject bigObj, IAstronomicalObject smallObj)
        {
            var secondSpeed = Math.Sqrt(2) * FirstSpaceVelocity(bigObj, smallObj);
            return secondSpeed;
        }

        public static double AttractivePower(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var length = obj1.Distance(obj2);
            var power = GravitationalConstant * (obj1.Mass / length) * (obj2.Mass / length);
            return power;
        }

        public static void ChangeAccelerationVectors(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var normalVector = NormalVectorFromFirstToSecondBody(obj1, obj2);
            var length = obj1.Distance(obj2);
            var lengthSquare = length * length;
            var power1 = GravitationalConstant * obj2.Mass / lengthSquare;
            var power2 = -GravitationalConstant * obj1.Mass / lengthSquare;
            obj1.SpeedVector.Add(power1 * normalVector);
            obj2.SpeedVector.Add(power2 * normalVector);
        }

        public static Vector NormalVectorFromFirstToSecondBody(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            var dx = obj2.Position.X - obj1.Position.X;
            var dy = obj2.Position.Y - obj1.Position.Y;
            var length = obj1.Distance(obj2);
            var nv = new Vector(dx / length, dy / length);
            return nv;
        }

        public static bool IsAbandoned(IAstronomicalObject bigObj, IAstronomicalObject smallObj)
        {
            var vectorToBigObj = new Vector(bigObj.Position.X - smallObj.Position.X, bigObj.Position.Y - smallObj.Position.Y);
            var cosine = vectorToBigObj.Cosine(smallObj.SpeedVector);
            if (cosine > 0)
                return false;
            var secondSpeed = SecondSpaceVelocity(bigObj, smallObj);
            return smallObj.SpeedVector.Length >= secondSpeed;
        }

        public static List<IAstronomicalObject> IsAbandoned(List<IAstronomicalObject> objs)
        {
            var abandoned = new List<IAstronomicalObject>();
            bool currentIsAbandoned;
            for (int i = objs.Count - 1; i >= 1; i--)
            {
                currentIsAbandoned = true;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (!IsAbandoned(objs[j], objs[i]))
                    {
                        currentIsAbandoned = false;
                        break;
                    }
                }
                if (currentIsAbandoned)
                    abandoned.Add(objs[i]);
            }
            return abandoned;
        }
    }
}