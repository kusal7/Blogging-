namespace KushalBlogWebApp.Data.Common.Paging
{
    /// <summary>
    /// The paged info.
    /// </summary>
    public class PagedInfo
    {
        private string _sortBy = string.Empty;
        private string _sortOrder = string.Empty;

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the filtered count.
        /// </summary>
        public int FilteredCount { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Gets or sets the showingfrom.
        /// </summary>
        public int Showingfrom { get; set; }
        /// <summary>
        /// Gets or sets the showing to.
        /// </summary>
        public int ShowingTo { get; set; }


        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
       // public virtual string SortBy

        public virtual string SortingCol

        {
            get => _sortBy;
            set => _sortBy = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
       // public virtual string SortOrder

        public virtual string SortType

        {
            get => _sortOrder;
            set => _sortOrder = value is not null && value.Equals("DESC", StringComparison.InvariantCultureIgnoreCase)
                ? "DESC"
                : "ASC";
        }
    }
}
