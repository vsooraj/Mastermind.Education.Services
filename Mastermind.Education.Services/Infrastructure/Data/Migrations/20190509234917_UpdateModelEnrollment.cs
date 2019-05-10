using Microsoft.EntityFrameworkCore.Migrations;

namespace Mastermind.Education.Services.Infrastructure.Data.Migrations
{
    public partial class UpdateModelEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Enrollment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Enrollment");
        }
    }
}
