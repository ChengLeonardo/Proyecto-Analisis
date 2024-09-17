namespace Proyecto.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; } // INT NOT NULL
    public uint IdEjemplar { get; set; } // INT UNSIGNED NOT NULL
    public int IdSocio { get; set; } // INT NOT NULL
    public DateTime? Salida { get; set; } // DATETIME NULL DEFAULT CURRENT_TIMESTAMP
    public int IdOperadorEntrega { get; set; } // INT NOT NULL
    public DateTime? Regreso { get; set; } // DATETIME NULL DEFAULT NULL
    public int? IdOperadorRegreso { get; set; } // INT NULL DEFAULT NULL
}