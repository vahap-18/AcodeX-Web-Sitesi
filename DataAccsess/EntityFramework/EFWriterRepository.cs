using DataAccsess.Abstract;
using DataAccsess.Concrate;
using DataAccsess.Repository;
using EntityLayer.Concrate;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace DataAccsess.EntityFramework
{
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public EFWriterRepository()
        {
        }
    }
}
