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
    internal class WriterRepository : IWriterDal
    {
        public void Delete(Writer entity)
        {
           using (var context =new Context())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public Writer GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Writers.FirstOrDefault(x => x.WriterId == id);
            }
        }


        public List<Writer> GetListAll()
        {
            using (var context = new Context())
            {
                return context.Writers.ToList();
            }
        }

        public List<Writer> GetListAll(Expression<Func<Writer, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Writers.Where(filter).ToList();
            }
        }

        public List<Blog> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public void Insert(Writer t)
        {
            using (var context = new Context())
            {
                context.Writers.Add(t);
                context.SaveChanges();
            }
        }
       
        public void Update(Writer entity)
        {
           using (var context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
