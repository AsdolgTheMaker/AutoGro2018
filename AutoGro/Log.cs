using System;
using System.IO;
using System.Windows.Forms;

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

    public class LogInterface : Log
    {
        public RichTextBox logBox;

        // Appends message into log and scrolls textbox
        public void Message(string message, bool saveToFile = true, bool addFormatting = true)
        {
            if (addFormatting) message = DateTime.Now.ToLocalTime().ToString() + " || " + message + "\n";
            logBox.AppendText(message);

            if (saveToFile)
            {
                StreamWriter logtxt = File.AppendText(logfile);
                logtxt.Write(message);
                logtxt.Dispose();
            }

            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        public void Clear()
        {
            logBox.Text = string.Empty;
        }

        public void Line() 
        { 
            logBox.AppendText("------------------------------------------------------------------------------\n");
        }

        public LogInterface(RichTextBox LogTextBox, string output = "Autogro_log.txt")
        {
            logfile = output;
            logBox = LogTextBox;
        }
    }

}