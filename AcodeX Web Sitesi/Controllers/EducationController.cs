using BussinesLayer.Abstarct;
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EducationController : Controller
{
    EducationManager em = new EducationManager(new EFEducationRespository());
    CategoryManager cm = new CategoryManager(new EFCategoryRepository());
    private readonly EducationManager _educationManager;
    private readonly CategoryManager _categoryManager;
    private readonly WriterManager _writerManager;

    public EducationController(EducationManager educationManager, CategoryManager categoryManager, WriterManager writerManager)
    {
        _educationManager = educationManager;
        _categoryManager = categoryManager;
        _writerManager = writerManager;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var education = _educationManager.GetList();
        return View(education);
    }

    public PartialViewResult EducationLeftNavbar()
    {
        return new PartialViewResult();
    }

    public string GetWriterName(int id)
    {
        var writer = _writerManager.GetWriterById(id);
        return writer != null ? writer.Name : "Unknown";
    }
    [AllowAnonymous]
    public IActionResult EducationDetails(int id)
    {
        var education = _educationManager.GetEducationById(id);
        var values = new List<Education> { education };
        return View(values);
    }

    public IActionResult EducationListByWriter(int id)
    {
        var values = em.GetEducationListWithCategory(id);
        return View(values);
    }
    public IActionResult EducationDelete(int id) { 
    var value = em.TGetById(id);
        em.TDelete(value);
        return RedirectToAction("EducatiionListEriter");
    }
    [HttpGet]
    public ActionResult EducationEdit( int id)
    {
        var eduValue = em.TGetById(id);
        List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
        ViewBag.cav = CategoryValues;

        return View(eduValue);
    }

    [HttpPost]
    public IActionResult EducationEdit(Education e)
    {
        e.WriterId = 1;
        e.Status = true;
        em.TUpdate(e);
        return RedirectToAction("EducationListByWriter");
    }
    [HttpGet]
    public IActionResult EducationAdd(int id)
    {
        List<SelectListItem> cv = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
        ViewBag.cv = cv;
        return View();
    }

    [HttpPost]
    public IActionResult EducationAdd(Education e)
    {
        EducationValidator ev = new EducationValidator();
        FluentValidation.Results.ValidationResult results = ev.Validate(e);
        if (results.IsValid)
        {
            e.Status = true;
            em.TAdd(e);
            return RedirectToAction("EducationListByWriter", "Education");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
}
