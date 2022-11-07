namespace WebApi.ViewModels
{
    public class RequestForgotPassword
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string FullName { get; set; }
    }
}
