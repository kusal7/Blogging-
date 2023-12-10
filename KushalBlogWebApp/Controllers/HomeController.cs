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
            return View();
        }
        #region Single Blog Details
        [HttpGet]
        public async Task<IActionResult> SingleBlogDetails(int Id)
        {
            ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
            var blogDetails = await _blogService.GetSingleBlogDetails(Id);
            return View(blogDetails);
         
        }
        #endregion
    }
}
