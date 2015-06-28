using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class RegistrySettings
    {
        public void Disable(String Item) {
            try { Properties.Settings.Default.RegistryDisabled.Remove(Item); }
            catch { }
            Properties.Settings.Default.RegistryDisabled.Add(Item);
        }
      
        public void Enable(String Item) {
            try { Properties.Settings.Default.RegistryDisabled.Remove(Item); }
            catch { }
        }

          public bool IsDisabled(String Item) { 
            return (Properties.Settings.Default.RegistryDisabled.Contains(Item));
 
        }
    }
}
