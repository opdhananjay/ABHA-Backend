using ABDM.ExternalServices;
using ABDM.Helpers;
using ABDM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ABDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ABDMController : ControllerBase
    {
        public readonly IAadhaarServices _aadhaarServices;
        public ABDMController(IAadhaarServices aadhaarServices)
        {
            _aadhaarServices = aadhaarServices;
        }

        // Registration  
        [HttpPost("RegisterAadhaar")]
        public async Task<IActionResult> RegistrationAadhaar(RegisterAadhaar registerAadhaar)
        {
            if (string.IsNullOrEmpty(registerAadhaar.aadharNumber))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Aadhaar number is required."));
            }

            if(!Regex.IsMatch(registerAadhaar.aadharNumber, @"^\d{12}$"))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Aadhaar number must be exactly 12 digits. "));
            }

            var response = await _aadhaarServices.RegisterbyAadhaarService(registerAadhaar);

            return StatusCode(response.StatusCode, response);
        }

        // Validate OTP for Aadhaar 
        [HttpPost("ValidateAadhaarOTP")]
        public async Task<IActionResult> ValidateOTP(ValidateOTP validateOTP)
        {
            if(string.IsNullOrEmpty(validateOTP.otp) || string.IsNullOrEmpty(validateOTP.txnId) || string.IsNullOrEmpty(validateOTP.mobile))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "One or more required fields have invalid or missing values."));
            }

            var response = await _aadhaarServices.ValidateOTPService(validateOTP);

            return StatusCode(response.StatusCode, response);
        }

        // Resent OTP 
        [HttpPost("ResentOTPAadhaar")]
        public async Task<IActionResult> ResentOTPAadhaarVerification(ResendOTPAadhaar resendOTPAadhaar)
        {
            if (string.IsNullOrEmpty(resendOTPAadhaar.aadharNumber))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "aadhaar number is missing"));
            }

            if (string.IsNullOrEmpty(resendOTPAadhaar.txnId))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "transaction id is missing"));
            }

            var response = await _aadhaarServices.ResendOTPService(resendOTPAadhaar);

            return StatusCode(response.StatusCode, response);
        }


        // Register Via Phone Number 
        [HttpPost("VerifyPhone")]
        public async Task<IActionResult> VerifyPhone(VerifyPhone verifyPhone)
        {
            if (string.IsNullOrEmpty(verifyPhone.txnId) || string.IsNullOrEmpty(verifyPhone.phoneNumber))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Transaction ID and phone number are required."));
            }

            if (!Regex.IsMatch(verifyPhone.phoneNumber, @"^\d{10}$"))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Phone number must be 10 digits."));
            }

            var response = await _aadhaarServices.VerifyPhoneService(verifyPhone);

            return StatusCode(response.StatusCode, response);
        }


        // Validate Phone OTP 
        [HttpPost("ValidatePhoneOTP")]
        public async Task<IActionResult> ValidatePhoneOTP(ValidateOTP validateOTP)
        {
            if (string.IsNullOrEmpty(validateOTP.otp) || string.IsNullOrEmpty(validateOTP.txnId) || string.IsNullOrEmpty(validateOTP.mobile))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "One or more required fields have invalid or missing values."));
            }

            var response = await _aadhaarServices.ValidatePhoneOTPService(validateOTP);

            return StatusCode(response.StatusCode, response);
        }

    }
}
