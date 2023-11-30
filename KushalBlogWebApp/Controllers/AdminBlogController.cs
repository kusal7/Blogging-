using KushalBlogWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using KushalBlogWebApp.Common.Helper;
using KushalBlogWebApp.Data.IServices;

namespace KushalBlogWebApp.Controllers
{
    public class AdminBlogController : Controller
    {

        private readonly IAdminBlogService _adminblogservice;
        public AdminBlogController(IAdminBlogService adminBlogService)
        {
            _adminblogservice = adminBlogService;
        }
        #region Index Page
        public async Task<IActionResult> Index()
        {
            var data = await _adminblogservice.GetAllDataAdminBlog();
            if (WebHelper.IsAjaxRequest(Request))
            {
                return PartialView("_AdminBlogIndex", data);
            }
            return View(data);
         
        }
        #endregion

        #region Save Posts
        [HttpGet]
        public IActionResult SavePost()
        {
            return PartialView();
        }
        [HttpPost]
        
        public async Task<IActionResult> SavePost(AdminBlogModelVm adminBlogModelVm)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var responseMessage = await _adminblogservice.SavePost(adminBlogModelVm);
                if (responseMessage.ReturnId > 0)
                {
                  //  _notyfService.Success(responseMessage.Msg);
                    return Ok();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var errors = new List<string> { responseMessage.Msg };
                    ViewBag.Error = errors;
                    return PartialView();
                }
             
            }
        }
        #endregion
    }
}
