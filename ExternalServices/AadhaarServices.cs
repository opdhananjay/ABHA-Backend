using ABDM.Helpers;
using ABDM.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ABDM.ExternalServices
{
    public class AadhaarServices:IAadhaarServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _abdmBaseUrl;
        public AadhaarServices(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _abdmBaseUrl = configuration["ABDM:BASE_URL"];
        }

        // Register by Aadhaar Number 
        public async Task<ApiResponse<object>> RegisterbyAadhaarService(RegisterAadhaar registerAadhaar)
        {
            var requestJson = JsonSerializer.Serialize(registerAadhaar);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/register-by-aadhaar", httpContent);

            // Handle non-success http response 
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            // Read response content as string
            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // Validate Aadhaar OTP 
        public async Task<ApiResponse<object>> ValidateOTPService(ValidateOTP validateOTP)
        {
            var requestJson = JsonSerializer.Serialize(validateOTP);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/validate-otp", httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            // Read Content 
            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        public async Task<ApiResponse<object>> ResendOTPService(ResendOTPAadhaar resendOTPAadhaar)
        {
            var requestJson = JsonSerializer.Serialize(resendOTPAadhaar);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/resend-otp",httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // Verify Phone Number  
        public async Task<ApiResponse<object>> VerifyPhoneService(VerifyPhone verifyPhone)
        {
            var requestJson = JsonSerializer.Serialize(verifyPhone);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/verify-phone",httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        public async Task<ApiResponse<object>> ValidatePhoneOTPService(ValidateOTP validateOTP)
        {
            var requestJson = JsonSerializer.Serialize(validateOTP);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/validate-phone-otp", httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

    }
}
