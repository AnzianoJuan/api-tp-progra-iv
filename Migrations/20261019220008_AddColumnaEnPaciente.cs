using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnaEnPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ObraSocialId",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "IdObraSocial",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdObraSocial",
                table: "Pacientes",
                column: "IdObraSocial");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes",
                column: "IdObraSocial",
                principalTable: "ObrasSociales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_IdObraSocial",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdObraSocial",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId",
                principalTable: "ObrasSociales",
                principalColumn: "Id");
        }
    }
}
