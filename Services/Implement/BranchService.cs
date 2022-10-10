using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Services.Interface;

namespace TimeSheet.Services.Implement
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;
        private readonly DbSet<Branch> branches;
        public BranchService(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
            branches = this.branchRepository.GetAll();
        }
        public ObjectResponse GetAllBranches()
        {
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = branches.Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    DisplayName = e.DisplayName
                })
            };

        }
    }
}
