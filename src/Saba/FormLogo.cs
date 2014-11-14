using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Saba
{
    public partial class FormLogo : Form
    {
        public FormLogo()
        {
            InitializeComponent();
        }

        AutoResetEvent delay = new AutoResetEvent(false);

        private void FormLogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 1; i <= 20; i++)
            {
                this.Opacity -= 0.05;
                Application.DoEvents();
                delay.WaitOne(50, false);
            }
        }

        private void FormLogo_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
