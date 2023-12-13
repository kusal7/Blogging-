using Dapper;
using KushalBlogWebApp.Data.IServices;
using KushalBlogWebApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DBManager;
using System.Text.RegularExpressions;
using KushalBlogWebApp.Data.Common;

namespace KushalBlogWebApp.Data.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _map;
        public BlogService( IMapper map)
        {
            _map = map;
        }
        public async Task<IEnumerable<BlogModel>> GetAllData()
        {
            try
            {
               
               
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    var datas = await db.QueryMultipleAsync(sql: "[dbo].[USP_GetAllBlog]",param:param, commandType: CommandType.StoredProcedure);
                    var blogList = await datas.ReadAsync<BlogModel>();
                    var mappeddata = _map.Map<IEnumerable<BlogModel>>(blogList);
                    return mappeddata;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BlogModel> GetLatestPost()
        {
            try
            {

                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    
                    await db.OpenAsync();
                    var datas = await db.QuerySingleOrDefaultAsync<BlogModel>(sql: "[dbo].[usp_GetLatestBlog]",  commandType: CommandType.StoredProcedure);
                    return datas;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SingleBlogModel> GetSingleBlogDetails(int Id)
        {
            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    param.Add("@Id", Id);
                    var data = await db.QuerySingleAsync<SingleBlogModel>(sql: "[dbo].[USP_GetSingleBlogDetailsById]", param: param, commandType: CommandType.StoredProcedure);
                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<BlogModel>> GetAllPinnedBlogList()
        {
            try
            {


                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    var datas = await db.QueryMultipleAsync(sql: "[dbo].[USP_GetAllPinnedBlogPost]", param: param, commandType: CommandType.StoredProcedure);
                    var blogList = await datas.ReadAsync<BlogModel>();
                    var mappeddata = _map.Map<IEnumerable<BlogModel>>(blogList);
                    return mappeddata;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<(SpResponseMessage, IEnumerable<BlogsComment>)> SaveBlogComment(SaveBlogComment  saveBlogComment)
        {
            var p = new DynamicParameters();
     

            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    await db.OpenAsync();
                    p.Add("@BlogId", saveBlogComment.Id);
                    p.Add("@Username", saveBlogComment.FullName);
                    p.Add("@BlogComment", saveBlogComment.Comment);
                    p.Add("@Return_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@Msg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    p.Add("@StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@MsgType", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = await db.QueryMultipleAsync("[dbo].[Usp_I_BlogComment]", param: p, commandType: CommandType.StoredProcedure);
                    var blogComments = await result.ReadAsync<BlogsComment>();
                    var mappeddata = _map.Map<IEnumerable<BlogsComment>>(blogComments);
                    var spresponsemessage = new SpResponseMessage
                    {
                        ReturnId = p.Get<int>("@Return_Id"),
                        Msg = p.Get<string>("@Msg"),
                        StatusCode = p.Get<int>("@StatusCode"),
                        MsgType = p.Get<string>("@MsgType")
                    };
                    db.Close();
                    return (spresponsemessage, mappeddata);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<BlogsComment>> GetBlogComments(int Id)
        {
            try
            {
                var dbfactory = DbFactoryProvider.GetFactory();
                using (var db = (DbConnection)dbfactory.GetConnection())
                {
                    var param = new DynamicParameters();
                    await db.OpenAsync();
                    param.Add("@Id", Id);
                    var datas = await db.QueryMultipleAsync(sql: "[dbo].[USP_GetBlogsComment]", param: param, commandType: CommandType.StoredProcedure);
                    var blogList = await datas.ReadAsync<BlogsComment>();
                    var mappeddata = _map.Map<IEnumerable<BlogsComment>>(blogList);
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
