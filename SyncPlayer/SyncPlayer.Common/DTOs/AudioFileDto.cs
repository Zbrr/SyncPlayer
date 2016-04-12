using System;
using SyncPlayer.Common.Enums;

namespace SyncPlayer.Common.DTOs
{
    public class AudioFileDto
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime Expires { get; set; }

        public AudioFileSource FileSource { get; set; }
    }
}
