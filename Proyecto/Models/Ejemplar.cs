namespace Proyecto.Models;

public class Ejemplar
{
    public uint IdEjemplar { get; set; } // INT UNSIGNED NOT NULL AUTO_INCREMENT
    public int IdLibro { get; set; } // INT NOT NULL
    public uint NroEjemplar { get; set; } // INT(3) UNSIGNED NOT NULL
}
