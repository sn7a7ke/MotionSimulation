using System.Threading;
using System.Windows.Forms;
using Universe;

namespace MotionSimulation
{
    public partial class MainForm : Form
    {
        private SystemOfBody _system;
        private Canvas _canvas;
        private const int secondsInHour = 3600;
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
                SpeedVector = new SpeedVector(0, -12.6)
            };
            var Moon = new AstronomicalObject
            {
                Name = "Moon",
                Mass = 7.3477E22,
                Radius = 1.737E6,
                Position = new Position(7.84467E8, 4E8),
                SpeedVector = new SpeedVector(0, 1023)
            };
            var Asteroid = new AstronomicalObject
            {
                Name = "Asteroid",
                Mass = 5E8,
                Radius = 1E3,
                Position = new Position(8.84467E8, 7E8),
                SpeedVector = new SpeedVector(-1000, -810)
            };
            _system = new SystemOfBody();
            _system.AddBody(Earth);
            _system.AddBody(Moon);
            _system.AddBody(Asteroid);
            _canvas = new Canvas(pb_Universe.Image, _system);
            _canvas.Scale.Length = (double)nUD_Length.Value;
            _canvas.Scale.Time = (int)(nUD_Time.Value / timerInterval);

            _canvas.Refresh();
            FillInForm();

            timer1.Interval = timerInterval;
        }


        private void FillInForm()
        {
            pb_Universe.Image = _canvas.MainBmp;
            lbl_Info.Text = "From start: " + GetDateFromHours(_canvas.SecondsFromStart) + "\n" +
                "Asteroid speed: " + GetSpeedInKilometersPerSecond(_canvas.SystemOfBody.Bodies[_canvas.SystemOfBody.Count - 1].SpeedVector.Speed) + "\n" +
                "Distance to asteroid: " + GetDistanceInKilometers(_canvas.SystemOfBody[0].Position, _canvas.SystemOfBody.Bodies[_canvas.SystemOfBody.Count - 1].Position);
        }

        private string GetSpeedInKilometersPerSecond(double speed)
        {
            return (speed / 1000).ToString("0.00") + " km/s";
        }

        private string GetDistanceInKilometers(Position pos1, Position pos2)
        {
            return (Position.Distance(pos1, pos2) / 1E6).ToString("#") + " Kkm";
        }

        private string GetDateFromHours(int numberOfSeconds)
        {
            var hours = numberOfSeconds / secondsInHour;
            return (hours / 8766).ToString("0") + " y " + 
                    (hours % 8766 / 730).ToString("0") + " m " + 
                    (hours % 730 / 24).ToString("00") + " d " + 
                    (hours % 24).ToString("00") + " h";
        }


        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _canvas.DoStep();
            FillInForm();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer1.Start();
                button1.Text = "Stop";
            }
        }

        private void nUD_Length_ValueChanged(object sender, System.EventArgs e)
        {
            _canvas.Scale.Length = (double)nUD_Length.Value;
            _canvas.Refresh();
            FillInForm();
        }

        private void nUD_Time_ValueChanged(object sender, System.EventArgs e)
        {
            _canvas.Scale.Time = (int)(nUD_Time.Value / timerInterval);
        }

        private void btn_ToCenter_Click(object sender, System.EventArgs e)
        {
            _canvas.TransferMassCenter();
            _canvas.Refresh();
            FillInForm();
        }
    }
}
