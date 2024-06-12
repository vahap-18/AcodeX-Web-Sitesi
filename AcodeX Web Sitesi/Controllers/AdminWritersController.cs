using AcodeX_Web_Sitesi.Models;
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.Abstract;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminWritersController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        private readonly WriterManager _writerManager;

        public AdminWritersController(WriterManager writerManager)
        {
            _writerManager = writerManager;
        }

        public IActionResult WritersProfilView(int id)
        {
            var writer = _writerManager.GetWriterById(id);
            var values = new List<Writer> { writer };
            return View(values);
        }
        public IActionResult WriterList(int wp = 1)
        {
            var values = wm.GetList().ToPagedList(wp, 10);
            return View(values);
        }

        public IActionResult WriterAboutDashboard(int id)
        {
            var writer = wm.GetListWriterById(1);
            return View(writer);
        }
        [HttpGet]
        public IActionResult WriterUpdate(int id)
        {
            var writerValue = wm.TGetById(id);
            List<SelectListItem> CategoryValues = (from x in wm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.WriterId.ToString()
                                                   }).ToList();
            ViewBag.cv = CategoryValues;
            return View(writerValue);
        }

        [HttpPost]
        public IActionResult WriterUpdate(Writer updatedWriter)
        {
            Writer existingWriter = wm.GetWriterById(updatedWriter.WriterId);
            updatedWriter.Password = existingWriter.Password;
            updatedWriter.Image = existingWriter.Image;
            updatedWriter.About = existingWriter.About;
            updatedWriter.Adress = existingWriter.Adress;
            updatedWriter.Tweeter = existingWriter.Tweeter;
            wm.TUpdate(updatedWriter);
            return RedirectToAction("WriterList", "AdminWriters");
        }


        public IActionResult WriterDelete(int id)
        {
            var values = wm.GetWriterById(id);
            wm.TDelete(values);
            return RedirectToAction("WriterList");
        }

        [HttpGet]
        public IActionResult WriterAdd(int id)
        {
            List<SelectListItem> genderValues = new List<SelectListItem>
    {
        new SelectListItem { Text = "Erkek", Value = "1" },
        new SelectListItem { Text = "Kadın", Value = "0" },
    };

            ViewBag.Sex = genderValues;

            return View();
        }



        [HttpPost]
        public IActionResult WriterAdd(Writer w)
        {
            WriterValidator wv = new WriterValidator();
            FluentValidation.Results.ValidationResult results = wv.Validate(w);
            if (results.IsValid)
            {
                w.Status = true;
                wm.TAdd(w);
                return RedirectToAction("WriterList", "AdminWriters");
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
    }
}
