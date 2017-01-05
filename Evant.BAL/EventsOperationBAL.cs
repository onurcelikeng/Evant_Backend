using Evant.BO;
using Evant.BO.Models;
using Evant.DAL;
using System;

namespace Evant.BAL
{
    public sealed class EventsOperationBAL
    {
        private EventsOperationDAL eventOperationDal;


        public EventsOperationBAL()
        {
            eventOperationDal = new EventsOperationDAL();
        }


        public ResultModel EventsOperation(EventOperationModel model)
        {
            return eventOperationDal.EventOperation(model);
        }

        public EventOperationBO GetEventOperationStatistic(int eventId)
        {
            return eventOperationDal.GetEventOperationStatistic(eventId);
        }

        public EventOperationStatusModel EventOperationStatus(int eventId, int personId)
        {
            return eventOperationDal.EventOperationStatus(eventId, personId);
        }
    }
}