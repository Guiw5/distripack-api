using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    EsRubro = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Sku = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 255, nullable: false),
                    Marca = table.Column<string>(maxLength: 50, nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Capacidad = table.Column<string>(maxLength: 50, nullable: true),
                    Medidas = table.Column<string>(maxLength: 50, nullable: true),
                    Material = table.Column<string>(maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaEliminado = table.Column<DateTime>(nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => new { x.Id, x.Sku });
                });

            migrationBuilder.CreateTable(
                name: "ProductoCategoria",
                columns: table => new
                {
                    CategoriaId = table.Column<byte>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    ProductoSku = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCategoria", x => new { x.CategoriaId, x.ProductoId, x.ProductoSku });
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoCategoria_Productos_ProductoId_ProductoSku",
                        columns: x => new { x.ProductoId, x.ProductoSku },
                        principalTable: "Productos",
                        principalColumns: new[] { "Id", "Sku" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_ProductoId_ProductoSku",
                table: "ProductoCategoria",
                columns: new[] { "ProductoId", "ProductoSku" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoCategoria");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
