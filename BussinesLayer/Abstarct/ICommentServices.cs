using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    public interface ICommentServices
    {
        void CommentAdd(Comment comment);
       // void CommentDelete(Comment comment);
       // void CommentUpdate(Comment comment);
        List<Comment> GetList(int id);
       // Comment GetCommentById(int id);
    }
}
