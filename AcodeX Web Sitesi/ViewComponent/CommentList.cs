using AcodeX_Web_Sitesi.Models;
using Microsoft.AspNetCore.Mvc;


namespace AcodeX_Web_Sitesi.ViewComponent
{
    public class CommentList : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName = "Vahap"
                },
                new UserComment
                {
                    Id = 2,
                    UserName = "Saba"
                },
                new UserComment
                {
                    Id = 3,
                    UserName = "Doğan"
                }
            };

            return View("Default", commentValues);
        }
    }
}
