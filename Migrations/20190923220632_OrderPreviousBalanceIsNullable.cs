using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class OrderPreviousBalanceIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PreviousBalance",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PreviousBalance",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
