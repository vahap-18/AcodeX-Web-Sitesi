using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract
{
    //Kategoriler için CRUD (create, read, update, delete) işlemlerinin yapıldığı yer.
    // CRUD işlemlerinde her işlem için ayrı bir metot yazılır.
    public interface ICategoryDal : BlogManager<Category>
    {
        void Delete(Category category);
        void Insert(Category category);
    }
}
