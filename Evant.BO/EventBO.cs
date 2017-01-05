namespace Evant.BO
{
    public sealed class EventBO : BaseBO
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string EventName { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string Category { get; set; }
    }
}