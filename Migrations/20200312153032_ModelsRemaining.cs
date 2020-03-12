using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ActivosFijosAPI.Migrations
{
    public partial class ModelsRemaining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    TipoPersona = table.Column<int>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposActivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    CuentaContableCompra = table.Column<string>(nullable: true),
                    CuentaContableDepreciacion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    TipoActivoId = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ValorCompra = table.Column<decimal>(nullable: false),
                    DepreciacionAcumulada = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosFijos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_TiposActivos_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "TiposActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculosDepreciaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoPreceso = table.Column<int>(nullable: false),
                    MesPreceso = table.Column<int>(nullable: false),
                    ActivoFijoId = table.Column<int>(nullable: false),
                    FechaProceso = table.Column<DateTime>(nullable: false),
                    MontoDepreciado = table.Column<decimal>(nullable: false),
                    DepreciacionAcumulada = table.Column<decimal>(nullable: false),
                    CuentaCompra = table.Column<string>(nullable: true),
                    CuentaDepreciacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculosDepreciaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculosDepreciaciones_ActivosFijos_ActivoFijoId",
                        column: x => x.ActivoFijoId,
                        principalTable: "ActivosFijos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_DepartamentoId",
                table: "ActivosFijos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_TipoActivoId",
                table: "ActivosFijos",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculosDepreciaciones_ActivoFijoId",
                table: "CalculosDepreciaciones",
                column: "ActivoFijoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculosDepreciaciones");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "TiposActivos");
        }
    }
}
