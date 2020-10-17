using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    internal partial class Asset
    {
        private Log Log; // for output purposes

        public string FullPath;
        public string SoftPath { get => GetSoftPath(FullPath); }
        public string Extension;
        public AssetType Type;
        public Asset Source;
        public List<Asset> Children;

        /// <summary>
        /// Adds all related assets to a given queue
        /// </summary>
        internal void EnqueueChildrenAndSubchildren(Queue<Asset> packingQueue)
        {
            throw new NotImplementedException();
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

            #region Check asset type, fill Type and Extension

            throw new NotImplementedException();
            #endregion

            #region Read RFIL, fill Children list

            throw new NotImplementedException();
            #endregion
        }
    }
}