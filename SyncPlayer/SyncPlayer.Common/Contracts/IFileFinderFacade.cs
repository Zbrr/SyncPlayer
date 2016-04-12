using System.Collections.Generic;
using System.Threading.Tasks;
using SyncPlayer.Common.DTOs;

namespace SyncPlayer.Common.Contracts
{
    public interface IFileFinderFacade
    {
        IEnumerable<IFileFinderService> FileFinderServices { get; set; }

        Task<AudioFileDto[]> FindAudioFileAsync(string name);
    }
}
