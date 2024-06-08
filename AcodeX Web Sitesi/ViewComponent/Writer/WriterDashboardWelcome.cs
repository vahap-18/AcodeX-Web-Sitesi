using BussinesLayer.Concrate;
using DataAccsess.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class WriterDashboardWelcome : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var name = User.Identity.Name;
            ViewBag.username = name;
            var writerId = c.Writers.Where(x =>x.Email == name).Select(y=>y.WriterId).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            return View(values);
        }
    }
}
