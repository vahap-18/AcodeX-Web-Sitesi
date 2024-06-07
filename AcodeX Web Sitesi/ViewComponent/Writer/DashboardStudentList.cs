using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class DashboardStudentList : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            var writer = wm.GetList();
            return View(writer);
        }
    }
}
