using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.Controllers
{
    public interface IAdminBlogController
    {
        IActionResult BlogAdd();
        IActionResult BlogAdd(Blog p);
        IActionResult BlogDetail();
        IActionResult BlogList();
        IActionResult BlogUpdate(Blog p);
        IActionResult BlogUpdate(int id);
        IActionResult DeleteBlog(int id);
    }
}