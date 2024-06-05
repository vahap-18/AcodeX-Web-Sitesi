using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        EducationManager em = new EducationManager(new EFEducationRespository());
        public IActionResult AnalysisPanel()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
