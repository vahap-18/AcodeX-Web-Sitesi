using DataAccsess.Abstract;
using DataAccsess.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repository
{

    //Bir sınıfın içinde miras alınıyorsa ilgili sınıftan implement edilmelidir.
    //ICategoryDal sınıfından implement aldığımız için bileşenler implement edildi.

    public class CategoryRepository : ICategoryDal
    {
        // Veritabanındaki tablolar Context sınıfında olduğu için Context sınıfından c adında bir nesne ürettik ve c nesnesi üzerinden işlemler yapılacak.

        Context c = new Context();
        public void AddCategory(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetListAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> ListAllCategory()
        {
            //ListAllCategory metodu void olmadığı geriye değer döndürmek zorunda o yüzden return ile kullanıldı.
            return c.Categories.ToList();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}
