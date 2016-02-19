using System;
using System.Windows.Forms;
using Utilities.File_Loader;
using System.Threading;
using System.Collections.Generic;
using Utilities;
using System.Diagnostics;
namespace FileShredder
{
    public partial class Shredder : Form
    {

        CFileloader Loader;
        ShredingManager ShredManager;
        private Stopwatch st;

        int id = 1;
        int count = 0;
        public Shredder()
        {
            InitializeComponent();
        }

        //-----------------------------   Private functions -------------------------------------



        private void ShowFolderDialog()
        {
            Thread th;
            if (folderDialog1.ShowDialog() == DialogResult.OK)
            {
                th = new Thread(() => LoadFilesFromFolder(folderDialog1.SelectedPath));
                th.Start();

            }
        }

        //loading a list of files from folder.
        private void LoadFilesFromFolder(String Path)
        {
            StatusStatus.Text = "Scanning....";
            st.Start();
            listView1.Cursor = Cursors.WaitCursor;
            Loader = new CFileloader(Path, true);
            Loader.Start();

            List<CFileHelper> LoadedFiles = Loader.GetList();
            foreach (CFileHelper fl in LoadedFiles)
            {

                ListViewItem lv = new ListViewItem();
                lv.Text = id.ToString();
                lv.SubItems.Add(fl.FileName);
                lv.SubItems.Add(fl.FilePath);
                lv.SubItems.Add(Extra.GetMimeType(fl.Extension));
                lv.SubItems.Add(Extra.GetFileSize(fl.Size));
                lv.SubItems.Add(" ");
                lv.SubItems.Add(fl.Extension);
                lv.Checked = true;
                lv.Tag = fl.FullPath;
                UpdateListView(lv);
                id++;
            }
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            count = id;
            st.Stop();
            StatusStatus.Text = "Scan completed...(" + st.Elapsed.TotalSeconds + " sec.)";
            listView1.Cursor = Cursors.Default;
            Status_count.Text = count.ToString();
        }

        //cross-thread incoke of listview control.
        delegate void InvokeListView(ListViewItem lv);
        private void UpdateListView(ListViewItem lv)
        {

            if (listView1.InvokeRequired)
            {
                // Execute the same method, but this time on the GUI thread
                listView1.BeginInvoke(new InvokeListView(UpdateListView), lv);
                // we return immedeately
                return;
            }
            listView1.Items.Add(lv);
        }

        //build a final list for wiping a file..
        private void ShredBuilder()
        {
            List<ShredingManagerHelper> Sh = new List<ShredingManagerHelper>();
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.Checked == true)
                {
                    Sh.Add(new ShredingManagerHelper(Convert.ToInt32(lvi.SubItems[0].Text), lvi.Tag.ToString()));
                }
            }
            ShredManager = new ShredingManager(listView1, Sh);
            ShredManager.Start();
        }

#region Controls
        private void Shredder_Load(object sender, EventArgs e)
        {
            Shredder.CheckForIllegalCrossThreadCalls = false;
            st = new Stopwatch();
        }

        private void viewFilePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                String path = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text + "\\" + listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text + listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text;
                Extra.ShowFileProperties(path);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(ShredBuilder);
            th.IsBackground = true;
            th.Start();

        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeSelectedTool_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0) { return; }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked) { listView1.Items.Remove(item); }
            }
            Status_count.Text = listView1.Items.Count.ToString();
        }

        private void removeAllTool_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Status_count.Text = listView1.Items.Count.ToString();
        }

        private void MenuFolderAdd_Click(object sender, EventArgs e)
        {
            ShowFolderDialog();
        }

        private void ToolFoderAdd_Click(object sender, EventArgs e)
        {
            ShowFolderDialog();
        }

        private void startShreddingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(ShredBuilder);
            th.IsBackground = true;
            th.Start();
        }

#endregion
    }
}
