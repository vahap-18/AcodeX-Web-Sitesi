using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace AcodeX_Web_Sitesi.ViewComponent.HomeIndex
{
    public class HomeLastThreeEducation : Microsoft.AspNetCore.Mvc.ViewComponent 
    {
        private readonly EducationManager _educationManager;

        public HomeLastThreeEducation(EducationManager educationManager)
        {
            _educationManager = educationManager;
        }

        public IViewComponentResult Invoke()
        {
            var educations = _educationManager.GetList().OrderByDescending(b => b.CreateDate).Take(3).ToList();
            return View(educations);
        }
    }
}
