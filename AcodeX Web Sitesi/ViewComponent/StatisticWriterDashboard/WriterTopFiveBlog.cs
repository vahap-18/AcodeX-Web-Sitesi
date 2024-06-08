using BussinesLayer.Concrate;
using DataAccsess.Abstract;
using DataAccsess.EntityFramework;
using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticWriterDashboard
{
    public class WriterTopFiveBlog : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly BlogManager _blogManager;
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public WriterTopFiveBlog(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var lastFiveBlogs = bm.GetList().Take(5).ToList();

            return View(lastFiveBlogs);
        }
    }
}
