namespace Proyecto.Models;

public class Operador
{
    public int IdOperador { get; set; } // INT NOT NULL AUTO_INCREMENT
    public string Nombre { get; set; } // VARCHAR(45) NOT NULL
    public string Apellido { get; set; } // VARCHAR(45) NOT NULL
    public string Email { get; set; } // VARCHAR(100) NOT NULL
    public string Usuario { get; set; } // VARCHAR(45) NULL
    public string Pass { get; set; } // CHAR(64) NOT NULL
}