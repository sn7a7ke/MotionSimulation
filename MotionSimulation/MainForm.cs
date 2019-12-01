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
            Initialize();
            FillInForm();
            timer1.Interval = timerInterval;
        }

        private void Initialize()
        {
            var Earth = new AstronomicalObject
            {
                Name = "Земля",
                Mass = 5.9726E24,
                Radius = 6.371E6,
                Position = new Position(4E8, 4E8),
                SpeedVector = new SpeedVector(0, -12.6)
            };
            var Moon = new AstronomicalObject
            {
                Name = "Місяць",
                Mass = 7.3477E22,
                Radius = 1.737E6,
                Position = new Position(7.84467E8, 4E8),
                SpeedVector = new SpeedVector(0, 1023)
            };

            var speedX = (double)nUD_speedX.Value;
            var speedY = (double)nUD_speedY.Value;
            var positionX = (double)nUD_positionX.Value;
            var positionY = (double)nUD_positionY.Value;
            var scaleLength = (double)nUD_Length.Value;
            var Asteroid = new AstronomicalObject
            {
                Name = "Астероїд",
                Mass = 5E9,
                Radius = 1E3,
                Position = new Position(positionX, positionY),
                SpeedVector = new SpeedVector(speedX, speedY)
            };

            _system = new SystemOfBody();
            _system.AddBody(Earth);
            _system.AddBody(Moon);
            _system.AddBody(Asteroid);
            _mainObject = _system.Bodies[0];
            _canvas = new Canvas(pb_Universe.Width, pb_Universe.Height, _system);
            _canvas.Scale.Length = scaleLength;
            _canvas.Scale.Time = (int)(nUD_Time.Value / timerInterval);
            _canvas.Refresh();
        }

        private void FillInForm()
        {
            pb_Universe.Image = _canvas.MainBmp;
            lbl_Info.Text = "З початку: " + GetDateFromHours(_canvas.SecondsFromStart) + "\n" +
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
                $"   - швидкість    {GetSpeedInKilometersPerSecond(obj.SpeedVector.Speed)} км/с" + "\n" +
                $"   - відстань {GetDistanceInKilometers(_mainObject.Position, obj.Position)} тис. км" + "\n";
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
            return (hours / 8766).ToString("0") + " г " +
                    (hours % 8766 / 730).ToString("0") + " м " +
                    (hours % 730 / 24).ToString("00") + " д " +
                    (hours % 24).ToString("00") + " г";
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
                button1.Text = "Розпочати";
                nUD_positionX.Enabled = true;
                nUD_positionY.Enabled = true;
                nUD_speedX.Enabled = true;
                nUD_speedY.Enabled = true;
            }
            else
            {
                timer1.Start();
                button1.Text = "Зупинити";
                nUD_positionX.Enabled = false;
                nUD_positionY.Enabled = false;
                nUD_speedX.Enabled = false;
                nUD_speedY.Enabled = false;
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
            _canvas.MoveCenterTo();
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

        private void nUD_NumChanged(object sender, EventArgs e)
        {
            Initialize();
            FillInForm();
        }
    }
}
