using System;

namespace Evant.BO
{
    public sealed class CommentBO : BaseBO
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}