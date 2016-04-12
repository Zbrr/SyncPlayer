using Dropbox.Api.Files;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;

namespace SyncPlayer.DropboxAPI.Services.FileValidationService.Rules
{
    public class IsNotDeletedRule : IFileValidationRule<Metadata>
    {
        public bool IsValidFile(Metadata file, ValidationData validationData = null)
        {
            if (file == null)
            {
                return false;
            }

            return !file.IsDeleted;
        }
    }
}
