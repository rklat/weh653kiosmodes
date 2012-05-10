using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OEMTitleBarHandler
{
    public partial class LockDownTestForm : Form
    {
        public LockDownTestForm()
        {
            InitializeComponent();
            label1.Text = "This form will show without StartIcon. The registry changes are done before the form is shown. \r\nOn close, the registry changes are reverted.";
        }
    }
}