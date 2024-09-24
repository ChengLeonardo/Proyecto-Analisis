using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data;

public class SeedData
{
    public static void Initialize(IRepoOperador repoOperador, IRepoEjemplar repoEjemplar, IRepoPrestamo repoPrestamo, IRepoSocio repoSocio)
    {
        // Verificar si ya existen datos en la base de datos
        if (!repoOperador.Select().Any())
        {
            // Agregar datos seed

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
            // Agregar más datos seed según sea necesario

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
        }
    }
}
