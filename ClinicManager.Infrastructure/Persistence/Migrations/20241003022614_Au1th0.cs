using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Au1th0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Bloodtype",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Height",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Telephone",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                schema: "dbo",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                schema: "dbo",
                table: "Patients",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Patients",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bloodtype",
                schema: "dbo",
                table: "Patients",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Patients",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "dbo",
                table: "Patients",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Patients",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Patients",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                schema: "dbo",
                table: "Patients",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Patients",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                schema: "dbo",
                table: "Patients",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                schema: "dbo",
                table: "Patients",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
