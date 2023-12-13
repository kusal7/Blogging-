using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class SaveBlogComment
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Full Name or Email is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Comments is Required")]
        public string Comment { get; set; }
    }
    public class BlogsComment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string BlogComment { get; set; }
        public DateTime CreatedDate { get;set; }
    }

}
