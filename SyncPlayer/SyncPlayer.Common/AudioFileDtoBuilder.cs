using System;
using SyncPlayer.Common.DTOs;

namespace SyncPlayer.Common
{
    public abstract class AudioFileDtoBuilder
    {
        protected AudioFileDto AudioFileDto;

        public virtual void BuildStandardAudioFile()
        {
            AudioFileDto = new AudioFileDto()
            {
                Guid = new Guid()
            };
        }

        public abstract void AddStreamingDetails<T>(T mediaFile);

        public abstract void AddMetadataInformation<T>(T metadata);

        public virtual AudioFileDto GetAudioFileDto()
        {
            return AudioFileDto;
        }
    }
}
