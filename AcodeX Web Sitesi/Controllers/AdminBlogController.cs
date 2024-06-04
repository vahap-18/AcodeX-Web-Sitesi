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

    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        private readonly BlogManager _blogManager;
        public AdminBlogController(BlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public IActionResult BlogList()
        {
            var values = bm.GetList();
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
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogList", "AdminBlog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult BlogDelete(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogList", "AdminBlog");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
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
        public IActionResult BlogUpdate(Blog p)
        {
            p.WriterId = 1;
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        public IActionResult BlogDetail()
        {
            var values = bm.GetList();
            return View(values);
        }
    }
}
