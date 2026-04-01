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
    }
}
