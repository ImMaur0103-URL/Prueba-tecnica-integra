using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba_Tecnica_Integra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_GRUPO_PROV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GRUPO_PROV", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_PROVEEDOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDGrupoProv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PROVEEDOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_PROVEEDOR_T_GRUPO_PROV_IDGrupoProv",
                        column: x => x.IDGrupoProv,
                        principalTable: "T_GRUPO_PROV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ARTÍCULO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IDProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ARTÍCULO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_ARTÍCULO_T_PROVEEDOR_IDProveedor",
                        column: x => x.IDProveedor,
                        principalTable: "T_PROVEEDOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ARTÍCULO_IDProveedor",
                table: "T_ARTÍCULO",
                column: "IDProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_T_PROVEEDOR_IDGrupoProv",
                table: "T_PROVEEDOR",
                column: "IDGrupoProv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ARTÍCULO");

            migrationBuilder.DropTable(
                name: "T_PROVEEDOR");

            migrationBuilder.DropTable(
                name: "T_GRUPO_PROV");
        }
    }
}
