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

            if (!Regex.IsMatch(registerAadhaar.aadharNumber, @"^\d{12}$"))
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
            if (string.IsNullOrEmpty(validateOTP.otp) || string.IsNullOrEmpty(validateOTP.txnId) || string.IsNullOrEmpty(validateOTP.mobile))
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


        [HttpPost("GetABHAIDSuggestions")]
        public async Task<IActionResult> GetABHAIDSuggestions(ABHASuggestion aBHASuggestion)
        {
            if (string.IsNullOrEmpty(aBHASuggestion.txnId))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Transaction ID is required."));
            }

            var response = await _aadhaarServices.GetAbhaSuggestionsService(aBHASuggestion);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("CreateCustomeABHAID")]
        public async Task<IActionResult> CreateCustomeABHAID(CreateABHA createABHA)
        {
            if (string.IsNullOrEmpty(createABHA.txnId) || string.IsNullOrEmpty(createABHA.abhaAddress))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Transaction ID and ABHA address are required."));
            }

            var response = await _aadhaarServices.CreateABHAIDService(createABHA);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("ValidateAbhaByAadhar")]
        public async Task<IActionResult> ValidateAbhaByAadhar(AbhaAddress AbhaAddress)
        {
            if (string.IsNullOrEmpty(AbhaAddress.abhaAddress))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "ABHA address are required."));
            }

            var response = await _aadhaarServices.ValidateAbhaByAadhar(AbhaAddress);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("ValidateAbhaByAadharOTP")]
        public async Task<IActionResult> ValidateAbhaByAadhar(AbhaOTPVerification abhaAddressOTP)
        {
            if (string.IsNullOrEmpty(abhaAddressOTP.txnId) || string.IsNullOrEmpty(abhaAddressOTP.otp))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Transaction ID and Otp are required."));
            }

            var response = await _aadhaarServices.ValidateAbhaByAadharOTP(abhaAddressOTP);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("ValidateAbhaByPhone")]
        public async Task<IActionResult> ValidateAbhaByPhone(ValidateAbhaByPhone ValidateAbhaByPhone)
        {
            if (string.IsNullOrEmpty(ValidateAbhaByPhone.phoneNumber))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Phone number are required."));
            }

            var response = await _aadhaarServices.ValidateAbhaByPhone(ValidateAbhaByPhone);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("ValidateAbhaByPhoneOtp")]
        public async Task<IActionResult> ValidateAbhaByPhoneOtp(AbhaOTPVerification AbhaOTPVerification)
        {
            if (string.IsNullOrEmpty(AbhaOTPVerification.txnId) || string.IsNullOrEmpty(AbhaOTPVerification.otp))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Transaction ID and Otp are required."));
            }

            var response = await _aadhaarServices.ValidateAbhaByPhoneOtp(AbhaOTPVerification);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("SearchAbhaByAddress")]
        public async Task<IActionResult> SearchAbhaByAddress(AbhaAddress AbhaAddress)
        {
            if (string.IsNullOrEmpty(AbhaAddress.abhaAddress))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "ABHA address are required."));
            }

            var response = await _aadhaarServices.SearchAbhaByAddress(AbhaAddress);
            return StatusCode(response.StatusCode, response);
        }


        // 6.1 
        [HttpPost("GetAbhaProfile")]
        public async Task<IActionResult> GetAbhaProfile(GetAbha getAbha)
        {
            if (string.IsNullOrEmpty(getAbha.abhaNumber) || string.IsNullOrEmpty(getAbha.transactionId))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "ABHA number and Transaction ID are required."));
            }
            var response = await _aadhaarServices.GetAbhaProfile(getAbha);
            return StatusCode(response.StatusCode, response);
        }

        // 6.2 Get Abha Card
        [HttpPost("GetAbhaCard")]
        public async Task<IActionResult> GetAbhaCard(GetAbha getAbha)
        {
            if (string.IsNullOrEmpty(getAbha.abhaNumber) || string.IsNullOrEmpty(getAbha.transactionId))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "ABHA number and Transaction ID are required."));
            }
            var response = await _aadhaarServices.GetAbhaCard(getAbha);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost("GetPatient")]
        public async Task<IActionResult> GetPatient(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Search Criteria is required"));
            }

            var response = await _aadhaarServices.GetPatient(searchText);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("GetPatientByMrNo")]
        public async Task<IActionResult> GetPatientByMrNo(string mrNo)
        {
            if (string.IsNullOrEmpty(mrNo))
            {
                return BadRequest(new ApiResponse<object>(false, 400, "Mrno is required"));
            }

            var response = await _aadhaarServices.GetPatientByMrNo(mrNo);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost("save-patient")]
        public async Task<IActionResult> SavePatient([FromBody] SavePatientRequest request)
        {
            try
            {
                var result = await _aadhaarServices.SavePatient(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
