using DataAccsess.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class AdminWelcome : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = c.Admins.Where(x => x.AdminId == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.Surname = c.Admins.Where(x => x.AdminId == 1).Select(y => y.Surname).FirstOrDefault();
            ViewBag.Image = c.Admins.Where(x=>x.AdminId == 1).Select(y=>y.ImageUrl).FirstOrDefault();
            return View();
        }
    }
}
