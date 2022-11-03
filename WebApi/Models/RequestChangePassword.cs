namespace WebApi.Models
{
    public class RequestChangePassword
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

    }
}
