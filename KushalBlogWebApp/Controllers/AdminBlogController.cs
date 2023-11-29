using KushalBlogWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KushalBlogWebApp.Controllers
{
    public class AdminBlogController : Controller
    {
        #region Index Page
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Save Posts
        [HttpGet]
        public IActionResult SavePost()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SavePost(BlogModel blogModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                //var responseMessage = await _amountTypeService.Save(amounttype);
                //if (responseMessage.ReturnId > 0) 
                //{
                //    _notyfService.Success(responseMessage.Msg);
                //    return Ok();
                //}
                //else
                //{
                //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    var errors = new List<string> { responseMessage.Msg };
                //    ViewBag.Error = errors;
                //    return PartialView();
                //}
                return Ok();
            }
        }
        #endregion
    }
}
