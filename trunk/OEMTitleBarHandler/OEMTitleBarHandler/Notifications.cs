using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Win32;

namespace Notifications
{
    class Notifications:IDisposable
    {
        private class _notificationEntry
        {
            public string subkey { get; set; }
            public int options { get; set; }
            public _notificationEntry(string s, int i)
            {
                subkey = s;
                options = i;
            }
        }
        List<_notificationEntry> _notificationSettings;
        public Notifications()
        {
            _notificationSettings = new List<_notificationEntry>();
            SaveNotificationSettings();
        }
        ~Notifications()
        {
            RestoreNotificationSettings();
        }
        public void Dispose()
        {
            RestoreNotificationSettings();
        }
        private bool SaveNotificationSettings()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"ControlPanel\Notifications", true);
            if (regKey == null)
                return false;
            //enum all subkeys
            string[] subKeys = regKey.GetSubKeyNames();
            foreach (string s in subKeys)
            {
                RegistryKey regSubSub = regKey.OpenSubKey(s);
                int iVal;
                try
                {
                    iVal = (int)regSubSub.GetValue("Options", 9999);
                }
                catch (Exception)
                {
                    iVal = 9999;
                }
                if (iVal != 9999)
                {
                    _notificationSettings.Add(new _notificationEntry(s, iVal));
                }
                regSubSub.Close();
            }
            regKey.Close();
            return true;
        }
        public bool RestoreNotificationSettings()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"ControlPanel\Notifications", true);
            if (regKey == null)
                return false;
            int iCount = 0;
            //write down all sub keys-options
            foreach (_notificationEntry e in _notificationSettings)
            {
                try
                {
                    RegistryKey regSubSub = regKey.OpenSubKey(e.subkey, true);
                    regSubSub.SetValue("Options", e.options, RegistryValueKind.DWord);
                    regSubSub.Flush();
                    regSubSub.Close();
                    iCount++;
                }
                catch (Exception)
                {
                }
            }
            regKey.Flush();
            regKey.Close();
            if (iCount == _notificationSettings.Count)
                return true;
            else
                return false;
        }
        public bool disableAllNotifications()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"ControlPanel\Notifications", true);
            if (regKey == null)
                return false;
            int iCount = 0;
            //write down all sub keys-options
            foreach (_notificationEntry e in _notificationSettings)
            {
                try
                {
                    RegistryKey regSubSub = regKey.OpenSubKey(e.subkey, true);
                    regSubSub.SetValue("Options", 0, RegistryValueKind.DWord);
                    regSubSub.Flush();
                    regSubSub.Close();
                    iCount++;
                }
                catch (Exception)
                {
                }
            }
            regKey.Flush();
            regKey.Close();
            if (iCount == _notificationSettings.Count)
                return true;
            else
                return false;
        }
    }
}
