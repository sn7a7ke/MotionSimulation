using System;

namespace Universe
{
    public interface ICollison
    {
        Tuple<IAstronomicalObject, IAstronomicalObject> Run(IAstronomicalObject obj1, IAstronomicalObject obj2);
    }
}