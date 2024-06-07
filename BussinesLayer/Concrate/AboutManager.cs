using BussinesLayer.Abstarct;
using DataAccsess.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    public class AboutManager : IAboutServices
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

		public About TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<About> GetList()
        {
           return _aboutDal.GetListAll();
        }

		public void TAdd(About t)
		{
			_aboutDal.Insert(t);
		}

		public void TDelete(About t)
		{
			_aboutDal.Delete(t);
		}

		public void TUpdate(About t)
		{
			_aboutDal.Update(t);
		}

        public List<About> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
    
