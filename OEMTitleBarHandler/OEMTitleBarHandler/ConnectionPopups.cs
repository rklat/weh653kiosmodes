using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Win32;

namespace OEMTitleBarHandler
{
    class ConnectionPopups
    {
        public ConnectionPopups()
        {
            _sRegKey = @"Software\Microsoft\Shell\Rai\:MSREMNET\Disable";
        }
        public bool reDirectRemnetRestore()
        {
            return reDirectRemnet("Remnet.exe");
        }
        public bool reDirectRemnet(string sExecutable)
        {
            string sReg = @"Software\Microsoft\Shell\Rai\:MSREMNET";
            try
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(sReg, true);
                regKey.SetValue("1", sExecutable);
                regKey.Flush();
                regKey.Close();
            }
            catch (Exception) {
                return false;
            }
            return true;
        }
        public bool disablePopup(ConnectPopupIDs popupID){
            bool bRet = false;
            RegistryKey registryKey1 = ((RegistryKey)null);
            try
            {
                registryKey1 = Registry.LocalMachine.CreateSubKey(this._sRegKey);
                //OpenSubKey(this._sRegKey, true);
                int iID = (int)popupID;
                //registryKey1.SetValue("\"" + iID.ToString() + "\"", 1, RegistryValueKind.DWord);
                registryKey1.SetValue(iID.ToString(), 1, RegistryValueKind.DWord); // use double quotes around number or not?
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception disablePopup(): " + ex.Message);
            }
            return bRet;
        }
        public bool enablePopup(ConnectPopupIDs popupID){
            bool bRet = false;
            RegistryKey registryKey1 = ((RegistryKey)null);
            try
            {
                registryKey1 = Registry.LocalMachine.CreateSubKey(this._sRegKey);
                registryKey1.DeleteValue("\"" + popupID.ToString() + "\"");
                registryKey1.Flush();
                registryKey1.Close();
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception enablePopup(): " + ex.Message); 
            }
            return bRet;
        }
        public bool enableAll(){
            bool bRet = false;
            RegistryKey registryKey1 = ((RegistryKey)null);
            try
            {
                registryKey1 = Registry.LocalMachine.CreateSubKey(this._sRegKey);
                string[] sValues = registryKey1.GetValueNames();
                foreach (string sVal in sValues)
                {
                    registryKey1.DeleteValue(sVal);
                }
                registryKey1.Flush();
                registryKey1.Close();
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception enableAll(): " + ex.Message);
            }
            return bRet;
        }
        public bool disableAllPopups(){
            bool bRet = false;
            RegistryKey registryKey1 = ((RegistryKey)null);
            try
            {
                registryKey1 = Registry.LocalMachine.CreateSubKey(this._sRegKey);
                registryKey1.SetValue("\"" + "All" + "\"", 1, RegistryValueKind.DWord);
                registryKey1.Flush();
                registryKey1.Close();
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception disableAllPopups(): " + ex.Message);
            }
            return bRet;
        }

        public enum ConnectPopupIDs
        {
            IDS_RAS_CARRIER_DROPPED = 0,
            IDS_RAS_NO_CARRIER = 1,
            IDS_RAS_NO_DIALTONE = 2,
            IDS_RAS_DEVICE_NOT_READY = 3,
            IDS_RAS_LINE_BUSY = 4,
            IDS_RAS_NO_ANSWER = 5,
            IDS_RAS_ERROR_UNKNOWN = 8,
            IDS_RAS_ERROR_AUTHENTICATION_FAILURE = 9,
            IDS_RAS_BAD_PHONE_NUMBER = 10,
            IDS_RAS_PHONE_OFF = 14,
            IDS_CM_STATUS_DISCONNECTED = 31,
            IDS_CM_STATUS_NOPATHTODESTINATION = 37,
            IDS_CM_ERROR_UNKNOWN = 39,
            IDS_PROXY_ERROR_CONNECT = 41,
            IDS_PROXY_ERROR_AUTHENTICATION = 42,
            IDS_PROXY_ERROR_AUTHENTICATION_TYPE = 43,
            IDS_PROXY_ERROR_NOTFOUND = 44,
            IDS_PROXY_ERROR_UNKNOWN = 45,
            IDS_CM_STATUS_WAITINGFORPHONE = 46,
            IDS_CM_STATUS_EXCLUSIVECONFLICT = 52,
            IDS_CM_STATUS_NORESOURCES = 53,
            IDS_CM_STATUS_CONNECTIONLINKFAILED = 54,
            IDS_CM_STATUS_AUTHENTICATIONFAILED = 55,
            IDS_VPN_NO_CARRIER = 71,
        }
        private string _sRegKey;
    }
}
