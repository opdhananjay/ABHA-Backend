using ABDM.Helpers;
using ABDM.Models;
using ComServRef;

namespace ABDM.ExternalServices
{
    public class AuthServices: IAuthServices
    {

  
        public async Task<ApiResponse<object>> LoginCheck(LoginModel loginCheck)
        {
            dynamic response = await LoginService(loginCheck);

            if(response != null && response.ChkLoginNewResult.Length > 3)
            {
                bool isSuccess = response.ChkLoginNewResult[0] ? true:false;
                string message = response.ChkLoginNewResult[2] != null ? response.ChkLoginNewResult[2] : "";

                var InfoObj = new { userId = loginCheck.username.ToUpper(), data = response.ChkLoginNewResult };

                if (isSuccess && !string.IsNullOrEmpty(response.ChkLoginNewResult[3]))  // Haing GUID => Success 
                {
                    return new ApiResponse<object>(true, 200, message, InfoObj);
                }
                else
                {
                    return new ApiResponse<object>(false, 200, message, InfoObj);
                }
            }
            else
            {
                return new ApiResponse<object>(false, 400, "No response found", null);
            }
        }
            

        public async Task<object> LoginService(LoginModel loginModel)
        {
            CommonServiceClient comserv = new CommonServiceClient();
            var response = await comserv.ChkLoginNewAsync(loginModel.username,loginModel.password,loginModel.IpAddress);
            return response;
        }




    }
}
