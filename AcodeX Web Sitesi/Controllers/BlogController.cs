using BussinesLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AcodeX_Web_Sitesi.Controllers
{
    
    public class BlogController : Controller
    {
        
        private readonly BlogManager _blogManager;

        public BlogController(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            var blog = _blogManager.GetBlogById(id);
            var values = new List<Blog> { blog };
            return View(values);
        }
    
    }
}
