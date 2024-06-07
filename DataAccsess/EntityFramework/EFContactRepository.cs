using DataAccsess.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.EntityFramework
{
    public class EFContactRepository : BlogManager<Contact>, IContactDal
    {
        public void Delete(Contact t)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetListAll(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public void Insert(Contact t)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
