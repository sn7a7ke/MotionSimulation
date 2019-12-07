using System.Collections.Generic;

namespace Universe
{
    public interface ICollison
    {
        List<IAstronomicalObject> Run(IAstronomicalObject obj1, IAstronomicalObject obj2);
    }
}