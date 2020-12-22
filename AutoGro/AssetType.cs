using System;
using System.ComponentModel;
using System.Linq;

namespace AutoGro
{
    public partial class Asset
    {
        public AssetType Type
        {
            get
            {
                var enumType = typeof(AssetType);
                foreach (AssetType assetType in Enum.GetValues(enumType))
                {
                    var memberInfos = enumType.GetMember(assetType.ToString());
                    var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                    var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(AssetTypeDescriptionAttribute), false);
                    var extension = ((AssetTypeDescriptionAttribute)valueAttributes[0]).ExtensionString;
                    if (extension == Extension) return assetType;
                }
                return AssetType.UNKNOWN;
            }
        }

        public enum AssetType
        {
            [AssetTypeDescription("ANH", "Animation host", isBinary: true)]
            ANH,

            [AssetTypeDescription("ANS", "Animation set", isBinary: true)]
            ANS,

            [AssetTypeDescription("BMF", "Mesh file", isBinary: true)]
            BMF,

            [AssetTypeDescription("CB", "Character behaviour", isBinary: true)]
            CB,

            [AssetTypeDescription("CTBL", "Collision table", isBinary: true)]
            CTBL,

            [AssetTypeDescription("CTL", "Character tool", isBinary: true)]
            CTL,

            [AssetTypeDescription("DEPENDENCYDATABASE", "Dependency database", isBinary: true)]
            DEPENDENCYDATABASE,

            [AssetTypeDescription("FNT", "Font")]
            FNT,

            [AssetTypeDescription("DLG", "Terminal dialog")]
            DLG,

            [AssetTypeDescription("EP", "Entity parameters", isBinary: true)]
            EP,

            [AssetTypeDescription("GTITLE", "Game title", isBinary: true)] 
            GTITLE,

            [AssetTypeDescription("GTITLEINFO", "Game title info")]
            GTITLEINFO,

            [AssetTypeDescription("LFX", "Light special effect", isBinary: true)]
            LFX,

            [AssetTypeDescription("LUA", "LUA script")]
            LUA,

            [AssetTypeDescription("MAT", "Material interaction", isBinary: true)]
            MAT,

            [AssetTypeDescription("MTR", "Material surface", isBinary: true)]
            MTR,

            [AssetTypeDescription("MDL", "Model configuration", isBinary: true)]
            MDL,

            [AssetTypeDescription("NFO", "Additional info")]
            NFO,

            [AssetTypeDescription("PFX", "Particle special effect", isBinary: true)]
            PFX,

            [AssetTypeDescription("RSC", "Generic resource", isBinary: true)]
            RSC,

            [AssetTypeDescription("SCP", "Particles scheme", isBinary: true)]
            SCP,

            [AssetTypeDescription("SCS", "Sounds scheme", isBinary: true)]
            SCS,

            [AssetTypeDescription("TEX", "Texture image", isBinary: true)]
            TEX,

            [AssetTypeDescription("TMA", "Terrain material interaction", isBinary: true)]
            TMA,

            [AssetTypeDescription("TMT", "Terrain material surface", isBinary: true)]
            TMT,

            [AssetTypeDescription("TSS", "Text style sheet")]
            TSS,

            [AssetTypeDescription("TXT", "Text")] 
            TXT,

            [AssetTypeDescription("WLD", "World", isBinary: true)] 
            WLD,

            [AssetTypeDescription("XML", "Markup sheet")]
            XML,

            [AssetTypeDescription("Unknown file type")] 
            UNKNOWN,
        }
    }
}