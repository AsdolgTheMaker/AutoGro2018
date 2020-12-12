using System;
using System.IO;
using System.Windows.Forms;

namespace AutoGro
{
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

        public void Line(bool forFile = false) 
        {
            if (forFile) Message("------------------------------------------------------------------------------\n", true, false);
            else logBox.AppendText("------------------------------------------------------------------------------\n");
        }

        public LogInterface(RichTextBox LogTextBox, string output = "Autogro_log.txt")
        {
            logfile = output;
            logBox = LogTextBox;
        }
    }

}