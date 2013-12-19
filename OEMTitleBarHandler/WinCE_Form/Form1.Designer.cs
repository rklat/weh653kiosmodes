namespace WinCE_Form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMenuOnOff = new System.Windows.Forms.CheckBox();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuExtra = new System.Windows.Forms.MenuItem();
            this.mnuFullscreen = new System.Windows.Forms.MenuItem();
            this.mnuControlBox = new System.Windows.Forms.MenuItem();
            this.mnuControlBoxEnabled = new System.Windows.Forms.MenuItem();
            this.mnuControlBoxMinimize = new System.Windows.Forms.MenuItem();
            this.mnuControlBoxMaximize = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuFile);
            this.mainMenu1.MenuItems.Add(this.mnuExtra);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 65);
            this.label1.Text = "This is a Windows CE Form created via VS2008 Smart Device Target=Windows CE";
            // 
            // chkMenuOnOff
            // 
            this.chkMenuOnOff.Checked = true;
            this.chkMenuOnOff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMenuOnOff.Location = new System.Drawing.Point(11, 96);
            this.chkMenuOnOff.Name = "chkMenuOnOff";
            this.chkMenuOnOff.Size = new System.Drawing.Size(110, 23);
            this.chkMenuOnOff.TabIndex = 1;
            this.chkMenuOnOff.Text = "Menu on/off";
            this.chkMenuOnOff.CheckStateChanged += new System.EventHandler(this.chkMenuOnOff_CheckStateChanged);
            // 
            // mnuFile
            // 
            this.mnuFile.MenuItems.Add(this.mnuExit);
            this.mnuFile.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            // 
            // mnuExtra
            // 
            this.mnuExtra.MenuItems.Add(this.mnuFullscreen);
            this.mnuExtra.MenuItems.Add(this.mnuControlBox);
            this.mnuExtra.Text = "Extra";
            // 
            // mnuFullscreen
            // 
            this.mnuFullscreen.Text = "Fullscreen";
            this.mnuFullscreen.Click += new System.EventHandler(this.mnuFullscreen_Click);
            // 
            // mnuControlBox
            // 
            this.mnuControlBox.MenuItems.Add(this.mnuControlBoxEnabled);
            this.mnuControlBox.MenuItems.Add(this.mnuControlBoxMinimize);
            this.mnuControlBox.MenuItems.Add(this.mnuControlBoxMaximize);
            this.mnuControlBox.Text = "ControlBox";
            // 
            // mnuControlBoxEnabled
            // 
            this.mnuControlBoxEnabled.Checked = true;
            this.mnuControlBoxEnabled.Text = "Enabled";
            this.mnuControlBoxEnabled.Click += new System.EventHandler(this.mnuControlBoxEnabled_Click);
            // 
            // mnuControlBoxMinimize
            // 
            this.mnuControlBoxMinimize.Checked = true;
            this.mnuControlBoxMinimize.Text = "Minimize Box";
            this.mnuControlBoxMinimize.Click += new System.EventHandler(this.mnuControlBoxMinimize_Click);
            // 
            // mnuControlBoxMaximize
            // 
            this.mnuControlBoxMaximize.Text = "Maximize Box";
            this.mnuControlBoxMaximize.Click += new System.EventHandler(this.mnuControlBoxMaximize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.chkMenuOnOff);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "WinCE Form Sample";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuExtra;
        private System.Windows.Forms.MenuItem mnuFullscreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkMenuOnOff;
        private System.Windows.Forms.MenuItem mnuControlBox;
        private System.Windows.Forms.MenuItem mnuControlBoxEnabled;
        private System.Windows.Forms.MenuItem mnuControlBoxMinimize;
        private System.Windows.Forms.MenuItem mnuControlBoxMaximize;
    }
}

