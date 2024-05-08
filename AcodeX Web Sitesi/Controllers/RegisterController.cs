using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
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
            p.Status = true;
            p.About = "Kullanıcı hakkında bilgilerin yer aldığı bölüm.";
            p.Image = "Profil";
            wm.WriterAdd(p);
            return RedirectToAction("Index", "Blog");
        }

    }
}
