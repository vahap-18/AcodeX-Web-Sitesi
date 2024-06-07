using DataAccsess.Abstract;
using DataAccsess.Concrate;
using EntityLayer.Concrate;
using System.Linq.Expressions;

namespace DataAccsess.EntityFramework
{
    public class EFNewsLetterRepository : INewsLetterDal
    {
        public void Delete(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetListAll(Expression<Func<NewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public void Insert(NewsLetter entity)
        {
            using (var context = new Context())
            {
                context.NewsLetters.Add(entity);
                context.SaveChanges();
            }
        }


        public void Update(NewsLetter entity)
        {
            throw new NotImplementedException();
        }
    }
}