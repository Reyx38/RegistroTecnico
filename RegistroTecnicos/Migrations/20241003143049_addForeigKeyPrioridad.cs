using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class addForeigKeyPrioridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrioridadId",
                table: "Trabajos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_PrioridadId",
                table: "Trabajos",
                column: "PrioridadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajos_Prioridades_PrioridadId",
                table: "Trabajos",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "PrioridadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajos_Prioridades_PrioridadId",
                table: "Trabajos");

            migrationBuilder.DropIndex(
                name: "IX_Trabajos_PrioridadId",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "PrioridadId",
                table: "Trabajos");
        }
    }
}
