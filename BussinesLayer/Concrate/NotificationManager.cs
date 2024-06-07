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
    public class NotificationManager : INotificationServices
    {
        INotificationDal _notificationDal;
        public NotificationManager() 
        {

        }
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetListByMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
