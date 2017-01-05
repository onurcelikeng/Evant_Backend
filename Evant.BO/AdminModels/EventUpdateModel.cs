using System;

namespace Evant.BO.AdminModels
{
    public sealed class EventUpdateModel : BaseModel
    {
        public string Name { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}