using Microsoft.AspNetCore.Mvc;
using KushalBlogWebApp.Models.Pagination;

namespace KushalBlogWebApp.Components.Pagination
{
    public class SortByViewComponent : ViewComponent
    {
        public SortByViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortByModel model)
        {
            return View(model);
        }
    }
}
