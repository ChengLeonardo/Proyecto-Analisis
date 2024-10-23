﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(ProyectoDbContext))]
    partial class ProyectoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AutorTitulo", b =>
                {
                    b.Property<int>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int>("IdTitulo")
                        .HasColumnType("int");

                    b.HasKey("IdAutor", "IdTitulo");

                    b.HasIndex("IdTitulo");

                    b.ToTable("AutorTitulo", (string)null);
                });

            modelBuilder.Entity("GeneroTitulo", b =>
                {
                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdTitulo")
                        .HasColumnType("int");

                    b.HasKey("IdGenero", "IdTitulo");

                    b.HasIndex("IdTitulo");

                    b.ToTable("GeneroTitulo", (string)null);
                });

            modelBuilder.Entity("Proyecto.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdAutor"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdAutor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Proyecto.Models.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEditorial"));

                    b.Property<string>("editorial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEditorial");

                    b.ToTable("Editorial");
                });

            modelBuilder.Entity("Proyecto.Models.Ejemplar", b =>
                {
                    b.Property<uint>("IdEjemplar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<uint>("IdEjemplar"));

                    b.Property<bool>("Disponible")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.Property<uint>("NroEjemplar")
                        .HasColumnType("int unsigned");

                    b.HasKey("IdEjemplar");

                    b.HasIndex("IdLibro");

                    b.ToTable("Ejemplar");
                });

            modelBuilder.Entity("Proyecto.Models.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdGenero"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RutaFoto")
                        .HasColumnType("longtext");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdGenero");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("Proyecto.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<double>("Calificacion")
                        .HasColumnType("double");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaAgregada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<int>("IdTitulo")
                        .HasColumnType("int");

                    b.Property<string>("RutaFoto")
                        .HasColumnType("longtext");

                    b.HasKey("IdLibro");

                    b.HasIndex("IdEditorial");

                    b.HasIndex("IdTitulo");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("Proyecto.Models.Operador", b =>
                {
                    b.Property<int>("IdOperador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOperador"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdOperador");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Operador");
                });

            modelBuilder.Entity("Proyecto.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdPrestamo"));

                    b.Property<bool>("Cancelado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DevolucionConfirmadaPorOperador")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DevueltoPorSocio")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EntregadoPorOperador")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("IdEjemplar")
                        .HasColumnType("int unsigned");

                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.Property<int?>("OperadorEntregaIdOperador")
                        .HasColumnType("int");

                    b.Property<int?>("OperadorRegresoIdOperador")
                        .HasColumnType("int");

                    b.Property<bool>("Recibido")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("RecibidoConfirmadoPorSocio")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Regreso")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Salida")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("IdEjemplar");

                    b.HasIndex("IdSocio");

                    b.HasIndex("OperadorEntregaIdOperador");

                    b.HasIndex("OperadorRegresoIdOperador");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Proyecto.Models.Socio", b =>
                {
                    b.Property<int>("IdSocio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdSocio"));

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdSocio");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Socio");
                });

            modelBuilder.Entity("Proyecto.Models.Titulo", b =>
                {
                    b.Property<int>("IdTitulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdTitulo"));

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdTitulo");

                    b.ToTable("Titulo");
                });

            modelBuilder.Entity("Proyecto.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int")
                        .HasColumnName("TipoUsuario");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AutorTitulo", b =>
                {
                    b.HasOne("Proyecto.Models.Autor", null)
                        .WithMany()
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Titulo", null)
                        .WithMany()
                        .HasForeignKey("IdTitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneroTitulo", b =>
                {
                    b.HasOne("Proyecto.Models.Genero", null)
                        .WithMany()
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Titulo", null)
                        .WithMany()
                        .HasForeignKey("IdTitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto.Models.Ejemplar", b =>
                {
                    b.HasOne("Proyecto.Models.Libro", "Libro")
                        .WithMany("Ejemplares")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("Proyecto.Models.Libro", b =>
                {
                    b.HasOne("Proyecto.Models.Editorial", "Editorial")
                        .WithMany("Libros")
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Titulo", "Titulo")
                        .WithMany("Libros")
                        .HasForeignKey("IdTitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Proyecto.Models.Operador", b =>
                {
                    b.HasOne("Proyecto.Models.Usuario", "Usuario")
                        .WithOne("Operador")
                        .HasForeignKey("Proyecto.Models.Operador", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto.Models.Prestamo", b =>
                {
                    b.HasOne("Proyecto.Models.Ejemplar", "Ejemplar")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdEjemplar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Socio", "Socio")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Operador", "OperadorEntrega")
                        .WithMany("PrestamosEntregados")
                        .HasForeignKey("OperadorEntregaIdOperador");

                    b.HasOne("Proyecto.Models.Operador", "OperadorRegreso")
                        .WithMany("PrestamosRegresados")
                        .HasForeignKey("OperadorRegresoIdOperador");

                    b.Navigation("Ejemplar");

                    b.Navigation("OperadorEntrega");

                    b.Navigation("OperadorRegreso");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("Proyecto.Models.Socio", b =>
                {
                    b.HasOne("Proyecto.Models.Usuario", "Usuario")
                        .WithOne("Socio")
                        .HasForeignKey("Proyecto.Models.Socio", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto.Models.Editorial", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Proyecto.Models.Ejemplar", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("Proyecto.Models.Libro", b =>
                {
                    b.Navigation("Ejemplares");
                });

            modelBuilder.Entity("Proyecto.Models.Operador", b =>
                {
                    b.Navigation("PrestamosEntregados");

                    b.Navigation("PrestamosRegresados");
                });

            modelBuilder.Entity("Proyecto.Models.Socio", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("Proyecto.Models.Titulo", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Proyecto.Models.Usuario", b =>
                {
                    b.Navigation("Operador");

                    b.Navigation("Socio");
                });
#pragma warning restore 612, 618
        }
    }
}
