using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Universe;

namespace MotionSimulation
{
    public partial class MainForm : Form
    {
        private Canvas _canvas;
        private const int secondsInHour = 3600;
        private const int hoursInYear = 8766;
        private const int hoursInMonth = 730;
        private const int hoursInDay = 24;
        private const int timerInterval = 40;
        private const int framesPerSecond = 1000 / timerInterval;
        private IAstronomicalObject _mainObject;

        private const double minDensity = 0.5;
        private const double maxDensity = 7;
        private readonly string validationWarning = $"Згідно класифікація є три основних типи астероїдів.\nКлас С (1.38 г/см³) — вуглецеві, 75% відомих астероїдів.\nКлас S (2.71 г/см³) — силікатні, 17% відомих астероїдів.\nКлас M (5.32 г/см³)— металеві, більшість інших.\nСамий: легкий метал це Літій 0,53 г/см³, щільний метал це Осмій 22,58 г/см³";

        public MainForm()
        {
            InitializeComponent();
            Initialize();
            timer1.Interval = timerInterval;
        }

        private void Initialize()
        {
            var scaleLength = (double)nUD_Length.Value;

            var Earth = new AstronomicalObject
            (
                name: "Земля",
                mass: 5.9726E24,
                radius: 6.371E6,
                position: new Position(4E8, 4E8),
                speedVector: new Vector(0, -12.6)
            );
            var Moon = new AstronomicalObject
            (
                name: "Місяць",
                mass: 7.3477E22,
                radius: 1.737E6,
                position: new Position(7.84467E8, 4E8),
                speedVector: new Vector(0, 1023)
            );

            _mainObject = Earth;
            _canvas = new Canvas(pb_Universe.Width, pb_Universe.Height);
            _canvas.AddBody(Earth);
            _canvas.AddBody(Moon);
            _canvas.Scale.Length = scaleLength;
            _canvas.Scale.Time = (int)(nUD_Time.Value / framesPerSecond);
            FillInForm();
        }

        private void FillInForm()
        {
            _canvas.Refresh();
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
            return $"{obj.Name}, R {(obj.Radius / 1000).ToString("# ##0.#")} км, ρ {obj.GetDensity().ToString("0.00")} г/cм³:\n" +
                $"   - швидкість    {GetSpeedInKilometersPerSecond(obj.SpeedVector.Speed)} км/с\n" +
                $"   - відстань {GetDistanceInKilometers(_mainObject, obj)} т.км\n";
        }

        private string GetSpeedInKilometersPerSecond(double speed) => (speed / 1000).ToString("0.00");

        private string GetDistanceInKilometers(IAstronomicalObject obj1, IAstronomicalObject obj2)
        {
            return (obj1.Distance(obj2) / 1E6).ToString("# ###");
        }

        private string GetDateFromHours(int numberOfSeconds)
        {
            var hours = numberOfSeconds / secondsInHour;
            var sb = new StringBuilder();
            sb.Append((hours / hoursInYear).ToString("0"));
            sb.Append(" р ");
            sb.Append((hours % hoursInYear / hoursInMonth).ToString("0"));
            sb.Append(" м ");
            sb.Append((hours % hoursInMonth / hoursInDay).ToString("00"));
            sb.Append(" д ");
            sb.Append((hours % hoursInDay).ToString("00"));
            sb.Append(" г");
            return sb.ToString();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (_canvas.DoStep())
                Bang();
            FillInForm();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Розпочати";
                groupBox1.Enabled = true;
            }
            else
            {
                timer1.Start();
                button1.Text = "Зупинити";
                groupBox1.Enabled = false;
            }
        }

        private void nUD_Length_ValueChanged(object sender, System.EventArgs e)
        {
            _canvas.Scale.Length = (double)nUD_Length.Value;
            FillInForm();
        }

        private void nUD_Time_ValueChanged(object sender, System.EventArgs e)
        {
            _canvas.Scale.Time = (int)(nUD_Time.Value / framesPerSecond);
        }

        private void btn_ToCenter_Click(object sender, System.EventArgs e)
        {
            _canvas.MoveCenterTo();
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
            if (Gravity.IsAbandoned(_canvas.SystemOfBody[0], _canvas.SystemOfBody[_canvas.SystemOfBody.Count - 1]))
            {
                btn_IsAbandoned.ForeColor = Color.Red;
                Abandoned();
            }
            else
                btn_IsAbandoned.ForeColor = Color.ForestGreen;
        }

        private void btn_AddBody_Click(object sender, EventArgs e)
        {
            var speedX = (double)nUD_speedX.Value;
            var speedY = (double)nUD_speedY.Value;
            var positionX = (double)nUD_positionX.Value;
            var positionY = (double)nUD_positionY.Value;
            var mass = (double)nUD_Mass.Value * 1000;
            var radius = (double)nUD_Radius.Value;
            var density = AstronomicalObject.GetDensity(mass, radius);
            var Asteroid = new AstronomicalObject
            (
                name: "Астероїд",
                mass: mass,
                radius: radius,
                position: new Position(positionX, positionY),
                speedVector: new Vector(speedX, speedY)
            );
            if (!Validation(Asteroid))
            {
                var result = MessageBox.Show(
                    validationWarning + $"\n\nСтворити астероїд з щільністю {density.ToString("# ##0.0##")} г/см³?\nЩоб продовжити редагування оберіть <Нет>.", "Попередження", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
            _canvas.AddBody(Asteroid);
            FillInForm();
        }

        public bool Validation(IAstronomicalObject obj) => obj.GetDensity() >= minDensity && obj.GetDensity() <= maxDensity;

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Font = new Font(toolStripStatusLabel2.Font,
                toolStripStatusLabel2.Font.Style == FontStyle.Strikeout ? FontStyle.Regular : FontStyle.Strikeout);
            toolStripStatusLabel2.BorderStyle =
                toolStripStatusLabel2.BorderStyle == Border3DStyle.RaisedOuter ? Border3DStyle.SunkenInner : Border3DStyle.RaisedOuter;
            _canvas.ShowTraces = !_canvas.ShowTraces;
            if (!timer1.Enabled)
                FillInForm();
        }

        private void Bang()
        {
            PlayWavFile("Bang.wav");
        }

        private void Abandoned()
        {
            PlayWavFile("Funeral.wav");
        }

        private static void PlayWavFile(string wav)
        {
            if (!File.Exists(wav))
                return;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.SoundLocation = wav;
            sp.Load();
            sp.Play();
            sp.Dispose();
        }

        protected override void OnClosed(EventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            base.OnClosed(e);
        }
    }
}
