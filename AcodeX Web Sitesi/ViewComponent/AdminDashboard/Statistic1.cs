using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.AdminDashboard
{
    public class Static1 : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
