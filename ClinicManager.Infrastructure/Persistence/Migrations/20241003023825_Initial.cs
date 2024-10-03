using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Bloodtype = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Height = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Document = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialty = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CRMRegistration = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Care",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Healthinsurance = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime", nullable: false),
                    End = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeService = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Care", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Care_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Care_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Care_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "dbo",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Care_DoctorId",
                schema: "dbo",
                table: "Care",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Care_PatientId",
                schema: "dbo",
                table: "Care",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Care_ServiceId",
                schema: "dbo",
                table: "Care",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                schema: "dbo",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                schema: "dbo",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Care",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");
        }
    }
}
