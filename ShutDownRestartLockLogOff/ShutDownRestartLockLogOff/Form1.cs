//Develop by Irfan Noor from Pakistan
//Date May 28,2018
//Time 12:29 PM
//Contact +92 301 4111098
//Email irfannoor6667@gmail.com
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ShutDownRestartLockLogOff
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public Form1()
        {
            InitializeComponent();
        }
       
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SetSuspendState(true, true, true);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            SetSuspendState(false, true, true);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                help a = new help();
                a.Show();                
            }
            //if (e.Control && e.Alt && e.KeyCode == Keys.O)

            if (e.Control && e.KeyCode == Keys.S)
            {
                Process.Start("shutdown", "/s /t 0");
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                Process.Start("shutdown", "/r /t 0");
            }
            else if (e.Control && e.KeyCode == Keys.H)
            {
                SetSuspendState(true, true, true);
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                LockWorkStation();
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                SetSuspendState(false, true, true);
            }
            else if (e.Alt && e.KeyCode == Keys.L)
            {
                ExitWindowsEx(0, 0);
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
