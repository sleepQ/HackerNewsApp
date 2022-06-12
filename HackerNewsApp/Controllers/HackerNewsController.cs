using HackerNewsApp.Interfaces;
using HackerNewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackerNewsApp.Controllers
{
    public class HackerNewsController : Controller
    {
        private readonly IHackerNewsRepository _hackerNewsRepository;

        public HackerNewsController(IHackerNewsRepository hackerNewsRepository)
        {
            _hackerNewsRepository = hackerNewsRepository;
        }

        public async Task<IActionResult> Index(string topic = "", string postStatus = "topstories")
        {
            try
            {
                var posts = await _hackerNewsRepository.GetHackerNews(topic, postStatus);

                return View(posts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Exception ex)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
        }
    }
}
