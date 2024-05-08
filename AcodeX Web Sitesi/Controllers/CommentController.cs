using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class CommentController : Controller
    {

        CommentManager cm = new CommentManager(new EFCommentRepository());

        public CommentController(CommentManager cm)
        {
            this.cm = cm;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            p.BlogId = '2';
            cm.CommentAdd(p);
            return PartialView();
        }

        public IActionResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }

        public IActionResult GeriBildirimYazar()
        {
            return View();
        }
    }
}
