using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    // Bussines katmanındaki Abstract klasöründeki interfaceler Service olarak adlandırılır.
    public interface ICategoryServices : IGenericServices<Category>
    {
        
    }
}
