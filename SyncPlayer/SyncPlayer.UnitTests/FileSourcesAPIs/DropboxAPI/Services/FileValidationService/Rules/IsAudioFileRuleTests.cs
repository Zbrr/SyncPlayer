using System;
using Dropbox.Api.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncPlayer.Common.Contracts;
using SyncPlayer.DropboxAPI.Services.FileValidationService.Rules;

namespace SyncPlayer.UnitTests.FileSourcesAPIs.DropboxAPI.Services.FileValidationService.Rules
{
    [TestClass]
    public class IsAudioFileRuleTests
    {
        // We cannot moq FileMetadata class properties as they are not virtual and the dropbox api doesn't provide any interface for the class !
        private FileMetadata file;
        private IFileValidationRule<Metadata> validationRule;

        [TestInitialize]
        public void Setup()
        {
            validationRule = new IsAudioFileRule();
        }

        [TestMethod]
        public void IsValidFile_WithValidFile_ReturnTrue()
        {
            const string filePath = "valid.mp3";
            file = new FileMetadata(string.Empty, filePath, DateTime.Now, DateTime.Now, "954604b7b7d3", ulong.MinValue);

            var result = validationRule.IsValidFile(file);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidFile_WithInValidFile_ReturnFalse()
        {
            const string filePath = "invalid";
            file = new FileMetadata(string.Empty, filePath, DateTime.Now, DateTime.Now, "954604b7b7d3", ulong.MinValue);

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidFile_WithNullFile_ReturnFalse()
        {
            file = null;

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidFile_WithEmptyFile_ReturnFalse()
        {
            file = new FileMetadata();

            var result = validationRule.IsValidFile(file);

            Assert.IsFalse(result);
        }
    }
}
