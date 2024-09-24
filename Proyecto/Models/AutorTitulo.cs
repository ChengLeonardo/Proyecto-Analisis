namespace Proyecto.Models;

public class AutorTitulo
{
    public int IdAutor { get; set; }
    public int IdTitulo { get; set; }

    public Autor Autor { get; set; } // Relación N:1 con Autor
    public Titulo Titulo { get; set; } // Relación N:1 con Titulo
}
