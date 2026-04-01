using ABDM.ExternalServices;
using ABDM.Helpers;
using ABDM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthServices _authService;

        public AuthController(IAuthServices authServices)
        {
            _authService = authServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginService(LoginModel loginModel)
        {
            try 
            {
                var response = await _authService.LoginCheck(loginModel);

                if (response.Success)
                {
                    return Ok(response);
                }
           
                return StatusCode(response.StatusCode, response);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(false, 500, "exception occured.", null));
            }
        }

        [HttpGet("GetUnits")]
        public IActionResult GetUnits()
        {
            var units = new List<object>
            {
                new  { Id = "01", Name = "Center of Oncopathology" },
                new  { Id = "02", Name = "SVIKAR" },
                new  { Id = "03", Name = "RANCHI" }
            };

            return Ok(new { Units = units });
        }




        
        
    }
}
