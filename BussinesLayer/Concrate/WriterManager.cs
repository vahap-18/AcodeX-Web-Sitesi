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
    public class WriterManager : IWriterServices
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }


        public List<Writer> GetList()
        {
            return _writerdal.GetListAll();
        }

        public List<Writer> GetListWriterById(int id)
        { 
            return _writerdal.GetListAll(x => x.WriterId == id);
        }

        public Writer GetWriterById(int id)
        {
            return _writerdal.GetListAll(x => x.WriterId == id).FirstOrDefault();
        }


        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            _writerdal.Delete(t);
        }

        public void TDelete(List<Writer> values)
        {
            foreach (var writer in values)
            {
                _writerdal.Delete(writer);
            }
        }

        public Writer TGetById(int id)
        {
            return _writerdal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        public void TUpdate(Education e)
        {
            throw new NotImplementedException();
        }

        List<Writer> IWriterServices.GetWriterById(int id)
        {
            throw new NotImplementedException();
        }
    }
}