using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticAdminDashboard
{
    public class AdminLastFiveBlog : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly BlogManager _blogManager;
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public AdminLastFiveBlog(BlogManager blogManager)
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

