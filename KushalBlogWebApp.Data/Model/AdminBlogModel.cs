﻿using System;
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
    }

    public class AdminBlogGetById
    {
        public int Id { get; set; }
        public string BlogHeader { get; set; }
        public string BlogBody { get; set; }
        public string CreatedBy { get; set; }
    }

   
}
