using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinCE_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.WindowState = FormWindowState.Normal;
        }

        private void mnuFullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show("Press ESC to leave fullscreen");
                mnuFullscreen.Checked = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                mnuFullscreen.Checked = false;
            }
        }

        private void chkMenuOnOff_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkMenuOnOff.Checked)
            {
                this.Menu = mainMenu1;
            }
            else{
                this.Menu = null;
            }
        }

        private void mnuControlBoxEnabled_Click(object sender, EventArgs e)
        {
            mnuControlBoxEnabled.Checked = !mnuControlBoxEnabled.Checked;
            this.ControlBox = mnuControlBoxEnabled.Checked;
        }

        private void mnuControlBoxMinimize_Click(object sender, EventArgs e)
        {
            mnuControlBoxMinimize.Checked = !mnuControlBoxMinimize.Checked;
            this.MinimizeBox = mnuControlBoxMinimize.Checked;
        }

        private void mnuControlBoxMaximize_Click(object sender, EventArgs e)
        {
            mnuControlBoxMaximize.Checked = !mnuControlBoxMaximize.Checked;
            this.MaximizeBox = mnuControlBoxMaximize.Checked;
        }
    }
}