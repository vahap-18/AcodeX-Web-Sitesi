using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticWriterDashboard
{
    public class WriterTopEducation : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        
          private readonly EducationManager _educationManager;
        EducationManager em = new EducationManager(new EFEducationRespository());
        public WriterTopEducation(EducationManager educationManager)
        {
            _educationManager = educationManager;
        }

        public IViewComponentResult Invoke()
        {
            var topBlog = em.GetList().Take(1).ToList();

            return View(topBlog);
        }
    }
}
