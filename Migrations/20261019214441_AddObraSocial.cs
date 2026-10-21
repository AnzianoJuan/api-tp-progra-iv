using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddObraSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObraSocial",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_ObrasSociales_Nombre",
                table: "ObrasSociales",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes",
                column: "ObraSocialId",
                principalTable: "ObrasSociales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ObrasSociales_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "ObrasSociales");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ObraSocialId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ObraSocialId",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "ObraSocial",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
