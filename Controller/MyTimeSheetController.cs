using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Request;
using TimeSheet.Services;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTimeSheetController : ControllerBase
    {
        private readonly ITimeSheetLogService timeSheetLogService;
        public MyTimeSheetController(ITimeSheetLogService timeSheetLogService)
        {
            this.timeSheetLogService = timeSheetLogService;
        }
        [HttpGet("/user/{id}")]
        public IActionResult GetById(int id)
        {
            var result = timeSheetLogService.GetByUserId(id);
            if (result.Code == 404)
                return NotFound(result);
            else if (result.Code == 200)
                return Ok(result);
            else return BadRequest("@@");

        }
        [HttpPost]
        public IActionResult CreateTimeSheet(TimeSheetLogRequest timeSheetLogRequest)
        {
            var result = timeSheetLogService.Create(timeSheetLogRequest);
            if (result.Code == 400)
                return BadRequest(result);
            else if (result.Code == 200)
                return Ok(result);
            else return NotFound("@@");
        }
        [HttpPut("{id}")]
        public IActionResult CreateTimeSheet(int id,TimeSheetLogRequest timeSheetLogRequest)
        {
            var result = timeSheetLogService.Update(id,timeSheetLogRequest);
            if (result.Code == 400)
                return BadRequest(result);
            else if (result.Code == 200)
                return Ok(result);
            else return NotFound("@@");
        }
        [HttpDelete("{id}")]
        public IActionResult DeteteTimeSheet(int id)
        {
            var result = timeSheetLogService.Delete(id);
            if (result.Code == 404)
                return NotFound(result);
            else if (result.Code == 200)
                return Ok(result);
            else return BadRequest("@@");
        }
    }
}
