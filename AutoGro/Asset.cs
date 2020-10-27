using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AutoGro.SeriousStream;

namespace AutoGro
{
    public partial class Asset
    {
        // Cache variables are used to avoid multiplie calculations for certain properties
        private string extension_cache = string.Empty;
        private AssetType? type_cache = null;
        private string softPath_cache = string.Empty;

        private Log Log;
        private string fullPath = string.Empty;
        
        public string FullPath {
            get => fullPath;
            set {
                // empty cache before setting the value
                extension_cache = string.Empty;
                softPath_cache = string.Empty;
                type_cache = null;
                
                fullPath = value;
            }
        }

        // SED-like path conversion
        public string SoftPath {
            get {
                if (string.IsNullOrEmpty(softPath_cache)) softPath_cache = GetSoftPath(FullPath);
                return softPath_cache;
            }
        }

        // File extension. Basing on this, we can try to determine asset type, if not able to read it from binary file.
        public string Extension {
            get {
                if (string.IsNullOrEmpty(extension_cache)) extension_cache = GetAssetExtension(FullPath);
                return extension_cache;
            }
        }

        public AssetType Type {
            get {
                if (type_cache == null)
                {
                    
                }
                return (AssetType)type_cache;
            }
        }

        public Asset Source;

        public List<Lazy<Asset>> Children;

        /// <summary>
        /// Adds all related assets to a given queue
        /// </summary>
        public void EnqueueChildrenAndSubchildren(Queue<Asset> packingQueue)
        {
            throw new NotImplementedException();
        }

        public string GetAssetExtension() => Extension;
        public static string GetAssetExtension(string assetPath)
        {
            int iDot = assetPath.LastIndexOf(".");
            if (iDot >= assetPath.Length) throw new ArgumentException("Invalid path: was not able to detect file extension.");

            return assetPath.Substring(iDot);
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
        public bool TryParse(Log log, out List<string> result)
        {
            bool output = !(log == null);

            SeriousStream stream = new SeriousStream(FullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
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
                        if (output) log.Message("Parsing binary: Detected RFIL struct. Reading file references:");
                        result = stream.ReadStruct(StructType.RFIL);
                        if (output) log.Message(result.ToString(), addFormatting: false);
                        return true;

                    case StructType.Unknown: // could not read binary, give false result
                    default:
                        if (output) log.Message("Parsing binary: Failed.");
                        result = null; return false;
                }
            }
            result = null; return false;
        }

        public Asset(string fullPath, Log log, Asset source = null)
        {
            Log = log;
            FullPath = fullPath;
            Source = source;

            log.Message("Examining asset: " + SoftPath);
            List<string> childrenList = new List<string>();
            bool isBinary = TryParse(Log, out childrenList);

            if (isBinary) // binary was successfuly parsed and we can read the results
            {
                log.Message("Binary parsed. Found resources:");
                for (int i = 0; i < childrenList.Count; i++)
                {
                    log.Message(childrenList[i], false);
                    Children.Add(new Lazy<Asset>(() => 
                        new Asset(childrenList[i], Log, this))
                    );
                }
            }
            else // wasn't able to parse file as binary. Stick to regex search then
            {
                log.Message("Failed parsing binary. Attempting regex search...");

                string fileContents = System.IO.File.ReadAllText(fullPath);
                MatchCollection searchResult = new Regex(@"\w+(?>\/\w+)+(?>\w*.[a-z0-9_]+)+").Matches(fileContents);
                if (searchResult.Count == 0) log.Message("Regex search failed.");
                else
                {
                    log.Message("Regex search results:");
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        log.Message(searchResult[i].Value, false);
                        Children.Add(new Lazy<Asset>(() => 
                            new Asset(searchResult[i].Value, Log, this))
                        );
                    }
                }
            }
        }
    }
}