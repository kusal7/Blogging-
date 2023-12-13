using AspNetCoreHero.ToastNotification.Abstractions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using KushalBlogWebApp.Common.Helper;
using KushalBlogWebApp.Data.IServices;
using KushalBlogWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KushalBlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly INotyfService _notyfService;
        public HomeController(IBlogService blogService, INotyfService notyfService)
        {
            _blogService = blogService;
            _notyfService = notyfService;
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
            ViewBag.Id = Id;
            ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
            ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
            ViewBag.AllBlogComments = await _blogService.GetBlogComments(Id);
            var blogDetails = await _blogService.GetSingleBlogDetails(Id);
            var commentsData = await _blogService.GetBlogComments(Id);

            if (WebHelper.IsAjaxRequest(Request))
            {
                return PartialView("_BlogComments", commentsData);
            }
            return View(blogDetails);      
        }
        #endregion


        #region Save Comment
        [HttpPost]
        public async Task<IActionResult> SaveComment(SaveBlogComment saveBlogComment)
        {
            ViewBag.Id = saveBlogComment.Id;
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = new List<string> { "Full Name/Email and Comment is required!!" };
                ViewBag.Error = errors;
                var blogDetails = await _blogService.GetSingleBlogDetails(saveBlogComment.Id);
                ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
                return View("SingleBlogDetails", blogDetails);
            }
            else
            {
                var (responseMessage, data) = await _blogService.SaveBlogComment(saveBlogComment);
               
                if (responseMessage.ReturnId > 0)
                {
                   
                    _notyfService.Success(responseMessage.Msg);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var errors = new List<string> { responseMessage.Msg };
                    ViewBag.Error = errors;
                    return View($"SingleBlogDetails");
                }
            }
        }
        #endregion

    }
}
