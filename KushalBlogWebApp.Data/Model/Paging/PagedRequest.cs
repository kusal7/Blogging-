namespace KushalBlogWebApp.Common.Paging
{
    /// <summary>
    /// The paged request.
    /// </summary>
    public class PagedRequest
    {
        protected int MaxPageSize = 500;
        protected int DefaultPageSize = 20;

        private int _pageSize;
        private int _pageNumber;
        private string _searchVal = string.Empty;
        private string _SortType = "ASC";
        private string _SortingCol = string.Empty;

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public virtual int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? DefaultPageSize : Math.Min(Math.Max(value, 1), MaxPageSize);
        }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public virtual int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = Math.Max(value, 1);
        }

        /// <summary>
        /// Gets or sets the search val.
        /// </summary>
        public virtual string SearchVal
        {
            get => _searchVal;
            set => _searchVal = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        /// <summary>
        /// Gets or sets the sorting col.
        /// </summary>
        public virtual string SortingCol
        {
            get => _SortingCol;
            set => _SortingCol = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        /// <summary>
        /// Gets or sets the sort type.
        /// </summary>
        public virtual string SortType
        {
            get => _SortType;
            set => _SortType = value is not null && value.Equals("DESC", StringComparison.InvariantCultureIgnoreCase)
                ? "DESC"
                : "ASC";
        }
    }
}
