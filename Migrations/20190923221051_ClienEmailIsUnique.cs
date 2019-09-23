using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class ClienEmailIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Email",
                table: "Clients");
        }
    }
}
