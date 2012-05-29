using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace OEMTitleBarHandler
{
    class FullScreen:IDisposable
    {
        Form _frm;
        public FullScreen(Form frm)
        {
            _frm = frm;
        }
        public void Dispose(){

        }
        public bool enableTaskbar(bool bEnable)
        {
            bool bRet = false;
            IntPtr hTaskbar = FindWindow("HHTaskBar", String.Empty);
            if (hTaskbar != IntPtr.Zero)
                bRet = EnableWindow(hTaskbar, bEnable);
            return bRet;
        }

        public bool hideTaskbar(bool bHide)
        {
            if (bHide)
                _frm.WindowState = FormWindowState.Maximized;
            else
                _frm.WindowState = FormWindowState.Normal;
            return bHide;
        }
        public bool showOKButton(bool bShow)
        {
            _frm.ControlBox = bShow;
            _frm.MinimizeBox = false;
            return bShow;
        }
        public bool showXButton(bool bShow)
        {
            _frm.ControlBox = bShow;
            _frm.MinimizeBox = true;
            return bShow;
        }
        public bool showControlButton(bool bShow)
        {
            _frm.ControlBox = bShow;
            return bShow;
        }
        #region SHFullScreen
        const uint SHFS_SHOWTASKBAR = 0x0001;
        const uint SHFS_HIDETASKBAR = 0x0002;
        const uint SHFS_SHOWSIPBUTTON = 0x0004;
        const uint SHFS_HIDESIPBUTTON = 0x0008;
        const uint SHFS_SHOWSTARTICON = 0x0010;
        const uint SHFS_HIDESTARTICON = 0x0020;
        [Flags]
        private enum SHFS_Flags:uint
        {
            /// <summary>
            /// Return the taskbar to its topmost state.
            /// </summary>
            SHFS_SHOWTASKBAR = 0x0001,  
            /// <summary>
            /// Put the taskbar at the bottom of the z-order. Note that a game or an application that requires take-over of the entire screen may use this flag. It is the responsibility of the application to make sure it is sized FULL SCREEN before using this flag. Otherwise, it will appear as though the function did nothing.
            /// </summary>
            SHFS_HIDETASKBAR = 0x0002,
            /// <summary>
            /// Return the Input Panel button to its visible state. 
            /// </summary>
            SHFS_SHOWSIPBUTTON = 0x0004,
            /// <summary>
            /// Hide the Input Panel button. 
            /// </summary>
            SHFS_HIDESIPBUTTON = 0x0008,
            /// <summary>
            /// Return the Start button icon to the navigation bar. 
            /// </summary>
            SHFS_SHOWSTARTICON = 0x0010,
            /// <summary>
            /// Hide the Start button icon on the navigation bar. When the Start icon is hidden, the shell is in a special state in which clicking or tapping the navigation bar will not display the drop-down Start menu. The navigation bar is essentially disabled when in this state. While in this mode, WM_LBUTTONDOWN and WM_LBUTTONUP messages will be forwarded to hwndRequester. This allows an application to drop out of this mode by calling this function with the SHFS_SHOWSTARTICON, when the user clicks or taps the navigation bar. 
            /// </summary>
            SHFS_HIDESTARTICON = 0x0020,
        }
        [DllImportAttribute("coredll.dll", EntryPoint = "AllKeys", SetLastError = true, PreserveSig = true, CallingConvention = CallingConvention.Winapi)]
        [PreserveSigAttribute()]
        private static extern bool AllKeys(bool bAllKeys);

        /// <summary>
        /// the SHFullScreen API does not work anymore with WEH 6.5.3:
        /// </summary>
        /// <param name="hwndRequester"></param>
        /// <param name="shFlags"></param>
        /// <returns></returns>
        [DllImport("aygshell.dll", SetLastError=true)]
        static extern bool SHFullScreen(IntPtr hwndRequester, SHFS_Flags shFlags);

        [DllImport("coredll.dll", SetLastError=true)]
        public static extern IntPtr GetCapture();
        
        [DllImport("coredll.dll", SetLastError=true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImport("coredll.dll", SetLastError=true)]
        private static extern IntPtr FindWindow(string lpClass, string lpTitle);
        
        [DllImport("coredll.dll", SetLastError=true)]
        static extern bool UpdateWindow(IntPtr hWnd);
        
        [DllImportAttribute("coredll.dll", SetLastError=true)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowFlags cmdShow);
        
        [DllImportAttribute("coredll.dll", SetLastError=true)]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        
        [DllImportAttribute("coredll.dll", SetLastError=true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowFlags uCmd);
        
        private enum GetWindowFlags
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_MAX = 5,
        }
        [Flags]
        private enum ShowWindowFlags
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWNA = 8,
            SW_SHOWMAXIMIZED = 11,
            SW_MAXIMIZE = 12,
            SW_RESTORE = 13,
        }
        public bool enableStartMenu(bool bEnable)
        {
            IntPtr hwndStartIcon = FindWindow("MSSTARTMENU", "Start");
            if (hwndStartIcon != IntPtr.Zero)
            {
                if (!EnableWindow(hwndStartIcon, bEnable))
                {
                    addLog("showStartMenu:ShowWindow failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                    return false;
                }
                else
                    return true;

                //############### alternative not working code
                //IntPtr hwndStartChild = GetWindow(hwndStartIcon, GetWindowFlags.GW_CHILD);
                //if (hwndStartIcon != IntPtr.Zero)
                //{
                //    if (!ShowWindow(hwndStartChild, (bShow ? ShowWindowFlags.SW_SHOWNORMAL | ShowWindowFlags.SW_SHOWNOACTIVATE : 0)))
                //    {
                //        addLog("showStartMenu:ShowWindow:hwndStartChild failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                //        return false;
                //    }
                //    if (!ShowWindow(hwndStartIcon, (bShow ? ShowWindowFlags.SW_SHOWNORMAL | ShowWindowFlags.SW_SHOWNOACTIVATE : 0)))
                //    {
                //        addLog("showStartMenu:ShowWindow:hwndStartIcon failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                //        return false;
                //    }
                //}
                //else
                //{
                //    addLog("ShowStartMenu no child of MSSTARTMENU found");
                //    return false;
                //}
                //############### alternative not working code
                //if (bShow)
                //{
                //    //EnableWind
                //    if (!ShowWindow(hwndStartIcon, ShowWindowFlags.SW_SHOW))
                //    {
                //        addLog("showStartMenu:ShowWindow failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (!ShowWindow(hwndStartIcon, ShowWindowFlags.SW_HIDE))
                //    {
                //        addLog("showStartMenu:ShowWindow failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                //        return false;
                //    }
                //}
            }
            else
            {
                addLog("ShowStartMenu no MSSTARTMENU found");
                return false;
            }
            //return true;
        }
        public bool enableAllKeys(bool bEnable)
        {
            if (!AllKeys(bEnable))
            {
                addLog("enableAllKeys failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool showStartIcon(bool bShow)
        {
            bool bRet = false;
            bool bRes;
            _frm.Show();
            _frm.Capture = true;
            IntPtr hwndForm = GetCapture();
            _frm.Capture = false;
            SHFS_Flags flags;
            if (bShow)
                flags = SHFS_Flags.SHFS_SHOWSTARTICON;
            else
                flags = SHFS_Flags.SHFS_HIDESTARTICON;

            bRes = SetForegroundWindow(hwndForm);
            if (!bRes)
                addLog("showStartIcon:SetForegroundWindow failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
            bRes = SHFullScreen(hwndForm, flags); //21
            if (!bRes)
                addLog("showStartIcon:SHFullScreen failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
            bRet = bRes;
            _frm.Invalidate();

            return bRet;
        }
        public bool shSIPIcon(bool bShow)
        {
            bool bRet = false;
            bool bRes;
            _frm.Show();
            _frm.Capture = true;
            IntPtr hwndForm = GetCapture();
            _frm.Capture = false;
            SHFS_Flags flags;
            if (bShow)
                flags = SHFS_Flags.SHFS_SHOWSIPBUTTON;
            else
                flags = SHFS_Flags.SHFS_HIDESIPBUTTON;

            bRes = SetForegroundWindow(hwndForm);
            if (!bRes)
                addLog("showStartIcon:SetForegroundWindow failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
            bRes = SHFullScreen(hwndForm, flags); //21
            if (!bRes)
                addLog("showStartIcon:SHFullScreen failed: GetLastError=0x" + Marshal.GetLastWin32Error().ToString("x"));
            bRet = bRes;
            _frm.Invalidate();

            return bRet;
        }        
        
        public bool showSIPIcon(bool bShow)
        {
            IntPtr hwndSIP = FindWindow("MS_SIPBUTTON", "MS_SIPBUTTON");
            if (hwndSIP == IntPtr.Zero)
            {
                return false;
            }
            IntPtr hwndSIPchild = GetWindow(hwndSIP, GetWindowFlags.GW_CHILD);
            if (hwndSIPchild != IntPtr.Zero)
            {
                bool b1 = ShowWindow(hwndSIPchild, (bShow ? ShowWindowFlags.SW_SHOWNORMAL | ShowWindowFlags.SW_SHOWNOACTIVATE : 0));
                bool b2 = ShowWindow(hwndSIP, (bShow ? ShowWindowFlags.SW_SHOWNORMAL | ShowWindowFlags.SW_SHOWNOACTIVATE : 0));
            }
            return bShow;
        }
        #endregion
        public static void addLog(string s){
            System.Diagnostics.Debug.WriteLine(s);
        }
    }
}
