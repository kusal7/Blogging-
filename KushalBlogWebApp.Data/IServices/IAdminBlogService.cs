using KushalBlogWebApp.Data.Common.Paging;
using KushalBlogWebApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.IServices
{
    public interface IAdminBlogService
    {
        public Task<PagedResponse<AdminBlogModel>> GetAllDataAdminBlog();
        public Task<SpResponseMessage> SavePost(AdminBlogModelVm adminBlogModelVm);
        public Task<AdminBlogModelVm> GetBlogPostById(int Id);
        public Task<SpResponseMessage> DeletePost(int Id);
        public Task<SpResponseMessage> UpdatePinnedStatus(AdminBlogModelVm adminBlogModelVm);
        public Task<SpResponseMessage> SaveChildBlog(AddNewChildBlogVm adminBlogModelVm);
        public Task<PagedResponse<AdminBlogModel>> GetAllChildBlogDetails(int Id);
        public Task<AddNewChildBlogVm> GetChildBlogById(int Id);
    }
}
