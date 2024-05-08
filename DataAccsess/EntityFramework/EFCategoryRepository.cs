using DataAccsess.Abstract;
using DataAccsess.Repository;
using EntityLayer.Concrate;
using System.Collections.Generic;

namespace DataAccsess.EntityFramework
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        // ICategoryDal arayüzündeki yöntemleri Category türü üzerinde uygula
        public void Delete(Category t)
        {
            base.Delete(t);
        }

        public void Insert(Category t)
        {
            base.Insert(t);
        }

        public void Update(Category t)
        {
            base.Update(t);
        }

        public Category GetById(int id)
        {
            return base.GetById(id);
        }

        public List<Category> GetListAll()
        {
            return base.GetListAll();
        }
    }
}
