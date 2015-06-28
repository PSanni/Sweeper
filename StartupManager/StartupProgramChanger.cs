using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace StartupManager
{
    class StartupProgramChanger
    {
        RegistryKey CurrentKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        RegistryKey LocalKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        StartupItem st;
        public StartupProgramChanger(StartupItem st) {
            this.st = st;
        }

        public bool Enable() {
            if (st.type != StartupType.Registry) return false;
            if (st.rights == "CurrentUser")
            {
                try
                {
                    CurrentKey.SetValue(st.name, st.path);
                    return true;
                }
                catch (Exception e) { return false; }
            }
            if (st.rights == "LocalMachine")
            {
                try
                {
                    LocalKey.SetValue(st.name, st.path);
                    return true;
                }
                catch (Exception e) { return false; }
            }
            return false;
        }

        public bool Disable() 
        {
            if (st.type != StartupType.Registry) return false;
            if (st.rights == "CurrentUser")
            {
                try
                {
                    CurrentKey.DeleteValue(st.name);
                    return true;
                }
                catch (Exception e) { return false; }
            }
            if (st.rights == "LocalMachine")
            {
                try
                {
                    LocalKey.DeleteValue(st.name);
                    return true;
                }
                catch (Exception e) { return false; }
            }
            return false;
        }
    }
}
