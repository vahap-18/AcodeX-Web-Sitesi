using BussinesLayer.Abstarct;
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

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);

        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(1);
        }

        public Blog TGetById(int id)
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

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
    }
}
