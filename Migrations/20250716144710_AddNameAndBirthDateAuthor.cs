using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAsp.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAndBirthDateAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Authors");
        }
    }
}
