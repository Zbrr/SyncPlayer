using Dropbox.Api.Files;
using SyncPlayer.Common;
using SyncPlayer.Common.Contracts;

namespace SyncPlayer.DropboxAPI.Services.FileValidationService.Rules
{
    public class IsSearchedFileRule : IFileValidationRule<Metadata>
    {
        public bool IsValidFile(Metadata file, ValidationData validationData = null)
        {
            if (file == null || file.Name == null)
            {
                return false;
            }

            return validationData == null || file.Name.Contains(validationData.SearchTerm);
        }
    }
}
