using DataAccsess.Abstract;
using DataAccsess.Concrate;
using EntityLayer.Concrate;
using System.Linq.Expressions;

namespace DataAccsess.EntityFramework
{
    public class EFWriterRepository : IGenericDal<Writer>, IWriterDal
    {
        public void Delete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetListAll(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public void Insert(Writer t)
        {
            using (var context = new Context()) // Veritabanı bağlantısını oluştur
            {
                // Yazarı ekleyerek değişiklikleri takip et
                context.Writers.Add(t);
                // Değişiklikleri veritabanına kaydet
                context.SaveChanges();
            }
        }

        public void Update(Writer t)
        {
            throw new NotImplementedException();
        }
    }
}
