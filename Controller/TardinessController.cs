using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Services;
using TimeSheet.Services.Implement;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TardinessController : ControllerBase
    {
        private readonly ITardinessService tardinessService;
        public TardinessController(ITardinessService tardinessService)
        {
            this.tardinessService = tardinessService;
        }
        [HttpGet("checkin/{id}")]
        public IActionResult CheckInById(int id)
        {
            var result = tardinessService.CheckIn(id);
            if (result.Code == 404)
                return NotFound(result);
            else if (result.Code == 200)
                return Ok(result);
            else return BadRequest("@@");
        }
        [HttpGet("checkout/{id}")]
        public IActionResult CheckOutById(int id)
        {
            var result = tardinessService.CheckOut(id);
            if (result.Code == 404)
                return NotFound(result);
            else if (result.Code == 200)
                return Ok(result);
            else return BadRequest("@@");
        }
    }
}
