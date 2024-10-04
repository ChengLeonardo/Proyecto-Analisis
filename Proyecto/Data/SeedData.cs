using Proyecto.Data.Repositorios;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data;

public class SeedData
{
    public static void Initialize(IRepoOperador repoOperador, IRepoEjemplar repoEjemplar, IRepoPrestamo repoPrestamo, IRepoSocio repoSocio, IRepoLibro repoLibro, IRepoEditorial repoEditorial, IRepoAutor repoAutor, IRepoTitulo repoTitulo, IRepoGenero repoGenero)
    {
        // Verificar si ya existen datos en la base de datos
        if (!repoOperador.Select().Any())
        {
            //Seed Operador
            var operadorAdministrador = new Operador
            {
                IdOperador = 0,
                Pass = BCrypt.Net.BCrypt.HashPassword("admin"),
                Nombre = "Leonardo",
                Apellido = "Cheng",
                Email = "leonardo.chenget12de1@gmail.com",
                Usuario  = "admin"
            };

            var operadorComun1 = new Operador
            {
                IdOperador = 0,
                Pass = BCrypt.Net.BCrypt.HashPassword("operador1"),
                Nombre = "Cheng",
                Apellido = "Leonardo",
                Email = "leonardo.chen1@gmail.com",
                Usuario  = "operador1"
            };

            var operadorComun2 = new Operador
            {
                IdOperador = 0,
                Pass = BCrypt.Net.BCrypt.HashPassword("operador2"),
                Nombre = "Maria",
                Apellido = "Gomez",
                Email = "maria.gomez@gmail.com",
                Usuario = "operador2"
            };

            var operadorComun3 = new Operador
            {
                IdOperador = 0,
                Pass = BCrypt.Net.BCrypt.HashPassword("operador3"),
                Nombre = "Juan",
                Apellido = "Perez",
                Email = "juan.perez@gmail.com",
                Usuario = "operador3"
            };


            repoOperador.Insert(operadorAdministrador, "IdOperador");
            repoOperador.Insert(operadorComun1, "IdOperador");
            repoOperador.Insert(operadorComun2, "IdOperador");
            repoOperador.Insert(operadorComun3, "IdOperador");


            
            // Seed Autor
            var autor1 = new Autor
            {
                IdAutor = 0,
                Apellido = "Garcia",
                Nombre = "Gabriel",
                Titulos = new List<Titulo>()
            };

            var autor2 = new Autor
            {
                IdAutor = 0,
                Apellido = "Martinez",
                Nombre = "Jose",
                Titulos = new List<Titulo>()
            };

            repoAutor.Insert(autor1, "IdAutor");
            repoAutor.Insert(autor2, "IdAutor");

            //Seed Editorial
            var editorial1 = new Editorial
            {
                editorial = "Editorial Moderna",
                IdEditorial = 0,
                Libros = new List<Libro>()
            };

            var editorial2 = new Editorial
            {
                editorial = "Editorial Clásica",
                IdEditorial = 0,
                Libros = new List<Libro>()
            };

            repoEditorial.Insert(editorial1, "IdEditorial");
            repoEditorial.Insert(editorial2, "IdEditorial");


            //Seed Genero
            var genero1 = new Genero
            {
                genero = "Ficción",
                IdGenero = 0,
            };

            var genero2 = new Genero
            {
                genero = "Ciencia Ficción",
                IdGenero = 0
            };

            var genero3 = new Genero
            {
                genero = "Fantasía",
                IdGenero = 0
            };

            repoGenero.Insert(genero1, "IdGenero");
            repoGenero.Insert(genero2, "IdGenero");
            repoGenero.Insert(genero3, "IdGenero");

            // Seed Titulo
            var titulo1 = new Titulo
            {
                titulo = "Cien Años de Soledad",
                IdTitulo = 0,
                Autores = new List<Autor> { repoAutor.IdSelect(1) }, // Relacionando con autor1 (Gabriel Garcia)
                Generos = new List<Genero> { repoGenero.IdSelect(1) } // Asumiendo que tienes géneros
            };

            var titulo2 = new Titulo
            {
                titulo = "El Otoño del Patriarca",
                IdTitulo = 0,
                Autores = new List<Autor> { repoAutor.IdSelect(2) }, // Relacionando con autor2 (Jose Martinez)
                Generos = new List<Genero> { repoGenero.IdSelect(2) }
            };

            repoTitulo.Insert(titulo1, "IdTitulo");
            repoTitulo.Insert(titulo2, "IdTitulo");


            //Seed Libro
            var libro1 = new Libro
            {
                Editorial = repoEditorial.IdSelect(1), // Relacionando con Editorial 1
                Calificacion = 4.8,
                Ejemplares = new List<Ejemplar>(),
                FechaAgregada = DateTime.Now,
                IdTitulo = repoTitulo.IdSelect(1).IdTitulo, // Relacionando con Titulo 1
                IdEditorial = repoEditorial.IdSelect(1).IdEditorial,
                IdLibro = 0,
                ISBN = "123456789",
                RutaFoto = null,
                Titulo = repoTitulo.IdSelect(1)
            };

            var libro2 = new Libro
            {
                Editorial = repoEditorial.IdSelect(2), // Relacionando con Editorial 2
                Calificacion = 4.5,
                Ejemplares = new List<Ejemplar>(),
                FechaAgregada = DateTime.Now,
                IdTitulo = repoTitulo.IdSelect(2).IdTitulo, // Relacionando con Titulo 2
                IdEditorial = repoEditorial.IdSelect(2).IdEditorial,
                IdLibro = 0,
                ISBN = "987654321",
                RutaFoto = null,
                Titulo = repoTitulo.IdSelect(2)
            };

            repoLibro.Insert(libro1, "IdLibro");
            repoLibro.Insert(libro2, "IdLibro");
            

            //Seed Socio
            Socio socio1 = new Socio
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan.perez@example.com",
                Telefono = 123456789,
                FechaNacimiento = DateTime.Now,
                IdSocio = 0,
                Prestamos = new List<Prestamo>()
            };

            Socio socio2 = new Socio
            {
                Nombre = "María",
                Apellido = "Gómez",
                Email = "maria.gomez@example.com",
                Telefono = 987654321,
                FechaNacimiento = DateTime.Now,
                IdSocio = 0,
                Prestamos = new List<Prestamo>()
            };

            Socio socio3 = new Socio
            {
                Nombre = "Carlos",
                Apellido = "López",
                Email = "carlos.lopez@example.com",
                Telefono = 456789123,
                FechaNacimiento = DateTime.Now,
                IdSocio = 0,
                Prestamos = new List<Prestamo>()
            };

            repoSocio.Insert(socio1, "IdSocio");
            repoSocio.Insert(socio2, "IdSocio");
            repoSocio.Insert(socio3, "IdSocio");

            // Seed Ejemplar
            Ejemplar ejemplar1 = new Ejemplar
            {
                IdLibro = 1, // Asegúrate de que este IdLibro exista en la tabla Libro
                NroEjemplar = 1
            };
            
            Ejemplar ejemplar2 = new Ejemplar
            {
                IdLibro = 1,
                NroEjemplar = 2
            };

            Ejemplar ejemplar3 = new Ejemplar
            {
                IdLibro = 2,
                NroEjemplar = 1
            };

            repoEjemplar.Insert(ejemplar1, "IdEjemplar");
            repoEjemplar.Insert(ejemplar2, "IdEjemplar");
            repoEjemplar.Insert(ejemplar3, "IdEjemplar");


            //Seed Prestamo
            var prestamo1 = new Prestamo
            {
                Ejemplar = repoEjemplar.IdSelect(1),
                IdEjemplar = 1,
                IdOperadorEntrega = repoOperador.IdSelect(1).IdOperador,
                IdOperadorRegreso = null,
                IdPrestamo = 0,
                IdSocio = repoSocio.IdSelect(1).IdSocio,
                OperadorEntrega = repoOperador.IdSelect(1),
                OperadorRegreso = null,
                Regreso = null,
                Salida = DateTime.Now,
                Socio = repoSocio.IdSelect(1)
            };

            var prestamo2 = new Prestamo
            {
                Ejemplar = repoEjemplar.IdSelect(2),
                IdEjemplar = 2,
                IdOperadorEntrega = repoOperador.IdSelect(2).IdOperador,
                IdOperadorRegreso = null,
                IdPrestamo = 0,
                IdSocio = repoSocio.IdSelect(2).IdSocio,
                OperadorEntrega = repoOperador.IdSelect(2),
                OperadorRegreso = null,
                Regreso = null,
                Salida = DateTime.Now,
                Socio = repoSocio.IdSelect(2)
            };

            repoPrestamo.Insert(prestamo1, "IdPrestamo");
            repoPrestamo.Insert(prestamo2, "IdPrestamo");



        }
    }
}
