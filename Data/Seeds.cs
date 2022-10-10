using TimeSheet.Model.Entity;
using Task = TimeSheet.Model.Entity.Task;

namespace TimeSheet.Data
{
    public class Seeds
    {
        public static TaskType[] TaskTypes => new[]
        {
            new TaskType{Id = 1 , Name = "Common"},
            new TaskType{Id = 2 , Name = "Orther"}
        };
        public static Model.Entity.Task[] Tasks => new[]
        {
            new Task{Id = 1 , Name = "Task 1", TaskTypeId = 1,IsDeleted = false},
            new Task{Id = 2 , Name = "Task 2", TaskTypeId = 2,IsDeleted = false},
            new Task{Id = 3 , Name = "Task 3", TaskTypeId = 1,IsDeleted = false},
            new Task{Id = 4 , Name = "Task 4", TaskTypeId = 2,IsDeleted = false},
            new Task{Id = 5 , Name = "Task 5", TaskTypeId = 1,IsDeleted = false},
            new Task{Id = 6 , Name = "Task 6", TaskTypeId = 2,IsDeleted = false},
            new Task{Id = 7 , Name = "Task 7", TaskTypeId = 1,IsDeleted = false},
            new Task{Id = 8 , Name = "Task 8", TaskTypeId = 2,IsDeleted = false},
        };
        public static Client[] Clients => new[]
        {
            new Client{Id = 1  , Name = "Client 01",Code ="C01",Address="Address 1"},
            new Client{Id = 2  , Name = "Client 02",Code ="C02",Address="Address 2"},
            new Client{Id = 3  , Name = "Client 03",Code ="C03",Address="Address 3"},
            new Client{Id = 4  , Name = "Client 04",Code ="C04",Address="Address 4"},
            new Client{Id = 5  , Name = "Client 05",Code ="C05",Address="Address 5"},
            new Client{Id = 6  , Name = "Client 06",Code ="C06",Address="Address 6"},
            new Client{Id = 7  , Name = "Client 07",Code ="C07",Address="Address 7"},
            new Client{Id = 8  , Name = "Client 08",Code ="C08",Address="Address 8"},
            new Client{Id = 9  , Name = "Client 09",Code ="C09",Address="Address 9"},
            new Client{Id = 10 , Name = "Client 10",Code ="C10",Address="Address 10"}
        };
        public static UserType[] UserTypes => new[]
        {
            new UserType{Id = 1 , Name = "Staff"},
            new UserType{Id = 2 , Name = "Internship"},
            new UserType{Id = 3, Name = "Collaborator"},
        };
        public static UserStatus[] UserStatuses => new[]
        {
            new UserStatus{Id = 1 , Name = "Active"},
            new UserStatus{Id = 2 , Name = "Inactive"}
        };
        public static Role[] Roles => new[]
       {
            new Role{Id = 1 , Name = "Admin" , DisplayName="Quản trị viên",Normalized="admin"},
            new Role{Id = 2 , Name = "Staff",DisplayName="Nhân viên",Normalized="staff"},
            new Role{Id = 3, Name = "Project Manager",DisplayName="Quản lý dự án",Normalized="pm"},
        };
        public static UserLevel[] UserLevels => new[]
        {
            new UserLevel{Id = 1    , Name = "Intern_0"},
            new UserLevel{Id = 2    , Name = "Intern_1"},
            new UserLevel{Id = 3    , Name = "Intern_2"},
            new UserLevel{Id = 4    , Name = "Intern_3"},
            new UserLevel{Id = 5    , Name = "Fresher_0"},
            new UserLevel{Id = 6    , Name = "Fresher_1"},
            new UserLevel{Id = 7    , Name = "Fresher_2"},
            new UserLevel{Id = 8    , Name = "Junior_0"},
            new UserLevel{Id = 9    , Name = "Junior_1"},
            new UserLevel{Id = 10   , Name = "Junior_2"},
            new UserLevel{Id = 11   , Name = "Middle_0"},
            new UserLevel{Id = 12   , Name = "Middle_1"},
            new UserLevel{Id = 13   , Name = "Middle_2"},
            new UserLevel{Id = 14   , Name = "Senior_0"},
            new UserLevel{Id = 15   , Name = "Senior_1"},
            new UserLevel{Id = 16   , Name = "Senior_2"},
        };
        public static User[] Users => new[]
        {
            new User{Id = 1,UserName = "UserName01",UserCode="U01",EmailAddress="user1@ncc.asia",UserTypeId=2,UserLevelId=2
                ,BranchId=1,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=2000},
            new User{Id = 2,UserName = "UserName02",UserCode="U02",EmailAddress="admin1@ncc.asia",UserTypeId=3,UserLevelId=16
                ,BranchId=2,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=6000},
            new User{Id = 3,UserName = "UserName03",UserCode="U03",EmailAddress="staff1@ncc.asia",UserTypeId=1,UserLevelId=8
                ,BranchId=3,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=4000},
            new User{Id = 4,UserName = "UserName04",UserCode="U04",EmailAddress="staff2@ncc.asia",UserTypeId=1,UserLevelId=6
                ,BranchId=2,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=4000},
            new User{Id = 5,UserName = "UserName05",UserCode="U05",EmailAddress="staff3@ncc.asia",UserTypeId=1,UserLevelId=7
                ,BranchId=3,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=4000},
            new User{Id = 6,UserName = "UserName06",UserCode="U06",EmailAddress="staff4@ncc.asia",UserTypeId=1,UserLevelId=9
                ,BranchId=2,MorningWorking=3.5,MorningStartAt=8.30,MorningEndAt=12
                ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30
                ,StartDate=DateTime.Now,AllowedLeaveDay=4,Salary=4000}
        };
        public static Branch[] Branches => new[]
        {
            new Branch{Id = 1 , Name = "Da Nang",Code="DN",DisplayName="Đà Nẵng",Color="Red"
                        ,MorningWorking = 3.5,MorningStartAt=8.30,MorningEndAt=12
                        ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30},
            new Branch{Id = 2 , Name = "Sai Gon",Code="SG",DisplayName="Sài Gòn",Color="Blue"
                        ,MorningWorking = 3.5,MorningStartAt=8.30,MorningEndAt=12
                        ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30},
            new Branch{Id = 3 , Name = "Ha Noi",Code="HN",DisplayName="Hà Nội",Color="Green"
                        ,MorningWorking = 3.5,MorningStartAt=8.30,MorningEndAt=12
                        ,AfternoonWorking=4.5,AfternoonStartAt=13,AfternoonEndAt=17.30},
        };
        public static ProjectStatus[] ProjectStatuses => new[]
        {
            new ProjectStatus{Id = 1 , Name = "Active"},
            new ProjectStatus{Id = 2 , Name = "Deactive"}
        };
        public static ProjectType[] ProjectTypes => new[]
        {
            new ProjectType{Id = 1 , Name = "Time & Materials"},
            new ProjectType{Id = 2 , Name = "Fixed Fee"},
            new ProjectType{Id = 3 , Name = "Non-Billable"},
            new ProjectType{Id = 4 , Name = "OCD"},
            new ProjectType{Id = 5 , Name = "Product"},
            new ProjectType{Id = 6 , Name = "Training"},
        };
        public static Project[] Projects=> new[]
        {
            new Project{Id = 1 , Name = "Project 1",Code="P1",StartAt=DateTime.Now,EndAt=DateTime.Now.AddMonths(6)
                        ,ClientId=1,Note = "Note project 1",ProjectTypeId=1,ProjectStatusId=1},
            new Project{Id = 2 , Name = "Project 2",Code="P2",StartAt=DateTime.Now,EndAt=DateTime.Now.AddMonths(3)
                        ,ClientId=2,Note = "Note project 2",ProjectTypeId=2,ProjectStatusId=2},
            new Project{Id = 3 , Name = "Project 3",Code="P3",StartAt=DateTime.Now,EndAt=DateTime.Now.AddMonths(9)
                        ,ClientId=3,Note = "Note project 3",ProjectTypeId=3,ProjectStatusId=1},
        };
        public static ProjectTask[] ProjectTasks => new[]
        {
            new ProjectTask{ProjectId=1,TaskId=1},
            new ProjectTask{ProjectId=1,TaskId=2},
            new ProjectTask{ProjectId=1,TaskId=3},
            new ProjectTask{ProjectId=2,TaskId=1},
            new ProjectTask{ProjectId=2,TaskId=3},
            new ProjectTask{ProjectId=2,TaskId=6},
            new ProjectTask{ProjectId=3,TaskId=5},
            new ProjectTask{ProjectId=3,TaskId=8}
        };
        public static ProjectMember[] ProjectMembers => new[]
        {
            new ProjectMember{ProjectId=1,UserId=3,RoleId=2,UserStatusId=1},
            new ProjectMember{ProjectId=1,UserId=4,RoleId=3,UserStatusId=1},
            new ProjectMember{ProjectId=1,UserId=1,RoleId=1,UserStatusId=2},
            new ProjectMember{ProjectId=2,UserId=3,RoleId=3,UserStatusId=1},
            new ProjectMember{ProjectId=2,UserId=4,RoleId=2,UserStatusId=1},
            new ProjectMember{ProjectId=2,UserId=5,RoleId=2,UserStatusId=2},
            new ProjectMember{ProjectId=2,UserId=6,RoleId=1,UserStatusId=1},
            new ProjectMember{ProjectId=3,UserId=3,RoleId=3,UserStatusId=1},
            new ProjectMember{ProjectId=3,UserId=4,RoleId=2,UserStatusId=2},
            new ProjectMember{ProjectId=3,UserId=5,RoleId=2,UserStatusId=1},
            new ProjectMember{ProjectId=3,UserId=6,RoleId=1,UserStatusId=1},
        };
        public static UserRole[] UserRoles => new[]
            {
                new UserRole{UserId=1,RoleId=1},
                new UserRole{UserId=2,RoleId=2},
                new UserRole{UserId=3,RoleId=2},
                new UserRole{UserId=4,RoleId=2},
                new UserRole{UserId=5,RoleId=2},
                new UserRole{UserId=6,RoleId=2},
                new UserRole{UserId=1,RoleId=2},
                new UserRole{UserId=2,RoleId=1},
                new UserRole{UserId=2,RoleId=3},
        };
        public static TimeSheetLogType[] TimeSheetLogTypes => new[]
        {
            new TimeSheetLogType{Id=1,Name="Normal working hours"},
            new TimeSheetLogType{Id=2,Name="Overtime"},
        };
        public static TimeSheetLog[] TimeSheetLogs => new[]
        {
            new TimeSheetLog{Id=1,UserId=1,ProjectId=1,TaskId=1,Note="Note project1_task1",WorkingTime=5,TimeSheetLogTypeId=1
                ,CreateAt=DateTime.Now,UpdateAt=DateTime.Now},

            new TimeSheetLog{Id=2,UserId=2,ProjectId=2,TaskId=2,Note="Note project2_task2",WorkingTime=6,TimeSheetLogTypeId=2
                ,CreateAt=DateTime.Now,UpdateAt=DateTime.Now},

            new TimeSheetLog{Id=3,UserId=3,ProjectId=3,TaskId=3,Note="Note project3_task3",WorkingTime=7,TimeSheetLogTypeId=1
                ,CreateAt=DateTime.Now,UpdateAt=DateTime.Now},
        };
        public static TardinessStatus[] TardinessStatuses => new[]
        {
            new TardinessStatus{Id=1,Name="TardinessStatus 1"},
            new TardinessStatus{Id=2,Name="TardinessStatus 2"},
            new TardinessStatus{Id=3,Name="TardinessStatus 3"}
        };
        public static Tardiness[] Tardinesses => new[]
        {
            new Tardiness{Id=1,UserId=1,CreateAt=DateTime.Now,RegistrationStart=8.30,RegistrationEnd=17.30,CheckIn=8.40,CheckOut=17.40
                ,TardinessStatusId=1,EditorId=null,UserNote="Work on task 1",NoteReply=""},
            new Tardiness{Id=2,UserId=2,CreateAt=DateTime.Now,RegistrationStart=8.30,RegistrationEnd=17.30,CheckIn=8.20,CheckOut=17.40
                ,TardinessStatusId=2,EditorId=3,UserNote="Work on task 2",NoteReply="Confirm"},
            new Tardiness{Id=3,UserId=4,CreateAt=DateTime.Now,RegistrationStart=8.30,RegistrationEnd=17.30,CheckIn=8.30,CheckOut=17.30
                ,TardinessStatusId=1,EditorId=null,UserNote="Work on task 3",NoteReply=""},
        };
    };
}

