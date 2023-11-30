using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.Model
{
    public class AdminBlogModelVm : BaseClass
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; } = string.Empty;
        public string BlogBody { get; set; } = string.Empty;

    }
}
