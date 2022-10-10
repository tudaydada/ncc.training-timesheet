using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Services;

namespace TimeSheet.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;
        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        [HttpGet]
        public IActionResult GetAllBranchese()
        {
            return Ok(branchService.GetAllBranches());
        }
    }
}
