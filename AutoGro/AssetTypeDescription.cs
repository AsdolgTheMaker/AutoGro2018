namespace AutoGro
{
    public struct AssetTypeDescription
    {
        public string ExtensionString;
        public string Description;
        public bool IsBinary;

        public AssetTypeDescription(string extension, string description, bool isBinary)
        {
            ExtensionString = extension;
            Description = description;
            IsBinary = isBinary;
        }

        public override bool Equals(object obj) 
            => obj is AssetTypeDescription descrition && ExtensionString == descrition.ExtensionString;

        public override int GetHashCode() => ExtensionString.GetHashCode();

        public static bool operator ==(AssetTypeDescription obj1, AssetTypeDescription obj2) => obj1.Equals(obj2);
        public static bool operator !=(AssetTypeDescription obj1, AssetTypeDescription obj2) => !obj1.Equals(obj2);

        public override string ToString() => ExtensionString;
    }
}