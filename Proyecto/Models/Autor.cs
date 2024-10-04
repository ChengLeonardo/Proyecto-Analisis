namespace Proyecto.Models;

public class Autor
{
    public int IdAutor { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public ICollection<Titulo> Titulos { get; set; } // Relación 1:N con AutorTitulo
}