using KushalBlogWebApp.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.Model
{
    public class AdminBlogFilterDto : PagedRequest
    {
        public string BlogHeader { get; set; } 
        public string BlogBody { get; set; } 
        public string WrittenBy { get; set; } 
    }
}
