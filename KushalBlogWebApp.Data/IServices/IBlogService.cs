using KushalBlogWebApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.IServices
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogModel>> GetAllData();
        public Task<BlogModel> GetLatestPost();
        public Task<SingleBlogModel> GetSingleBlogDetails(int Id);
        public Task<IEnumerable<BlogModel>> GetAllPinnedBlogList();
        //public Task<SpResponseMessage> SaveBlogComment(SaveBlogComment saveBlogComment);
        public  Task<(SpResponseMessage, IEnumerable<BlogsComment>)> SaveBlogComment(SaveBlogComment saveBlogComment);
        public Task<IEnumerable<BlogsComment>> GetBlogComments(int Id);
        public Task<IEnumerable<AddNewChildBlogSaveVm>> GetChildBlogsData(int Id);

    }
}
