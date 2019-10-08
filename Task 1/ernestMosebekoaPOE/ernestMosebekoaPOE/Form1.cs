using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ernestMosebekoaPOE
{
    public partial class Form1 : Form, FormView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void invalidateView()
        {
            throw new NotImplementedException();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //START timer
            tmrTimer.Enabled = true;
        }

        private void timerTrigger(object sender, EventArgs e)
        {

        }
    }
}
