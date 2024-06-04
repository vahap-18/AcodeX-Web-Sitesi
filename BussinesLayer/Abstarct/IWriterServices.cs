using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    public interface IWriterServices : IGenericServices<Writer>
    {
        List<Writer> GetWriterById(int id);
        List<Writer> GetListWriterById(int id);
    }
}
