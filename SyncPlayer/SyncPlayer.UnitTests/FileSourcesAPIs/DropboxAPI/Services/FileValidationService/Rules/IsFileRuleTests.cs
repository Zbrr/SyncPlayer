using Dropbox.Api.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncPlayer.Common.Contracts;
using SyncPlayer.DropboxAPI.Services.FileValidationService.Rules;

namespace SyncPlayer.UnitTests.FileSourcesAPIs.DropboxAPI.Services.FileValidationService.Rules
{
    [TestClass]
    public class IsFileRuleTests
    {
        // We cannot moq FileMetadata class properties as they are not virtual and the dropbox api doesn't provide any interface for the class !
        private Metadata file;
        private IFileValidationRule<Metadata> validationRule;

        [TestInitialize]
        public void Setup()
        {
            validationRule = new IsFileRule();
        }

        [TestMethod]
        public void IsValidFile_WithNullFile_ReturnFalse()
        {
            file = null;

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidFile_WithMetadataFile_ReturnFalse()
        {
            file = new Metadata();

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidFile_WithFileMetadataFile_ReturnTrue()
        {
            file = new FileMetadata();

            var result = validationRule.IsValidFile(file);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidFile_WithFolderMetadataFile_ReturnFalse()
        {
            file = new FolderMetadata();

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }
    }
}
