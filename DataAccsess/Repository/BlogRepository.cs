using DataAccsess.Abstract;
using DataAccsess.Concrate;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repository
{
    public class BlogRepository : IBlogDal
    {
        public void AddBlog(Blog blog)
        {
            using var c = new Context();
            c.Add(blog);
            c.SaveChanges();
        }

        public List<Blog> BlogListAll()
        {
            using var c = new Context();
            return c.Blogs.ToList();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            using var c = new Context();
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog TGetBlog(int id)
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll()
        {
           throw new NotImplementedException();
        }

        public List<Blog> GetListAll(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null
                    ? context.Set<Blog>().ToList()
                    : context.Set<Blog>().Where(filter).ToList();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategory(Blog entitiy)
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).ToList();
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            using var c = new Context();
            c.Update(blog);
            c.SaveChanges();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
