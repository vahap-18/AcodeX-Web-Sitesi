using BussinesLayer.Abstarct;
using DataAccsess.Abstract;
using EntityLayer.Concrate;
using System.Collections.Generic;

namespace BussinesLayer.Concrate
{
    public class CategoryManager : ICategoryServices, ICategoryManager
    {
        ICategoryDal _categoryDal;
        private object value;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public CategoryManager(object value)
        {
            this.value = value;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
    }

    internal interface ICategoryManager
    {
    }
}
