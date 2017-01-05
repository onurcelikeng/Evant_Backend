namespace Evant.BO
{
    public sealed class UserBO : BaseBO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}