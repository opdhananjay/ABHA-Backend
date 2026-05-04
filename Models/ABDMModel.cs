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
        public string? MRNo { get; set; } // Only for update flow

        // From ABDM profile
        public string Patfname { get; set; }
        public string Patlname { get; set; }
        public string Patdob { get; set; }        // YYYYMMDD
        public string Patsex { get; set; }
        public string Patmobile { get; set; }

        // User enters manually
        public string Patemail { get; set; }

        // From ABDM Address
        public string Pataddr1 { get; set; }
        public string Zip { get; set; }

        // User selects from dropdown
        public string Districtid { get; set; }
        public string Regionid { get; set; }
        public string Cityid { get; set; }

        // Default India → frontend no need
        // Keep optional if future international support
        public string? Countryid { get; set; }

        // From ABDM verification
        public string AbhaNumber { get; set; }
        public string AbhaAddress { get; set; }

        // User selects dropdown
        public string Salutation { get; set; }

        // From Aadhaar
        public string IdentityNumber { get; set; }

        // Auto calculated frontend
        public string Patage { get; set; }

        // Logged in user
        public string UserID { get; set; }

        // Optional future fields
        public string? MaritalStatus { get; set; }
        public string? Occupation { get; set; }
        public string? Religion { get; set; }
        public string? BloodGroup { get; set; }

        public int TranMode { get; set; } // 1=new, 2=update
        public string appUnitSelection { get; set; }
    }

}
