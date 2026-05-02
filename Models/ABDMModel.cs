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

    public class SavePatientRequest
    {
        public string? MRNo { get; set; }

        public string Patfname { get; set; }
        public string Patlname { get; set; }
        public string Patdob { get; set; }
        public string Patsex { get; set; }
        public string Patmobile { get; set; }
        public string Patemail { get; set; }

        public string Pataddr1 { get; set; }
        public string Districtid { get; set; }
        public string Regionid { get; set; }
        public string Cityid { get; set; }
        public string Countryid { get; set; }
        public string Zip { get; set; }

        public string AbhaNumber { get; set; }
        public string AbhaAddress { get; set; }

        public string Salutation { get; set; }
        public string IdentityCode { get; set; }
        public string IdentityNumber { get; set; }
        public string UserID { get; set; }
        public string Patage { get; set; }

        public int TranMode { get; set; } //1=new, 2=update
    }

}
