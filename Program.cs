using Microsoft.EntityFrameworkCore;
using TimeSheet.Data;
using TimeSheet.Services;
using TimeSheet.Services.Implement;
using TimeSheet.Services.Interface;
using TimeSheet.Services.Interface.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.

services.AddControllers();
builder.Services.AddSwaggerGen();
services.AddEndpointsApiExplorer();
services.AddDbContext<TimeSheetDataContext>(options => options.UseSqlServer(config.GetConnectionString("DatabaseName")));

//Depedency Injection
services.AddTransient<IBranchRepository, BranchRepository>();
services.AddTransient<IClientRepository, ClientRepository>();
services.AddTransient<IProjectMemberRepository, ProjectMemberRepository>();
services.AddTransient<IProjectRepository, ProjectRepository>();
services.AddTransient<IProjectStatusRepository, ProjectStatusRepository>();
services.AddTransient<IProjectTaskRepository, ProjectTaskRepository>();
services.AddTransient<IProjectTypeRepository, ProjectTypeRepository>();
services.AddTransient<IRoleRepository, RoleRepository>();
services.AddTransient<ITardinessRepository, TardinessRepository>();
services.AddTransient<ITardinessStatusRepository, TardinessStatusRepository>();
services.AddTransient<ITaskRepository, TaskRepository>();
services.AddTransient<ITaskTypeRepository, TaskTypeRepository>();
services.AddTransient<ITimeSheetLogRepository, TimeSheetLogRepository>();
services.AddTransient<ITimeSheetLogTypeRepository, TimeSheetLogTypeRepository>();
services.AddTransient<IUserLevelRepository, UserLevelRepository>();
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<IUserRoleRepository, UserRoleRepository>();
services.AddTransient<IUserStatusRepository, UserStatusRepository>();
services.AddTransient<IUserTypeRepository, UserTypeRepository>();


services.AddTransient<IBranchService, BranchService>();
services.AddTransient<IClientService, ClientService>();
services.AddTransient<IProjectService, ProjectService>();
services.AddTransient<ITardinessService, TardinessService>();
services.AddTransient<ITaskService, TaskService>();
services.AddTransient<ITimeSheetLogService, TimeSheetLogService>();
services.AddTransient<IUserService, UserService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
