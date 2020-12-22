using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using static AutoGro.SeriousStream;

namespace AutoGro
{
    public partial class Asset : IEqualityComparer<Asset>
    {
        // Cache variables are used to avoid multiplie calculations for certain properties
        private string extension_cache = string.Empty;

        private readonly Log Log;
        private string fullPath = string.Empty;
        
        public string FullPath {
            get => fullPath;
            set {
                // empty cache before setting the value
                extension_cache = string.Empty;
                
                fullPath = value;
            }
        }

        public string PathWithoutExtension { get => FullPath.Substring(0, FullPath.Length - Extension.Length).Trim('.'); }

        // File extension. Basing on this, we can try to determine asset type, if not able to read it from binary file.
        public string Extension {
            get {
                if (string.IsNullOrEmpty(extension_cache)) extension_cache = GetAssetExtension(FullPath);
                return extension_cache;
            }
        }

        public Asset Source;

        public List<string> ChildrenSoft = new List<string>();

        public string GetAssetExtension() => Extension;
        public static string GetAssetExtension(string assetPath)
        {
            int iDot = assetPath.LastIndexOf(".") + 1;
            if (iDot >= assetPath.Length) throw new ArgumentException("Invalid path: was not able to detect file extension.");

            return assetPath.Substring(iDot);
        }

        internal void CollectExtensionBasedAssetsTo(List<Asset> result)
        {
            switch (Extension)
            {
                case "ogg": case "wav": case "mp3":
                {
                    string fileAttempt = PathWithoutExtension + ".srt";
                    if (File.Exists(fileAttempt)) result.Add(new Asset(fileAttempt, (LogInterface)Log, this));
                    fileAttempt = PathWithoutExtension + ".ass";
                    if (File.Exists(fileAttempt)) result.Add(new Asset(fileAttempt, (LogInterface)Log, this));
                    break;
                }

                case "gtitle":
                {
                    string fileAttempt = FullPath + "info";
                    if (File.Exists(fileAttempt)) result.Add(new Asset(fileAttempt, (LogInterface)Log, this));
                    break;
                }

                case "wld":
                {
                    string fileAttempt = PathWithoutExtension + ".nfo";
                    if (File.Exists(fileAttempt)) result.Add(new Asset(fileAttempt, (LogInterface)Log, this));
                    break;
                }
                
                case "tex":
                {
                    string fileAttempt = PathWithoutExtension + "--Big.tex";
                    if (File.Exists(fileAttempt)) result.Add(new Asset(fileAttempt, (LogInterface)Log, this));
                    break;
                }
            }
        }

        #region Path type conversions
        /// <summary>
        /// Converts given string path to SED's format
        /// </summary>
        /// <param name="source">Path to convert</param>
        /// <returns>Converted path string</returns>
        internal static string GetSoftPath(string source)
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
                throw new ArgumentException("Could not convert full path to soft path.");
        }
        /// <summary>
        /// Converts given string path to Windows format
        /// </summary>
        /// <param name="source">String to change</param>
        /// <returns>Converted string</returns>
        internal static string GetFullPath(string source, string contentFolder)
        {
            if (source.Contains("Content/"))
            {
                // Content folder + resource folder without "Content" part
                source = contentFolder + source.Substring(source.IndexOf("Content") + 8);

                // SED uses flipped slash, so flip them back
                source = source.Replace('/', '\\');

                return source;
            }
            else
                return source;
        }
        #endregion

        /// <summary>
        /// Parses given binary file. Returns true if result is successful, false if could not read the file. Writes resulting RFIL to given string list.
        /// </summary>
        public bool TryParse(LogInterface log, out List<string> result)
        {
            bool output = !(log == null);

            SeriousStream stream = new SeriousStream(FullPath, FileMode.Open, FileAccess.Read);
            while (stream.Position < stream.Length)
            {
                StructType structType = stream.CheckID();
                switch (structType)
                {
                    // one of those generic structures we are not interested in - skip them
                    case StructType.WRKSTRM1:
                    case StructType.CTSEMETA:
                    case StructType.MSGS:
                    case StructType.INFO:
                        if (output) log.Message("Parsing binary: skipping generic struct " + structType.ToString()); // TODO: StructType output is not user-friendly.
                        stream.ReadStruct(structType);
                        break;

                    // a separate log for SIGSTRM1 cause that's an important struct for further reading
                    case StructType.SIGSTRM1:
                        if (output) log.Message("Parsing binary: reading SIGSTRM1.");
                        stream.ReadStruct(StructType.SIGSTRM1);
                        break;

                    case StructType.RFIL: // found rfil, read it and return
                        if (output) log.Message("Parsing binary: Detected RFIL struct. Reading file references.");
                        result = stream.ReadStruct(StructType.RFIL);
                        stream.Dispose();
                        return true;

                    case StructType.Unknown: // could not read binary, give false result
                    default:
                        if (output) log.Message("Parsing binary: Failed.");
                        stream.Dispose();
                        result = null; 
                        return false;
                }
            }
            stream.Dispose();
            result = null; 
            return false;
        }

        public static Asset AssetFromSoftPath(string inputPath, string gameFolder, LogInterface log, Asset source = null)
            => new Asset(gameFolder.Trim('\\') + "\\" + inputPath, log, source);

        public override string ToString() => FullPath;

        public bool Equals(Asset x, Asset y)
        {
            if (x.FullPath == y.FullPath) return true;
            else return false;
        }

        public int GetHashCode(Asset obj) => obj.FullPath.GetHashCode();

        public Asset(string inputPath, LogInterface log, Asset source = null)
        {
            Log = log;
            Source = source;
            FullPath = inputPath;

            log.Message("Examining asset: " + inputPath);
            bool isBinary = TryParse(log, out List<string> childrenList);

            if (isBinary) // binary was successfuly parsed and we can read the results
            {
                log.Message("Binary parsed.");
                for (int i = 0; i < childrenList.Count; i++)
                {
                    string path = childrenList[i];
                    log.Message("Found asset: " + path);
                    ChildrenSoft.Add(path);
                }
            }
            else // wasn't able to parse file as binary. Stick to regex search then
            {
                log.Message("Failed parsing binary. Attempting regex search...");

                string fileContents = File.ReadAllText(inputPath);
                MatchCollection searchResult = new Regex(@"\w+(?>\/\w+)+(?>\w*.[a-z0-9_]+)+").Matches(fileContents);
                if (searchResult.Count == 0) log.Message("Regex search did not find any assets.");
                else
                {
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        string path = searchResult[i].Groups[1].ToString();
                        log.Message("Found asset: " + path);
                        ChildrenSoft.Add(path);
                    }
                }
            }
        }
    }
}