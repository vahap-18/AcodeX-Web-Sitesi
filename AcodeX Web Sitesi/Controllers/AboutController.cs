using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());

        public AboutController(AboutManager abm)
        {
            this.abm = abm;
        }

        public IActionResult BizKimiz()
        {
            return View();
        }
        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
        public IActionResult GeriBildirimAdmin()
        {
            return View();
        }
    }
}
