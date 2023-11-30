using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.Model
{
    public class BaseClass
    {

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public string Event { get; set; } = "I";
    }
}
