using Microsoft.AspNetCore.Mvc;
using KushalBlogWebApp.Models.Pagination;

namespace KushalBlogWebApp.Components.Pagination
{
    public class PaginationSummary : ViewComponent
    {
        public PaginationSummary()
        {

        }
        public IViewComponentResult Invoke(PaginationSummaryModel model)
        {
            return View(model);
        }

    }
}
