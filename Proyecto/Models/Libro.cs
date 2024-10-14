namespace Proyecto.Models;


public class Libro
{
    public int IdLibro { get; set; }
    public int IdEditorial { get; set; }
    public int IdTitulo { get; set; }
    public string ISBN { get; set; }
    public string? RutaFoto { get; set; }
    public DateTime FechaAgregada { get; set; } = DateTime.Now;
    public double Calificacion { get; set; }
    public Editorial Editorial { get; set; } // Relación N:1 con Editorial
    public Titulo Titulo { get; set; } // Relación N:1 con Titulo
    public ICollection<Ejemplar> Ejemplares { get; set; } // Relación 1:N con Ejemplar
}