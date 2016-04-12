using SyncPlayer.Common.DTOs;

namespace SyncPlayer.Common.Contracts
{
    public interface IFileMappingService<in T>
    {
        AudioFileDto MapToAudioFileDto(T file);
    }
}
