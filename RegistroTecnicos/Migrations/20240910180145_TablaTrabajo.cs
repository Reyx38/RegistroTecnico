using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class TablaTrabajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Trabajos",
                type: "TEXT",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Trabajos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Monto",
                table: "Trabajos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TecnicoId",
                table: "Trabajos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TecnicosTecnicoId",
                table: "Trabajos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_TecnicosTecnicoId",
                table: "Trabajos",
                column: "TecnicosTecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajos_Tecnicos_TecnicosTecnicoId",
                table: "Trabajos",
                column: "TecnicosTecnicoId",
                principalTable: "Tecnicos",
                principalColumn: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabajos_Tecnicos_TecnicosTecnicoId",
                table: "Trabajos");

            migrationBuilder.DropIndex(
                name: "IX_Trabajos_TecnicosTecnicoId",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "TecnicoId",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "TecnicosTecnicoId",
                table: "Trabajos");
        }
    }
}
