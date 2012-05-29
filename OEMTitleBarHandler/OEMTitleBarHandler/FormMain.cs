using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OEMTitleBarHandler
{
    public partial class FormMain : Form
    {
        FullScreen _fullscreen;
        Notifications.Notifications _not;

        public FormMain(string[] sCmds)
        {
            InitializeComponent();
            _fullscreen = new FullScreen(this);
            _not = new Notifications.Notifications();

            foreach (string s in sCmds)
                textBox1.Text += s + "\r\n";
            if (sCmds.Length == 1 && sCmds[0] == "/TASKBAR_DATACONNECTION")
                MessageBox.Show("Application has been called by Taskbar popup list");

            dumpSettings();
            dumpRectangle();
        }
        private void dumpSettings()
        {
            textBox1.Text += "------------------------\r\n";
            foreach (string s in CustomTitleBar.TitelBarHandlers)
            {
                addText(s);
                addText(CustomTitleBar.getCustomHandler((CustomTitleBar.titleBarEvents)Enum.Parse(typeof(CustomTitleBar.titleBarEvents), s, true)));
                addText("------------------------");
            }
        }
        private void dumpRectangle()
        {
            Rectangle cRect = this.ClientRectangle;
            addText(string.Format("ClientRectangle= {0};{1} {2};{3}", cRect.Left, cRect.Top, cRect.Right, cRect.Bottom));
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            _not.RestoreNotificationSettings();
            Application.Exit();
        }
        private void addText(string s)
        {
            textBox1.Text += s + "\r\n";
            textBox1.SelectionStart = textBox1.Text.Length - 1;
            textBox1.ScrollToCaret();
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (CustomTitleBar.resetCustomHandler(CustomTitleBar.titleBarEvents.TASKBAR_DATACONNECTION))
                addText("resetCustomHandler OK");
            else
                addText("resetCustomHandler failed");
            dumpSettings();
        }

        private void mnuSet_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if(CustomTitleBar.setCustomHandler(CustomTitleBar.titleBarEvents.TASKBAR_DATACONNECTION))
                addText("setCustomHandler = OK");
            else
                addText("setCustomHandler = Failed");
            dumpSettings();
        }

        private void mnuMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                //remove Taskbar
                this.WindowState = FormWindowState.Maximized;
                mnuMaximize.Checked = true;
            }
            else
            {
                //show Taskbar
                this.WindowState = FormWindowState.Normal;
                mnuMaximize.Checked = false;
            }
        }

        private void mnuControlBox_Click(object sender, EventArgs e)
        {
            if (this.ControlBox)
            {
                //show the (X) button, hide OK button
                this.ControlBox = false;
                mnuControlBox.Checked = false;
            }
            else
            {
                //remove the (X) button in title, show the OK button
                this.ControlBox = true;
                mnuControlBox.Checked = true;
            }
        }

        private void mnuMinimizeBox_Click(object sender, EventArgs e)
        {
            if (this.MinimizeBox)
            {
                //hide minimize button (OK)
                this.MinimizeBox = false;
                mnuMinimizeBox.Checked = false;
            }
            else
            {
                //show minimize button (OK)
                this.MinimizeBox = true;
                mnuMinimizeBox.Checked = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            addText("Form Resized:");
            dumpRectangle();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            addText("KeyDown: " + e.KeyCode.ToString());
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
            if ((e.KeyCode == Keys.Escape))
            {
                if (this.Menu == null)
                    this.Menu = mainMenu1;
            }
        }

        private void mnuHideMainMenu_Click(object sender, EventArgs e)
        {
            if (this.Menu != null)
            {
                MessageBox.Show("Use the Escape key to bring the menu back!");
                this.Menu = null;
                mnuHideMainMenu.Checked = false;
            }
            else
                mnuHideMainMenu.Checked = true;

        }

        private void mnuSIPIcon_Click(object sender, EventArgs e)
        {
            mnuSIPIcon.Checked = !mnuSIPIcon.Checked;
            this._fullscreen.showSIPIcon(mnuSIPIcon.Checked);
        }

        private void mnuCnctDisableAll_Click(object sender, EventArgs e)
        {
            ConnectionPopups cnct = new ConnectionPopups();
            if (cnct.disableAllPopups())
                addText("All connect popups disabled");
            else
                addText("All connect popups disable FAILED");
            
        }

        private void mnuCnctAnableAll_Click(object sender, EventArgs e)
        {
            ConnectionPopups cnct = new ConnectionPopups();
            if (cnct.enableAll())
                addText("All connect popups enabled");
            else
                addText("All connect popups enable FAILED");

        }

        private void mnuCnctDisableCannotConnect_Click(object sender, EventArgs e)
        {
            ConnectionPopups cnct = new ConnectionPopups();
            if (cnct.disablePopup(ConnectionPopups.ConnectPopupIDs.IDS_CM_STATUS_NOPATHTODESTINATION))
                addText("Disable Popup 'IDS_CM_STATUS_NOPATHTODESTINATION' OK");
            else
                addText("Disable Popup 'IDS_CM_STATUS_NOPATHTODESTINATION' FAILED");

        }

        private void mnuCnctEnableCannotConnect_Click(object sender, EventArgs e)
        {
            ConnectionPopups cnct = new ConnectionPopups();
            if (cnct.enablePopup(ConnectionPopups.ConnectPopupIDs.IDS_CM_STATUS_NOPATHTODESTINATION))
                addText("Enable Popup 'IDS_CM_STATUS_NOPATHTODESTINATION' OK");
            else
                addText("Enable Popup 'IDS_CM_STATUS_NOPATHTODESTINATION' FAILED");

        }

        private void mnuStartIconShow_Click(object sender, EventArgs e)
        {
            mnuStartIconShow.Checked = !mnuStartIconShow.Checked;
            if (_fullscreen.showStartIcon(mnuStartIconShow.Checked))
                addText("ShFullScreen StartIcon OK");
            else
                addText("ShFullScreen StartIcon FAILED");
        }

        private void mnuSIPShow_Click(object sender, EventArgs e)
        {
            mnuSIPIcon.Checked = !mnuSIPIcon.Checked;
            if(_fullscreen.shSIPIcon(mnuSIPIcon.Checked))
                addText("ShFullScreen SIPIcon OK");
            else
                addText("ShFullScreen SIPIcon FAILED");
        }

        private void mnuTaskbarShow_Click(object sender, EventArgs e)
        {
            mnuTaskbarShow.Checked = !mnuTaskbarShow.Checked;
            if (_fullscreen.shSIPIcon(mnuTaskbarShow.Checked))
                addText("ShFullScreen Taskbar OK");
            else
                addText("ShFullScreen Taskbar FAILED");

        }

        private void mnuStartMenuShow_Click(object sender, EventArgs e)
        {
            mnuStartMenuShow.Checked = !mnuStartMenuShow.Checked;
            if (_fullscreen.enableStartMenu(mnuStartMenuShow.Checked))
                addText("Enable/Disable MSSTARTMENU OK");
            else
                addText("Enable/Disable MSSTARTMENU FAILED");

        }

        private void mnuStartIconTestForm_Click(object sender, EventArgs e)
        {
            Lockdown.LockDown.SaveRegistryFullScreen();
            Lockdown.LockDown.SetRegistryFullScreen(true, false, false);
            LockDownTestForm frm = new LockDownTestForm();
            frm.ShowDialog();
            Lockdown.LockDown.RestoreRegistryFullScreen();
            frm.Dispose();
        }

        private void mnuNotificationsEnable_Click(object sender, EventArgs e)
        {
            mnuNotificationsEnable.Checked = !mnuNotificationsEnable.Checked;
            if (mnuNotificationsEnable.Checked)
            {
                if (_not.RestoreNotificationSettings())
                    addText("Notifications restore OK");
                else
                    addText("Notifications restore FAILED");
            }
            else
            {
                if (_not.disableAllNotifications())
                    addText("Notifications disableAll OK");
                else
                    addText("Notifications disableAll FAILED");
            }
        }

        private void mnuReDirectRemnet_Click(object sender, EventArgs e)
        {
            mnuReDirectRemnet.Checked = !mnuReDirectRemnet.Checked;
            ConnectionPopups cnct = new ConnectionPopups();
            if (mnuReDirectRemnet.Checked)
            {
                if (cnct.reDirectRemnet("OEMTitleBarHandler.exe"))
                    addText("Redirect OK");
                else
                    addText("Redirect FAILED");
            }
            else
            {
                if(cnct.reDirectRemnetRestore())
                    addText("Redirect restore OK");
                else
                    addText("Redirect restore FAILED");
            }
        }

        private void mnuBlacklistAdd_Click(object sender, EventArgs e)
        {
            Blacklist.BlackList _blacklist = new Blacklist.BlackList();
            if (_blacklist.addEntry("iexplore.exe"))
                addText("Blacklist: add iexplore.exe OK");
            else
                addText("Blacklist: add iexplore.exe FAILED");
            if(_blacklist.enableBlacklist(true))
                addText("Blacklist: enabled OK");
            else
                addText("Blacklist: enabled FAILED");
            mnuBlacklistEnable.Checked = _blacklist._isEnabled;
        }

        private void mnuBlacklistRemove_Click(object sender, EventArgs e)
        {
            Blacklist.BlackList _blacklist = new Blacklist.BlackList();
            if (_blacklist.removeEntry("iexplore.exe"))
                addText("Blacklist: remove iexplore.exe OK");
            else
                addText("Blacklist: remove iexplore.exe FAILED");
            mnuBlacklistEnable.Checked = _blacklist._isEnabled;

        }

        private void mnuBlacklistEnable_Click(object sender, EventArgs e)
        {
            mnuBlacklistEnable.Checked = !mnuBlacklistEnable.Checked;
            Blacklist.BlackList _blacklist = new Blacklist.BlackList();
            if (_blacklist.enableBlacklist(mnuBlacklistEnable.Checked))
                addText("Blacklist: enabled/disabled OK");
            else
                addText("Blacklist: enabled/disabled FAILED");
            mnuBlacklistEnable.Checked = _blacklist._isEnabled;
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            addText("KeyPress: '" + e.KeyChar.ToString() + "'");
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            addText("KeyUp: " + e.KeyCode.ToString());
        }

        private void mnuAllKeys_Click(object sender, EventArgs e)
        {
            mnuAllKeys.Checked = !mnuAllKeys.Checked;
            Lockdown.LockDown.AllKeys(mnuAllKeys.Checked);
        }

        private void mnuReplaceRemnet_Click(object sender, EventArgs e)
        {
            mnuReplaceRemnet.Checked = !mnuReplaceRemnet.Checked;

            EmbeddedResources _res = new EmbeddedResources();
            if (mnuReplaceRemnet.Checked)
            {
                if (_res.replaceRemnet())
                    addText("Replacement of Remnet.exe OK");
                else
                    addText("Replacement of Remnet.exe FAILED");
            }
            else
            {
                if (_res.restoreRemnet())
                    addText("Restore of Remnet.exe OK");
                else
                    addText("Restore of Remnet.exe FAILED");
            }
        }

        private void mnuLockTaskbar_Click(object sender, EventArgs e)
        {
            mnuLockTaskbar.Checked = !mnuLockTaskbar.Checked;
            if (_fullscreen.enableTaskbar(!mnuLockTaskbar.Checked))
                if (mnuLockTaskbar.Checked)
                    addText("Taskbar locked");
                else
                    addText("Taskbar unlocked");
            else
                addText("enableTaskbar failed");
        }

    }
}