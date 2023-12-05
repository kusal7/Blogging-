using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.Model
{
    public class BlogModel 
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; }
        public string BlogBody { get; set; }
        public bool PinnedStatus { get; set; }

        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
    public class SingleBlogModel
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; }
        public string BlogBody { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

}
