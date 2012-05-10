using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Win32;

namespace Blacklist
{
    class BlackList
    {
        internal class _blacklistEntry
        {
            public int number { get; set; }
            public string sExecutable { get; set; }
            public _blacklistEntry(int iNumber, string sExe)
            {
                number = iNumber;
                sExecutable = sExe;
            }
        }
        private List<_blacklistEntry> _blacklist;
        private Dictionary<int, string> _blacklistDict;
        private int _maxCount = -1;

        const string _RegEnableBlacklist = @"Security\Policies\Shell"; //HKLM
        const string _RegBlacklistEntries = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowRun"; //HKCU

        public bool _isEnabled
        {
            get
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(_RegEnableBlacklist);
                bool bRet = false;
                try
                {
                    int iVal = (int)regKey.GetValue("DisallowRun", 99);
                    if (iVal == 99)
                    {
                        bRet = false;
                    }
                    if (iVal == 1)
                        bRet = true;
                    else
                        bRet = false;
                    regKey.Close();
                }
                catch (Exception)
                {
                    bRet = false;
                }
                return bRet;
            }
            set
            {
                enableBlacklist(value);
            }
        }
        public BlackList()
        {
            _blacklist = new List<_blacklistEntry>();
            _blacklistDict = new Dictionary<int, string>();
            createUserRegTree();
            _maxCount = buildList();
        }
        public bool enableBlacklist(bool bEnable)
        {
            RegistryKey regKey = Registry.LocalMachine.CreateSubKey(_RegEnableBlacklist);
            try
            {
                if(bEnable)
                    regKey.SetValue("DisallowRun", 1, RegistryValueKind.DWord);
                else
                    regKey.SetValue("DisallowRun", 0, RegistryValueKind.DWord);
                regKey.Flush();
                regKey.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private int buildList()
        {
            int iCnt = 0;
            _blacklistDict.Clear();
            _blacklist.Clear();
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(_RegBlacklistEntries);
                string[] subKeys = regKey.GetValueNames();
                if (subKeys == null || subKeys.Length == 0)
                    iCnt = -1;
                foreach (string s in subKeys)
                {
                    string sValue = (string)regKey.GetValue(s, "");
                    if (s != "")
                    {
                        _blacklist.Add(new _blacklistEntry(int.Parse(s), sValue));
                        _blacklistDict.Add(int.Parse(s), sValue);
                        iCnt++;
                    }
                }
                regKey.Close();
            }
            catch (Exception)
            {
                iCnt = -1;
            }
            return iCnt;
        }
        private bool saveList()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(_RegBlacklistEntries, true);
                int iCnt = 0;
                foreach (_blacklistEntry b in _blacklist)
                {
                    //we need to use a new numbering
                    regKey.SetValue(iCnt.ToString(), b.sExecutable, RegistryValueKind.String);
                    iCnt++;
                }
                regKey.Flush();
                regKey.Close();
                _maxCount = buildList();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private bool createUserRegTree()
        {
            bool bRet = false;
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion", true);
                regKey = regKey.CreateSubKey("Policies");
                regKey = regKey.CreateSubKey("Explorer");
                regKey = regKey.CreateSubKey("DisallowRun");
                regKey.Flush();
                regKey.Close();
                bRet = true;
            }
            catch (Exception)
            {
            }
            return bRet;
        }
        public bool addEntry(string sExecutable)
        {
            //check if already exists
            if (_maxCount <= 0)
            {
                //no entry = new entry
                try
                {
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(_RegBlacklistEntries, true);
                    regKey.SetValue("0", sExecutable);
                    regKey.Flush();
                    regKey.Close();
                }
                catch (Exception) { return false; }
                return true;
            }
            else { 
                //find entry
                if (!_blacklistDict.ContainsValue(sExecutable))
                {
                    //add new
                    try
                    {
                        RegistryKey regKey = Registry.CurrentUser.OpenSubKey(_RegBlacklistEntries, true);
                        regKey.SetValue(_maxCount.ToString(), sExecutable);
                        regKey.Flush();
                        regKey.Close();
                        _maxCount = buildList();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                    return true; //already there
            }
            return true;
        }
        public bool removeEntry(string sExecutable)
        {
            if (_blacklistDict.ContainsValue(sExecutable))
            {
                try
                {
                    int key = -1;
                    foreach (_blacklistEntry e in _blacklist)
                    {
                        if (e.sExecutable.ToLower() == sExecutable.ToLower())
                        {
                            key = e.number;
                            _blacklist.Remove(e);
                            _blacklistDict.Remove(key);
                            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(_RegBlacklistEntries, true);
                            regKey.DeleteValue(e.number.ToString());
                            _maxCount--;
                            break;
                        }
                    }
                    if (key >= 0)
                    {
                        //save new list
                        return saveList();
                    }
                    else
                        return true;   // not found
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true; //was not in the list
            }
        }
    }
}
