using System.Collections.Generic;
using System.Threading.Tasks;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Common.DTOs;
using SyncPlayer.DropboxAPI.Services;
using SyncPlayer.YoutubeAPI.Services;

namespace SyncPlayer.Domain.Services
{
    public class FileFinderFacade : IFileFinderFacade
    {
        public IEnumerable<IFileFinderService> FileFinderServices { get; set; }

        public FileFinderFacade()
        {
            FileFinderServices = new List<IFileFinderService>()
            {
                new DropboxFileFinderService(),
                new YoutubeFileFinderService()
            };
        }

        public async Task<AudioFileDto[]> FindAudioFileAsync(string name)
        {
            var audioFiles = new List<AudioFileDto>();

            foreach (var audioSource in FileFinderServices)
            {
                audioFiles.AddRange(await audioSource.SearchAudioFileAsync(name));
            }

            return audioFiles.ToArray();
        }
    }
}
