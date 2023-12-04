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
    }
}
