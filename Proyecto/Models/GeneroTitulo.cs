namespace Proyecto.Models;


public class GeneroTitulo
{
    public int IdGenero { get; set; }
    public int IdTitulo { get; set; }

    public Genero Genero { get; set; } // Relación N:1 con Genero
    public Titulo Titulo { get; set; } // Relación N:1 con Titulo
}