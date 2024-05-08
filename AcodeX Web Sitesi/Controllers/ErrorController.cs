using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int code)
        {
            return View();
        }
    }
}
