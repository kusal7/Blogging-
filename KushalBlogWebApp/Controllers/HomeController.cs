using KushalBlogWebApp.Data.IServices;
using Microsoft.AspNetCore.Mvc;

namespace KushalBlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var blogList = await _blogService.GetAllData();
            return View();
        }
    }
}
