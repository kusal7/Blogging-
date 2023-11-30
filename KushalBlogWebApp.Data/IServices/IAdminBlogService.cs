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
        public Task<IEnumerable<BlogModel>> GetAllDataAdminBlog();
        public Task<SpResponseMessage> SavePost(AdminBlogModelVm adminBlogModelVm);
    }
}
