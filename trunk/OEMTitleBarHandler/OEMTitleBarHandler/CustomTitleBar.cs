using System;

using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace OEMTitleBarHandler
{
    class CustomTitleBar
    {
        public enum titleBarEvents{
            TASKBAR_DATACONNECTION,
            TASKBAR_RADIOSIGNAL,
            TASKBAR_VOLUME,
            TASKBAR_BATTERY,
            TASKBAR_CLOCK
        }
        enum OEM_TitleBarHandlerArgs
        {
            DataConnection,
            RadioSignal,
            Volume,
            Battery,
            Clock
        }
        public static string[] TitelBarHandlers = new string[] { "TASKBAR_DATACONNECTION", "TASKBAR_RADIOSIGNAL", "TASKBAR_VOLUME", "TASKBAR_BATTERY", "TASKBAR_CLOCK" };
        static string sSubKey = @"Software\Microsoft\Shell\Rai";
        /*
         * http://msdn.microsoft.com/en-us/library/ff599645.aspx
        :TASKBAR_DATACONNECTION

        REG_SZ

        Specifies the Data Connection event in the TitleBarList by setting the following values:

        "0"="OEM_DataConnection"

        "1"="\windows\OEMTitleBarHandler.exe /DataConnection"

        If the value is not set or is empty, the default path will be the current built-in application path.
        To replace a task bar item, define the HKEY_LOCAL_MACHINE\Software\Microsoft\Shell\Rai registry key and specify the values 
        as shown in the following code snippet.

        Code example

        HKEY_LOCAL_MACHINE\Software\Microsoft\Shell\Rai\:TASKBAR_[Registry Key Name]
            "0" = "window_class_name"
            "1" = "command to execute the OEM handler"

        The values can be set to the new path \path\to\new\target.exe plus command parameters.
        */
        // set to 0 for OEM apps
        // set to 1 for \Windows\OEM_TitleBarHandler.exe app
        public static bool setCustomHandler(titleBarEvents titleName)
        {
            string regName = ":" + titleName.ToString();
            string sKey = sSubKey + @"\" + regName;
            bool bRet = true;
            try
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(sKey, true);
                if (regKey == null)
                {
                    regKey = Registry.LocalMachine.CreateSubKey(sKey);
                }
                regKey.SetValue("0", "OEM_DataConnection", RegistryValueKind.String);
                regKey.SetValue("1", @"\windows\OEMTitleBarHandler.exe" + " /" + titleName, RegistryValueKind.String);
                regKey.Flush();

                regKey.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in setCustomHandler(): " + ex.Message);
                bRet = false;
            }
            return bRet;
        }
        public static string getCustomHandler(titleBarEvents titleName)
        {
            string regName = ":" + titleName.ToString();
            string sKey = sSubKey + @"\" + regName;
            string sRet = "n/a";
            try
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(sKey, true);
                if (regKey != null)
                {
                    string s0 = (string)regKey.GetValue("0", "");
                    string s1 = (string)regKey.GetValue("1", "");
                    System.Diagnostics.Debug.WriteLine(string.Format("Read Reg: '0'='{0}', '1'='{1}'", s0, s1));
                    sRet = string.Format("Read Reg: '0'='{0}', '1'='{1}'", s0, s1);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in getCustomHandler(): " + ex.Message);
                
            }
            return sRet;
        }
        public static bool resetCustomHandler(titleBarEvents titleName)
        {
            string regName = ":" + titleName.ToString();
            string sKey = sSubKey + @"\" + regName;
            bool bRet = true;
            try
            {
                Registry.LocalMachine.DeleteSubKeyTree(sKey);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in resetCustomHandler(): " + ex.Message);
                bRet = false;
            }
            return bRet;
        }
    }
}
