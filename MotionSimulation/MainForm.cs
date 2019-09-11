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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            var timer = new System.Threading.Timer(tm, null, 0, 200);
        }
    }
}
