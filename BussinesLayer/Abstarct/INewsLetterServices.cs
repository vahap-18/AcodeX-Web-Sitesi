using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    public interface INewsLetterServices
    {
        void AddNewsLetter(NewsLetter newsLetter);
    }
}
