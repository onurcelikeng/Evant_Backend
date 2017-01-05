namespace Evant.BO.Models
{
    public class ChangePasswordModel
    {
        public int PersonId { get; set; }

        public string NewPassword { get; set; }

        public string ReNewPassword { get; set; }

        public string OldPassword { get; set; }
    }
}