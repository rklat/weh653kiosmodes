namespace OEMTitleBarHandler
{
    partial class FormMain
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
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuWindowOptions = new System.Windows.Forms.MenuItem();
            this.mnuControlBox = new System.Windows.Forms.MenuItem();
            this.mnuMinimizeBox = new System.Windows.Forms.MenuItem();
            this.mnuMaximize = new System.Windows.Forms.MenuItem();
            this.mnuHideMainMenu = new System.Windows.Forms.MenuItem();
            this.mnuSIPIcon = new System.Windows.Forms.MenuItem();
            this.mnuStartMenuShow = new System.Windows.Forms.MenuItem();
            this.mnuTitleBarList = new System.Windows.Forms.MenuItem();
            this.mnuSetHandler = new System.Windows.Forms.MenuItem();
            this.mnuResetHandler = new System.Windows.Forms.MenuItem();
            this.mnuConnectPopup = new System.Windows.Forms.MenuItem();
            this.mnuCnctDisableAll = new System.Windows.Forms.MenuItem();
            this.mnuCnctAnableAll = new System.Windows.Forms.MenuItem();
            this.mnuCnctDisableCannotConnect = new System.Windows.Forms.MenuItem();
            this.mnuCnctEnableCannotConnect = new System.Windows.Forms.MenuItem();
            this.mnuReDirectRemnet = new System.Windows.Forms.MenuItem();
            this.mnuReplaceRemnet = new System.Windows.Forms.MenuItem();
            this.mnuShFullScreen = new System.Windows.Forms.MenuItem();
            this.mnuStartIconShow = new System.Windows.Forms.MenuItem();
            this.mnuSIPShow = new System.Windows.Forms.MenuItem();
            this.mnuTaskbarShow = new System.Windows.Forms.MenuItem();
            this.mnuStartIconTestForm = new System.Windows.Forms.MenuItem();
            this.mnuNotificationsEnable = new System.Windows.Forms.MenuItem();
            this.mnuBlacklistIExplore = new System.Windows.Forms.MenuItem();
            this.mnuBlacklistAdd = new System.Windows.Forms.MenuItem();
            this.mnuBlacklistRemove = new System.Windows.Forms.MenuItem();
            this.mnuBlacklistEnable = new System.Windows.Forms.MenuItem();
            this.mnuAllKeys = new System.Windows.Forms.MenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mnuLockTaskbar = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuExit);
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuWindowOptions);
            this.mnuOptions.MenuItems.Add(this.mnuTitleBarList);
            this.mnuOptions.MenuItems.Add(this.mnuConnectPopup);
            this.mnuOptions.MenuItems.Add(this.mnuShFullScreen);
            this.mnuOptions.MenuItems.Add(this.mnuStartIconTestForm);
            this.mnuOptions.MenuItems.Add(this.mnuNotificationsEnable);
            this.mnuOptions.MenuItems.Add(this.mnuBlacklistIExplore);
            this.mnuOptions.MenuItems.Add(this.mnuAllKeys);
            this.mnuOptions.Text = "TESTS";
            // 
            // mnuWindowOptions
            // 
            this.mnuWindowOptions.MenuItems.Add(this.mnuControlBox);
            this.mnuWindowOptions.MenuItems.Add(this.mnuMinimizeBox);
            this.mnuWindowOptions.MenuItems.Add(this.mnuMaximize);
            this.mnuWindowOptions.MenuItems.Add(this.mnuHideMainMenu);
            this.mnuWindowOptions.MenuItems.Add(this.mnuSIPIcon);
            this.mnuWindowOptions.MenuItems.Add(this.mnuStartMenuShow);
            this.mnuWindowOptions.MenuItems.Add(this.mnuLockTaskbar);
            this.mnuWindowOptions.Text = "Window Options";
            // 
            // mnuControlBox
            // 
            this.mnuControlBox.Text = "ControlBox";
            this.mnuControlBox.Click += new System.EventHandler(this.mnuControlBox_Click);
            // 
            // mnuMinimizeBox
            // 
            this.mnuMinimizeBox.Text = "MinimizeBox";
            this.mnuMinimizeBox.Click += new System.EventHandler(this.mnuMinimizeBox_Click);
            // 
            // mnuMaximize
            // 
            this.mnuMaximize.Text = "Maximize";
            this.mnuMaximize.Click += new System.EventHandler(this.mnuMaximize_Click);
            // 
            // mnuHideMainMenu
            // 
            this.mnuHideMainMenu.Checked = true;
            this.mnuHideMainMenu.Text = "Main Menu";
            this.mnuHideMainMenu.Click += new System.EventHandler(this.mnuHideMainMenu_Click);
            // 
            // mnuSIPIcon
            // 
            this.mnuSIPIcon.Checked = true;
            this.mnuSIPIcon.Text = "SIP Icon";
            this.mnuSIPIcon.Click += new System.EventHandler(this.mnuSIPIcon_Click);
            // 
            // mnuStartMenuShow
            // 
            this.mnuStartMenuShow.Checked = true;
            this.mnuStartMenuShow.Text = "Start Menu";
            this.mnuStartMenuShow.Click += new System.EventHandler(this.mnuStartMenuShow_Click);
            // 
            // mnuTitleBarList
            // 
            this.mnuTitleBarList.MenuItems.Add(this.mnuSetHandler);
            this.mnuTitleBarList.MenuItems.Add(this.mnuResetHandler);
            this.mnuTitleBarList.Text = "TitleBar-pullDownList";
            // 
            // mnuSetHandler
            // 
            this.mnuSetHandler.Text = "Set Handler";
            this.mnuSetHandler.Click += new System.EventHandler(this.mnuSet_Click);
            // 
            // mnuResetHandler
            // 
            this.mnuResetHandler.Text = "Reset Handler";
            this.mnuResetHandler.Click += new System.EventHandler(this.mnuReset_Click);
            // 
            // mnuConnectPopup
            // 
            this.mnuConnectPopup.MenuItems.Add(this.mnuCnctDisableAll);
            this.mnuConnectPopup.MenuItems.Add(this.mnuCnctAnableAll);
            this.mnuConnectPopup.MenuItems.Add(this.mnuCnctDisableCannotConnect);
            this.mnuConnectPopup.MenuItems.Add(this.mnuCnctEnableCannotConnect);
            this.mnuConnectPopup.MenuItems.Add(this.mnuReDirectRemnet);
            this.mnuConnectPopup.MenuItems.Add(this.mnuReplaceRemnet);
            this.mnuConnectPopup.Text = "Connect Popup";
            // 
            // mnuCnctDisableAll
            // 
            this.mnuCnctDisableAll.Text = "Disable All";
            this.mnuCnctDisableAll.Click += new System.EventHandler(this.mnuCnctDisableAll_Click);
            // 
            // mnuCnctAnableAll
            // 
            this.mnuCnctAnableAll.Text = "Enable All";
            this.mnuCnctAnableAll.Click += new System.EventHandler(this.mnuCnctAnableAll_Click);
            // 
            // mnuCnctDisableCannotConnect
            // 
            this.mnuCnctDisableCannotConnect.Text = "Disable CannotConnect";
            this.mnuCnctDisableCannotConnect.Click += new System.EventHandler(this.mnuCnctDisableCannotConnect_Click);
            // 
            // mnuCnctEnableCannotConnect
            // 
            this.mnuCnctEnableCannotConnect.Text = "Enable CannotConnect";
            this.mnuCnctEnableCannotConnect.Click += new System.EventHandler(this.mnuCnctEnableCannotConnect_Click);
            // 
            // mnuReDirectRemnet
            // 
            this.mnuReDirectRemnet.Text = "ReDirect Remnet";
            this.mnuReDirectRemnet.Click += new System.EventHandler(this.mnuReDirectRemnet_Click);
            // 
            // mnuReplaceRemnet
            // 
            this.mnuReplaceRemnet.Text = "Replace Remnet";
            this.mnuReplaceRemnet.Click += new System.EventHandler(this.mnuReplaceRemnet_Click);
            // 
            // mnuShFullScreen
            // 
            this.mnuShFullScreen.MenuItems.Add(this.mnuStartIconShow);
            this.mnuShFullScreen.MenuItems.Add(this.mnuSIPShow);
            this.mnuShFullScreen.MenuItems.Add(this.mnuTaskbarShow);
            this.mnuShFullScreen.Text = "SHFullScreen";
            // 
            // mnuStartIconShow
            // 
            this.mnuStartIconShow.Checked = true;
            this.mnuStartIconShow.Text = "Show Start Icon";
            this.mnuStartIconShow.Click += new System.EventHandler(this.mnuStartIconShow_Click);
            // 
            // mnuSIPShow
            // 
            this.mnuSIPShow.Checked = true;
            this.mnuSIPShow.Text = "Show SIP Icon";
            this.mnuSIPShow.Click += new System.EventHandler(this.mnuSIPShow_Click);
            // 
            // mnuTaskbarShow
            // 
            this.mnuTaskbarShow.Checked = true;
            this.mnuTaskbarShow.Text = "TaskBar";
            this.mnuTaskbarShow.Click += new System.EventHandler(this.mnuTaskbarShow_Click);
            // 
            // mnuStartIconTestForm
            // 
            this.mnuStartIconTestForm.Text = "Form without StartIcon";
            this.mnuStartIconTestForm.Click += new System.EventHandler(this.mnuStartIconTestForm_Click);
            // 
            // mnuNotificationsEnable
            // 
            this.mnuNotificationsEnable.Checked = true;
            this.mnuNotificationsEnable.Text = "Notifications";
            this.mnuNotificationsEnable.Click += new System.EventHandler(this.mnuNotificationsEnable_Click);
            // 
            // mnuBlacklistIExplore
            // 
            this.mnuBlacklistIExplore.MenuItems.Add(this.mnuBlacklistAdd);
            this.mnuBlacklistIExplore.MenuItems.Add(this.mnuBlacklistRemove);
            this.mnuBlacklistIExplore.MenuItems.Add(this.mnuBlacklistEnable);
            this.mnuBlacklistIExplore.Text = "Blacklist iexplore";
            // 
            // mnuBlacklistAdd
            // 
            this.mnuBlacklistAdd.Text = "Add iexplore";
            this.mnuBlacklistAdd.Click += new System.EventHandler(this.mnuBlacklistAdd_Click);
            // 
            // mnuBlacklistRemove
            // 
            this.mnuBlacklistRemove.Text = "Remove iexplore";
            this.mnuBlacklistRemove.Click += new System.EventHandler(this.mnuBlacklistRemove_Click);
            // 
            // mnuBlacklistEnable
            // 
            this.mnuBlacklistEnable.Text = "Enable Blacklist";
            this.mnuBlacklistEnable.Click += new System.EventHandler(this.mnuBlacklistEnable_Click);
            // 
            // mnuAllKeys
            // 
            this.mnuAllKeys.Text = "AllKeys";
            this.mnuAllKeys.Click += new System.EventHandler(this.mnuAllKeys_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 268);
            this.textBox1.TabIndex = 0;
            // 
            // mnuLockTaskbar
            // 
            this.mnuLockTaskbar.Text = "Lock Taskbar";
            this.mnuLockTaskbar.Click += new System.EventHandler(this.mnuLockTaskbar_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Text = "Fullscreen Test";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuWindowOptions;
        private System.Windows.Forms.MenuItem mnuControlBox;
        private System.Windows.Forms.MenuItem mnuMinimizeBox;
        private System.Windows.Forms.MenuItem mnuMaximize;
        private System.Windows.Forms.MenuItem mnuTitleBarList;
        private System.Windows.Forms.MenuItem mnuSetHandler;
        private System.Windows.Forms.MenuItem mnuResetHandler;
        private System.Windows.Forms.MenuItem mnuHideMainMenu;
        private System.Windows.Forms.MenuItem mnuSIPIcon;
        private System.Windows.Forms.MenuItem mnuConnectPopup;
        private System.Windows.Forms.MenuItem mnuCnctDisableAll;
        private System.Windows.Forms.MenuItem mnuCnctAnableAll;
        private System.Windows.Forms.MenuItem mnuCnctDisableCannotConnect;
        private System.Windows.Forms.MenuItem mnuCnctEnableCannotConnect;
        private System.Windows.Forms.MenuItem mnuShFullScreen;
        private System.Windows.Forms.MenuItem mnuStartIconShow;
        private System.Windows.Forms.MenuItem mnuSIPShow;
        private System.Windows.Forms.MenuItem mnuTaskbarShow;
        private System.Windows.Forms.MenuItem mnuStartMenuShow;
        private System.Windows.Forms.MenuItem mnuStartIconTestForm;
        private System.Windows.Forms.MenuItem mnuNotificationsEnable;
        private System.Windows.Forms.MenuItem mnuReDirectRemnet;
        private System.Windows.Forms.MenuItem mnuBlacklistIExplore;
        private System.Windows.Forms.MenuItem mnuBlacklistAdd;
        private System.Windows.Forms.MenuItem mnuBlacklistRemove;
        private System.Windows.Forms.MenuItem mnuBlacklistEnable;
        private System.Windows.Forms.MenuItem mnuAllKeys;
        private System.Windows.Forms.MenuItem mnuReplaceRemnet;
        private System.Windows.Forms.MenuItem mnuLockTaskbar;
    }
}

