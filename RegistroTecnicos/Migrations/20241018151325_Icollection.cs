using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Icollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrabajoId",
                table: "Articulos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 1,
                column: "TrabajoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 2,
                column: "TrabajoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 3,
                column: "TrabajoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TrabajoId",
                table: "Articulos",
                column: "TrabajoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Trabajos_TrabajoId",
                table: "Articulos",
                column: "TrabajoId",
                principalTable: "Trabajos",
                principalColumn: "TrabajoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Trabajos_TrabajoId",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_TrabajoId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "TrabajoId",
                table: "Articulos");
        }
    }
}
