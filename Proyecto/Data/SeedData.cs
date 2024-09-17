using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data;

public class SeedData
{
    public static void Initialize(IRepoOperador repoOperador)
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
            };

            repoOperador.Insert(operadorAdministrador, "IdOperador");
            // Agregar más datos seed según sea necesario
        }
    }
}
