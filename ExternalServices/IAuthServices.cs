using ABDM.Helpers;
using ABDM.Models;

namespace ABDM.ExternalServices
{
    public interface IAuthServices
    {
        Task<object> LoginService(LoginModel loginModel);
        Task<ApiResponse<object>> LoginCheck(LoginModel loginModel);
    }

}
