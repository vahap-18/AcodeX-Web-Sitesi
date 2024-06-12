using AcodeX_Web_Sitesi.Models;
using BussinesLayer.Concrate;
using BussinesLayer.ValidationRules;
using DataAccsess.Concrate;
using DataAccsess.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace AcodeX_Web_Sitesi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewData["v"] = usermail;

            using (var c = new Context())
            {
                var userName = c.Writers
                    .Where(x => x.Email == usermail)
                    .Select(y => y.Name)
                    .FirstOrDefault();

                ViewData["v2"] = userName;
            }

            return View();
        }
        public IActionResult Profil(int id)
        {
            var writer = wm.GetListWriterById(1);
            if (writer == null)
            {
                
                return NotFound("Yazar bulunamadı.");
            }
            return View(writer);
        }

        public IActionResult Message()
        {
            return View();
        }
        public PartialViewResult WriterNavBar()
        {
            return new PartialViewResult();
        }
        public PartialViewResult WriterHeader()
        {
            return new PartialViewResult();
        }
        public PartialViewResult WriterRightMenu()
        {
            return new PartialViewResult();
        }
        public IActionResult WriterNotification()
        {
            Context _context = new Context();
            var notifications = _context.Notifications.ToList();
            return View(notifications);
        }

        [HttpGet]
        public IActionResult WriterProfilSettings(int id)
        {
            var values = wm.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterProfilSettings(Writer p)
        {
            WriterValidator wl = new WriterValidator();
            FluentValidation.Results.ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Profil", "Writer");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(p);
            }
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer
            {
                Name = p.Name,
                Surname = p.Surname,
                Adress = p.Adress,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                Password = p.Password,
                Status = p.Status,
                Youtube = p.Youtube,
                Country = p.Country,
                Facebook = p.Facebook,
                Instagram = p.Instagram,
                LinkedIn = p.LinkedIn,
                Sex = p.Sex ?? true,
                About = p.About,
                FieldOfInterest = p.FieldOfInterest,
                GitHub = p.GitHub,
                KnowTeknologies = p.KnowTeknologies,
                ProgrammingLanguages = p.ProgrammingLanguages,
                Tweeter = p.Tweeter,
                Website = p.Website
            };

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImage/", newImage);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    p.Image.CopyTo(stream);
                }
                w.Image = newImage;
            }

            wm.TAdd(w);
            return RedirectToAction("Profil", "Writer");
        }


    }
}
