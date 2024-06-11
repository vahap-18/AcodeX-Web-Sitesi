 using BussinesLayer.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {

        CommentManager cm = new CommentManager(new EFCommentRepository());

        public CommentController(CommentManager cm)
        {
            this.cm = cm;
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

        public IActionResult GeriBildirimYazar()
        {
            return View();
        }
    }
}
