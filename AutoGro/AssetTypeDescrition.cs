namespace AutoGro
{
    public struct AssetTypeDescrition
    {
        public string ExtensionString;
        public string Description;
        public bool IsBinary;

        public AssetTypeDescrition(string extension, string description, bool isBinary)
        {
            ExtensionString = extension;
            Description = description;
            IsBinary = isBinary;
        }

        public override bool Equals(object obj) 
            => obj is AssetTypeDescrition descrition && ExtensionString == descrition.ExtensionString;

        public override int GetHashCode() => ExtensionString.GetHashCode();

        public static bool operator ==(AssetTypeDescrition obj1, AssetTypeDescrition obj2) => obj1.Equals(obj2);
        public static bool operator !=(AssetTypeDescrition obj1, AssetTypeDescrition obj2) => !obj1.Equals(obj2);

        public override string ToString() => ExtensionString;
    }
}