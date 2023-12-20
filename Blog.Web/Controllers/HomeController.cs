using Blog.Web.Models;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostsRepository _blogPostsRepository;

        public HomeController(ILogger<HomeController> logger, IBlogPostsRepository blogPostsRepository)
        {
            _logger = logger;
            _blogPostsRepository = blogPostsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts = await _blogPostsRepository.GetAllAsync();
            return View(blogPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
