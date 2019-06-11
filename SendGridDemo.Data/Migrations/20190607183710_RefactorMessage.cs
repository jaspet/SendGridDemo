using Microsoft.EntityFrameworkCore.Migrations;

namespace SendGridDemo.Data.Migrations
{
    public partial class RefactorMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendGridMessageId",
                table: "EmailMessage",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "EmailMessageId",
                table: "EmailMessage",
                newName: "pkMessageId");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailMessage",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "EmailMessage",
                newName: "SendGridMessageId");

            migrationBuilder.RenameColumn(
                name: "pkMessageId",
                table: "EmailMessage",
                newName: "EmailMessageId");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "EmailMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
