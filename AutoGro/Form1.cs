// Defining this variable enables deprecated code which is meant to be replaced with a new method.
//#define USE_DEPRECATED_ANALYSIS

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutoGro
{
    public partial class F_Main : Form
    {
        public string[] extExamineExceptions = { "tex", "wav", "ogg", "tga", "fbx", "obj", "mp3", "png", "amf", "zpr" };
        public List<string> extPackExceptions = new List<string>() { "tga", "fbx", "obj", "mp3", "png", "amf", "zpr" };

        private string contentFolder = "";
        private LogInterface log;


        public F_Main(string[] args)
        { 
            // check for updates sequence
            if (File.Exists(Updater.tempFile))
                File.Delete(Updater.tempFile);
                
            Updater.UpdateCheckResult updaterResult = Updater.CheckForUpdates();

            InitializeComponent();

            log = new LogInterface(RTB_Log);
            log.Line(true);
            log.Message("AutoGro 2018 " + Updater.version + " initialized.");

            // print out update check result
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

                        // output what's new
                        log.Message("What's new in this version?" +
                            "\n- Implemented binary reading, which rapidly increased analysis speed." +
                            "\n- For generic text filetypes, new regex search is used instead of old Content-relying method." +
                            "\n- Internal workflow went through some harsh refactoring.\n",
                            saveToFile: false, addFormatting: false);
                        break;
                    } 
            }
            log.Line();

            // Reserved for settings section
            /* if (args.Length > 0)
            {
                TB_DirWLD.Text = args[0];
                TB_OutputName.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.Length - 3) + "gro";
                if (TB_DirWLD.Text.Contains("\\Content\\"))
                    TB_ContentPath.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.IndexOf("\\Content\\") + 9);
                if (TB_DirWLD.Text.Contains("\\steamapps\\common\\"))
                    TB_WorkshopPath.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.IndexOf("common")) + "workshop\\content\\564310\\";
            }
            else
            {
                FBD_ContentDir.SelectedPath = Application.StartupPath;
            }
            */

            LB_CurrentState.Text = "";
        }

        // Select .wld file to analyze
        private void BT_WldInput_Click(object sender, EventArgs e)
        {
            DialogResult dRes = OFD_WldInput.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                TB_DirWLD.Text = OFD_WldInput.FileName;
                if (CB_Autodetection.Checked)
                {
                    if (string.IsNullOrEmpty(TB_OutputName.Text))
                        TB_OutputName.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.Length - 3) + "gro";
                    if (string.IsNullOrEmpty(TB_GamePath.Text) && TB_DirWLD.Text.Contains("\\Serious Sam 4\\"))
                        TB_GamePath.Text = TB_DirWLD.Text.Substring(0, TB_DirWLD.Text.IndexOf("\\Serious Sam 4\\") + 15);
                    if (string.IsNullOrEmpty(TB_WorkshopPath.Text) && TB_DirWLD.Text.Contains("\\steamapps\\common\\"))
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
                    if (TB_GamePath.Text == "")
                        TB_GamePath.Text = TB_WorkshopPath.Text.Substring(0, TB_WorkshopPath.Text.IndexOf("workshop")) + "common\\Serious Sam Fusion 2017\\Content\\";
                }
            }
            else
                MessageBox.Show("Invalid workshop content folder selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Select Content folder path
        private void BT_ContentDir_Click(object sender, EventArgs e)
        {
            FBD_ContentDir.SelectedPath = TB_GamePath.Text;
            DialogResult dRes = FBD_ContentDir.ShowDialog();
            if (dRes == DialogResult.OK && FBD_ContentDir.SelectedPath.Contains("\\Content"))
            {
                TB_GamePath.Text = FBD_ContentDir.SelectedPath;
                if (CB_Autodetection.Checked)
                {
                    if (TB_WorkshopPath.Text == "" && TB_GamePath.Text.Contains("\\steamapps\\common\\"))
                        TB_WorkshopPath.Text = TB_GamePath.Text.Substring(0, TB_GamePath.Text.IndexOf("common")) + "workshop\\content\\564310\\";
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
            if (!CB_Exceptions.Checked) extPackExceptions.Clear();

            string fnInput = TB_DirWLD.Text;
            string fnOutput = TB_OutputName.Text;
            contentFolder = TB_GamePath.Text;

            log.Message("Analyzing " + fnInput + " file...");

            // a small fixup in case of missing slash
            if (!contentFolder.EndsWith("\\"))
                contentFolder += "\\";

            // check if a) file extensions are correct, b) Content folder path has Content folder
            if (fnInput.Contains(".tex"))
            {
                log.Message("Invalid input file selected!");
                MessageBox.Show("Invalid input file selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            /*else if (!contentFolder.Contains("Content"))
            {
                log.Message("Invalid Content directory!");
                MessageBox.Show("Invalid Content folder directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }*/
            else if (CB_Workshop.Checked && !TB_WorkshopPath.Text.Contains("\\workshop\\content\\"))
            {
                log.Message("Invalid workshop content directory!");
                MessageBox.Show("Invalid workshop content directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Message("Analysis stopped.");
                log.Line();
            }
            else // proceed to analysis
            {
                #region New analysis code

                LB_CurrentState.Text = "Checking asset references...";

                // find referenced files
                Asset rootAsset = new Asset(fnInput, log);
                List<Asset> assetsToPack = ReadAllChildren(rootAsset);

                // create compression stream
                log.Message("Opening archive file...");
                FileStream grofile = File.OpenWrite(fnOutput);

                log.Message("Creating compression stream...");
                ZipArchive zip = new ZipArchive(grofile, ZipArchiveMode.Create, false);

                log.Message("Starting packing...");

                PB_Process.Value = 0;
                PB_Process.Maximum = assetsToPack.Count;
                LB_CurrentState.Text = "Packing assets...";

                foreach (Asset asset in assetsToPack)
                {
                    log.Message("Packing file " + asset.FullPath + "...");
                    PB_Process.Value++;
                    zip.CreateEntryFromFile(asset.FullPath, asset.FullPath.Replace(TB_GamePath.Text, string.Empty));
                }
                log.Message("Releasing compression stream... (may take a while)");
                zip.Dispose();
                log.Message("Packing successfully finished.");
                log.Line(true);

                LB_CurrentState.Text = string.Empty;
                PB_Process.Value = 0;
                PB_Process.Maximum = 0;

                #endregion
            }
        }

        public List<Asset> ReadAllChildren(Asset rootAsset)
        {
            List<Asset> result = new List<Asset>();
            result.Add(rootAsset);

            foreach (string softPath in rootAsset.ChildrenSoft)
            {
                string fullPath = TB_GamePath.Text.Trim('\\') + "\\" + softPath.Replace('/', '\\');
                if (!File.Exists(fullPath))
                {
                    log.Message("File " + softPath + " not found on local disk.");
                    continue;
                }
                Asset child = new Asset(fullPath, log, rootAsset);
                result.AddRange(ReadAllChildren(child));
            }
            return result;
        }

        /*
        /// <summary>
        /// Examines specified resource and collects all other resources linked inside
        /// </summary>
        /// <param name="resource">Path of resource to examine</param>
        /// <param name="files">General queue to add files</param>
		/// <param name="depth">Indicates how deep recursion went so far. First call should have 1.</param>
        private void ExamineResource(string resource, Queue<string> files, int depth)
        {
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

					string respath = contents.Substring(iStart, iEnd - iStart);
                    if (!files.Contains(respath))
                    {
                        if (!extPackExceptions.Contains(extension))
                        {
                            if (extension == "gtitle")
                            { // pack gtitle only if it is going to be analyzed
                                if (CB_Gtitle.Checked)
                                {
                                    log.Message("Adding resource " + respath);
                                    files.Enqueue(respath);

                                    // also add gtitleinfo for gtitle
                                    files.Enqueue(respath + "info");

                                    respath = ConvertSEDPathToWindows(respath);
                                    if (CB_Gtitle.Checked)
                                        ExamineResource(respath, files, depth + 1);
                                }
                            }
                            else if (extension == "wld")
                            { // pack worlds only if user desired so
                                if (CB_OtherWLDs.Checked || depth == 0)
                                { // we don't only need .wld, but also .nfo file coming with it
                                    log.Message("Adding resource " + respath + " to queue.");
                                    files.Enqueue(respath);

                                    log.Message("Adding resource " + respath.Substring(0, respath.Length - 3) + "nfo" + " to queue.");
                                    files.Enqueue(respath.Substring(0, respath.Length - 3) + "nfo");

                                    respath = ConvertSEDPathToWindows(respath);
                                    if (CB_OtherWLDs.Checked)
                                        ExamineResource(respath, files, depth + 1);
                                }
                            }
                            else if (extension == "tex")
                            { // texture can use streaming, so attempt to pack '<name>--Big.tex' too
                                log.Message("Adding resource " + respath + " to queue.");
                                files.Enqueue(respath);
                                files.Enqueue(respath.Substring(0, respath.Length - 4) + "--Big.tex");
                            }
                            else if (extension == "ogg" || extension == "wav")
                            {
                                files.Enqueue(respath);

                                // consider there are subtitles
                                files.Enqueue(respath.Substring(0, respath.Length - 3) + "srt");
                                files.Enqueue(respath.Substring(0, respath.Length - 3) + "ass");
                            }
                            else
                            {
                                log.Message("Adding resource " + respath + " to queue.");
                                files.Enqueue(respath);

                                if (!extExamineExceptions.Contains(extension))
                                    ExamineResource(respath, files, depth + 1);
                            }
                        }
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
        */

        private void BT_Log_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(log.logBox.Text);
            MessageBox.Show("Log copied into clipdoard!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BT_Log_Clear_Click(object sender, EventArgs e)
        {
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
            LogInterface log = new LogInterface(RTB_Log);

            Updater.UpdateCheckResult updaterResult = Updater.CheckForUpdates();
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
        }

        private void BT_Log_Open_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Этот функционал кое-кто сломал и так и не починил. Если несложно, пни автора пожалуйста.");
        }

        private void BT_Settings_Click(object sender, EventArgs e)
        {
            // SETTINGS ARE UNDER CONSTRUCTION, DISABLED FOR NOW
            MessageBox.Show("This is not implemented yet.\n\nPlease, wait for an update.");

            // F_Settings settingsDlg = new F_Settings();
            // settingsDlg.ShowDialog(this);
        }

        private void BT_Help_Exceptions_Click(object sender, EventArgs e)
            => MessageBox.Show("Enable this to exclude desired extensions from resulting gro.\nYou can manually set which extensions will not be packed by clicking 'Tune extensions' button.");

        private void BT_ExceptionsSettings_Click(object sender, EventArgs e)
        {
            ExtensionsTuner tuner = new ExtensionsTuner(extPackExceptions);
            DialogResult result = tuner.ShowDialog();
            if (result == DialogResult.OK)
                extPackExceptions = tuner.extensions;
            tuner.Dispose();
        }

        private void CB_Exceptions_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Exceptions.Checked && extPackExceptions.Count == 0)
            {
                DialogResult result = MessageBox.Show("Warning! Exceptions list is empty. Open Exceptions Tuner?", "No exceptions", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    BT_ExceptionsSettings_Click(CB_Exceptions, new EventArgs());
            }
        }
    }
}