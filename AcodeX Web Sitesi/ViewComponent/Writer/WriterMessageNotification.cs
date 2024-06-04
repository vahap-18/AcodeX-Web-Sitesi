using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class WriterMessageNotification : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
