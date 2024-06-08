using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.StatisticAdminDashboard
{
    public class AdminStatisticTotal : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        EducationManager em = new EducationManager(new EFEducationRespository());
        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlog = bm.GetList().Count();
            ViewBag.TotalEducation = em.GetList().Count();
            ViewBag.TotalStudent = wm.GetList().Count();
            ViewBag.TotalEducator = wm.GetList().Count();
            ViewBag.TotalCategory = cm.GetList().Count();
            return View();
        }
    }
}
