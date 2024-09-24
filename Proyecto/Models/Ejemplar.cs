namespace Proyecto.Models;


public class Ejemplar
{
    public uint IdEjemplar { get; set; }
    public int IdLibro { get; set; }
    public uint NroEjemplar { get; set; }

    public Libro Libro { get; set; } // Relación N:1 con Libro
    public ICollection<Prestamo> Prestamos { get; set; } // Relación 1:N con Prestamo
}