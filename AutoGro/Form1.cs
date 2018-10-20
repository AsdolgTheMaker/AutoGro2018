using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace AutoGro
{
    public partial class F_Main : Form
    {
        public string[] extExceptions = { "tex", "wav", "ogg", "tga", "fbx", "obj", "mp3", "png", "amf", "zpr" };


        public class Log
        {
            RichTextBox LogText;

            // Appends message into log and scrolls textbox
            public void Message(string message)
            {
                LogText.AppendText(DateTime.Now.ToLocalTime().ToString() + " || " + message + "\n");
                LogText.SelectionStart = LogText.Text.Length;
                LogText.ScrollToCaret();
            }

            // Clears log textbox
            public void Clear()
            {
                LogText.Text = "";
            }

            public void Line()
            {
                LogText.AppendText("------------------------------------------------------------------------------\n");
            }

            public Log(RichTextBox LogTextBox)
            {
                LogText = LogTextBox;
            }
        }

        private string sContent = "";

        public F_Main()
        {
            if (Updater.tempFile == Application.ExecutablePath)
            { // update is in progress, proceed to continuing it
                string oldFile = Updater.tempFile.Replace("_.exe", ".exe");
                File.Copy(Updater.tempFile, oldFile);
                Process.Start(oldFile);
                Application.Exit();
            }
            else // common run, act as usual
            {
                // if we are running after update - delete temp executable
                if (File.Exists(Updater.tempFile))
                {
                    File.Delete(Updater.tempFile);
                    Application.Exit();
                }
                else
                {
                    Updater.UpdateCheckResult updaterResult = Updater.CheckForUpdates();

                    InitializeComponent();
                    FBD_ContentDir.SelectedPath = Application.StartupPath;

                    Log log = new Log(RTB_Log);
                    log.Message("AutoGro 2018 " + Updater.version);

                    switch (updaterResult)
                    {
                        case Updater.UpdateCheckResult.Available:
                            {
                                string newVersion = Updater.availableVersion.ToString();
                                log.Message("Version " + newVersion + " is available!");

                                DialogResult dlgRes = MessageBox.Show("Version " + newVersion + " is available!\n\nUpdate now?", "Update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                switch (dlgRes)
                                {
                                    case DialogResult.Yes:
                                        {
                                            Updater.Update();
                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            log.Message("You can update any time by pressing \"Check for updates\" button below.");
                                            break;
                                        }
                                }
                                break;
                            }
                        case Updater.UpdateCheckResult.Failed:
                            {
                                log.Message("Error occurred while checking for updates!");
                                break;
                            }
                        case Updater.UpdateCheckResult.None:
                            {
                                log.Message("No updates available.");
                                break;
                            }
                    }

                    log.Line();
                }
            }
        }

        // Select .wld file to analyze
        private void BT_WldInput_Click(object sender, EventArgs e)
        {
            DialogResult dRes = OFD_WldInput.ShowDialog();
            if (dRes == DialogResult.OK && OFD_WldInput.FileName.Contains(".wld"))
            {
                TB_DirWLD.Text = OFD_WldInput.FileName;
                if (CB_Autodetection.Checked)
                {
                    if (TB_OutputName.Text == "")
                        TB_OutputName.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.Length - 3) + "gro";
                    if (TB_ContentPath.Text == "" && TB_ContentPath.Text.Contains("\\Content\\"))
                    TB_ContentPath.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.IndexOf("\\Content\\") + 9);
                    if (TB_WorkshopPath.Text == "" && TB_ContentPath.Text.Contains("\\steamapps\\common\\"))
                        TB_WorkshopPath.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.IndexOf("common")) + "workshop\\content\\564310\\";
                }
            }
            else
                MessageBox.Show("Invalid world file selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Select filename for .gro output
        private void BT_OutputFN_Click(object sender, EventArgs e)
        {
            DialogResult dRes = SFD_OutputFN.ShowDialog();
            if (dRes == DialogResult.OK && SFD_OutputFN.FileName.Contains(".gro"))
                TB_OutputName.Text = SFD_OutputFN.FileName;
            else
                MessageBox.Show("Invalid output filename selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BT_Browse_Workshop_Click(object sender, EventArgs e)
        {
            FBD_ContentDir.SelectedPath = TB_WorkshopPath.Text;
            DialogResult dRes = FBD_ContentDir.ShowDialog();
            if (dRes == DialogResult.OK && FBD_ContentDir.SelectedPath.Contains("\\workshop\\content\\"))
            {
                TB_WorkshopPath.Text = FBD_ContentDir.SelectedPath;
                if (CB_Autodetection.Checked)
                {
                    if (TB_ContentPath.Text == "")
                        TB_ContentPath.Text = TB_WorkshopPath.Text.Substring(0, TB_WorkshopPath.Text.IndexOf("workshop")) + "common\\Serious Sam Fusion 2017\\Content\\";
                }
            }
            else
                MessageBox.Show("Invalid workshop content folder selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Select Content folder path
        private void BT_ContentDir_Click(object sender, EventArgs e)
        {
            FBD_ContentDir.SelectedPath = TB_ContentPath.Text;
            DialogResult dRes = FBD_ContentDir.ShowDialog();
            if (dRes == DialogResult.OK && FBD_ContentDir.SelectedPath.Contains("\\Content"))
            {
                TB_ContentPath.Text = FBD_ContentDir.SelectedPath;
                if (CB_Autodetection.Checked)
                {
                    if (TB_WorkshopPath.Text == "" && TB_ContentPath.Text.Contains("\\steamapps\\common\\"))
                        TB_WorkshopPath.Text = TB_ContentPath.Text.Substring(0, TB_ContentPath.Text.IndexOf("common")) + "workshop\\content\\564310\\";
                }
            }
            else
            {
                MessageBox.Show("Invalid Content folder selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Initialize analyzing sequence
        private void BT_PackGro_Click(object sender, EventArgs e)
        {
            Log log = new Log(RTB_Log);

            string fnInput = TB_DirWLD.Text;
            string fnOutput = TB_OutputName.Text;
            sContent = TB_ContentPath.Text;

            log.Message("Analyzing " + fnInput + " file...");

            // a small fixup in case of missing slash
            if (!sContent.EndsWith("\\"))
                sContent += "\\";

            // check if a) file extensions are correct, b) Content folder path has Content folder
            if (!fnInput.Contains(".wld"))
            {
                log.Message("Invalid world file selected!");
                MessageBox.Show("Invalid world file selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }
            else if (!fnOutput.Contains(".gro"))
            {
                log.Message("Invalid output filename!");
                MessageBox.Show("Invalid output filename!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }
            else if (!sContent.Contains("Content"))
            {
                log.Message("Invalid Content directory!");
                MessageBox.Show("Invalid Content folder directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }
            else if (CB_Workshop.Checked && !TB_WorkshopPath.Text.Contains("\\workshop\\content\\"))
            {
                log.Message("Invalid workshop content directory!");
                MessageBox.Show("Invalid workshop content directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }
            else // proceed to analysis
            {
                // at first we put all found files in this queue
                Queue<string> files = new Queue<string>();

                // start recursive method which examines world file and everything inside it
                ExamineResource(fnInput, files, 0);

                // go to compressing
                try
                {
                    // create compressing stream
                    FileStream grofile = File.Create(fnOutput);
                    log.Message("Created " + fnOutput + " file.");
                    ZipArchive zip = new ZipArchive(grofile, ZipArchiveMode.Create, false);
                    log.Message("Starting packing...");

                    string[] filesList = RemoveDuplicates(files.ToArray());

                    // pack every file one by one
                    while (files.Count > 0)
                    {
                        try
                        {
                            string file = files.Dequeue();
                            log.Message("Packing " + file + "...");
                            zip.CreateEntryFromFile(ConvertSEDPathToWindows(file), file);
                        }
                        catch (FileNotFoundException)
                        {
                            log.Message("Error: file does not exist.");
                        }
                        catch (DirectoryNotFoundException)
                        {
                            log.Message("Error: file's location does not exist.");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            log.Message("Insufficient permissions to access the file!");
                        }
                        catch (PathTooLongException)
                        {
                            log.Message("Directory path is too long and is not supported by filesystem.");
                        }
                        catch (IOException)
                        {
                            log.Message("Error occurred while opening the file!");
                        }
                        catch (ArgumentException)
                        {
                            log.Message("Unknown error! Please, check filename for validity.");
                        }
                        catch (InvalidOperationException)
                        {
                            log.Message("Invalid operation on dequeueing! Unknown file was skipped.");
                        }
                    }

                    log.Line();
                    log.Message("Finishing forming the package... (this may take a while)");

                    // release filestream
                    grofile.Dispose();

                    log.Message("Package successfully created.");

                    // if we are not done yet - no need to interrupt the process
                    if (!CB_Workshop.Checked)
                        MessageBox.Show("Packing finished!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.Line();

                    // if requested, proceed to analyzing workshop entries
                    if (CB_Workshop.Checked)
                    {
                        log.Message("Examining workshop subcriptions...");
                        string sPathWS = TB_WorkshopPath.Text;

                        Queue<string> subscriptions = new Queue<string>();
                        try
                        {
                            string[] asWS = Directory.GetFiles(sPathWS, "*.gro", SearchOption.AllDirectories);


                            Dictionary<string, string[]> workshopEntries = new Dictionary<string, string[]>();
                            for (int i = 0; i < asWS.Length; i++)
                            {
                                // let's find out what subscription we are examining
                                string sNameFile = asWS[i].Replace(".gro", ".txt");
                                try
                                {
                                    sNameFile = File.ReadAllText(sNameFile);
                                    // that's how entries are kept - between first and second '#' symbols
                                    int iFirstReshotka = sNameFile.IndexOf('#');
                                    int iSecondReshotka = sNameFile.IndexOf('#', iFirstReshotka + 1);
                                    sNameFile = sNameFile.Substring(iFirstReshotka, iSecondReshotka - iFirstReshotka);

                                    // time to scan that little .gro
                                    FileStream wsFile = new FileStream(asWS[i], FileMode.Open, FileAccess.Read);
                                    ZipArchive gro = new ZipArchive(wsFile, ZipArchiveMode.Read, false);

                                    var entries = gro.Entries;

                                    // we already have all entries in a collection stored, so dispose the files
                                    wsFile.Dispose();

                                    string[] entriesNames = new string[entries.Count];

                                    // now for each entry assign 
                                    for (int j = 0; j < entries.Count; j++)
                                    {
                                        entriesNames[j] = entries[j].FullName;
                                    }
                                    // store filenames into a dictionary

                                    try
                                    {
                                        workshopEntries.Add(sNameFile, entriesNames);
                                    }
                                    catch (ArgumentException)
                                    {
                                        log.Message("Failed to analyze subscription with key value " + sNameFile);
                                    }
                                }
                                catch (FileNotFoundException)
                                {
                                    log.Message("Cannot find info file " + sNameFile);
                                }
                                catch (DirectoryNotFoundException)
                                {
                                    log.Message("Cannot find info file directory " + sNameFile);
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    log.Message("Denied permissions in access to file " + sNameFile);
                                }
                                catch (IOException)
                                {
                                    log.Message("Unexpected error when reading " + sNameFile);
                                }
                                catch (ArgumentException)
                                {
                                    log.Message("Invalid argument: " + sNameFile);
                                }

                            }


                            // Now that we have a dictionary full of workshop entries and their names, let's find out if
                            // collected before list has any of these

                            // here we will store all found names
                            Queue<string> WSsubscriptions = new Queue<string>();

                            for (int i = 0; i < workshopEntries.Count; i++)
                            {
                                string key = workshopEntries.Keys.ToArray()[i];
                                log.Message("Analyzing " + key + " subscription...");

                                for (int k = 0; k < workshopEntries[key].Length; k++)
                                {
                                    bool bStop = false;
                                    for (int j = 0; j < filesList.Length; j++)
                                    {
                                        if (workshopEntries[key][k] == filesList[j])
                                        {
                                            WSsubscriptions.Enqueue(key);
                                            log.Message("Subscription \"" + key + "\" usage detected.");

                                            // this entry is submitted, no need to check anymore
                                            bStop = true;
                                            break;
                                        }
                                    }
                                    if (bStop) break;
                                }
                            }
                            log.Line();
                            log.Message("Workshop subscriptions used:");
                            while (WSsubscriptions.Count != 0)
                            {
                                try
                                {
                                    log.Message(WSsubscriptions.Dequeue());
                                }
                                catch (InvalidOperationException)
                                {
                                    log.Message("Invalid Operation Exception during dequeueing! Please, report this.");
                                }
                            }
                            MessageBox.Show("Packing done!\nWorkshop subscriptions dependency examined!\n\nCheck the log box to see the results.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            log.Line();
                        }
                        // that's for the very start, go back :V
                        catch (DirectoryNotFoundException)
                        {
                            log.Message("Cannot find " + sPathWS + " directory.");
                        }
                        catch (ArgumentException)
                        {
                            log.Message("Invalid argument: " + sPathWS);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            log.Message("Cannot access " + sPathWS + " - permission denied.");
                        }
                        catch (IOException)
                        {
                            log.Message("Unknown error when accessing " + sPathWS);
                        }
                    }
                }
                catch (OutOfMemoryException)
                {
                    log.Message("CRITICAL ERROR: Out of memory.");
                    log.Message("Cannot continue packing.");
                    MessageBox.Show("Application is out of memory.\n\nThe process will be aborted.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    log.Line();
                }

            }
        }
        
        /// <summary>
        /// Converts given string path to SED's format
        /// </summary>
        /// <param name="source">Path to convert</param>
        /// <returns>Converted path string</returns>
        private string ConvertPathToSED(string source)
        {
            if (source.Contains("Content"))
            {
                // cut string to Content part
                source = source.Substring(source.IndexOf("Content"));

                // SED uses flipped slash
                source = source.Replace('\\', '/');
                return source;
            }
            else // that's some bullshit path
                return(source);
        }

        /// <summary>
        /// Converts given string path to Windows format
        /// </summary>
        /// <param name="source">String to change</param>
        /// <returns>Converted string</returns>
        private string ConvertSEDPathToWindows(string source)
        {
            if (source.Contains("Content/"))
            {
                // Content folder + resource folder without "Content" part
                source = sContent + source.Substring(source.IndexOf("Content") + 8);

                // SED uses flipped slash, so flip them back
                source = source.Replace('/', '\\');

                return source;
            }
            else
                return source;
        }

        /// <summary>
        /// Examines specified resource and collects all other resources linked inside
        /// </summary>
        /// <param name="resource">Path of resource to examine</param>
        /// <param name="files">General queue to add files</param>
		/// <param name="depth">Indicates how deep recursion went so far. First call should have 0.</param>
        private void ExamineResource(string resource, Queue<string> files, int depth)
        {
            Log log = new Log(RTB_Log);


            resource = ConvertSEDPathToWindows(resource);
            try
            {
                FileStream file = new FileStream(resource, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                resource = ConvertPathToSED(resource);
                log.Message("Analyzing " + resource + ". Recursion depth: " + depth + ".");

                // read entire file as a single string
                string contents = reader.ReadToEnd();

                file.Dispose();

                while (contents.Contains("Content/"))
                {
                    int iStart = contents.IndexOf("Content/");
                    int iEnd = contents.IndexOf(".", iStart) + 4;

                    string extension = contents.Substring(iEnd - 3, 3);
                    if (extension == "gti")
                    { // either .gtitle or .gtitleinfo
                        extension = contents.Substring(iEnd - 3, 7);
                        if (extension.Contains("gtitleinfo"))
                        { // that's .gtitleinfo
                            iEnd += 7;
                        }
                        else // that's .gtitle
                        {
                            extension = "gtitle";
                            iEnd += 3;
                        }
                    }
                    else if (extension == "ctb")
                    { // that's .ctbl
                        extension = "ctbl";
                        iEnd++;
                    }
                    // check if it's one of two-lettered extensions
                    else if (extension.StartsWith("ep") || extension.StartsWith("cb"))
                    {
                        extension = extension.Substring(0, 2);
                        iEnd--;
                    }

					string resPath = contents.Substring(iStart, iEnd - iStart);
                    if (!files.Contains(resPath))
                    {
                        if (extension == "gtitle" || extension == "gtitleinfo")
                        { // pack gtitle only if it is going to be analyzed
                            if (CB_Gtitle.Checked)
                            {
                                log.Message("Adding resource " + resPath);
                                files.Enqueue(resPath);
                            }
                        }
                        else if (extension == "wld")
                        { // pack worlds only if user desired so
                            if (CB_OtherWLDs.Checked || depth == 0)
                            { // we don't only need .wld, but also .nfo file coming with it
                                log.Message("Adding resource " + resPath + " to queue.");
                                files.Enqueue(resPath);

                                log.Message("Adding resource " + resPath.Substring(0, resPath.Length - 3) + "nfo" + " to queue.");
                                files.Enqueue(resPath.Substring(0, resPath.Length - 3) + "nfo");
                            }
                        }
                        else if (extension == "tex")
                        { // texture can use streaming, so attempt to pack '<name>--Big.tex' too
                            log.Message("Adding resource " + resPath + " to queue.");
                            files.Enqueue(resPath);
                            files.Enqueue(resPath.Substring(0, resPath.Length - 4) + "--Big.tex");
                        }
                        else // in other case, pack everything
                        {
                            log.Message("Adding resource " + resPath + " to queue.");
                            files.Enqueue(resPath);
                        }

                        resPath = ConvertSEDPathToWindows(resPath);


                        if (extension == "gtitle")
                        {
                            if (CB_Gtitle.Checked)
                                ExamineResource(resPath, files, depth + 1);
                        }
                        else if (extension == "wld")
                        {
                            if (CB_OtherWLDs.Checked)
                                ExamineResource(resPath, files, depth + 1);
                        }
                        // exclude several predefined extensions from analysis
                        else if (!extExceptions.Contains(extension))
                            ExamineResource(resPath, files, depth + 1);
                    }

                    contents = contents.Substring(iEnd);
                }
            }
            catch (DirectoryNotFoundException)
            {
                log.Message("Unexisting resource " + resource);
            }
            catch (FileNotFoundException)
            {
                log.Message("Unexisting resource: " + resource);
            }
            catch (ArgumentException)
            {
                log.Message("Unknown error while analyzing " + resource + ". Recursion depth: " + depth);
            }
        }

        private void BT_Log_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RTB_Log.Text);
            MessageBox.Show("Log copied into clipdoard!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Log_Clear_Click(object sender, EventArgs e)
        {
            Log log = new Log(RTB_Log);
            log.Clear();
        }

        private void BT_Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private static string[] RemoveDuplicates(string[] s)
        {
            HashSet<string> set = new HashSet<string>(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }

        private void CB_Workshop_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Workshop.Checked)
            {
                TB_WorkshopPath.Enabled = true;
                BT_Browse_Workshop.Enabled = true;
            }
            else
            {
                TB_WorkshopPath.Enabled = false;
                BT_Browse_Workshop.Enabled = false;
            }
        }

        private void BT_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AutoGro 2018 " + Updater.version + "\n\nMade with:\n.NET Framework 4.6.1\nC# Windows Forms\nVisual Studio Community 2017\n\nAuthor: Asdolg\n" + Updater.updateDate, "About", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void BT_Help_OtherWLDs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option defines if analizer will examine .wld files which are linked from selected one.\nThat means, if you have a ten levels campaign, you should select first level and tick this option, so resources from all levels will be collected.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Help_Gtitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Every world file links to .gtitle it's using, and .gtitle has many resources links in it. If you don't use custom .gtitle, you don't need this option.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Help_Autodetection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If this setting is checked, after browsing one of below directories all others will try to detect their location.\n\nNote: autodetection will not happen for non-empty fields.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Help_Workshop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("After packing is done, the program will detect which workshop resources were used and display that info in log box.\n\nNote: the feature may work incorrectly for subscriptions which replace original game's content.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Update_Click(object sender, EventArgs e)
        {
            
        }
    }
}