using BussinesLayer.Concrate;
using DataAccsess.Abstract;
using DataAccsess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AcodeX_Web_Sitesi.ViewComponent.Writer
{
    public class StudentOfWriter : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly WriterManager _writerManager;
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public StudentOfWriter(WriterManager writerManager)
        {
            _writerManager = writerManager;
        }

        public IViewComponentResult Invoke()
        {
            var  LastTenStudent = wm.GetList().Take(10).ToList();
            return View(LastTenStudent);
        }
    }
}
