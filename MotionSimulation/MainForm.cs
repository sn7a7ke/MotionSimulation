using System.Threading;
using System.Windows.Forms;
using Universe;

namespace MotionSimulation
{
    public partial class MainForm : Form
    {
        private SystemOfBody _system;
        private Canvas _canvas;
        public MainForm()
        {
            InitializeComponent();
            

            var Earth = new AstronomicalObject
            {
                Name = "Earth",
                Mass = 5.9726E24,
                Radius = 6.371E6,
                Position = new Position(3E8, 3E8),
                SpeedVector = new SpeedVector(0, -12.3)
            };
            var Moon = new AstronomicalObject
            {
                Name = "Moon",
                Mass = 7.3477E22,
                Radius = 1.737E6,
                Position = new Position(6.84467E8, 3E8),
                SpeedVector = new SpeedVector(0, 1000)
            };
            _system = new SystemOfBody();
            _system.AddBody(Earth);
            _system.AddBody(Moon);
            _canvas = new Canvas(pb_Universe.Width, pb_Universe.Height, _system);

            timer1.Interval = 20;
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _canvas.DoStep();
            pb_Universe.Image = _canvas.MainBmp;
            label1.Text = _canvas.NumberOfSteps.ToString();
        }
    }
}
