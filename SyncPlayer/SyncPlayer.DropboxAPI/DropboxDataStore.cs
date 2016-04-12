using System.Threading.Tasks;
using Dropbox.Api.Files;
using SyncPlayer.DropboxAPI.Contracts;
using SyncPlayer.DropboxAPI.Models;

namespace SyncPlayer.DropboxAPI
{
    public class DropboxDataStore : IDropboxDataStore
    {
        private readonly DropboxClientWrapper dropboxClient;

        public DropboxDataStore()
        {
            dropboxClient = new DropboxClientWrapper();
        }

        public async Task<MediaFile> GetFileUrlForStreamingAsync(string filePath)
        {
            return await dropboxClient.GetFileUrlForStreaming(filePath);
        }

        public async Task<SearchResult> SearchAsync(string searchTerm)
        {
            return await dropboxClient.SearchAsync(searchTerm);
        }
    }
}
