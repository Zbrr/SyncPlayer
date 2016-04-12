using System.Linq;
using System.Threading.Tasks;
using Dropbox.Api.Files;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Common.DTOs;
using SyncPlayer.DropboxAPI.Contracts;
using SyncPlayer.DropboxAPI.Services.FileValidationService;

namespace SyncPlayer.DropboxAPI.Services
{
    public class DropboxFileFinderService : IFileFinderService
    {
        private readonly IFileValidationService<Metadata> fileValidationService;
        private readonly IDropboxDataStore fileDropboxDataStore;
        private readonly AudioFileDtoBuilder dropboxAudioFileDtoBuilder;

        public DropboxFileFinderService()
        {
            //TODO: Use unity container to initialize services 
            fileValidationService = new DropboxFileValidationService();
            fileDropboxDataStore = new DropboxDataStore();
            dropboxAudioFileDtoBuilder = new DropboxAudioFileDtoBuilder();
        }

        public async Task<AudioFileDto[]> SearchAudioFileAsync(string searchTerm)
        {
            var searchResult = await fileDropboxDataStore.SearchAsync(searchTerm);

            var files = searchResult.Matches.Select(p => p.Metadata).ToArray();

            files = fileValidationService.FilterFiles(files, null);

            var tasks = files.Select(async p => await BuildAndGetAudioFileDto(p)).ToArray();

            await Task.WhenAll(tasks);

            return tasks.Select(p => p.Result).ToArray();
        }

        private async Task<AudioFileDto> BuildAndGetAudioFileDto(Metadata metadata)
        {
            var mediaFile = await fileDropboxDataStore.GetFileUrlForStreamingAsync(metadata.PathLower);

            dropboxAudioFileDtoBuilder.BuildStandardAudioFile();
            dropboxAudioFileDtoBuilder.AddMetadataInformation(metadata);
            dropboxAudioFileDtoBuilder.AddStreamingDetails(mediaFile);

            return dropboxAudioFileDtoBuilder.GetAudioFileDto();
        }
    }
}
