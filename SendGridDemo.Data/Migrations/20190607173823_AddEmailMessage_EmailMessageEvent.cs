using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SendGridDemo.Data.Migrations
{
    public partial class AddEmailMessage_EmailMessageEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailMessage",
                columns: table => new
                {
                    EmailMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SendGridMessageId = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessage", x => x.EmailMessageId);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessageEvent",
                columns: table => new
                {
                    EmailMessageEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fkEmailMessageId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<double>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    SendGridEventId = table.Column<string>(maxLength: 100, nullable: true),
                    Response = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessageEvent", x => x.EmailMessageEventId);
                    table.ForeignKey(
                        name: "FK_EmailMessageEvent_EmailMessage_fkEmailMessageId",
                        column: x => x.fkEmailMessageId,
                        principalTable: "EmailMessage",
                        principalColumn: "EmailMessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessageEvent_fkEmailMessageId",
                table: "EmailMessageEvent",
                column: "fkEmailMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailMessageEvent");

            migrationBuilder.DropTable(
                name: "EmailMessage");
        }
    }
}
