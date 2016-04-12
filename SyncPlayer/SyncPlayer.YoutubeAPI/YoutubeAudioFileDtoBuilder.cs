using System;
using Google.Apis.YouTube.v3.Data;
using SyncPlayer.Common;
using SyncPlayer.Common.Enums;

namespace SyncPlayer.YoutubeAPI
{
    public class YoutubeAudioFileDtoBuilder : AudioFileDtoBuilder
    {
        public override void AddStreamingDetails<T>(T mediaFile)
        {
            var data = mediaFile as ResourceId;

            if (data == null)
            {
                return;
            }

            AudioFileDto.Url = string.Format(Config.YoutubeVideoUrl, data.VideoId);
            AudioFileDto.Expires = DateTime.MaxValue;
        }

        public override void AddMetadataInformation<T>(T metadata)
        {
            AudioFileDto.FileSource = AudioFileSource.Youtube;

            var data = metadata as SearchResultSnippet;

            if (data == null)
            {
                return;
            }

            AudioFileDto.Title = data.Title;
            AudioFileDto.Description = data.Description;
        }
    }
}
