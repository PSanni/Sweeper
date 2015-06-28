/*
 *  Claas :- Setting Managers
 *  Date:- 1-Aug-2014
 *  Name:- Sunny
 *  Description:- Class to serialize and deserialize software settings to file as a XML tag format;
 *                It serializes the given object to XML format, at given location.
 *                Object must have to same during serialization and deserialization. 
 * 
 * */

using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
namespace Utilities
{
    public class SettingsManager
    {
        XmlSerializer SObj;
        StreamWriter writer;
        StreamReader reader;
        ArrayList List;
        object type;
        private String FileName = null;
     
        public SettingsManager(String FileName,object type) {
            this.FileName = FileName;
            this.type = type;
            List = new ArrayList();
        }

        public bool AnySerialize(ArrayList Items) 
        {
            if (Items.Count == 0) {
                File.Delete(FileName);
                return true;
            }
            try
            {
                SObj = new XmlSerializer(Items.GetType(), new Type[] { type.GetType() });
                writer = new StreamWriter(@FileName);
                SObj.Serialize(writer, Items);
                writer.Close();
                return true;
            }
            catch (Exception e) 
            {
                writer.Close();
                return false;
            }
        }
        public void Serialize(){
           
            if (List.Count == 0) { return; }//Exits if no item available
            try{
            SObj = new XmlSerializer(List.GetType(),new Type[]{type.GetType()});
            writer = new StreamWriter(@FileName);
            SObj.Serialize(writer, List);
            writer.Close();
            }
            catch(Exception e){
              writer.Close();
            }
        }

        public void  DeSerialize(){
            try
            {
               

                SObj = new XmlSerializer(List.GetType(), new Type[] { type.GetType() });
                reader = new StreamReader(@FileName);
                object obj = SObj.Deserialize(reader);
                List = (ArrayList)obj;
                reader.Close();
     
            }
            catch (FileNotFoundException e)
            {
                
            }
            catch(Exception e) {
                reader.Close();
            }
        }

        public object GetItems() {
            return List;
        }
        public void Clear() {
            List.Clear();
            FileName = "";
        }
    }
}
