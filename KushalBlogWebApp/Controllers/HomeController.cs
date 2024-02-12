using AspNetCoreHero.ToastNotification.Abstractions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using KushalBlogWebApp.Common.Helper;
using KushalBlogWebApp.Data.IServices;
using KushalBlogWebApp.Data.Model;
using KushalBlogWebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AdminLoginPage(string returnUrl = "/Home/AdminLoginPage")
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/AdminBlog/Index");
            }
            return View(new AdminLoginVm { ReturnUrl = returnUrl });

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLoginPage(AdminLoginVm adminLoginVm, string returnUrl)
        {
            var (data, responseMessage) = await _blogService.GetAdminUserUsernamePassword(adminLoginVm);
            if (responseMessage.StatusCode != 200)
            {
                ViewBag.Error = responseMessage.Msg;
                return View();
            }
 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,data.Id.ToString()),
                new Claim(ClaimTypes.Name,data.Username),
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principle,
                new AuthenticationProperties { IsPersistent = adminLoginVm.Rememberme, RedirectUri = returnUrl });

            if (returnUrl != "/Home/AdminLoginPage")
            {
                return LocalRedirect(returnUrl);
            }
            return LocalRedirect("~/AdminBlog/Index");


        }

        #region Index
        public async Task<IActionResult> Index()
        {

                ViewBag.LatestPost = await _blogService.GetLatestPost();
                ViewBag.AllBlogList = await _blogService.GetAllData();
                ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
            return View();
        }
        #endregion
        #region Single Blog Details
        [HttpGet]
        public async Task<IActionResult> SingleBlogDetails(int Id)
        {
            ViewBag.Id = Id;
            ViewBag.AllPinnedBlogList = await _blogService.GetAllPinnedBlogList();
            ViewBag.AllBlogComments = await _blogService.GetBlogComments(Id);
            ViewBag.AllChildBlogs = await _blogService.GetChildBlogsData(Id);
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
