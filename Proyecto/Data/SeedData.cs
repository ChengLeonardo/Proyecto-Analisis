using Proyecto.Data.Repositorios;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data;

public class SeedData
{
    public static void Initialize(IRepoOperador repoOperador, IRepoEjemplar repoEjemplar, IRepoPrestamo repoPrestamo, IRepoSocio repoSocio, IRepoLibro repoLibro, IRepoEditorial repoEditorial, IRepoAutor repoAutor, IRepoTitulo repoTitulo, IRepoAutorTitulo repoAutorTitulo, IRepoGenero repoGenero, IRepoGeneroTitulo repoGeneroTitulo)
    {
        // Verificar si ya existen datos en la base de datos
        if (!repoOperador.Select().Any())
        {
            // Seed Autor
            var autor = new Autor
            {
                Apellido = "Cheng",
                AutorTitulos = new List<AutorTitulo>(),
                IdAutor = 0,
                Nombre = "leonardo"
            };

            repoAutor.Insert(autor, "IdAutor");


            //Seed Operador
            var operadorAdministrador = new Operador
            {
                IdOperador = 0,
                Pass = BCrypt.Net.BCrypt.HashPassword("admin"), // Asegúrate de que la contraseña esté correctamente hasheada
                Nombre = "Leonardo",
                Apellido = "Cheng",
                Email = "leonardo.chenget12de1@gmail.com",
                Usuario  = "admin"
            };

            repoOperador.Insert(operadorAdministrador, "IdOperador");

            //Seed Editorial
            var editorial = new Editorial
            { 
                editorial = "Test", 
                IdEditorial = 0, 
                Libros = new List<Libro>()
            };

            repoEditorial.Insert(editorial, "IdEditorial");

            // Seed Titulo
            var titulo = new Titulo
            {
                AutorTitulos = new List<AutorTitulo>(),
                GeneroTitulos = new List<GeneroTitulo>(),
                IdTitulo = 0,
                Libros = new List<Libro>(),
                titulo = "TestTitulo"
            };

            repoTitulo.Insert(titulo, "IdTitulo");

            //Seed Libro
            var libro = new Libro
            { 
                Editorial = repoEditorial.IdSelect(1),
                Calificacion = 5.0,
                Ejemplares = new List<Ejemplar>(),
                FechaAgregada = DateTime.Now,
                IdTitulo = 1,
                IdEditorial = 1,
                IdLibro = 0,
                ISBN = "Test",
                RutaFoto = null,
                Titulo = repoTitulo.IdSelect(1)
            };

            repoLibro.Insert(libro, "IdLibro");

            //Seed Prestamo
            var prestamotest = new Prestamo
            {
                Ejemplar = repoEjemplar.IdSelect(1),
                IdEjemplar = 1,
                IdOperadorEntrega = 1,
                IdOperadorRegreso = null,
                IdPrestamo = 0,
                IdSocio = 100,
                OperadorEntrega = repoOperador.IdSelect(1),
                OperadorRegreso = null,
                Regreso = null,
                Salida = null,
                Socio = repoSocio.IdSelect(1)
            };

            repoPrestamo.Insert(prestamotest, "IdPrestamo");

            // Seed AutorTitulo
            var AutorTitulo = new AutorTitulo()
            {
                Autor = repoAutor.IdSelect(2),
                IdAutor = 2,
                IdTitulo = 2,
                Titulo = repoTitulo.IdSelect(2)
            };

            
        }
    }
}
