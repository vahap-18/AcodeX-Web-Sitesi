using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    public interface IEducationServices : IGenericServices<Education>
    {
        List<Education> GetEducationListWithCategory();

        List<Education> GetEducationByWriter(int id);
    }
}
