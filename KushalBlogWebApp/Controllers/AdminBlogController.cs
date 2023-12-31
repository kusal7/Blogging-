﻿using KushalBlogWebApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using KushalBlogWebApp.Common.Helper;
using KushalBlogWebApp.Data.IServices;
using AspNetCoreHero.ToastNotification.Abstractions;
using KushalBlogWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace KushalBlogWebApp.Controllers
{
    public class AdminBlogController : Controller
    {

        private readonly IAdminBlogService _adminblogservice;
        private readonly INotyfService _notyfService;
        public AdminBlogController(IAdminBlogService adminBlogService, INotyfService notyfService)
        {
            _adminblogservice = adminBlogService;
            _notyfService = notyfService;
        }
        #region Index Page
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AdminBlogFilterDto adminBlogFilterDto)
        {
            var data = await _adminblogservice.GetAllDataAdminBlog(adminBlogFilterDto);
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
                    _notyfService.Success(responseMessage.Msg);
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


        #region Update Post
        [HttpGet]
        public async Task<IActionResult> EditPost(int Id)
        {
            var data = await _adminblogservice.GetBlogPostById(Id);
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(AdminBlogModelVm adminBlogModelVm)
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
                    _notyfService.Success(responseMessage.Msg);
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

        #region Delete Post
        [HttpGet]
        public IActionResult DeletePost(int Id)
        {
            ViewBag.Id = Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(AdminBlogModelVm adminBlogModelVm)
        {

            var responseMessage = await _adminblogservice.DeletePost(adminBlogModelVm.Id);
            if (responseMessage.ReturnId > 0)
            {
                _notyfService.Success(responseMessage.Msg);
                return Ok();
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = new List<string> { responseMessage.Msg };
            ViewBag.Error = errors;
            return PartialView();
        }
        #endregion

        #region Update Status
        [HttpPost]
        public async Task<IActionResult> UpdatePinnedStatus(AdminBlogModelVm adminBlogModel)
        {
            var responseMessage = await _adminblogservice.UpdatePinnedStatus(adminBlogModel);
            if (responseMessage.ReturnId > 0)
            {
                _notyfService.Success(responseMessage.Msg);
                return Ok();
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = new List<string> { responseMessage.Msg };
            ViewBag.Error = errors;
            return PartialView();
        }
        #endregion

        #region Add New Child Blog

        [HttpGet]
        public IActionResult AddNewChildBlog(int Id)
        {
            ViewBag.BlogsId = Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewChlidBlog(AddNewChildBlogVm adminBlogModelVm)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var responseMessage = await _adminblogservice.SaveChildBlog(adminBlogModelVm);
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
                    return PartialView();
                }

            }
        }

        #endregion

        #region Edit Child Blog
        [HttpGet]
        public async Task<IActionResult> EditChildBlog(int Id)
        {
            var data = await _adminblogservice.GetChildBlogById(Id);
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditChildBlog(AddNewChildBlogVm adminBlogModelVm)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView();
            }
            else
            {
                var responseMessage = await _adminblogservice.SaveChildBlog(adminBlogModelVm);
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
                    return PartialView();
                }

            }
        }
        #endregion

        #region Delete Child Blog
        [HttpGet]
        public IActionResult DeleteChildBlog(int Id)
        {
            ViewBag.Id = Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteChildBlog(AddNewChildBlogVm adminBlogModelVm)
        {

            var responseMessage = await _adminblogservice.DeleteChildBlogPost(adminBlogModelVm.Id);
            if (responseMessage.ReturnId > 0)
            {
                _notyfService.Success(responseMessage.Msg);
                return Ok();
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = new List<string> { responseMessage.Msg };
            ViewBag.Error = errors;
            return PartialView();
        }
        #endregion

        #region Blog Child Listing
        [HttpGet]
        public async Task<IActionResult> ChildBlogIndex(int Id)
        {
            var data = await _adminblogservice.GetAllChildBlogDetails(Id);
            if (WebHelper.IsAjaxRequest(Request))
            {
                return PartialView("_NewChildBlogIndex", data);
            }
            return View(data);
        }
        #endregion
    }
}
