using BussinesLayer.Abstarct;
using DataAccsess.Abstract;
using DataAccsess.Migrations;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    public class EducationManager : IEducationServices
    {
        IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public EducationManager()
        {
        }

        public List<Education> GetEducationByWriter(int id)
        {
            return _educationDal.GetListAll(x => x.WriterId == id);
        }

        public List<Education> GetEducationListWithCategory(int id)
        {
            return _educationDal.GetListWithEduCategoryByWriter(1);
        }

        public List<Education> GetList()
        {
            return _educationDal.GetListAll();
        }

        public void TAdd(Education t)
        {
            _educationDal.Insert(t);
        }

        public void TDelete(Education t)
        {
            _educationDal.Delete(t);
        }
        public Education GetEducationById(int id)
        {
            return _educationDal.GetListAll(x => x.EducationId == id).FirstOrDefault();
        }

        public Education TGetById(int id)
        {
            return _educationDal.GetById(id);
        }

        public void TUpdate(Education t)
        {
            _educationDal.Update(t);
        }

        public List<Education> GetEducationListWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}