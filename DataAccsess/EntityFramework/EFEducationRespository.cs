using DataAccsess.Abstract;
using DataAccsess.Concrate;
using DataAccsess.Repository;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.EntityFramework
{
    public class EFEducationRespository : GenericRepository<Education>, IEducationDal
    {
        public EFEducationRespository()
        {

        }

        //public List<Education> GetListWithEduCategory()
        //{
        //    throw new NotImplementedException();
        //}

        public List<Education> GetListWithEduCategory(Education entitiy)
        {
            throw new NotImplementedException();
        }

        public List<Education> GetListWithEduCategoryByWriter(int id)
        {
            using var e = new Context();
            return e.Educations.Include(x => x.Category).Where(x =>x.WriterId == id).ToList();  
        }

        List<Education> IEducationDal.GetListWithEduCategory()
        {
            using var e = new Context();
            return e.Educations.Include(x=>x.Category).ToList();
        }
    }
}
