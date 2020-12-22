using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    public partial class AssetTypeDescriptionAttribute : Attribute
    {
        public AssetTypeDescrition AssetTypeDescription = new AssetTypeDescrition();

        public string ExtensionString { get => AssetTypeDescription.ExtensionString; set => AssetTypeDescription.ExtensionString = value; }
        public string Description { get => AssetTypeDescription.Description; set => AssetTypeDescription.Description = value; }
        public bool IsBinary { get => AssetTypeDescription.IsBinary; set => AssetTypeDescription.IsBinary = IsBinary; }

        public AssetTypeDescriptionAttribute(string description)
        {
            Description = description;
            ExtensionString = string.Empty;
            IsBinary = false;
        }

        public AssetTypeDescriptionAttribute(string extension, string description, bool isBinary = false)
        {
            ExtensionString = extension;
            Description = description;
            IsBinary = isBinary;
        }
    }
}