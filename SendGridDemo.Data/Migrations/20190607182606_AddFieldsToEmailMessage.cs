using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SendGridDemo.Data.Migrations
{
    public partial class AddFieldsToEmailMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "EmailMessage",
                newName: "To");

            migrationBuilder.AddColumn<string>(
                name: "MessageText",
                table: "EmailMessage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageText",
                table: "EmailMessage");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "EmailMessage",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                });
        }
    }
}
