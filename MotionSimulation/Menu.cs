using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionSimulation
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm MotionSimulation = new MainForm();
            MotionSimulation.ShowInTaskbar = false;
            MotionSimulation.StartPosition = FormStartPosition.CenterScreen;
            MotionSimulation.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            theory theory = new theory();
            theory.ShowInTaskbar = false;
            theory.StartPosition = FormStartPosition.CenterScreen;
            theory.ShowDialog(this);
        }
    }
}
