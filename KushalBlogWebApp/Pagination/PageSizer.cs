using Microsoft.AspNetCore.Mvc;
using KushalBlogWebApp.Models.Pagination;

namespace KushalBlogWebApp.Components.Pagination
{
    public class PageSizer : ViewComponent
    {
        public PageSizer()
        {
        }

        public IViewComponentResult Invoke(PageSizeDdl model)
        {
            return View(model);
        }

    }
}
