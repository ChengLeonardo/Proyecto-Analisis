using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrestamoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo");

            migrationBuilder.AlterColumn<int>(
                name: "IdOperadorEntrega",
                table: "Prestamo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo",
                column: "IdOperadorEntrega",
                principalTable: "Operador",
                principalColumn: "IdOperador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo");

            migrationBuilder.AlterColumn<int>(
                name: "IdOperadorEntrega",
                table: "Prestamo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Operador_IdOperadorEntrega",
                table: "Prestamo",
                column: "IdOperadorEntrega",
                principalTable: "Operador",
                principalColumn: "IdOperador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
