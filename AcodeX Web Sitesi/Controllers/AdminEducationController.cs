using BussinesLayer.Abstarct;
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminEducationController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        EducationManager em = new EducationManager(new EFEducationRespository());
        private readonly EducationManager _educationManager;

        public AdminEducationController(EducationManager educationManager)
        {
            _educationManager = educationManager;
        }

        public IActionResult EducationList(int ep = 1)
        {
            var values = em.GetList().ToPagedList(ep, 10);
            return View(values);
        }
        public IActionResult EducationDelete(int id)
        {
            var values = em.GetEducationById(id);
            em.TDelete(values);
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public IActionResult EducationUpdate(int id)
        {
            List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;
            Education education = em.GetEducationById(id);
            return View(education);
        }

        [HttpPost]
        public IActionResult EducationUpdate(Education e)
        {
            e.WriterId = 1;
            e.Status = true;
            em.TUpdate(e);
            return RedirectToAction("EducationList", "AdminEducation");

        }

        [HttpGet]
        public IActionResult EducationAdd(int id)
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
        public IActionResult EducationAdd(Education e)
        {
            EducationValidator ev = new EducationValidator();
            FluentValidation.Results.ValidationResult results = ev.Validate(e);
            if (results.IsValid)
            {
                e.WriterId = 1;
                e.Status = true;
                em.TAdd(e);
                return RedirectToAction("EducationList", "AdminEducation");
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
        public IActionResult EducationDetail(int id)
        {
            var education = _educationManager.GetEducationById(id);
            var values = new List<Education> { education };
            return View(values);
        }
    }
}
