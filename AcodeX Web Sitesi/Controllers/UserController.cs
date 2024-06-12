
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class UserController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        private readonly WriterManager _writerManager;

        public UserController(WriterManager writerManager)
        {
            _writerManager = writerManager;
        }

        public IActionResult UserProfil(int id)
        {
            var writer = wm.GetListWriterById(1);
            return View(writer);
        }

        public IActionResult UserProfilView(int id)
        {
            var writer = _writerManager.GetWriterById(id);
            var values = new List<Writer> { writer };
            return View(values);
        }

        [HttpPost]
        public IActionResult UserProfilUpdate(Writer p)
        {
            WriterValidator wl = new WriterValidator();
            FluentValidation.Results.ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                if (results.IsValid)
                {
                    return RedirectToAction("UserProfil", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Güncelleme işlemi sırasında bir hata oluştu.");
                    return View(p);
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(p);
            }
        }


    }
}
