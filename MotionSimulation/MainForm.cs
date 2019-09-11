using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universe;

namespace MotionSimulation
{
    public partial class MainForm : Form
    {
        SystemOfBody system;
        public MainForm()
        {
            InitializeComponent();

            var posEarth = new Position(300, 300);
            var vecOfspEarth = new SpeedVector(4, 0);
            var body1 = new AstronomicalObject
            {
                Name = "Earth",
                Mass = 100,
                Radius = 5,
                Position = posEarth,
                SpeedVector = vecOfspEarth
            };

            system = new SystemOfBody();
            system.AddBody(body1);

            var timer = new System.Threading.Timer(CallBack, null, 0, 200);
        }

        public void CallBack(object obj)
        {
            system.Step();
        }
    }
}
