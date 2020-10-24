using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    internal partial class Asset
    {
        // Cache variables are used to avoid multiplie calculations for certain properties
        private string extension_cache = string.Empty;
        private AssetType? type_cache = null;
        private string softPath_cache = string.Empty;

        private Log Log; // for output purposes

        public string FullPath {
            get => FullPath;
            set {
                // empty cache before setting the value
                extension_cache = string.Empty;
                softPath_cache = string.Empty;
                type_cache = null;
                
                FullPath = value;
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
                    // To check the type, we have to do the following:
                    // 1) Try parsing the file. If it matches SED pattern - read it as a SED file, check the type out of it, set vars correspondingly.
                    // 2) If parsing wasn't a success - try reading file's extension.
                    // 3) If nothing helped - set file's type as Unknown.

                    
                    throw new NotImplementedException();
                }
                return (AssetType)type_cache;
            }
        }

        public Asset Source;

        public List<Asset> Children;


        /// <summary>
        /// Adds all related assets to a given queue
        /// </summary>
        internal void EnqueueChildrenAndSubchildren(Queue<Asset> packingQueue)
        {
            throw new NotImplementedException();
        }

        internal string GetAssetExtension() => Extension;
        internal static string GetAssetExtension(string assetPath)
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

        internal Asset(string fullPath, Log log, Asset source = null)
        {
            Log = log;
            FullPath = fullPath;
            Source = source;

            log.Message("Creating ");

            AssetTypeDescrition type = EnumOps.EnumExtensionMethods.GetAssetTypeDescription(Type);
            if (type.IsBinary) // read the file like normal humans do
            {

            }
            else // read the file like you are asdolg
            {

            }

            #region Read RFIL, fill Children list

            throw new NotImplementedException();
            #endregion
        }
    }
}