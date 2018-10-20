using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;


namespace AutoGro
{
    public partial class Updater
    {
        public static readonly Version version = Assembly.GetExecutingAssembly().GetName().Version;
        public static readonly string updateDate = "20th October 2018";
        public static Version availableVersion = null;

        public static string tempFile = Application.ExecutablePath.Replace(".exe", "_.exe");

        private static readonly string VersionFileLink = "https://raw.githubusercontent.com/AsdolgTheMaker/AutoGro2018/master/version.txt";
        private static readonly string VersionFileTarget = Path.GetTempPath() + "version.tmp";

        public enum UpdateCheckResult
        {
            Failed = 0,
            None = 1,
            Available = 2
        }

        public static UpdateCheckResult CheckForUpdates()
        {
            try
            {
                WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };
                webClient.DownloadFile(VersionFileLink, VersionFileTarget);

                Version netVersion = Version.Parse(File.ReadAllText(VersionFileTarget));
                if (netVersion > version)
                {
                    availableVersion = netVersion;
                    return UpdateCheckResult.Available;
                }
                else
                {
                    return UpdateCheckResult.None;
                }
                    
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid version check! Please, report this.", "Couldn't check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return UpdateCheckResult.Failed;
            }
            catch (WebException)
            {
                MessageBox.Show("Failed to connect to github.", "Couldn't check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return UpdateCheckResult.Failed;
            }

        }

        public static void Update()
        {
            string downloadLink = GetReleaseLink(availableVersion.ToString());

            DialogResult dlgRslt = DialogResult.Retry;
            while (dlgRslt == DialogResult.Retry)
            {
                try
                {
                    WebClient webClient = new WebClient();

                    webClient.DownloadFile(downloadLink, tempFile);

                    Process.Start(tempFile);
                    Application.Exit();
                    dlgRslt = DialogResult.None;
                }
                catch (WebException ex)
                {
                    WebExceptionStatus exStatus = ex.Status;
                    switch (exStatus)
                    {
                        case (WebExceptionStatus.ConnectFailure):
                            {
                                dlgRslt = MessageBox.Show("Failed update: couldn't connect to the server.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                break;
                            }
                        case (WebExceptionStatus.ConnectionClosed):
                            {
                                dlgRslt = MessageBox.Show("Failed update: connection remotely closed.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                break;
                            }
                        case (WebExceptionStatus.ProtocolError):
                            {
                                dlgRslt = MessageBox.Show("Failed update: error 401.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                break;
                            }
                        case (WebExceptionStatus.Timeout):
                            {
                                dlgRslt = MessageBox.Show("Failed update: request timeout.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                break;
                            }
                        default:
                            {
                                dlgRslt = MessageBox.Show("Failed update: " + exStatus.ToString(), "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
            }
        }

        private static string GetReleaseLink(string version)
        {
            return ("https://github.com/AsdolgTheMaker/AutoGro2018/releases/download/" + version + "/AutoGro.exe");
        }
    }   
}