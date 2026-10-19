using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnaEnPacienteYagregadaLaColumnaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes");

            migrationBuilder.AlterColumn<int>(
                name: "IdObraSocial",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes",
                column: "IdObraSocial",
                principalTable: "ObrasSociales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes");

            migrationBuilder.AlterColumn<int>(
                name: "IdObraSocial",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_IdObraSocial",
                table: "Pacientes",
                column: "IdObraSocial",
                principalTable: "ObrasSociales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
