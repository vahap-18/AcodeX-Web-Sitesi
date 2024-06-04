using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstarct
{
    public interface IBlogServices : IGenericServices<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        
        List<Blog> GetBlogByWriter(int id);
    }
}
