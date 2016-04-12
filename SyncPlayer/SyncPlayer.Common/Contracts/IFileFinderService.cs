using System.Threading.Tasks;
using SyncPlayer.Common.DTOs;

namespace SyncPlayer.Common.Contracts
{
    public interface IFileFinderService
    {
        Task<AudioFileDto[]> SearchAudioFileAsync(string searchTerm);
    }
}
