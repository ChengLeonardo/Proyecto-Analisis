namespace Proyecto.Models;

public class Socio
{
    public int IdSocio { get; set; } // INT NOT NULL AUTO_INCREMENT
    public string Nombre { get; set; } // VARCHAR(45) NOT NULL
    public string Apellido { get; set; } // VARCHAR(45) NOT NULL
    public string Email { get; set; } // VARCHAR(45) NULL
    public int? Telefono { get; set; } // INT(10) NULL
    public DateTime? FechaNacimiento { get; set; } // DATE NULL
}