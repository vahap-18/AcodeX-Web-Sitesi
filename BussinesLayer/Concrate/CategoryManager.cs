using BussinesLayer.Abstarct;
using DataAccsess.Abstract;
using EntityLayer.Concrate;
using System.Collections.Generic;

namespace BussinesLayer.Concrate
{
    public class CategoryManager : ICategoryServices
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
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.GetListAll(x => x.CategoryId == id).FirstOrDefault();
        }
        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }
        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }
        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}