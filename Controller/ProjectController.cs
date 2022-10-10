using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Request;
using TimeSheet.Services;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService=projectService;
        }
        [HttpGet("GetAllProject")]
        public IActionResult GetAll()
        {
            var result = projectService.GetAllProject(0,"");
            return Ok(result);
        }
        [HttpGet("GetQuantity")]
        public IActionResult GetQuantity()
        {
            var result = projectService.GetQuantityProject();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(ProjectRequest projectRequest)
        {
            var result = projectService.Create(projectRequest);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,ProjectRequest projectRequest)
        {
            var result = projectService.Update(id,projectRequest);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = projectService.Delete(id);
            return Ok(result);
        }

    }
}
