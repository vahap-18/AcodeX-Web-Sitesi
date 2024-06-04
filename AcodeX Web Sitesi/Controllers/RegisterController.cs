using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        //Ekleme işlemi yapılırken httpGet ve httpPost attributeleri tanımlandığında metotların isimleri aynı olmak zorundadır.

        //Sayfa yüklenince çalışan metot
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //Buton tetiklenince çalışan metot
        [HttpPost]


        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.About = "Kullanıcı hakkında bilgilerin yer aldığı bölüm.";
               // p.Image = "Profil";
                wm.TUpdate(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
