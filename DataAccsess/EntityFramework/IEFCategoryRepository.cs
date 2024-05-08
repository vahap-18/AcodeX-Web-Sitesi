using EntityLayer.Concrate;

namespace DataAccsess.EntityFramework
{
    public interface IEFCategoryRepository
    {
        void Delete(Blog t);
        void Delete(Category category);
        Category GetById(int id);
        List<Category> GetListAll();
        void Insert(Blog t);
        void Insert(Category category);
        void Update(Blog t);
        void Update(Category category);
    }
}