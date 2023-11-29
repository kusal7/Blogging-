using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushalBlogWebApp.Data.Model
{
    public class PagedResponse<T> : PagedInfo
    {
        private IEnumerable<T> _items = new List<T>();

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<T> Items
        {
            get => _items;
            set => _items = value ?? new List<T>();
        }
    }
}
