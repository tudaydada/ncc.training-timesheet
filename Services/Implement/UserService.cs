using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Services.Interface;

namespace TimeSheet.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DbSet<User> users;
        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
            users = _userRepository.GetAll();
        }
        public ObjectResponse GetAllUser()
        {
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = users.Select(e => new
                {
                    Id = e.Id,
                    Name = e.UserName,
                    EmailAddress = e.EmailAddress,
                    IsActive = e.IsActive,
                    Type = e.UserTypeId,
                    Level = e.UserLevelId,
                    Branch = e.BranchId
                })
            };
        }
    }
}
