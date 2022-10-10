using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Services;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;

        }
        [HttpGet]
        public IActionResult GetAllTask()
        {
            return Ok(taskService.GetAll());
        }
    }
}
