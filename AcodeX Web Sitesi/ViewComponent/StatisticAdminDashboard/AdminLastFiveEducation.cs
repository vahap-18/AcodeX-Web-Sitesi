using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticAdminDashboard
{
    public class AdminLastFiveEducation : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        EducationManager em = new EducationManager(new EFEducationRespository());
        public IViewComponentResult Invoke()
        {
            var education = em.GetList();
            return View(education);
        }
    }
}
