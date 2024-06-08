using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticWriterDashboard
{
    public class WriterTopBlog : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly BlogManager _blogManager;
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public WriterTopBlog(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var topBlog = bm.GetList().Take(1).ToList();

            return View(topBlog);
        }
    }
}
