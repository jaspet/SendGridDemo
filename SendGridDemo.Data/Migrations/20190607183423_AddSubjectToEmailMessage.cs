using Microsoft.EntityFrameworkCore.Migrations;

namespace SendGridDemo.Data.Migrations
{
    public partial class AddSubjectToEmailMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "EmailMessage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "EmailMessage");
        }
    }
}
