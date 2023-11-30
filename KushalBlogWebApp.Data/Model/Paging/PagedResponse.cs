namespace KushalBlogWebApp.Data.Common.Paging
{
    /// <summary>
    /// The paged response.
    /// </summary>
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
