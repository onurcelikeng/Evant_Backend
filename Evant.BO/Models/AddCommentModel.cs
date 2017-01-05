namespace Evant.BO.Models
{
    public class AddCommentModel
    {
        public int EventId { get; set; }

        public int PersonId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}