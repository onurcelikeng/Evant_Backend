namespace Evant.BO.AdminModels
{
    public sealed class EventModel : BaseModel
    {
        public string EventName { get; set; }

        public string City { get; set; }

        public string CreateDate { get; set; }

        public string StartDate { get; set; }

        public string Category { get; set; }

        public string PersonName { get; set; }

        public string Description { get; set; }
    }
}