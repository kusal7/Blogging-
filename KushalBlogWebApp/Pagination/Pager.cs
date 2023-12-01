using Microsoft.AspNetCore.Mvc;
using KushalBlogWebApp.Models.Pagination;

namespace KushalBlogWebApp.Components.Pagination
{
    public class Pager : ViewComponent
    {
        public Pager()
        {

        }

        public IViewComponentResult Invoke(PagerModel model)
        {
            return View(model);
        }
    }
}
