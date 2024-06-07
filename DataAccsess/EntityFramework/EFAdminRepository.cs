using DataAccsess.Abstract;
using DataAccsess.Repository;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.EntityFramework
{
    public class EFAdminRepository : GenericRepository<Admin>, IAdminDal
    {
    }
}
