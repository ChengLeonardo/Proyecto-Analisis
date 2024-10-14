using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    editorial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RutaFoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IdGenero);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Titulo",
                columns: table => new
                {
                    IdTitulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulo", x => x.IdTitulo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pass = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AutorTitulo",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IdTitulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorTitulo", x => new { x.IdAutor, x.IdTitulo });
                    table.ForeignKey(
                        name: "FK_AutorTitulo_Autor_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorTitulo_Titulo_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "Titulo",
                        principalColumn: "IdTitulo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GeneroTitulo",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdTitulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroTitulo", x => new { x.IdGenero, x.IdTitulo });
                    table.ForeignKey(
                        name: "FK_GeneroTitulo_Genero_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Genero",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroTitulo_Titulo_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "Titulo",
                        principalColumn: "IdTitulo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEditorial = table.Column<int>(type: "int", nullable: false),
                    IdTitulo = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RutaFoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAgregada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Calificacion = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalTable: "Editorial",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Titulo_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "Titulo",
                        principalColumn: "IdTitulo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operador",
                columns: table => new
                {
                    IdOperador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operador", x => x.IdOperador);
                    table.ForeignKey(
                        name: "FK_Operador_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.IdSocio);
                    table.ForeignKey(
                        name: "FK_Socio_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ejemplar",
                columns: table => new
                {
                    IdEjemplar = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    NroEjemplar = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejemplar", x => x.IdEjemplar);
                    table.ForeignKey(
                        name: "FK_Ejemplar_Libro_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEjemplar = table.Column<uint>(type: "int unsigned", nullable: false),
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdOperadorEntrega = table.Column<int>(type: "int", nullable: false),
                    Regreso = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdOperadorRegreso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamo_Ejemplar_IdEjemplar",
                        column: x => x.IdEjemplar,
                        principalTable: "Ejemplar",
                        principalColumn: "IdEjemplar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Operador_IdOperadorEntrega",
                        column: x => x.IdOperadorEntrega,
                        principalTable: "Operador",
                        principalColumn: "IdOperador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Operador_IdOperadorRegreso",
                        column: x => x.IdOperadorRegreso,
                        principalTable: "Operador",
                        principalColumn: "IdOperador");
                    table.ForeignKey(
                        name: "FK_Prestamo_Socio_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socio",
                        principalColumn: "IdSocio",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AutorTitulo_IdTitulo",
                table: "AutorTitulo",
                column: "IdTitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Ejemplar_IdLibro",
                table: "Ejemplar",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroTitulo_IdTitulo",
                table: "GeneroTitulo",
                column: "IdTitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdEditorial",
                table: "Libro",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdTitulo",
                table: "Libro",
                column: "IdTitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Operador_IdUsuario",
                table: "Operador",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdEjemplar",
                table: "Prestamo",
                column: "IdEjemplar");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdOperadorEntrega",
                table: "Prestamo",
                column: "IdOperadorEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdOperadorRegreso",
                table: "Prestamo",
                column: "IdOperadorRegreso");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdSocio",
                table: "Prestamo",
                column: "IdSocio");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdUsuario",
                table: "Socio",
                column: "IdUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorTitulo");

            migrationBuilder.DropTable(
                name: "GeneroTitulo");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Ejemplar");

            migrationBuilder.DropTable(
                name: "Operador");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Editorial");

            migrationBuilder.DropTable(
                name: "Titulo");
        }
    }
}
