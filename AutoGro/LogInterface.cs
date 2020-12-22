using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AutoGro
{
    public class LogInterface : Log
    {
        public RichTextBox logBox = null;
        public StreamWriter logTxt = null;

        // Appends message into log and scrolls textbox
        public void Message(string message, bool saveToFile = true, bool addFormatting = true)
        {
            if (addFormatting) message = DateTime.Now.ToLocalTime().ToString() + " || " + message + "\n";
            
            logBox.AppendText(message); // WARNING: AppendText can cause perfomance issues

            if (saveToFile)
            {
                if (logTxt == null) logTxt = File.AppendText(logfile);
                logTxt.Write(message);
            }
        }

        public void Clear()
        {
            logBox.Text = string.Empty;
        }

        public void Line(bool forFile = false) 
        {
            if (forFile) Message("------------------------------------------------------------------------------\n", true, false);
            else logBox.AppendText("------------------------------------------------------------------------------\n");
        }

        public LogInterface(RichTextBox LogTextBox, string output = "Autogro_log.txt")
        {
            logfile = output;
            logBox = LogTextBox;
            logBox.HideSelection = false;
        }
    }

}