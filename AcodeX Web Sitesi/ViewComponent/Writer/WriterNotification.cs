using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class WriterNotification : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        NotificationManager nm = new NotificationManager();
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
