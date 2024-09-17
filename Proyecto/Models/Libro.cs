namespace Proyecto.Models;

public class Libro
{
    public int IdLibro { get; set; } // INT NOT NULL AUTO_INCREMENT
    public int IdEditorial { get; set; } // INT NOT NULL
    public Editorial Editorial { get; set; }
    public Titulo Titulo { get; set; } 
    public int IdTitulo { get; set; } // INT NOT NULL
    public string ISBN { get; set; } // VARCHAR(30) NOT NULL
}