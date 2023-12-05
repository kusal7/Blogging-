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
        public async Task<IActionResult> Index()
        {

                ViewBag.LatestPost = await _blogService.GetLatestPost();
                ViewBag.AllBlogList = await _blogService.GetAllData();
                ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();


            //    var blogList = await _blogService.GetAllData();
            //    return View();
            //var pageSize = 4;
            //var currentPage = page ?? 1;

            //var displayedBlogs = await _blogService.GetAllData(pageSize, currentPage);
            //ViewBag.CurrentPage = currentPage;
            //ViewBag.AllBlogList = displayedBlogs;
            //ViewBag.TotalCount = displayedBlogs.Count();

            return View();
        }
        #region Single Blog Details
        [HttpGet]
        public async Task<IActionResult> SingleBlogDetails(int Id)
        {
            var blogDetails = await _blogService.GetSingleBlogDetails(Id);
            return View(blogDetails);
         
        }
        #endregion
    }
}
