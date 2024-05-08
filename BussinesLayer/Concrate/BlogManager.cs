﻿using BussinesLayer.Abstarct;
using DataAccsess.Abstract;
using EntityLayer.Concrate;

namespace BussinesLayer.Concrate
{
    public class BlogManager : IBlogServices
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
           _blogDal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);

        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
        public Blog GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id).FirstOrDefault();

        }
     
        public List<Blog> GetListAll()
        {
           return _blogDal.GetListAll();
        }

        public List<Blog> GetLastTreeBlog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
    }
}
