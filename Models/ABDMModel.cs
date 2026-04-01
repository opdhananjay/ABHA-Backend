using System.Runtime.CompilerServices;

namespace ABDM.Models
{
    public class ABDMModel
    {
        
    }

    public class RegisterAadhaar
    {
        public string aadharNumber { get; set; }
    }

    public class ValidateOTP
    {
        public string otp { get; set; }
        public string txnId { get; set; }
        public string mobile { get; set; }
    }

    public class ResendOTPAadhaar
    {
        public string txnId { get; set; }
        public string aadharNumber { get; set; }
    }

    public class VerifyPhone
    {
        public string txnId { get; set; }
        public string phoneNumber { get; set; }

    }
}
