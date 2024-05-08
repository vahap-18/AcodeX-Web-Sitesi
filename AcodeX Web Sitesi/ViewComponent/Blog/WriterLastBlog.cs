using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Blog
{
    public class WriterLastBlog : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        BlogManager bm =new BlogManager (new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogByWriter(1);
            return View(values);
        }
    }
}
