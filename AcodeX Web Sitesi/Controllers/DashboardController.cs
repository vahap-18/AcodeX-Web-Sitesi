using DataAccsess.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AcodeX_Web_Sitesi.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Dashboard()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Where(x =>x.WriterId ==1).Count();
            return View();
		}

		public IActionResult AnalysisPanel()
		{

			return View();
		}

	}
}
