using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticWriterDashboard
{
    public class WriterTopFiveEducation : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly EducationManager _educationManager;
        EducationManager em = new EducationManager(new EFEducationRespository());
        public WriterTopFiveEducation(EducationManager educationManager)
        {
            _educationManager = educationManager;
        }

        public IViewComponentResult Invoke()
        {
            var lastFiveEducation = em.GetList().Take(5).ToList();

            return View(lastFiveEducation);
        }
    }
}
