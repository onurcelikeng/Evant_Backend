using System;

namespace Evant.BO.Models
{
    public sealed class SendNotificationModel
    {
        public int PersonId { get; set; }

        public int SenderId { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}