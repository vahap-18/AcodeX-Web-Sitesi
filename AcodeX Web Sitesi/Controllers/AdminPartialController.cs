using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class AdminPartialController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminRightMenuPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterBlogsTables()
        {
            var values = wm.GetList();
            return PartialView(values);
        }

        public PartialViewResult WritersEducationsTables()
        {
            return PartialView();
        }
        public PartialViewResult CategoriesTables()
        {
            var values = cm.GetList();
            return PartialView(values);
        }
    }
}
