using System.Collections.Generic;

namespace Universe
{
    public class SimplyCollision : ICollison
    {
        public List<IAstronomicalObject> Run(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            return (obj1.Mass > obj2.Mass) 
                ? new List<IAstronomicalObject> { obj1 }
                : new List<IAstronomicalObject> { obj2 };
        }
    }
}
