using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Newtonsoft.Json;
using SyncPlayer.DropboxAPI.Models;

namespace SyncPlayer.DropboxAPI
{
    public class DropboxClientWrapper
    {
        private readonly DropboxClient dropboxClient;
        private readonly HttpClient dropboxHttpClient;

        public DropboxClientWrapper()
        {
            dropboxClient = new DropboxClient(Config.DropBoxAuthKey);

            dropboxHttpClient = new HttpClient();
            dropboxHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.DropBoxAuthKey);
        }

        public async Task<MediaFile> GetFileUrlForStreaming(string filePath)
        {
            var url = string.Format(Config.MediaFileUrl, filePath);

            try
            {
                var response = await dropboxHttpClient.PostAsync(url, null);

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<MediaFile>(json);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SearchResult> SearchAsync(string searchTerm)
        {
            return await dropboxClient.Files.SearchAsync(string.Empty, searchTerm);
        }
    }
}
