namespace Evant.BO.AdminModels
{
    public sealed class CommentModel : BaseModel
    {
        public string EventName { get; set; }

        public string PersonName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Date { get; set; }
    }
}