namespace Proyecto.Models;

public class Genero
{
    public int IdGenero { get; set; }
    public string NombreGenero { get; set; }
    public string RutaFoto { get; set; }

    public ICollection<GeneroTitulo> GeneroTitulos { get; set; } // Relación 1:N con GeneroTitulo
}
