namespace SyncPlayer.DropboxAPI
{
    public class Config
    {
        public const string DropBoxAuthKey = "27vtxmpZKl0AAAAAAAAJzXlP1oRKWGgLx1GeAd89lLou-ta4EcMYd-FoZAO-J9iz";

        public static string MediaFileUrl
        {
            get { return "https://api.dropboxapi.com/1/media/auto{0}"; }
        }
    }
}
