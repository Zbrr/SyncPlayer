using System.Threading.Tasks;
using Dropbox.Api.Files;
using SyncPlayer.DropboxAPI.Models;

namespace SyncPlayer.DropboxAPI.Contracts
{
    public interface IDropboxDataStore
    {
        Task<MediaFile> GetFileUrlForStreamingAsync(string filePath);

        Task<SearchResult> SearchAsync(string searchTerm);
    }
}
