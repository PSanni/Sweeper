using System;
using System.Collections;
using Microsoft.Win32;

namespace StartupManager
{
    public enum StartupType{
         None,
         Registry,
         System
         };
    
    class StartupLoader
    {
        
        private ArrayList Items = new ArrayList();
        
        public void Initialize() {
            InitRegistries();
        }
        public ArrayList GetItems() {
            return Items;
        }

        public ArrayList GetItems(StartupType type) {
            ArrayList ItemList = new ArrayList();
            foreach (StartupItem Item in Items) {
                if (Item.type == type) {
                    ItemList.Add(Item);              
                }
            }
            return ItemList;
        }

        public void Clear() {
            Items.Clear();
        }

        // Private functions

        private void InitRegistries() {
            RegistryKey RKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string[] values=RKey.GetValueNames();
            foreach(string r in values){
                StartupItem st = new StartupItem();
                st.name = r;
                st.path = RKey.GetValue(r).ToString();
                st.rights = "CurrentUser";
                st.type = StartupType.Registry;
                Items.Add(st);
            }
            RKey.Close();
            values = null;

            RKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            values = RKey.GetValueNames();
            foreach (string r in values)
            {
                StartupItem st = new StartupItem();
                st.name = r;
                st.path = RKey.GetValue(r).ToString();
                st.rights = "LocalMachine";
                st.type = StartupType.Registry;
                Items.Add(st);
            }
            RKey.Close();
        }
    }
    
   public class StartupItem
    {
        
        public String name = null;
        public String path = null;
        public StartupType type = StartupType.None;
        public String rights = null;
        public bool Status = true; // Disable or enable
    }
}
