using System;
using System.Collections.Generic;
using System.Drawing;
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
        private IAstronomicalObject _mainObject;
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
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(8.84467E8, 7E8),
                SpeedVector = new SpeedVector(-1000, -810)
            };
            var Asteroid2 = new AstronomicalObject
            {
                Name = "Asteroid2",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(8.84467E8 + 1E7, 7E8 + 1E7),
                SpeedVector = new SpeedVector(-1000, -810)
            };
            var Asteroid3 = new AstronomicalObject
            {
                Name = "Asteroid3",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(8.84467E8 + 2E7, 7E8 + 2E7),
                SpeedVector = new SpeedVector(-1000, -810)
            };
            var Asteroid4 = new AstronomicalObject
            {
                Name = "Asteroid4",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(8.84467E8 + 3E7, 7E8 + 3E7),
                SpeedVector = new SpeedVector(-1000, -810)
            };
            var Asteroid5 = new AstronomicalObject
            {
                Name = "Asteroid for Moon",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(7.84467E8 + 3E7, 4E8),
                SpeedVector = new SpeedVector(0, 1023 + 400)
            };
            var Asteroid6 = new AstronomicalObject
            {
                Name = "Asteroid for Earth",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(4E8 + 3E7, 4E8),
                SpeedVector = new SpeedVector(0, -12.6 + 4000)
            };

            _system = new SystemOfBody();
            _system.AddBody(Earth);
            _system.AddBody(Moon);
            _system.AddBody(Asteroid);
            _system.AddBody(Asteroid2);
            //_system.AddBody(Asteroid3);
            //_system.AddBody(Asteroid4);
            //_system.AddBody(Asteroid5);
            //_system.AddBody(Asteroid6);
            _mainObject = _system.Bodies[0];
            _canvas = new Canvas(pb_Universe.Width, pb_Universe.Height, _system);
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
                GetObjectsInfo(_canvas.SystemOfBody.Bodies);
        }

        private string GetObjectsInfo(List<IAstronomicalObject> objList)
        {
            var str = string.Empty;
            for (int i = 1; i < objList.Count; i++)
                str += GetObjectInfo(objList[i]);
            return str;
        }

        private string GetObjectInfo(IAstronomicalObject obj)
        {
            return $"{obj.Name}:" + "\n" +
                $"   - speed    {GetSpeedInKilometersPerSecond(obj.SpeedVector.Speed)} km/s" + "\n" +
                $"   - distance {GetDistanceInKilometers(_mainObject.Position, obj.Position)} Kkm" + "\n";
        }

        private string GetSpeedInKilometersPerSecond(double speed)
        {
            return (speed / 1000).ToString("0.00");
        }

        private string GetDistanceInKilometers(Position pos1, Position pos2)
        {
            return (Position.Distance(pos1, pos2) / 1E6).ToString("# ###");
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

        private void pb_Universe_Resize(object sender, System.EventArgs e)
        {
            _canvas.Width = pb_Universe.Width;
            _canvas.Height = pb_Universe.Height;
        }

        private void pb_Universe_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("{0}:{1}", e.X, e.Y);
        }

        private void btn_IsAbandoned_Click(object sender, EventArgs e)
        {
            if (_canvas.IsAbandoned(_canvas.SystemOfBody[0], _canvas.SystemOfBody[_canvas.SystemOfBody.Count - 1]))
                btn_IsAbandoned.ForeColor = Color.Red;
            else
                btn_IsAbandoned.ForeColor = Color.ForestGreen;
        }

        //pb_Universe.CreateGraphics
    }
}
