using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Common.DTOs;

namespace SyncPlayer.YoutubeAPI.Services
{
    public class YoutubeFileFinderService : IFileFinderService
    {
        private readonly YouTubeService youtubeService;
        private readonly AudioFileDtoBuilder youtubeFileDtoBuilder;

        public YoutubeFileFinderService()
        {
            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Config.YoutubeApiKey,
                ApplicationName = Config.ApplicationName
            });

            youtubeFileDtoBuilder = new YoutubeAudioFileDtoBuilder();
        }

        public async Task<AudioFileDto[]> SearchAudioFileAsync(string searchTerm)
        {
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchTerm;
            searchListRequest.Type = Config.SearchType;
            searchListRequest.MaxResults = Config.MaxResults;

            var searchResult = await searchListRequest.ExecuteAsync();

            return searchResult.Items.Select(BuildAndGetAudioFileDto).ToArray();
        }

        private AudioFileDto BuildAndGetAudioFileDto(SearchResult metadata)
        {
            youtubeFileDtoBuilder.BuildStandardAudioFile();
            youtubeFileDtoBuilder.AddMetadataInformation(metadata.Snippet);
            youtubeFileDtoBuilder.AddStreamingDetails(metadata.Id);

            return youtubeFileDtoBuilder.GetAudioFileDto();
        }
    }
}
