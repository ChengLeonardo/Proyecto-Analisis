using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class BorrarCamposInesesariosPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorRegreso",
                table: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "IdOperadorRegreso",
                table: "Prestamo",
                newName: "OperadorRegresoIdOperador");

            migrationBuilder.RenameColumn(
                name: "IdOperadorEntrega",
                table: "Prestamo",
                newName: "OperadorEntregaIdOperador");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_IdOperadorRegreso",
                table: "Prestamo",
                newName: "IX_Prestamo_OperadorRegresoIdOperador");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_IdOperadorEntrega",
                table: "Prestamo",
                newName: "IX_Prestamo_OperadorEntregaIdOperador");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_OperadorEntregaIdOperador",
                table: "Prestamo",
                column: "OperadorEntregaIdOperador",
                principalTable: "Operador",
                principalColumn: "IdOperador");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_OperadorRegresoIdOperador",
                table: "Prestamo",
                column: "OperadorRegresoIdOperador",
                principalTable: "Operador",
                principalColumn: "IdOperador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_OperadorEntregaIdOperador",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_OperadorRegresoIdOperador",
                table: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "OperadorRegresoIdOperador",
                table: "Prestamo",
                newName: "IdOperadorRegreso");

            migrationBuilder.RenameColumn(
                name: "OperadorEntregaIdOperador",
                table: "Prestamo",
                newName: "IdOperadorEntrega");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_OperadorRegresoIdOperador",
                table: "Prestamo",
                newName: "IX_Prestamo_IdOperadorRegreso");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_OperadorEntregaIdOperador",
                table: "Prestamo",
                newName: "IX_Prestamo_IdOperadorEntrega");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo",
                column: "IdOperadorEntrega",
                principalTable: "Operador",
                principalColumn: "IdOperador");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorRegreso",
                table: "Prestamo",
                column: "IdOperadorRegreso",
                principalTable: "Operador",
                principalColumn: "IdOperador");
        }
    }
}
