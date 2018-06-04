public static class GameConstants
{
    public const string WirtName = "Wirt";
	public const string GregName = "Greg";

    #region Resource file paths

    public static class ResourcePaths
    {
        const string AudioDirectory = "Audio";
        const string MusicDirectory = "Music";

        static string CreatePath(params string[] paths)
        {
            return string.Join("/", paths);
        }

        public static class AudioPath
        {
            public static readonly string PotatoesAndMolassesPickup = CreatePath(AudioDirectory, MusicDirectory, "Potatoes_Molasses/pickup");
            public static readonly string PotatoesAndMolassesLoop = CreatePath(AudioDirectory, MusicDirectory, "Potatoes_Molasses/loop");
        }
    }

    #endregion
}