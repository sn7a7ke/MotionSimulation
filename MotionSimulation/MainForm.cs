using System.Threading;
using System.Windows.Forms;
using Universe;

namespace MotionSimulation
{
    public partial class MainForm : Form
    {
        private SystemOfBody _system;
        private Canvas _canvas;
        private Scale _scale;
        private bool _start;
        private const int timerInterval = 40;
        public MainForm()
        {
            InitializeComponent();

            var Earth = new AstronomicalObject
            {
                Name = "Earth",
                Mass = 5.9726E24,
                Radius = 6.371E6,
                Position = new Position(4E8, 4E8),
                SpeedVector = new SpeedVector(0, -12.3)
            };
            var Moon = new AstronomicalObject
            {
                Name = "Moon",
                Mass = 7.3477E22,
                Radius = 1.737E6,
                Position = new Position(7.84467E8, 4E8),
                SpeedVector = new SpeedVector(0, 1000)
            };
            var Asteroid = new AstronomicalObject
            {
                Name = "Asteroid",
                Mass = 5E8,
                Radius = 1E3,
                Position = new Position(8.84467E8, 7E8),
                SpeedVector = new SpeedVector(-1000, -800)
            };
            _system = new SystemOfBody();
            _system.AddBody(Earth);
            _system.AddBody(Moon);
            _system.AddBody(Asteroid);

            _canvas = new Canvas(pb_Universe.Width, pb_Universe.Height, _system);
            _scale = _canvas.GetEstimateScale();

            _canvas.Refresh();
            FillForm();

            _start = false;
            timer1.Interval = timerInterval;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _canvas.Scale = _scale;
            _canvas.TransferMassCenter();
            _canvas.DoStep();
            FillForm();
        }

        private void FillForm()
        {
            pb_Universe.Image = _canvas.MainBmp;
            label1.Text = (_canvas.NumberOfSteps / 730).ToString() + " m " + (_canvas.NumberOfSteps % 730 / 24).ToString() + " d " + (_canvas.NumberOfSteps % 24).ToString() + " h";
            label2.Text = (_canvas.SystemOfBody.Bodies[_canvas.SystemOfBody.Count - 1].SpeedVector.Speed / 1000).ToString("0.00") + " km/s";
            label3.Text = (Position.Distance(_canvas.SystemOfBody[0].Position, _canvas.SystemOfBody.Bodies[_canvas.SystemOfBody.Count - 1].Position) / 1E6).ToString("#") + " Kkm";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (_start)
            {
                timer1.Stop();
                button1.Text = "Start";
                _start = false;
            }
            else
            {
                timer1.Start();
                button1.Text = "Stop";
                _start = true;
            }
        }

        private void nUD_Length_ValueChanged(object sender, System.EventArgs e)
        {
            _scale.Length = (double)nUD_Length.Value;
        }

        private void nUD_Time_ValueChanged(object sender, System.EventArgs e)
        {
            _scale.Time = (double)(nUD_Time.Value / timerInterval);
        }
    }
}
