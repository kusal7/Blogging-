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

    }
}
