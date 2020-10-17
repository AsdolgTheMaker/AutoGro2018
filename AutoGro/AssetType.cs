using System.ComponentModel;

namespace AutoGro
{
    internal partial class Asset
    {
        public enum AssetType
        {
            [Description("World / Level file")] WLD,
            [Description()] MDL,
            [Description()] BMF,
            [Description()] GTITLE,
            [Description()] RSC,
            [Description("Unknown file type")] UNKNOWN,
        }
    }
}
