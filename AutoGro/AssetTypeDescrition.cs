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
    }
}