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

    public class ABHASuggestion
    {
        public string txnId { get; set; }
    }

    public class CreateABHA
    {
        public string txnId { get; set; }
        public string abhaAddress { get; set; }
    }

    public class AbhaAddress
    { 
        public string abhaAddress { get; set; }
    }

    public class AbhaOTPVerification
    {
        public string otp { get; set; }
        public string txnId { get; set; }
    }

    public class ValidateAbhaByPhone
    {
        public string phoneNumber { get; set; }
    }

    public class GetAbha
    {
        public string abhaNumber { get; set; }
        public string transactionId { get; set; }
    }

}
