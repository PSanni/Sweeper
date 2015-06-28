using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Utilities;
using System.Collections;
namespace StartupManager
{
    public partial class StartupEntry : Form
    {
        private String EntryPath=null;
        OpenFileDialog fdlg;
        ArrayList List;
        public StartupEntry()
        {
            InitializeComponent();
        }
        
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartupEntry_Load(object sender, EventArgs e)
        {

        }
        public void setList(ArrayList L) {
            this.List = L;
        }
        private void browse_Click(object sender, EventArgs e)
        {
            ShowFileDialog();
            ShowFileInListview();
        }

        private void ShowFileDialog() {
            fdlg = new OpenFileDialog();
            fdlg.Filter = "Executable(*.exe)|*.exe|All Files(*.*)|*.*";
            fdlg.Title = "Select file";
            fdlg.Multiselect = false;
            fdlg.CheckFileExists = true;
            fdlg.FileOk += new CancelEventHandler(this.file_ok);
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                EntryPath = fdlg.FileName;
            }
        }

        private void file_ok(object sender,CancelEventArgs e) {
            if (fdlg.FilterIndex == 2 && Path.GetExtension(fdlg.SafeFileName) != ".exe" ||  Path.GetExtension(fdlg.SafeFileName) != ".exe")
            {
                if (MessageBox.Show("Are you sure! to continue with non executable program? \nBecause it may not start properly during windows startup.", "Wants to continue...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ShowFileInListview()
        {
            imageList1.Images.Add(Path.GetFileNameWithoutExtension(EntryPath),IconAssociation.GetAssociatedIcon(EntryPath));
            ListViewItem lv = new ListViewItem();
            listView1.SmallImageList = imageList1;
            lv.Text = Path.GetFileNameWithoutExtension(EntryPath);
            lv.SubItems.Add(Path.GetDirectoryName(EntryPath));
            lv.Tag = EntryPath;
            lv.ImageKey = Path.GetFileNameWithoutExtension(EntryPath);
            listView1.Items.Add(lv);
        }

        private void CreateEntry() { 
           
            }
        private void BOk_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0) {
                MessageBox.Show("System performace may decrease, while multiple program starts during startup.\n ", "Warning...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void listView1_MouseHover(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (listView1.SelectedItems.Count >= 0)
                {
                    button2.Enabled = true;
                }
            }
            else { button2.Enabled = false; }
        }

       
    }
}
