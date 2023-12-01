using Microsoft.AspNetCore.Mvc;
using KushalBlogWebApp.Models.Pagination;

namespace KushalBlogWebApp.Components.Pagination
{
    public class SortOrderViewComponent : ViewComponent
    {
        public SortOrderViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortOrderModel sortOrderModel)
        {
            return View(sortOrderModel);
        }
    }
}
