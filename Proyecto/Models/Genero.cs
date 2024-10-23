namespace Proyecto.Models;

public class Genero
{
    public int IdGenero { get; set; }
    public string genero { get; set; }
    public string? RutaFoto { get; set; }
    public bool Eliminado { get; set; } = false;
    public ICollection<Titulo>? Titulos { get; set; } // Relación 1:N con GeneroTitulo
}
