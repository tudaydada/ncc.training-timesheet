using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Services;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService; 
        }
        [HttpGet("getAllClient")]
        public IActionResult GetAllClient()
        {
            var result = clientService.GetAllClient();
            if (result.Code == 200)
                return Ok(result);
            else
                return NotFound();
        }
        [HttpGet("hasProject")]
        public IActionResult GetClientHasProject()
        {
            var result = clientService.GetClientHasProject();
            if(result.Code==200)
                return Ok(result);
            else
                return NotFound();
        }
        [HttpGet("hasProject/{clientCode}")]
        public IActionResult GetClientHasProjectByClientCode(string clientCode)
        {
            var result = clientService.GetClientHasProject(clientCode);
            if (result.Code == 200)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
