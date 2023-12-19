using Microsoft.AspNetCore.Http;
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
        public string ImageUrl { get; set; } = String.Empty;
        public IFormFile? ImageFile { get; set; }
        public bool PinnedStatus { get; set; }
        public List<DynamicField>? DynamicFields { get; set; }


    }

    public class AdminBlogSaveVm : BaseClass
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; } = string.Empty;
        public string BlogBody { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public bool PinnedStatus { get; set; }

    }

    public class DynamicField
    {
        public int BlogId { get; set; }
        public string? BlogHeader { get; set; }
        public string? BlogBody { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
    public class DynamicFieldSaveVm
    {
        public int BlogId { get; set; }
        public string? BlogHeader { get; set; }
        public string? BlogBody { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class AdminBlogModel
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; }
        public string BlogBody { get; set; }
        public bool PinnedStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ImageUrl { get; set; }
    }

    public class AdminBlogGetById
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; }
        public string BlogBody { get; set; }
        public string CreatedBy { get; set; }
    }

   
}
