/* 
   class name:- wiper
 * Description:- use to wipe any file
 */
using System;
using System.IO;
using System.Security.Cryptography;

namespace FileShredder
{
    public class WiperProperty
    {

        // ----------  INPUT -----------------
        protected String File_Name = "";
        protected int Wiper_Pass = 5;
        protected int FileID = 0;
        //----------  PROCESS --------------

        protected int Total_Size = 0;
        protected int  Pass_Completed = 0;
        protected int Sector_completed = 0;
        protected double sector = 0;
        protected bool ScanOver = false;
        public bool StopScan = false; // If want to stop scan, make it true;
        //----------- Event---------------------

        public delegate void PassCompletedHandler(object sender,int id, int pass);
        public event PassCompletedHandler OnPassCompleted;

        public delegate void SectorCompletedHandler(object sender,int id , int Sector,string per);
        public event SectorCompletedHandler OnSectorCompleted;

        public delegate void WipingCompletedHandler(object sender,int id);
        public event WipingCompletedHandler OnWipingCompleted;

        public delegate void OnErrorHandler(object sender,int id,Exception e);
        public event OnErrorHandler OnError;

        public delegate void OnScanStopHandler(object sender, int id);
        public event OnScanStopHandler OnScanStop;


        //----------- Properties------------------------
        public int Fileid {
            get { return this.FileID; }
            set { this.FileID = value; }
        }
        public String Filename {
            get { return this.File_Name; }
            set {
                if (value == null) { throw new ArgumentException("Invalid argument"); }
                this.File_Name = value;
                
               }
        }
        public int WiperPass {
            get { return this.Wiper_Pass; }
            set {
                if (value == 0 || value == null) { throw new ArgumentException("Invalid argument passed"); }
                this.Wiper_Pass = value;
                }
        }
        public string PercentageWorkDone
        {
            get 
            {
                double devider=(sector * (Wiper_Pass));
                double temp = ((Sector_completed ) * 100) / devider ;
                return temp.ToString();
            }
        }
        public double Sectors { get { return this.sector; } }
        public int PassCompteled
        {
            get { return this.Pass_Completed; }
        }

        protected void UpdatePass(int count) {
            Pass_Completed = count;
            OnPassCompleted(this,this.Fileid, count);
        }
        protected void UpdateSector(int sectors) {
            Sector_completed +=1;
            OnSectorCompleted(this,this.Fileid, sectors,this.PercentageWorkDone);
            
        }
        protected void ReportError(Exception e) {
            OnError(this,this.Fileid, e);
        }
        protected void WipeOver() {
            ScanOver = true;
            OnWipingCompleted(this, this.Fileid);
        }
        protected void ScanStopInvoker() {
            OnScanStop(this, this.Fileid);
        }

    } // Class ends here..

    class Wiper : WiperProperty
    {
        FileStream inputStream;
        public  Wiper(String Filename,int WipingPass,int Fileid) {
            this.Filename = Filename;
            this.WiperPass = WipingPass;
            this.Fileid = Fileid;
        }
        public  Wiper() { }
        
        public  void Start() {
            WipeFile(this.Filename);
        }
        private void WipeFile(String name) 
        {
            try
            {
                int iter = 1;
                if(File.Exists(name))
                {
                    //' Set the files attributes to normal in case it's read-only.
                    File.SetAttributes(name, FileAttributes.Normal);

                    //Calculating the total number of sector in file.
                    sector = Math.Ceiling(new FileInfo(name).Length / 520.0);

                    //Create a dummybuffer to store random string
                    Byte[] dummybuffer = new Byte[520];

                    //Using Crypto function to generate a random number generator
                    //This is the what i will use to create garbage data.
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                    //Open a file stream for file.
                    inputStream = new FileStream(name, FileMode.Open);
                   
                    //Iterating through pass
                     while (iter <= this.WiperPass) {
                         UpdatePass(iter);
                         //Go to begining of stream.
                         inputStream.Position = 0;
                         int CurrentSector = 0;
                         for ( CurrentSector = 0; CurrentSector < sector - 1; CurrentSector++) {
                             UpdateSector(CurrentSector);
                             rng.GetBytes(dummybuffer);
                             inputStream.Write(dummybuffer, 0, dummybuffer.Length);
                             if (this.StopScan == true) { this.FStopScan(); }
                         }
                         iter++;
                     }
                     inputStream.SetLength(0);
                     inputStream.Close();
                     FinalizeFile(name);
                     WipeOver();
                }// File existency check condiotion. 
            } //try Closing
               catch (Exception e)
            {
                ReportError(e);
          
            }//Catch closing
        }// Function closing

        private void FStopScan(){
            inputStream.Close();
        }

        private void FinalizeFile(String name) { 
        
            var dt= new  DateTime(2037, 1, 1, 0, 0, 0);
            File.SetCreationTime(name, dt);
            File.SetLastAccessTime(name, dt);
            File.SetLastWriteTime(name, dt);
            File.SetCreationTimeUtc(name, dt);
            File.SetLastAccessTimeUtc(name, dt);
            File.SetLastWriteTimeUtc(name,dt);

            File.Delete(name);

        }
    }
    
}
 