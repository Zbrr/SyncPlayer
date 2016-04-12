using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Domain.Services;
using SyncPlayer.DropboxAPI.Services;
using System.Collections.Generic;
using SyncPlayer.YoutubeAPI.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SyncPlayer.SPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileFinderFacade service;

        public HomeController(IFileFinderFacade service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var files = await service.FindAudioFileAsync("grasu");

            return View(files);
        }
    }
}
