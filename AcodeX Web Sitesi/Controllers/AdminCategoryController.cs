using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        EducationManager em = new EducationManager(new EFEducationRespository());
        public IActionResult CategoryList(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page, 10);
            return View(values);
        }
        public IActionResult CategoryDelete(int id)
        {
            var values = cm.GetCategoryById(id);
            cm.TDelete(values);
            return RedirectToAction("CategoryList", "AdminCategory");
        }
        [HttpGet]
        public IActionResult CategoryAdd(int id)
        {
            List<SelectListItem> values = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.cv = values;
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            FluentValidation.Results.ValidationResult results = cv.Validate(c);
            if (results.IsValid)
            {
                c.Status = true;
                cm.TAdd(c);
                return RedirectToAction("CategoryList", "AdminCategory");
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
        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var category = cm.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }

            List<SelectListItem> values = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.cv = values;
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            FluentValidation.Results.ValidationResult results = cv.Validate(c);
            if (results.IsValid)
            {
                c.Status = true;
                cm.TUpdate(c);
                return RedirectToAction("CategoryList", "AdminCategory");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            List<SelectListItem> values = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.cv = values;

            return View(c);
        }

    }
}
