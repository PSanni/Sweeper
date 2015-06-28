using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
namespace Utilities.File_Loader
{

    public class FileLoaderProperty
    {

        private string Parent_path = null;
        private bool Include_Sub_Folder = false;
        protected String[] Exclude_List = null;
        private bool Include_Size = false;
        private bool Check_Shortcut = false;

        //----------------------------------------------------------------------------------


        protected List<CFileHelper> FileList;
        protected List<String> FolderList;

        //----------------------------------------------------------------------------------

        public FileLoaderProperty()
        {

            FileList = new List<CFileHelper>();
            FolderList = new List<String>();
        }
        /// <summary>
        /// Gets/Sets parent path to perform scan.
        /// </summary>
        public string ParentPath
        {

            get
            {
                return this.Parent_path;
            }
            set
            {
                if (!Directory.Exists(value)) { throw new ShrederFilePathNotFoundException("Given path is invalid or directory not exists on given location"); }
                this.Parent_path = value;
            }
        }

        /// <summary>
        /// Gets/sets boolean value for IncludeSubFolder.
        /// </summary>
        public bool IncludeSubFolder
        {
            get
            {
                return this.Include_Sub_Folder;
            }
            set
            {
                this.Include_Sub_Folder = value;
            }
        }

        /// <summary>
        /// Gets/Sets,wether size calculated during scan or not.
        /// </summary>
        public bool IncludeSize
        {
            get
            {
                return this.Include_Size;
            }
            set
            {
                this.Include_Size = value;
            }
        }

        /// <summary>
        /// Gets/Sets,wether file should checked for shortcut or not.
        /// </summary>
        public bool CheckForShortcut
        {
            get
            {
                return this.Check_Shortcut;
            }
            set
            {
                this.Check_Shortcut = value;
            }
        }


        /// <summary>
        /// Gets/sets list of files to exclude during Scanning. 
        /// </summary>
        public String[] Exclude
        {
            get
            {
                return this.Exclude_List;
            }
            set
            {
                this.Exclude_List = value;
            }
        }

        public int DirectoriesCount
        {
            get { return FolderList.Count; }
        }

        public int FilesCount
        {
            get
            {
                return FileList.Count;

            }
        }
    }

    public class CFileloader : FileLoaderProperty
    {

        public CFileloader(String Path, bool IncludeSubFolder = true)
            : base()
        {
            this.ParentPath = Path;
            this.IncludeSubFolder = IncludeSubFolder;
        }

        public CFileloader()
            : base()
        { }

        public void Start()
        {
            LoadDirectories();

        }

        public void Pause()
        {
        }
        public List<CFileHelper> GetList() {
            return FileList;       
        }
        public void Resume() { }

        public void Stop() { }

        private void LoadDirectories()
        {
            bool state = true;
            int Count = 0;
            FolderList.Add(ParentPath);
            while (state)
            {

                try
                {
                    foreach (string name in Directory.GetDirectories(FolderList[Count]))
                    {
                        FolderList.Add(name);
                    }
                    
                    LoadFilesAndProcess(FolderList[Count]);
                }
                catch
                {

                }
                Count++;
                if (Count == FolderList.Count) { state = false; }
                if (!IncludeSubFolder) { state = false; }
            }
        }

        private  void LoadFilesAndProcess(string Path)
        {

            try
            {
                foreach (String s in Directory.GetFiles(Path))
                {
                    CFileHelper CFile = CheckFileContstraint(s);
                    if (CFile != null)
                    {
                        FileList.Add(CFile);
                    }
                }
            }
            catch
            {

            }
        }

        private CFileHelper CheckFileContstraint(string Path)
        {
            //if (Exclude_List.Contains(Path)) { return null; }
            CFileHelper Cfile = new CFileHelper();
            Cfile.FilePath = Path;
            Cfile.FileAttribute = File.GetAttributes(Path);
            return Cfile;
        }

    }
}
