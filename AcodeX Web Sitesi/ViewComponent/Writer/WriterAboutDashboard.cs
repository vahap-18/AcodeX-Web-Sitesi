using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class WriterAboutDashboard : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke(int id)
        {
            var writer = wm.GetListWriterById(id);
            return View(writer);
        }
    }
}
