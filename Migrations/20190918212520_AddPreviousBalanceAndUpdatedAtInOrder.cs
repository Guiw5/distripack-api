using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class AddPreviousBalanceAndUpdatedAtInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "PreviousBalance",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Items",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
