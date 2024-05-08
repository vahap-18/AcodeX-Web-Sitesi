using DataAccsess.Abstract;
using DataAccsess.Concrate;
using DataAccsess.Repository;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory(Blog entitiy)
        {
            throw new NotImplementedException();
        }

        List<Blog> GetListWithCategory()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).ToList();
        }

        List<Blog> IBlogDal.GetListWithCategory()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).ToList();
        }
    }
}
