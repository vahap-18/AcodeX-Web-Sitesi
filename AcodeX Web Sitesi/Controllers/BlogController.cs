using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AcodeX_Web_Sitesi.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
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
            var values = new List<Blog> {blog };
            return View(values);
        }
        public IActionResult BlogListByWriter(int id)
        {
            var values = bm.GetListWithCategoryByWriterBM(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p, IFormFile Image)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImage", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    p.Image = "/WriterImage/" + fileName;
                }

                p.Status = true;
                p.CreateDate = DateTime.Now;
                p.WriterId = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {   
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterId = 1;
            p.CreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

        public IActionResult WriterBlogDetail()
        { var values = bm.GetList();
            return View(values);
        }
    }
}
