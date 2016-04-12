using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncPlayer.Common.Contracts;
using SyncPlayer.DropboxAPI.Services;

namespace SyncPlayer.UnitTests.FileSourcesAPIs.DropboxAPI.Services
{
    [TestClass]
    public class DropboxFileFinderServiceTests
    {
        private IFileFinderService fileFinderService;

        [TestInitialize]
        public void Setup()
        {
            fileFinderService = new DropboxFileFinderService();
        }

        [TestMethod]
        public void SearchAsync_WithValidSearchTerm_ShouldReturnFile()
        {
            const string searchTerm = "racla";

            var files = fileFinderService.SearchAudioFileAsync(searchTerm).Result;

            var result = files.All(p => p.Title.ToLower().Contains(searchTerm));

            Assert.IsTrue(result);
        }
    }
}
