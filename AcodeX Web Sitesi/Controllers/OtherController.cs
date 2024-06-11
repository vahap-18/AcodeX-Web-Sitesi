using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace AcodeX_Web_Sitesi.Controllers
{
    [AllowAnonymous]
    public class OtherController : Controller
    {
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult SiteMap()
        {
            return View();
        }

    }
}
