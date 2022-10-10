using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Services.Interface;

namespace TimeSheet.Services.Implement
{
    public class TardinessService : ITardinessService
    {
        private readonly ITardinessRepository tardinessRepository;
        private readonly IUserRepository userRepository;
        private readonly IBranchRepository branchRepository;


        private DbSet<Tardiness> Tardinesses;

        public TardinessService(ITardinessRepository tardinessRepository, IUserRepository userRepository
            ,IBranchRepository branchRepository)
        {
            this.tardinessRepository = tardinessRepository;
            this.userRepository = userRepository;
            this.branchRepository = branchRepository;
        }
        public ObjectResponse CheckIn(int userId)
        {
            var user = (from u in userRepository.GetAll()
                        join b in branchRepository.GetAll() on u.BranchId equals b.Id
                        where u.Id== userId
                        select new
                        {
                            Id = u.Id,
                            EmailAddress = u.EmailAddress,
                            RegistrationTimeStart = b.MorningStartAt,
                            RegistrationTimeEnd = b.AfternoonEndAt
                        }).FirstOrDefault();
            if (user==null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Not Found"
                };
            else
            {
                var now = DateTime.Now;
                var isChecked = (from t in tardinessRepository.GetAll()
                                 where t.UserId == userId && Math.Abs(t.CheckIn - t.RegistrationStart) > 0.5 && t.CreateAt.Day == now.Day
                                 select t.Id).Any();

                if (isChecked)
                    return new ObjectResponse
                    {
                        Code = 200,
                        Message = "Checked"
                    };
                var tardiness = new Tardiness();
                tardiness.CreateAt = now;
                tardiness.CheckIn = now.Hour + (double)now.Minute /60;
                tardiness.TardinessStatusId = 1;
                tardiness.RegistrationStart = user.RegistrationTimeStart;
                tardiness.RegistrationEnd = user.RegistrationTimeEnd;
                tardiness.UserId=userId;
                tardiness.UserNote = "";
                tardiness.NoteReply = "";
                tardinessRepository.Create(tardiness);
                tardinessRepository.SaveChanges();
                var result = (from t in tardinessRepository.GetAll()
                              where t.UserId == tardiness.UserId
                              select new
                              {
                                  t.Id,
                                  t.CreateAt
                              }).OrderByDescending(e=>e.CreateAt).FirstOrDefault();
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = new
                    {
                        Id = result.Id,
                        CreateAt = result.CreateAt,
                        UserId = user.Id,
                        EmailAddress = user.EmailAddress,
                        RegistrationsTimeStart = user.RegistrationTimeStart,
                        RegistrationsTimeEnd = user.RegistrationTimeEnd,
                        CheckIn = tardiness.CheckIn,
                        Status = tardiness.TardinessStatusId
                    }

                };
            }
        }

        public ObjectResponse CheckOut(int userId)
        {
            var user = (from u in userRepository.GetAll()
                        join b in branchRepository.GetAll() on u.BranchId equals b.Id
                        where u.Id == userId
                        select new
                        {
                            Id = u.Id,
                            EmailAddress = u.EmailAddress,
                            RegistrationTimeStart = b.MorningStartAt,
                            RegistrationTimeEnd = b.AfternoonEndAt
                        }).FirstOrDefault();
            if (user == null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Not Found"
                };
            else
            {
                var now = DateTime.Now;
                var isChecked = (from t in tardinessRepository.GetAll()
                                 where t.UserId == userId && Math.Abs(t.CheckOut - t.RegistrationEnd) < 2 &&t.CreateAt.Day == now.Day
                                 select t.Id).Any();
                if (isChecked)
                    return new ObjectResponse
                    {
                        Code = 200,
                        Message = "Checked"
                    };
                var tardiness = (from t in tardinessRepository.GetAll()
                                 where t.UserId == userId && t.CreateAt.Day == now.Day
                                 select t).OrderByDescending(e => e.CreateAt).FirstOrDefault();
                tardiness.CheckOut = now.Hour + (double)now.Minute / 60;
                tardinessRepository.Update(tardiness);
                tardinessRepository.SaveChanges();
                var result = (from t in tardinessRepository.GetAll()
                              where t.Id == tardiness.Id
                              select new
                              {
                                  t.Id,
                                  t.CreateAt
                              }).OrderByDescending(e => e.CreateAt).FirstOrDefault();
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = new
                    {
                        Id = result.Id,
                        CreateAt = result.CreateAt,
                        UserId = user.Id,
                        EmailAddress = user.EmailAddress,
                        RegistrationsTimeStart = user.RegistrationTimeStart,
                        RegistrationsTimeEnd = user.RegistrationTimeEnd,
                        CheckIn = tardiness.CheckOut,
                        Status = tardiness.TardinessStatusId
                    }

                };
            }
        }


    }
}
