using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.File_Loader;
using System.Threading;
using System.Linq;
namespace FileShredder
{
    class ShredingManager
    {
        
        private ListView lv;               // Listview object passed from caller, to update status on it.   
        private Wiper Wip ;           // Object to wipe file from given location.
        private bool isRunning=false;      // Represents the current status of process. 
        private InvokerListView Invoker;
        
        private List<Wiper> ScanRunning;
        private List<ShredingManagerHelper> FilesToWipe;

        // Default constructor to initialize list and set the lisview object.
        public ShredingManager(ListView lv,List<ShredingManagerHelper> FilesToWipe) 
        {
            this.lv = lv;
            this.FilesToWipe = FilesToWipe;
            ScanRunning = new List<Wiper>();
            Invoker = new InvokerListView(this.lv);
        }
        
        public void Start() 
        {
            isRunning = true;
            foreach (ShredingManagerHelper SMH in FilesToWipe) 
            {
                Wip = new Wiper(SMH.FilePath,2,SMH.id);
                Wip.OnPassCompleted += new WiperProperty.PassCompletedHandler(this.PasscompleteHandler);
                Wip.OnSectorCompleted += new WiperProperty.SectorCompletedHandler(this.SectorcompleteHandler);
                Wip.OnError += new WiperProperty.OnErrorHandler(this.ErrorHandler);
                Wip.OnWipingCompleted += new WiperProperty.WipingCompletedHandler(this.WipeOver);
                Invoker.Invoke(SMH.id, "Wait...");
                Thread th = new Thread(Wip.Start);
                th.Start();
                ScanRunning.Add(Wip);
            }
           
        }

        public void Stop() 
        {
            foreach (Wiper wp in ScanRunning) {
                wp.StopScan = true;
            }
            isRunning = false;
        }
        private void PasscompleteHandler(object sender, int id, int pass)
        {
         
        }
        private void SectorcompleteHandler(object sender, int id, int sector,string per)
        {
           
           
            //Invoker.Invoke(id, per);
            //UpdateListView( id, per);
        }
        private void ErrorHandler(object sender, int id,Exception e)
        {
            
            Invoker.Invoke(id, "Error...");
            //UpdateListView( id, "Error...");
        }
        private void WipeOver(object sender, int id)
        {
            Invoker.Invoke(id, "Completed...");
            //UpdateListView( id, "Completed...");
        }
        private void ScanStopHandler(object sender, int id) 
        {
            Invoker.Invoke(id, "Stopped...");
            //UpdateListView( id, "Stopped...");
        }
      
    }
    
    public class InvokerListView{

        ListView Lv;

        public InvokerListView(ListView lv) {
            this.Lv = lv;
        }
        public void Invoke(int id, String value) {
            UpdateListView(id, value);
        }

        delegate void InvokeListView(int id, string value);
        private void UpdateListView(int id, string value)
        {

            if (Lv.InvokeRequired)
            {
                // Execute the same method, but this time on the GUI thread
                Lv.BeginInvoke(new InvokeListView(UpdateListView), id, value);
                // we return immedeately
                return;
            }


            foreach (ListViewItem lvi in Lv.Items)
            {
                if (lvi.SubItems[0].Text == id.ToString())
                {
                    lvi.SubItems[5].Text = value;
                    return;
                }
            }

        }
    }
   public class ShredingManagerHelper
    {
       public int id = -1;
       public string FilePath = "";

       public ShredingManagerHelper(int id, String FilePath) {
           this.id = id;
           this.FilePath = FilePath;
        }
    }
}
