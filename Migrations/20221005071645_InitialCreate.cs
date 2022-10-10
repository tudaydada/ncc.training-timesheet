using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MorningWorking = table.Column<double>(type: "float", nullable: false),
                    MorningStartAt = table.Column<double>(type: "float", nullable: false),
                    MorningEndAt = table.Column<double>(type: "float", nullable: false),
                    AfternoonWorking = table.Column<double>(type: "float", nullable: false),
                    AfternoonStartAt = table.Column<double>(type: "float", nullable: false),
                    AfternoonEndAt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Normalized = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TardinessStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TardinessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetLogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetLogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserLevelId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowedLeaveDay = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    MorningWorking = table.Column<double>(type: "float", nullable: false),
                    MorningStartAt = table.Column<double>(type: "float", nullable: false),
                    MorningEndAt = table.Column<double>(type: "float", nullable: false),
                    AfternoonWorking = table.Column<double>(type: "float", nullable: false),
                    AfternoonStartAt = table.Column<double>(type: "float", nullable: false),
                    AfternoonEndAt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserLevels_UserLevelId",
                        column: x => x.UserLevelId,
                        principalTable: "UserLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => new { x.ProjectId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMembers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMembers", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_UserStatuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tardinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationStart = table.Column<double>(type: "float", nullable: false),
                    RegistrationEnd = table.Column<double>(type: "float", nullable: false),
                    CheckIn = table.Column<double>(type: "float", nullable: false),
                    CheckOut = table.Column<double>(type: "float", nullable: false),
                    TardinessStatusId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    UserNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteReply = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tardinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tardinesses_TardinessStatuses_TardinessStatusId",
                        column: x => x.TardinessStatusId,
                        principalTable: "TardinessStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tardinesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingTime = table.Column<double>(type: "float", nullable: false),
                    TimeSheetLogTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetLog_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheetLog_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheetLog_TimeSheetLogType_TimeSheetLogTypeId",
                        column: x => x.TimeSheetLogTypeId,
                        principalTable: "TimeSheetLogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheetLog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "AfternoonEndAt", "AfternoonStartAt", "AfternoonWorking", "Code", "Color", "DisplayName", "MorningEndAt", "MorningStartAt", "MorningWorking", "Name" },
                values: new object[,]
                {
                    { 1, 17.300000000000001, 13.0, 4.5, "DN", "Red", "Đà Nẵng", 12.0, 8.3000000000000007, 3.5, "Da Nang" },
                    { 2, 17.300000000000001, 13.0, 4.5, "SG", "Blue", "Sài Gòn", 12.0, 8.3000000000000007, 3.5, "Sai Gon" },
                    { 3, 17.300000000000001, 13.0, 4.5, "HN", "Green", "Hà Nội", 12.0, 8.3000000000000007, 3.5, "Ha Noi" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "Address 1", "C01", "Client 01" },
                    { 2, "Address 2", "C02", "Client 02" },
                    { 3, "Address 3", "C03", "Client 03" },
                    { 4, "Address 4", "C04", "Client 04" },
                    { 5, "Address 5", "C05", "Client 05" },
                    { 6, "Address 6", "C06", "Client 06" },
                    { 7, "Address 7", "C07", "Client 07" },
                    { 8, "Address 8", "C08", "Client 08" },
                    { 9, "Address 9", "C09", "Client 09" },
                    { 10, "Address 10", "C10", "Client 10" }
                });

            migrationBuilder.InsertData(
                table: "ProjectStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Deactive" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Time & Materials" },
                    { 2, "Fixed Fee" },
                    { 3, "Non-Billable" },
                    { 4, "OCD" },
                    { 5, "Product" },
                    { 6, "Training" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DisplayName", "Name", "Normalized" },
                values: new object[,]
                {
                    { 1, "Quản trị viên", "Admin", "admin" },
                    { 2, "Nhân viên", "Staff", "staff" },
                    { 3, "Quản lý dự án", "Project Manager", "pm" }
                });

            migrationBuilder.InsertData(
                table: "TardinessStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TardinessStatus 1" },
                    { 2, "TardinessStatus 2" },
                    { 3, "TardinessStatus 3" }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Common" },
                    { 2, "Orther" }
                });

            migrationBuilder.InsertData(
                table: "TimeSheetLogType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Normal working hours" },
                    { 2, "Overtime" }
                });

            migrationBuilder.InsertData(
                table: "UserLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intern_0" },
                    { 2, "Intern_1" },
                    { 3, "Intern_2" },
                    { 4, "Intern_3" },
                    { 5, "Fresher_0" },
                    { 6, "Fresher_1" },
                    { 7, "Fresher_2" },
                    { 8, "Junior_0" },
                    { 9, "Junior_1" },
                    { 10, "Junior_2" },
                    { 11, "Middle_0" }
                });

            migrationBuilder.InsertData(
                table: "UserLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Middle_1" },
                    { 13, "Middle_2" },
                    { 14, "Senior_0" },
                    { 15, "Senior_1" },
                    { 16, "Senior_2" }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Staff" },
                    { 2, "Internship" },
                    { 3, "Collaborator" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "Code", "EndAt", "Name", "Note", "ProjectStatusId", "ProjectTypeId", "StartAt" },
                values: new object[,]
                {
                    { 1, 1, "P1", new DateTime(2023, 4, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4103), "Project 1", "Note project 1", 1, 1, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4093) },
                    { 2, 2, "P2", new DateTime(2023, 1, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4109), "Project 2", "Note project 2", 2, 2, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4109) },
                    { 3, 3, "P3", new DateTime(2023, 7, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4112), "Project 3", "Note project 3", 1, 3, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4112) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsDeleted", "Name", "TaskTypeId" },
                values: new object[,]
                {
                    { 1, false, "Task 1", 1 },
                    { 2, false, "Task 2", 2 },
                    { 3, false, "Task 3", 1 },
                    { 4, false, "Task 4", 2 },
                    { 5, false, "Task 5", 1 },
                    { 6, false, "Task 6", 2 },
                    { 7, false, "Task 7", 1 },
                    { 8, false, "Task 8", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AfternoonEndAt", "AfternoonStartAt", "AfternoonWorking", "AllowedLeaveDay", "BranchId", "EmailAddress", "IsActive", "MorningEndAt", "MorningStartAt", "MorningWorking", "Salary", "StartDate", "UserCode", "UserLevelId", "UserName", "UserTypeId" },
                values: new object[,]
                {
                    { 1, 17.300000000000001, 13.0, 4.5, 4, 1, "user1@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 2000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4478), "U01", 2, "UserName01", 2 },
                    { 2, 17.300000000000001, 13.0, 4.5, 4, 2, "admin1@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 6000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4481), "U02", 16, "UserName02", 3 },
                    { 3, 17.300000000000001, 13.0, 4.5, 4, 3, "staff1@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 4000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4483), "U03", 8, "UserName03", 1 },
                    { 4, 17.300000000000001, 13.0, 4.5, 4, 2, "staff2@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 4000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4485), "U04", 6, "UserName04", 1 },
                    { 5, 17.300000000000001, 13.0, 4.5, 4, 3, "staff3@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 4000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4486), "U05", 7, "UserName05", 1 },
                    { 6, 17.300000000000001, 13.0, 4.5, 4, 2, "staff4@ncc.asia", false, 12.0, 8.3000000000000007, 3.5, 4000.0, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(4488), "U06", 9, "UserName06", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "RoleId", "UserStatusId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 1, 3, 2, 1 },
                    { 1, 4, 3, 1 },
                    { 2, 3, 3, 1 },
                    { 2, 4, 2, 1 },
                    { 2, 5, 2, 2 },
                    { 2, 6, 1, 1 },
                    { 3, 3, 3, 1 },
                    { 3, 4, 2, 2 },
                    { 3, 5, 2, 1 },
                    { 3, 6, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 5 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Tardinesses",
                columns: new[] { "Id", "CheckIn", "CheckOut", "CreateAt", "EditorId", "NoteReply", "RegistrationEnd", "RegistrationStart", "TardinessStatusId", "UserId", "UserNote" },
                values: new object[,]
                {
                    { 1, 8.4000000000000004, 17.399999999999999, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5811), null, "", 17.300000000000001, 8.3000000000000007, 1, 1, "Work on task 1" },
                    { 2, 8.1999999999999993, 17.399999999999999, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5816), 3, "Confirm", 17.300000000000001, 8.3000000000000007, 2, 2, "Work on task 2" },
                    { 3, 8.3000000000000007, 17.300000000000001, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5818), null, "", 17.300000000000001, 8.3000000000000007, 1, 4, "Work on task 3" }
                });

            migrationBuilder.InsertData(
                table: "TimeSheetLog",
                columns: new[] { "Id", "CreateAt", "Note", "ProjectId", "TaskId", "TimeSheetLogTypeId", "UpdateAt", "UserId", "WorkingTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5754), "Note project1_task1", 1, 1, 1, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5756), 1, 5.0 },
                    { 2, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5757), "Note project2_task2", 2, 2, 2, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5758), 2, 6.0 },
                    { 3, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5759), "Note project3_task3", 3, 3, 1, new DateTime(2022, 10, 5, 14, 16, 45, 538, DateTimeKind.Local).AddTicks(5759), 3, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_RoleId",
                table: "ProjectMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_UserStatusId",
                table: "ProjectMembers",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_TaskId",
                table: "ProjectTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tardinesses_TardinessStatusId",
                table: "Tardinesses",
                column: "TardinessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tardinesses_UserId",
                table: "Tardinesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetLog_ProjectId",
                table: "TimeSheetLog",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetLog_TaskId",
                table: "TimeSheetLog",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetLog_TimeSheetLogTypeId",
                table: "TimeSheetLog",
                column: "TimeSheetLogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetLog_UserId",
                table: "TimeSheetLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLevelId",
                table: "Users",
                column: "UserLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectMembers");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Tardinesses");

            migrationBuilder.DropTable(
                name: "TimeSheetLog");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "TardinessStatuses");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TimeSheetLogType");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "UserLevels");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
