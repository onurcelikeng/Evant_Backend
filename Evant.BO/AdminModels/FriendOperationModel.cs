namespace Evant.BO.AdminModels
{
    public sealed class FriendOperationModel : BaseModel
    {
        public string Followed { get; set; }

        public string Follower { get; set; }
    }
}