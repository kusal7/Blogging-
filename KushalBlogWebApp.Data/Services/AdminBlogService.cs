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

namespace KushalBlogWebApp.Data.Services
{
    public class AdminBlogService : IAdminBlogService
    {
        private readonly IMapper _mapper;
        public AdminBlogService(IMapper mapper)
        {
            _mapper = mapper;
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
            var p = adminBlogModelVm.PrepareDynamicParameters();
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
    }
}
