using System;
using System.Reflection;
using System.Linq;

namespace EnumOps
{
    public static class EnumExtensionMethods
    {
        public static AutoGro.AssetTypeDescrition GetAssetTypeDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(AutoGro.AssetTypeDescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((AutoGro.AssetTypeDescriptionAttribute)_Attribs.ElementAt(0)).AssetTypeDescription;
                }
            }
            return new AutoGro.AssetTypeDescrition();
        }

    }
}