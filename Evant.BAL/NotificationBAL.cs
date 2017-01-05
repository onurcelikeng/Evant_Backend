using Evant.BO;
using Evant.BO.Models;
using Evant.DAL;
using System;
using System.Collections.Generic;

namespace Evant.BAL
{
    public sealed class NotificationBAL
    {
        private NotificationDAL notificationDal;


        public NotificationBAL()
        {
            notificationDal = new NotificationDAL();
        }


        public List<NotificationBO> GetAllNotifications(int personId)
        {
            return notificationDal.GetAllNotifications(personId);
        }
    }
}