namespace SyncPlayer.YoutubeAPI
{
    public class Config
    {
        public const string ApplicationName = "SyncPlayer";

        public const string YoutubeApiKey = "AIzaSyDwdXgt7U9N76iOLvkMKVGF2EYzIOm2wrs";

        public const string SearchType = "video";

        public const int MaxResults = 10;

        public static string YoutubeVideoUrl 
        {
            get { return "https://www.youtube.com/watch?v={0}"; }
        }
    }
}
