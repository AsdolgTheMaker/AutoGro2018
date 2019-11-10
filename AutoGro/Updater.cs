using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutoGro
{
    public class Updater
    {
        /// <summary>
        /// Current application version
        /// </summary>
        public static readonly Version version = Assembly.GetExecutingAssembly().GetName().Version;
        public static readonly string updateDate = "10th October 2019";

        /// <summary>
        /// Last stable version on Github. Filled in by CheckForUpdates() method.
        /// </summary>
        public static Version availableVersion = null;

        /// <summary>
        /// Where to download new version
        /// </summary>
        public static string tempFile = Application.ExecutablePath.Contains("_.exe") ? Application.ExecutablePath : Application.ExecutablePath.Replace(".exe", "_.exe");

        /// <summary>
        /// Version control file address
        /// </summary>
        private static readonly string VersionFileLink = "https://raw.githubusercontent.com/AsdolgTheMaker/AutoGro2018/master/version.txt";

        /// <summary>
        /// Version file download target location
        /// </summary>
        private static readonly string VersionFileTarget = Path.GetTempPath() + "version.tmp";

        /// <summary>
        /// Represents the result of checking for updates
        /// </summary>
        public enum UpdateCheckResult
        {
            Failed = 0,
            None = 1,
            Available = 2
        }

        /// <summary>
        /// Connects to Github server and checks if the latest stable version is used
        /// </summary>
        public static UpdateCheckResult CheckForUpdates()
        {
            try
            {
                WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };
                webClient.DownloadFile(VersionFileLink, VersionFileTarget);

                Version netVersion = Version.Parse(File.ReadAllText(VersionFileTarget));

                File.Delete(VersionFileTarget);

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
            catch (WebException ex)
            {
                WebExceptionStatus exStatus = ex.Status;
                switch (exStatus)
                {
                    case (WebExceptionStatus.ConnectFailure):
                        {
                            MessageBox.Show("Failed update: couldn't connect to the server.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            break;
                        }
                    case (WebExceptionStatus.ConnectionClosed):
                        {
                            MessageBox.Show("Failed update: connection remotely closed.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            break;
                        }
                    case (WebExceptionStatus.ProtocolError):
                        {
                            MessageBox.Show("Failed update: error 401.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            break;
                        }
                    case (WebExceptionStatus.Timeout):
                        {
                            MessageBox.Show("Failed update: request timeout.", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Failed update: " + exStatus.ToString(), "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            break;
                        }
                }
                return UpdateCheckResult.Failed;
            }

        }

        /// <summary>
        /// Performs an update
        /// </summary>
        public static void Update()
        {
            string downloadLink = GetReleaseLink(availableVersion.ToString());

            DialogResult dlgRslt = DialogResult.Retry;
            while (dlgRslt == DialogResult.Retry)
            {
                try
                {
                    string actualExe = Application.ExecutablePath;
                    File.Move(actualExe, tempFile);
                    WebClient webClient = new WebClient();

                    webClient.DownloadFile(downloadLink, actualExe);

                    Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Autogro").DeleteValue("FirstRun");

                    Process.Start(actualExe); 
                    Process.GetCurrentProcess().Kill();

                    break;
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

        /// <summary>
        /// Returns a link to download requested application version
        /// </summary>
        /// <param name="version">Version to download</param>
        /// <returns>File web-address</returns>
        private static string GetReleaseLink(string version) => ("https://github.com/AsdolgTheMaker/AutoGro2018/releases/download/" + version + "/AutoGro.exe");
    }   
}