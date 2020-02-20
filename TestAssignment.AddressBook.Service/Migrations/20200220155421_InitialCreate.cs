using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAssignment.AddressBook.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTACT",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 32, nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(maxLength: 20, nullable: false),
                    ADDRESS = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_PHONE",
                table: "CONTACT",
                column: "PHONE",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTACT");
        }
    }
}
