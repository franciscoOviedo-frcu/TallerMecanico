using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMecanico.Api.Migrations
{
    /// <inheritdoc />
    public partial class mapear_Trabajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto = table.Column<float>(type: "real", nullable: false),
                    descripcionArreglo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    vehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trabajos_Vehiculos_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_vehiculoId",
                table: "Trabajos",
                column: "vehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");
        }
    }
}
