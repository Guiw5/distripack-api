using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    Cuit = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    TelefonoFijo = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
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
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Descuento = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "PedidoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    ProductoSku = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalles", x => new { x.PedidoId, x.Id });
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Productos_ProductoId_ProductoSku",
                        columns: x => new { x.ProductoId, x.ProductoSku },
                        principalTable: "Productos",
                        principalColumns: new[] { "Id", "Sku" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_ProductoId_ProductoSku",
                table: "PedidoDetalles",
                columns: new[] { "ProductoId", "ProductoSku" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCategoria_ProductoId_ProductoSku",
                table: "ProductoCategoria",
                columns: new[] { "ProductoId", "ProductoSku" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoDetalles");

            migrationBuilder.DropTable(
                name: "ProductoCategoria");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
