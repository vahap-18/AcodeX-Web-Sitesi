using BussinesLayer.Concrate;
using DataAccsess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AcodeX_Web_Sitesi.ViewComponent.HomeIndex
{
    public class HomeIndexLastThreeBlog : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly BlogManager _blogManager;

        public HomeIndexLastThreeBlog(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _blogManager.GetList().OrderByDescending(b => b.CreateDate).Take(3).ToList();
            return View(blogs);
        }
    }
}
