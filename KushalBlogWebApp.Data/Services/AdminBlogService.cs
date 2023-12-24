using Dapper;
using DBManager;
using KushalBlogWebApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KushalBlogWebApp.Data.IServices;
using System.Security.Claims;
using KushalBlogWebApp.Data.Common.Paging;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using KushalBlogWebApp.Data.Common;
using Microsoft.Extensions.Configuration;

namespace KushalBlogWebApp.Data.Services
{
    public class AdminBlogService : IAdminBlogService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _environment;
        public AdminBlogService(IMapper mapper, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _mapper = mapper;
            _environment = hostingEnvironment;
            _config = configuration;
        }

        public async Task<PagedResponse<AdminBlogModel>> GetAllDataAdminBlog()
        {
            try
            {

                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    var datas = await db.QueryMultipleAsync(sql: "[dbo].[USP_GetAllBlogAdminPanel]", commandType: CommandType.StoredProcedure);

                    var blogLost = await datas.ReadAsync<AdminBlogModel>();
                    var pagedInfo = await datas.ReadFirstAsync<PagedInfo>();
                    var mappeddata = _mapper.Map<PagedResponse<AdminBlogModel>>(pagedInfo);
                    mappeddata.Items = blogLost;
                    return mappeddata;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<SpResponseMessage> SavePost(AdminBlogModelVm adminBlogModelVm)
        {
            string imagePath = "";
            string existingImage = string.Empty;
            if (adminBlogModelVm.Id > 0)
            {
                var result = await GetBlogPostById(adminBlogModelVm.Id);
                existingImage = result.ImageUrl;
            }
            if (adminBlogModelVm.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(existingImage) && existingImage != " ")
                {
                    string imgPath = existingImage.Substring(1);
                    string existingImages = Path.Combine("" + _environment.WebRootPath, imgPath);
                    System.IO.File.Delete(existingImages);
                }

                var folderPath = _config["Folder:BlogImage"];
                imagePath = await FileUploadHandler.UploadFile(_environment, folderPath, adminBlogModelVm.ImageFile);
            }

            var blogModel = new AdminBlogSaveVm()
            {
                Id = adminBlogModelVm.Id,
                BlogBody = adminBlogModelVm.BlogBody,
                BlogHeader = adminBlogModelVm.BlogHeader,
                ImageUrl = adminBlogModelVm.ImageFile != null ? imagePath : existingImage,
                CreatedBy = adminBlogModelVm.CreatedBy,
                UpdatedBy = adminBlogModelVm.UpdatedBy,
                PinnedStatus = adminBlogModelVm.PinnedStatus,
            };




            var p = blogModel.PrepareDynamicParameters();
            if (adminBlogModelVm.Id > 0)
            {
                p.AddMore("Event", "U");
            }

            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    await db.OpenAsync();
                    p.Add("@CreatedDate", DateTime.Now);
                    p.Add("@Return_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@Msg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    p.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@MsgType", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = await db.ExecuteAsync("[dbo].[Usp_IUD_AdminBlog]", param: p, commandType: CommandType.StoredProcedure);
                    var spresponsemessage = new SpResponseMessage
                    {
                        ReturnId = p.Get<int>("@Return_Id"),
                        Msg = p.Get<string>("@Msg"),
                        StatusCode = p.Get<int>("@StatusCode"),
                        MsgType = p.Get<string>("@MsgType")
                    };
                    db.Close();
                    return spresponsemessage;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<AdminBlogModelVm> GetBlogPostById(int Id)
        {
            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    param.Add("@Id", Id);
                    var data = await db.QuerySingleAsync<AdminBlogModelVm>(sql: "[dbo].[usp_GetBlogPostById]", param: param, commandType: CommandType.StoredProcedure);
                    return data;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SpResponseMessage> DeletePost(int Id)
        {
            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var p = new DynamicParameters();
                    await db.OpenAsync();
                    p.Add("@Id", Id);
          
                    p.Add("@Return_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@Msg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    p.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@MsgType", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = await db.ExecuteAsync("[Usp_Delete_AdminBlog]", param: p, commandType: CommandType.StoredProcedure);
                    var spresponsemessage = new SpResponseMessage
                    {
                        ReturnId = p.Get<int>("@Return_Id"),
                        Msg = p.Get<string>("@Msg"),
                        StatusCode = p.Get<int>("@StatusCode"),
                        MsgType = p.Get<string>("@MsgType")
                    };
                    return spresponsemessage;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<SpResponseMessage> UpdatePinnedStatus(AdminBlogModelVm adminBlogModelVm)
        {

            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    param.Add("@Id", adminBlogModelVm.Id);
                    param.Add("@PinnedStatus", adminBlogModelVm.PinnedStatus);
                    param.Add("@Return_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    param.Add("@Msg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    param.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    param.Add("@MsgType", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = await db.ExecuteAsync("[dbo].[USP_UpdatePinnedStatus]", param: param, commandType: CommandType.StoredProcedure);
                    var spresponsemessage = new SpResponseMessage
                    {
                        ReturnId = param.Get<int>("@Return_Id"),
                        Msg = param.Get<string>("@Msg"),
                        StatusCode = param.Get<int>("@StatusCode"),
                        MsgType = param.Get<string>("@MsgType")
                    };
                    return spresponsemessage;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<SpResponseMessage> SaveChildBlog(AddNewChildBlogVm adminBlogModelVm)
        {
            string imagePath = "";
            string existingImage = string.Empty;
            if (adminBlogModelVm.Id > 0)
            {
                var result = await GetBlogPostById(adminBlogModelVm.Id);
                existingImage = result.ImageUrl;
            }
            if (adminBlogModelVm.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(existingImage) && existingImage != " ")
                {
                    string imgPath = existingImage.Substring(1);
                    string existingImages = Path.Combine("" + _environment.WebRootPath, imgPath);
                    System.IO.File.Delete(existingImages);
                }

                var folderPath = _config["Folder:BlogImage"];
                imagePath = await FileUploadHandler.UploadFile(_environment, folderPath, adminBlogModelVm.ImageFile);
            }

            var blogModel = new AddNewChildBlogSaveVm()
            {
                Id = adminBlogModelVm.Id,
                BlogBody = adminBlogModelVm.BlogBody,
                BlogHeader = adminBlogModelVm.BlogHeader,
                ImageUrl = adminBlogModelVm.ImageFile != null ? imagePath : existingImage,
                BlogId = adminBlogModelVm.Id,

            };

            var p = blogModel.PrepareDynamicParameters();
            if (adminBlogModelVm.Id > 0)
            {
                p.AddMore("Event", "U");
            }

            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    await db.OpenAsync();
                    p.Add("@CreatedDate", DateTime.Now);
                    p.Add("@Return_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@Msg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    p.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@MsgType", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = await db.ExecuteAsync("[dbo].[Usp_IUD_AdminChildBlog]", param: p, commandType: CommandType.StoredProcedure);
                    var spresponsemessage = new SpResponseMessage
                    {
                        ReturnId = p.Get<int>("@Return_Id"),
                        Msg = p.Get<string>("@Msg"),
                        StatusCode = p.Get<int>("@StatusCode"),
                        MsgType = p.Get<string>("@MsgType")
                    };
                    db.Close();
                    return spresponsemessage;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<PagedResponse<AdminBlogModel>> GetAllChildBlogDetails(int Id)
        {
            try
            {

                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    param.Add("@Id", Id);
                    var datas = await db.QueryMultipleAsync(sql: "[dbo].[USP_GetAllChildBlogDetails]", commandType: CommandType.StoredProcedure);

                    var blogLost = await datas.ReadAsync<AdminBlogModel>();
                    var pagedInfo = await datas.ReadFirstAsync<PagedInfo>();
                    var mappeddata = _mapper.Map<PagedResponse<AdminBlogModel>>(pagedInfo);
                    mappeddata.Items = blogLost;
                    return mappeddata;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
