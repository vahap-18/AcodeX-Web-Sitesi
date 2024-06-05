using BussinesLayer.Abstarct;
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using System.Collections.Generic;
using System.Linq;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminEducationController : Controller
    {
        EducationManager em = new EducationManager(new EFEducationRespository());
        private readonly CategoryManager _categoryManager;
        private readonly EducationManager _educationManager;

        public AdminEducationController(CategoryManager categoryManager, EducationManager educationManager)
        {
            _categoryManager = categoryManager;
            _educationManager = educationManager;
        }

        public IActionResult EducationList(int ep = 1)
        {
            var values = _educationManager.GetList().ToPagedList(ep, 10);
            return View(values);
        }

        public IActionResult EducationDelete(int id)
        {
            var education = _educationManager.GetEducationById(id);
            _educationManager.TDelete(education);
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public IActionResult EducationUpdate(int id)
        {
            var categories = _categoryManager.GetList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.Categories = categories;

            var education = _educationManager.GetEducationById(id);
            return View(education);
        }

        [HttpPost]
        public IActionResult EducationUpdate(Education education)
        {
            education.Status = true;
            _educationManager.TUpdate(education);
            return RedirectToAction("EducationList", "AdminEducation");
        }

        [HttpGet]
        public IActionResult EducationAdd()
        {
            var categories = _categoryManager.GetList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult EducationAdd(Education education)
        {
            EducationValidator wv = new EducationValidator();
            FluentValidation.Results.ValidationResult results = wv.Validate(education);
            if (results.IsValid)
            {
                education.Status = true;
                em.TAdd(education);
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
