using DataAccsess.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AcodeX_Web_Sitesi.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Dashboard()
        {
            Context c = new Context();
			var username = User.Identity.Name;
			var email = c.Users.Where(x=> x.UserName == username).Select(c => c.Email).FirstOrDefault();
			var writerId = c.Writers.Where(x => x.Email == email).Select(y =>y.WriterId).FirstOrDefault();

            return View();
		}

		public IActionResult AnalysisPanel()
		{

			return View();
		}

	}
}
