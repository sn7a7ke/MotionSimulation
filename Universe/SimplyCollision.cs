using System;

namespace Universe
{
    public class SimplyCollision : ICollison
    {
        public Tuple<IAstronomicalObject, IAstronomicalObject> Run(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            return (obj1.Mass > obj2.Mass) 
                ? new Tuple<IAstronomicalObject, IAstronomicalObject>(obj1, null)
                : new Tuple<IAstronomicalObject, IAstronomicalObject>(null, obj2);
        }
    }
}
