using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{
    class Logger
    {
        static StreamWriter sr = new StreamWriter("log.txt");

        // Awad
        public static void LogException(Exception ex)
        {
            // TODO: Create log file named log.txt to log exception details in it
            string location = System.Environment.CurrentDirectory + "\\log.txt";
           /* 
            if (!File.Exists(location)){
                FileStream fs;
                using(fs = new FileStream(location, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                }
                fs.Close();
            }
            */
            //Datetime:
            string dateTime = "Date: " + DateTime.Now.ToString() + "\r\n";
            //message:
            string message ="Message:" + ex.Message;
            // for each exception write its details associated with datetime 
            /*
            StreamWriter sw = new StreamWriter(location, true);
            sw.WriteLine(dateTime);
            sw.WriteLine(message);
            sw.Close();
            sw = null;
            */
            using (StreamWriter sw = new StreamWriter(location, true))
            {
                sw.WriteLine(dateTime);
                sw.WriteLine(message);
                sw.Flush();
            }
        }
    }
}
