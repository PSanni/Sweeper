using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utilities.File_Loader
{
   
    public class CFileHelper
    {
        private String File_Name = null; // Name of file.
        private String File_Path=null;  // To store file path
        private FileAttributes File_Acess; // Read,Write, Read-Write etc.
        private String FExtension=null; //Extension of file.
       // public bool isWiped = false;
        public string FullPath = "";
        
        public String FileName{

           get{return this.File_Name;}
        }

        public String FilePath{
           get{return this.File_Path;}
           set
           {
               FullPath = value;
               this.File_Path = Path.GetDirectoryName(value) ;
               this.File_Name=Path.GetFileNameWithoutExtension(value);
               this.FExtension=Path.GetExtension(value);

           }
        }

        public FileAttributes FileAttribute{
            get { return this.File_Acess; }
            set { this.File_Acess = value; }
       
        }

        public String Extension{
            get { return this.FExtension; }

        }
        public long Size {
            get {
                FileInfo fi = new FileInfo(this.FullPath);
                return fi.Length;
            }
        }

    }

    class ShrederFilePathNotFoundException : Exception {
        
        public ShrederFilePathNotFoundException(string Message):base(Message) { }

        public ShrederFilePathNotFoundException(string Message, Exception Iner) : base(Message, Iner) { }
    }
}