using ABDM.Helpers;
using ABDM.Models;
using ComServRef;
using Microsoft.Extensions.Configuration;
using OPServRef;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

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


        // Get Patinet By MRNO 

        public async Task<ApiResponse<object>> GetPatientByMrNo(string mrNo)
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable();

            try
            {
                CommonServiceClient comserv = new CommonServiceClient();

                var response = await comserv.GetOPPatientDetailsAsync(
                    mrNo,     // SMRNO
                    "",       // First name
                    "",       // Middle name
                    "",       // Last name
                    "",       // Contact
                    "",       // Other search name
                    "", "", "", "", "", "", "", "", "", "", "", "", "N", ""
                );

                string xmlResult = response.GetOPPatientDetailsResult;

                if (string.IsNullOrEmpty(xmlResult))
                {
                    return new ApiResponse<object>(
                        false,
                        404,
                        "Patient not found"
                    );
                }

                using (var reader = new StringReader(xmlResult))
                {
                    ds.ReadXml(reader);
                }

                table = ds.Tables.Cast<DataTable>().FirstOrDefault();

                if (table == null || table.Rows.Count == 0)
                {
                    return new ApiResponse<object>(
                        false,
                        404,
                        "Patient not found"
                    );
                }

                var row = table.Rows[0];

                var patientData = new
                {
                    mrNo = row["MRNO"]?.ToString()?.Trim(),

                    firstName = row["PATFNAME"]?.ToString()?.Trim(),
                    middleName = row["PATMNAME"]?.ToString()?.Trim(),
                    lastName = row["PATLNAME"]?.ToString()?.Trim(),

                    fullName = row["PATNAME"]?.ToString()?.Trim(),

                    mobile = row["PATMOBILE"]?.ToString()?.Trim(),
                    email = row["PATEMAIL"]?.ToString()?.Trim(),

                    gender = row["PATSEX"]?.ToString()?.Trim(),
                    dob = row["PATDOB"]?.ToString()?.Trim(),

                    address1 = row["PATADDR1"]?.ToString()?.Trim(),
                    address2 = row["PATADDR2"]?.ToString()?.Trim(),
                    address3 = row["PATADDR3"]?.ToString()?.Trim(),

                    cityId = row["CITYID"]?.ToString()?.Trim(),
                    districtId = row["DISTRICTID"]?.ToString()?.Trim(),
                    regionId = row["REGIONID"]?.ToString()?.Trim(),

                    zip = row["ZIP"]?.ToString()?.Trim(),

                    patCategory = row["PATCATGCD"]?.ToString()?.Trim(),
                    tariffId = row["TARIFFID"]?.ToString()?.Trim(),

                    verifiedMobile = row.Table.Columns.Contains("VERIFIEDCONTACT")
                        ? row["VERIFIEDCONTACT"]?.ToString()?.Trim()
                        : ""
                };

                return new ApiResponse<object>(
                    true,
                    200,
                    "Patient found",
                    patientData
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>(
                    false,
                    500,
                    ex.Message
                );
            }
            finally
            {
                ds.Dispose();
                table.Dispose();
            }
        }

        // Save | Update
        //public async Task<ApiResponse<object>> SavePatient(SavePatientRequest request)
        //{
        //    try
        //    {
        //        BL_OPRegistration regis = new BL_OPRegistration();

        //        // =========================
        //        // Personal Details
        //        // =========================
        //        regis.Salutation = request.Salutation;
        //        regis.Patfname = request.Patfname;
        //        regis.Patlname = request.Patlname;
        //        regis.PatName = $"{request.Patfname} {request.Patlname}".Trim();

        //        regis.Patdob = request.Patdob;
        //        regis.Patsex = request.Patsex;

        //        // Optional
        //        regis.Patmname = "";
        //        regis.Patage = request.Patage;

        //        // =========================
        //        // Contact Details
        //        // =========================
        //        regis.Patmobile = request.Patmobile;
        //        regis.Patemail = request.Patemail;

        //        regis.VerifiedContacts =
        //            $"{request.Patmobile}/{request.Patmobile},{request.Patemail}";

        //        // =========================
        //        // Current Address
        //        // =========================
        //        regis.Pataddr1 = request.Pataddr1;
        //        regis.Pataddr2 = "";
        //        regis.Pataddr3 = "";

        //        regis.Cityid = request.Cityid;
        //        regis.Districtid = request.Districtid;
        //        regis.Regionid = request.Regionid;
        //        regis.Countryid = request.Countryid;
        //        regis.Zip = request.Zip;

        //        // =========================
        //        // Permanent Address
        //        // Legacy system expects this too
        //        // =========================
        //        regis.Patpaddr1 = request.Pataddr1;
        //        regis.Patpaddr2 = "";
        //        regis.Patpaddr3 = "";

        //        regis.Patpcitycd = request.Cityid;
        //        regis.PatPDistID = request.Districtid;
        //        regis.Patpregncd = request.Regionid;
        //        regis.Patpcntrcd = request.Countryid;

        //        regis.Ppincode = request.Zip;
        //        regis.Patpmobl = request.Patmobile;

        //        // =========================
        //        // Default Registration Config
        //        // =========================

        //        regis.Patcatgcd = "001";
        //        regis.Pattypcd = "01";
        //        regis.Tariffid = "01";
        //        regis.Paytype = "01";

        //        regis.HospUnit = "02";
        //        regis.CntrCd = "03";
        //        regis.PatientSource = "02";

        //        regis.Priority = "N";
        //        regis.Regstatus = "R";

        //        // =========================
        //        // Identity
        //        // =========================
        //        regis.IdentityCode = request.IdentityCode;  // "004"  - Aadhar 
        //        regis.IdentityNumber = request.IdentityNumber;  

        //        // Later replace with Aadhaar if needed
        //        // regis.IdentityNumber = request.AadhaarNumber;

        //        // =========================
        //        // System Fields
        //        // =========================
        //        regis.UserID = request.UserID;
        //        regis.ModuleID = "03";
        //        regis.IpAddress = "::1";

        //        // =========================
        //        // Future ABHA Mapping
        //        // Uncomment when DB/service supports it
        //        // =========================

        //        /*
        //        regis.AbhaNumber = request.AbhaNumber;
        //        regis.AbhaAddress = request.AbhaAddress;
        //        */

        //        string response = "";

        //        using (OutpatientClient op = new OutpatientClient())
        //        {
        //            // =========================
        //            // NEW REGISTRATION
        //            // =========================
        //            if (request.TranMode == 1)
        //            {
        //                regis.TranMode = 1;
        //                regis.TranModeSpecified = true;

        //                var result = await op.SaveUpdateRegistrationAsync(regis);

        //                response = result.SaveUpdateRegistrationResult;

        //                if (response.Contains("Successful"))
        //                {
        //                    return new ApiResponse<object>(
        //                      true,
        //                      200,
        //                      "Patient saved successfully",
        //                      response
        //                  );
        //                }
        //                else
        //                {
        //                    return new ApiResponse<object>(
        //                       true,
        //                       200,
        //                       "Kindly try again",
        //                       response
        //                   );   
        //                }
        //            }

        //            // =========================
        //            // UPDATE EXISTING PATIENT
        //            // =========================
        //            else if (request.TranMode == 2)
        //            {
        //                regis.TranMode = 2;
        //                regis.TranModeSpecified = true;

        //                regis.MRNo = request.MRNo;

        //                var result = await op.SaveUpdateRegistrationAsync(regis);

        //                response = result.SaveUpdateRegistrationResult;

        //                if (response.Contains("Successful"))
        //                {
        //                    return new ApiResponse<object>(
        //                        true,
        //                        200,
        //                        "Patient updated successfully",
        //                        response
        //                    );
        //                }
        //                else
        //                {
        //                    return new ApiResponse<object>(
        //                       true,
        //                       200,
        //                       "Kindly try again",
        //                       response
        //                   );
        //                }

        //            }

        //            else
        //            {
        //                return new ApiResponse<object>(
        //                    false,
        //                    400,
        //                    "Invalid TranMode"
        //                );
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponse<object>(
        //            false,
        //            500,
        //            ex.Message
        //        );
        //    }
        //}

        public async Task<ApiResponse<object>> SavePatient(SavePatientRequest request)
        {
            try
            {
                BL_OPRegistration regis = new BL_OPRegistration();

                // =========================
                // Personal Details
                // =========================
                regis.Salutation = request.Salutation ?? "004";

                regis.Patfname = request.Patfname ?? "";
                regis.Patlname = request.Patlname ?? "";
                regis.Patmname = "";

                regis.PatName =
                    $"{request.Patfname ?? ""} {request.Patlname ?? ""}".Trim();

                regis.Patdob = request.Patdob ?? "";
                regis.Patsex = request.Patsex ?? "";
                regis.Patage = request.Patage ?? "";

                // =========================
                // Contact Details
                // =========================
                regis.Patmobile = request.Patmobile ?? "";
                regis.Patemail = request.Patemail ?? "";

                regis.Patophone = "";
                regis.Patrphone = "";

                regis.VerifiedContacts =
                    $"{request.Patmobile ?? ""}/{request.Patmobile ?? ""},{request.Patemail ?? ""}";

                // =========================
                // Current Address
                // =========================
                regis.Pataddr1 = request.Pataddr1 ?? "";
                regis.Pataddr2 = "";
                regis.Pataddr3 = "";

                regis.Cityid = request.Cityid ?? "004";
                regis.Districtid = request.Districtid ?? "414";
                regis.Regionid = request.Regionid ?? "022";
                regis.Countryid = request.Countryid ?? "079";
                regis.Zip = request.Zip ?? "";

                // Missing legacy field
                regis.Areaid = "0397";

                // =========================
                // Permanent Address
                // =========================
                regis.Patpaddr1 = request.Pataddr1 ?? "";
                regis.Patpaddr2 = "";
                regis.Patpaddr3 = "";

                regis.Patpcitycd = request.Cityid ?? "004";
                regis.PatPDistID = request.Districtid ?? "414";
                regis.Patpregncd = request.Regionid ?? "022";
                regis.Patpcntrcd = request.Countryid ?? "079";

                regis.Ppincode = request.Zip ?? "";
                regis.Patpmobl = request.Patmobile ?? "";

                // Missing legacy field
                regis.PatpAreacd = "0397";

                // =========================
                // Guardian Details
                // =========================
                regis.Patgname = "";
                regis.Patgreln = "";
                regis.Patgmobl = "";

                regis.Patgaddr1 = "";
                regis.Patgaddr2 = "";
                regis.Patgaddr3 = "";

                regis.Patgcitycd = "";
                regis.Patgcntrcd = "";
                regis.PatgAreacd = "";

                // Missing legacy fields
                regis.Patgphon1 = "";
                regis.Patgphon2 = "";
                regis.Patgregncd = "";

                // =========================
                // Registration Config
                // =========================
                regis.Patcatgcd = "001";
                regis.Pattypcd = "01";
                regis.Tariffid = "01";
                regis.Paytype = "01";

                regis.HospUnit = "02";
                regis.CntrCd = "03";
                regis.PatientSource = "02";

                regis.Priority = "N";
                regis.PriorityRemarks = "";

                regis.Regstatus = "R";

                // Missing legacy field
                regis.RegTranTimeTaken = "00:00";

                // =========================
                // Identity
                // =========================
                regis.IdentityCode = request.IdentityCode ?? "004";
                regis.IdentityNumber = request.IdentityNumber ?? "";

                // =========================
                // Nationality
                // =========================
                regis.Nationlity = "01";

                // =========================
                // Scheme
                // =========================
                regis.SchemeCode = "testValue";

                // =========================
                // Department
                // =========================
                regis.Deptcode = "";
                regis.Gpincode = "";

                // =========================
                // Referral Fields
                // =========================
                regis.Refdoctcd = "";
                regis.Refhosp = "";
                regis.Referedby = "";

                regis.Prefdoct = "";
                regis.Cliniccd = "";

                // =========================
                // Insurance / Employee
                // =========================
                regis.Crdcompcd = "";
                regis.Empid = "";
                regis.Empname = "";
                regis.Empdepndcd = "";

                // =========================
                // Misc Fields
                // =========================
                regis.TokenNo = "";
                regis.Letterno = "";
                regis.Cardno = "";
                regis.Oldmrno = "";

                regis.PANNo = "";
                regis.Passportno = "";

                // =========================
                // Numeric/Specified Fields
                // =========================
                regis.Cardlimit = 0;
                regis.CardlimitSpecified = true;

                regis.DepstamtSpecified = false;
                regis.RefndamtSpecified = false;
                regis.TpalmtSpecified = false;
                regis.AplidamtSpecified = false;
                regis.AvllmtSpecified = false;

                // =========================
                // System Fields
                // =========================
                regis.UserID = request.UserID ?? "AI22";
                regis.ModuleID = "03";
                regis.IpAddress = "::1";

                string response = "";

                using (OutpatientClient op = new OutpatientClient())
                {
                    if (request.TranMode == 1)
                    {
                        regis.TranMode = 1;
                        regis.TranModeSpecified = true;

                        var result =
                            await op.SaveUpdateRegistrationAsync(regis);

                        response = result.SaveUpdateRegistrationResult;

                        if (response.Contains("Successful"))
                        {
                            return new ApiResponse<object>(
                              true,
                              200,
                              "Patient saved successfully",
                              response
                          );
                        }
                        else
                        {
                            return new ApiResponse<object>(
                               true,
                               200,
                               "Kindly try again",
                               response
                           );
                        }
                    }
                    else if (request.TranMode == 2)
                    {
                        regis.TranMode = 2;
                        regis.TranModeSpecified = true;

                        regis.MRNo = request.MRNo ?? "";

                        var result =
                            await op.SaveUpdateRegistrationAsync(regis);

                        response = result.SaveUpdateRegistrationResult;

                        if (response.Contains("Successful"))
                        {
                            return new ApiResponse<object>(
                                true,
                                200,
                                "Patient updated successfully",
                                response
                            );
                        }
                        else
                        {
                            return new ApiResponse<object>(
                               true,
                               200,
                               "Kindly try again",
                               response
                           );
                        }
                    }
                    else
                    {
                        return new ApiResponse<object>(
                            false,
                            400,
                            "Invalid TranMode"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>(
                    false,
                    500,
                    ex.Message
                );
            }
        }
    }
}
