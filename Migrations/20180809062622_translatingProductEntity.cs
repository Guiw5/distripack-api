using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class translatingProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Products",
                newName: "Nick");

            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "Products",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "BusinessName", "CelPhone", "Cuit", "Location", "Mail", "Name", "Nick", "Phone", "PostalCode" },
                values: new object[] { 1, null, null, null, null, null, "lafonda@gmail.com", "GuidoClient", "La Fonda", null, null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "BusinessName", "CelPhone", "Cuit", "Location", "Mail", "Name", "Nick", "Phone", "PostalCode" },
                values: new object[] { 2, null, null, null, null, null, "wagner.guido.5@gmail.com", "BrunoClient", "La Casa", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Nick",
                table: "Products",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Alias");
        }
    }
}
