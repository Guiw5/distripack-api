using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class InitialAmountInCheckingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InitialAmount",
                table: "CheckingAccount",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialAmount",
                table: "CheckingAccount");
        }
    }
}
