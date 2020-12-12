using System;
using System.IO;

namespace AutoGro
{
    public class Log
    {
        public static string logfile = "Autogro_log.txt";

        // Appends message into log and scrolls textbox
        public void Message(string message, bool addFormatting = true)
        {
            if (addFormatting) message = DateTime.Now.ToLocalTime().ToString() + " || " + message + "\n";
                        
            StreamWriter logtxt = File.AppendText(logfile);
            logtxt.Write(message);
            logtxt.Dispose();
        }

        public Log(string output = "Autogro_log.txt")
        {
            logfile = output;
        }
    }
}