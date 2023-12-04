using DocumentFormat.OpenXml.InkML;
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
        public async Task<IActionResult> Index(int? page)
        {

                ViewBag.LatestPost = await _blogService.GetLatestPost();


            ////    var blogList = await _blogService.GetAllData();
            //    return View();
            var pageSize = 4;
            var currentPage = page ?? 1;

            var displayedBlogs = await _blogService.GetAllData(pageSize, currentPage);
            ViewBag.CurrentPage = currentPage;
            ViewBag.AllBlogList = displayedBlogs;
            ViewBag.TotalCount = displayedBlogs.Count();

            return View();
        }
    }
}
