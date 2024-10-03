using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Auth0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Bloodtype",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Height",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Telephone",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bloodtype",
                schema: "dbo",
                table: "Users",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "dbo",
                table: "Users",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Users",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                schema: "dbo",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                schema: "dbo",
                table: "Users",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                schema: "dbo",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Bloodtype",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Height",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telephone",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bloodtype",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Doctors",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                schema: "dbo",
                table: "Doctors",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
