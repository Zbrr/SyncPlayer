using Dropbox.Api.Files;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;

namespace SyncPlayer.DropboxAPI.Services.FileValidationService.Rules
{
    public class IsFileRule : IFileValidationRule<Metadata>
    {
        public bool IsValidFile(Metadata file, ValidationData validationData)
        {
            if (file == null)
            {
                return false;
            }

            return file.IsFile;
        }
    }
}
