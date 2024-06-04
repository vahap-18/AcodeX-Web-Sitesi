using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract
{
    public interface IEducationDal : BlogManager<Education>
    {
        List<Education> GetListWithEduCategory();
        List<Education> GetListWithEduCategory(Education entitiy);
        List<Education> GetListWithEduCategoryByWriter(int id);
    }
}
