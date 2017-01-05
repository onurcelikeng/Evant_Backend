
namespace Evant.BO.Models
{
    public sealed class EventOperationModel 
    {
        public int EventId { get; set; }

        public int PersonId { get; set; }

        public bool IsGoing { get; set; }

        public bool IsInterested { get; set; }
    }
}