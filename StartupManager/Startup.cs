using System;
using System.Collections;
using System.Windows.Forms;
using Utilities;
namespace StartupManager
{
    public partial class Startup : Form
    {

        StartupLoader sl;
        SettingsManager settings;
        ArrayList StartupItemList;    //Holds the items loaded from Configuration and Loader. 
        int SelectedItemIndex;        // To store selected item, help to disable and enable item.

        public Startup()
        {
            InitializeComponent();
        }

        #region Loading definitions   // Region to classify the function and variables of loader.S

        //Load disables items from configuration files.

        private void LoadConfigurationFiles()
        {
            // Call this function to load disabled item from list.
            StartupItem obj = null;
            try
            {
                settings = new SettingsManager("StartupConfig.conf", new StartupItem() { });
                settings.DeSerialize();
                StartupItemList = new ArrayList();
                StartupItemList = (ArrayList)settings.GetItems();
            }
            catch (Exception e)
            {

            }
        }

        // Load the items from System.
        private void LoadSystemEntries()
        {
            sl = new StartupLoader();
            sl.Initialize();
            ArrayList temp = sl.GetItems();
            foreach (StartupItem Item in temp)
            {
                if (!MatchToList(Item))
                {
                    StartupItemList.Add(Item);
                }
            }

        }

        //Manipulate listview from LoadedItems
        private void ManiPulateListView()
        {

            ListViewItem litem;
            ImageList img = new ImageList();
            listView1.SmallImageList = img;
            listView1.Items.Clear();

            foreach (StartupItem i in StartupItemList)
            {

                litem = new ListViewItem();
                litem.Text = i.name;
                litem.SubItems.Add(i.path);
                litem.SubItems.Add(i.type.ToString());
                if (i.Status) { litem.SubItems.Add("Active"); } else { litem.SubItems.Add("Disabled"); }

                img.Images.Add(i.name, IconAssociation.GetAssociatedIcon(Extra.RemoveArgumentFromPath(i.path)));
                litem.ImageKey = i.name;

                listView1.Items.Add(litem);
            }
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void Save()
        {
            ArrayList temp = new ArrayList();
            foreach (StartupItem item in StartupItemList)
            {
                if (item.Status == false)
                {
                    temp.Add(item);
                }
            }
            if (settings.AnySerialize(temp))
            {

                MessageBox.Show("Changes applied successfully.", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unexpected error occured while writing to file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EnableItem(String name, String Path)
        {
            StartupProgramChanger stChanger;
            StartupItem stItem=new StartupItem();
            foreach (StartupItem item in StartupItemList)
            {
                if (item.name == name && item.path == Path)
                {
                    stItem = item;

                }
            }
            stChanger = new StartupProgramChanger(stItem);
            if (stChanger.Enable())
            {
                stItem.Status = true;             //Enabling the item... 
                ManiPulateListView();
                return true;
            }
            return false;
        }
        private bool DisableItem(String name, String Path)
        {

            StartupProgramChanger stChanger;
            StartupItem stItem = new StartupItem();
            foreach (StartupItem item in StartupItemList)
            {
                if (item.name == name && item.path == Path)
                {
                    stItem = item;
                }
            }
            stChanger = new StartupProgramChanger(stItem);
            if (stChanger.Disable())
            {
                stItem.Status = false;             //Disabling the item... 
                ManiPulateListView();
                return true;
            }
            return false;
        }

        private bool MatchToList(StartupItem SItem)
        {
            foreach (StartupItem Item in StartupItemList)
            {
                if (Item.name == SItem.name && Item.path == SItem.path)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion


        #region FormControlEvents

        private void Startup_Load(object sender, EventArgs e)
        {
            LoadConfigurationFiles();
            LoadSystemEntries();
            ManiPulateListView();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartupEntry obj = new StartupEntry();
            obj.ShowDialog();
        }



        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectedItemIndex = e.ItemIndex;
            ChangeButtonState(e.Item);
        }


        private void Disable_Click(object sender, EventArgs e)
        {
            String name = listView1.SelectedItems[0].SubItems[0].Text;
            String Path = listView1.SelectedItems[0].SubItems[1].Text;
            DisableItem(name, Path);
        }

        private void Enable_Click(object sender, EventArgs e)
        {
            String name = listView1.SelectedItems[0].SubItems[0].Text;
            String Path = listView1.SelectedItems[0].SubItems[1].Text;
            EnableItem(name, Path);
        }
        private void listView1_MouseHover(object sender, EventArgs e)
        {
            ChangeButtonState(null);
        }

        private void ChangeButtonState(ListViewItem lv)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                Enable.Visible = true;
                Disable.Visible = true;
            }
            else
            {
                Enable.Visible = false;
                Disable.Visible = false;
            }
            try
            {
                if (lv.SubItems[3].Text == "Active")
                {
                    Enable.Visible = false;
                    Disable.Visible = true;
                }
                if (lv.SubItems[3].Text == "Disabled")
                {
                    Enable.Visible = true;
                    Disable.Visible = false;
                }
            }
            catch (Exception e) { }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManiPulateListView();
        }
        private void SaveChanges_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion
    }


    public class RegistryManager
    {

    }
}
