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

namespace DataAccsess.EntityFramework
{
    public class EFCommentRepository : BlogManager<Comment>, ICommentDal
    {
        ICommentDal _commentDal;

        public EFCommentRepository()
        {
        }

        public EFCommentRepository(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Delete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment GetById(int id)
        {
           return  _commentDal.GetById(id);
        }

        public List<Comment> GetListAll()
        {
            return _commentDal.GetListAll();
        }


        public List<Comment> GetListAll(Expression<Func<Comment, bool>> filter)
        {
            using (var _context = new Context())
                if (filter != null)
                {
                    return _context.Comments.Where(filter).ToList();
                }
                else
                {
                    return _context.Comments.ToList();
                }
        }

        public void Insert(Comment t)
        {
           _commentDal.Insert(t);
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
