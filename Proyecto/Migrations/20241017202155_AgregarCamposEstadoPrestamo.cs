using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposEstadoPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DevolucionConfirmadaPorOperador",
                table: "Prestamo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DevueltoPorSocio",
                table: "Prestamo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EntregadoPorOperador",
                table: "Prestamo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecibidoConfirmadoPorSocio",
                table: "Prestamo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevolucionConfirmadaPorOperador",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "DevueltoPorSocio",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "EntregadoPorOperador",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "RecibidoConfirmadoPorSocio",
                table: "Prestamo");
        }
    }
}
