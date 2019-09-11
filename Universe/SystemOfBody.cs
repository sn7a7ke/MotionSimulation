using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universe
{
    class SystemOfBody
    {
        public SystemOfBody()
        {
            Bodies = new List<AstronomicalObject>();
        }

        public List<AstronomicalObject> Bodies { get; set; }

        public void Move()
        {
            foreach (var body in Bodies)
            {
                body.Move();
            }
        }
    }
}
