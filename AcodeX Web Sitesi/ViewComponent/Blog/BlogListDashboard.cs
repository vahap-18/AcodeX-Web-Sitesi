using BussinesLayer.Concrate;
using System;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Blog
{
    public class BlogListDashboard : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
