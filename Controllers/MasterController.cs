using ABDM.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpGet("salutation")]
        public async Task<IActionResult> GetSalutation()
        {
            var result = await _masterService.GetSalutationList();
            return Ok(result);
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetCity()
        {
            var result = await _masterService.GetCityList();
            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetState()
        {
            var result = await _masterService.GetStateList();
            return Ok(result);
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountry()
        {
            var result = await _masterService.GetCountryList();
            return Ok(result);
        }

        [HttpGet("district")]
        public async Task<IActionResult> GetDistrict()
        {
            var result = await _masterService.GetDistrictList();
            return Ok(result);
        }

        [HttpGet("area")]
        public async Task<IActionResult> GetArea()
        {
            var result = await _masterService.GetAreaList();
            return Ok(result);
        }

    }
}
