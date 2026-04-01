namespace ABDM.Models
{
    public class AuthModels
    {
    }

    public class LoginModel
    {
        public string username { get; set; }  
        public string password { get; set; }
        public string? IpAddress { get; set; } = "ABDMWEBAPI";
    }

}
