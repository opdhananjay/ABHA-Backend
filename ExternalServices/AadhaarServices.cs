using ABDM.Helpers;
using ABDM.Models;
using ComServRef;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Data;
using System.IO;

namespace ABDM.ExternalServices
{
    public class AadhaarServices : IAadhaarServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _abdmBaseUrl;
        public AadhaarServices(HttpClient httpClient, IConfiguration configuration)
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

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/resend-otp", httpContent);

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

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/verify-phone", httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // Validating Phone OTP Service 
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


        // Get Abha Suggestions 
        public async Task<ApiResponse<object>> GetAbhaSuggestionsService(ABHASuggestion ABHASuggestion)
        {
            var requestJson = JsonSerializer.Serialize(ABHASuggestion);

            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/suggested-addresses", httpContent);

            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }

            var responseJson = await apiResponse.Content.ReadAsStringAsync();

            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // Create ABHA ID 
        public async Task<ApiResponse<object>> CreateABHAIDService(CreateABHA createABHA)
        {
            var requestJson = JsonSerializer.Serialize(createABHA);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsync($"{_abdmBaseUrl}/abdm/registration/create-address", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }



        // 5 - 5.1 
        public async Task<ApiResponse<object>> ValidateAbhaByAadhar(AbhaAddress abhaAddress)
        {
            var requestJson = JsonSerializer.Serialize(abhaAddress);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsJsonAsync($"{_abdmBaseUrl}/abdm/validation/validate-by-aadhaar", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // 5.2 
        public async Task<ApiResponse<object>> ValidateAbhaByAadharOTP(AbhaOTPVerification abhaAddressOTP)
        {
            var requestJson = JsonSerializer.Serialize(abhaAddressOTP);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsJsonAsync($"{_abdmBaseUrl}/abdm/validation/validate-by-aadhaar-otp", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }


        // 5.3 
        public async Task<ApiResponse<object>> ValidateAbhaByPhone(ValidateAbhaByPhone validateAbhaByPhone)
        {
            var requestJson = JsonSerializer.Serialize(validateAbhaByPhone);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsJsonAsync($"{_abdmBaseUrl}/abdm/validation/validate-by-phone", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        public async Task<ApiResponse<object>> ValidateAbhaByPhoneOtp(AbhaOTPVerification AbhaOTPVerification)
        {
            var requestJson = JsonSerializer.Serialize(AbhaOTPVerification);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsJsonAsync($"{_abdmBaseUrl}/abdm/validation/validate-by-phone-otp", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        public async Task<ApiResponse<object>> SearchAbhaByAddress(AbhaAddress abhaAddress)
        {
            var requestJson = JsonSerializer.Serialize(abhaAddress);
            var httpContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PostAsJsonAsync($"{_abdmBaseUrl}/abdm/validation/search-by-address", httpContent);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }


        // 6.1 Get Abha Profile  
        public async Task<ApiResponse<object>> GetAbhaProfile(GetAbha getAbha)
        {
            var apiResponse = await _httpClient.GetAsync($"{_abdmBaseUrl}/abdm/profile/get?abhaNumber={getAbha.abhaNumber}&transactionId={getAbha.transactionId}");
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }

        // 6.2 Get Abha Card 
        public async Task<ApiResponse<object>> GetAbhaCard(GetAbha getAbha)
        {
            var apiResponse = await _httpClient.GetAsync($"{_abdmBaseUrl}/abdm/profile/get-card?abhaNumber={getAbha.abhaNumber}&transactionId={getAbha.transactionId}");
            if (!apiResponse.IsSuccessStatusCode)
            {
                return new ApiResponse<object>(false, (int)apiResponse.StatusCode, "Something went wrong");
            }
            var responseJson = await apiResponse.Content.ReadAsStringAsync();
            return new ApiResponse<object>(true, 200, "Success", responseJson);
        }


        // Fetch Patinet - 
        public async Task<ApiResponse<object>> GetPatient(string searchText)
        {
            string smrno = "";
            string fname = "";
            string contact = "";

            if (searchText.All(char.IsDigit))
            {
                if (searchText.Length == 10)
                    contact = searchText;
                else
                    smrno = searchText;
            }
            else
            {
                fname = searchText;
            }

            DataSet ds = new DataSet();

            CommonServiceClient comserv = new CommonServiceClient();

            var response = await comserv.GetOPPatientDetailsAsync(
                smrno, fname, "", "", contact,
                "", "", "", "", "", "", "", "", "", "", "", "", "", "Y", ""
            );

            string xmlResult = response.GetOPPatientDetailsResult;

            if (string.IsNullOrEmpty(xmlResult))
            {
                return new ApiResponse<object>(false, 404, "No Data found");
            }

            using (var reader = new StringReader(xmlResult))
            {
                ds.ReadXml(reader);
            }

            var table = ds.Tables.Cast<DataTable>().FirstOrDefault();

            if (table == null || table.Rows.Count == 0)
            {
                return new ApiResponse<object>(false, 404, "No Data found");
            }

            var jsonData = table.AsEnumerable().Select(row => new
            {
                firstName = $"{row["SALUNAME"]} {row["PATNAME"]}".Trim(),
                mrNo = row["MRNO"]?.ToString()?.Trim()
            }).ToList();

            return new ApiResponse<object>(true, 200, "Data Found", jsonData);
        }


    }
}
