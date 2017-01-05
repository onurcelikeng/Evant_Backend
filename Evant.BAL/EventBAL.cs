using Evant.BO;
using Evant.BO.AdminModels;
using Evant.BO.Models;
using Evant.DAL;
using System.Collections.Generic;

namespace Evant.BAL
{
    public sealed class EventBAL
    {
        private EventDAL eventDal;


        public EventBAL()
        {
            eventDal = new EventDAL();
        }


        public List<EventBO> GetAllEvents(string category)
        {
            return eventDal.GetAllEvents(category);
        }

        public List<EventBO> GetUserEvents(int userId)
        {
            return eventDal.GetUserEvents(userId);
        }

        public List<EventBO> GetEventSearch(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return eventDal.GetEventSearch(input);
            }

            else
            {
                return null;
            }
        }

        public List<EventBO> GetNewestEvents()
        {
            return eventDal.GetNewestEvents();
        }

        public EventBO GetEventDetail(int eventId)
        {
            return eventDal.GetEventDetail(eventId);
        }

        public ResultModel AddEvent(AddEventModel model)
        {
            if (!string.IsNullOrEmpty(model.City) &&
                !string.IsNullOrEmpty(model.Description) &&
                !string.IsNullOrEmpty(model.Name) &&
                !string.IsNullOrEmpty(model.StartDate.ToString()))
            {
                return eventDal.AddEvent(model);
            }

            else
            {
                return new ResultModel()
                {
                    IsSuccess = false,
                    Message = "Do not leave empty spaces"
                };
            }
        }

        public ResultModel RemoveEvent(int eventId)
        {
            return eventDal.RemoveEvent(eventId);
        }

        public List<EventModel> Admin_GetAllEvents()
        {
            return eventDal.Admin_GetAllEvents();
        }

        public void Admin_DeleteEvent(int eventId)
        {
            eventDal.Admin_DeleteEvent(eventId);
        }

        public ResultModel Admin_EventUpdate(EventUpdateModel model)
        {
            if (!string.IsNullOrEmpty(model.Name) &&
                !string.IsNullOrEmpty(model.City) &&
                !string.IsNullOrEmpty(model.StartDate.ToString()) &&
                !string.IsNullOrEmpty(model.Description))
            {
                return eventDal.Admin_EventUpdate(model);
            }

            else
            {
                return new ResultModel()
                {
                    IsSuccess = false,
                    Message = "Do not leave empty spaces"
                };
            }
        }

        public EventModel Admin_EventUpdateDetails(int eventId)
        {
            return eventDal.Admin_EventUpdateDetails(eventId);
        }
    }
}