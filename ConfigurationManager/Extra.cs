using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
namespace Utilities
{
   public static class Extra
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;

        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }

       public static String RemoveArgumentFromPath(String path) {

           if (path.Contains("/")) {
               path = path.Substring(0, path.LastIndexOf("/") );
           
           }
           if (path.Contains("-")) {
               path = path.Substring(0, path.LastIndexOf("-"));
           }
           return path;
       }

       public static string GetMimeType(string extension)
       {
           string mimeType = "application/unknown";

           RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(
               //fileInfo.Extension.ToLower()
               extension
               );

           if (regKey != null)
           {
               object contentType = regKey.GetValue("Content Type");

               if (contentType != null)
                   mimeType = contentType.ToString();
           }

           return mimeType;
       }

       public static string GetFileSize(double byteCount)
       {
           string size = "0 Bytes";
           if (byteCount >= 1073741824.0)
               size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
           else if (byteCount >= 1048576.0)
               size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
           else if (byteCount >= 1024.0)
               size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
           else if (byteCount > 0 && byteCount < 1024.0)
               size = byteCount.ToString() + " Bytes";

           return size;
       }

       public static bool DirectoryExists(String path) 
       {
           return Directory.Exists(path);
       }

       public static bool FileExists(String path) { return File.Exists(path); }

    }

}
