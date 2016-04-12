using Dropbox.Api.Files;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Common.Enums;

namespace SyncPlayer.DropboxAPI.Services.FileValidationService.Rules
{
    public class IsAudioFileRule : IFileValidationRule<Metadata>
    {
        private static readonly string Mp3Extension = string.Format(".{0}", AudioFileFormat.Mp3).ToLower();

        public bool IsValidFile(Metadata file, ValidationData validationData = null)
        {
            if (file == null || file.PathLower == null)
            {
                return false;
            }

            return file.PathLower.ToLower().Contains(Mp3Extension);
        }
    }
}
