using DataAccsess.Concrate;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Abstract
{
    //Bloglar ile ilgili CRUD (create, read, update, delete) işlemlerinin gerçekleştiği Interface.
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategory(Blog entitiy);
    }
}
