using ABDM.Helpers;
using ABDM.Models;

namespace ABDM.ExternalServices
{
    public interface IAadhaarServices
    {
        Task<ApiResponse<object>> RegisterbyAadhaarService(RegisterAadhaar registerAadhaar);
        Task<ApiResponse<object>> ValidateOTPService(ValidateOTP validateOTP);
        Task<ApiResponse<object>> ResendOTPService(ResendOTPAadhaar resendOTPAadhaar);
        Task<ApiResponse<object>> VerifyPhoneService(VerifyPhone verifyPhone);
        Task<ApiResponse<object>> ValidatePhoneOTPService(ValidateOTP validateOTP);
        Task<ApiResponse<object>> GetAbhaSuggestionsService(ABHASuggestion ABHASuggestion);
        Task<ApiResponse<object>> CreateABHAIDService(CreateABHA createABHA);
        Task<ApiResponse<object>> ValidateAbhaByAadhar(AbhaAddress abhaAddress);
        Task<ApiResponse<object>> ValidateAbhaByAadharOTP(AbhaOTPVerification abhaAddressOTP);
        Task<ApiResponse<object>> ValidateAbhaByPhone(ValidateAbhaByPhone validateAbhaByPhone);
        Task<ApiResponse<object>> ValidateAbhaByPhoneOtp(AbhaOTPVerification AbhaOTPVerification);
        Task<ApiResponse<object>> SearchAbhaByAddress(AbhaAddress abhaAddress);
        Task<ApiResponse<object>> GetAbhaProfile(GetAbha getAbha);
        Task<ApiResponse<object>> GetAbhaCard(GetAbha getAbha);
        Task<ApiResponse<object>> GetPatient(string searchText);
    }
}
