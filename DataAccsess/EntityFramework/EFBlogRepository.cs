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
        public EFBlogRepository()
        {
        }

        public List<Writer> GetListAll()
        {
            using var context = new Context();
            return context.Writers.ToList();
        }

        public List<Blog> GetListWithCategory(Blog entitiy)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).Where(x =>x.WriterId == id).ToList();
        }

        //List<Blog> GetListWithCategory()
        //{
        //    using var c = new Context();
        //    return c.Blogs.Include(x => x.Category).ToList();
        //}

        List<Blog> IBlogDal.GetListWithCategory()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).ToList();
        }
    }
}
