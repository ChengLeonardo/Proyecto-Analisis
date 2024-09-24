namespace Proyecto.Models;

public class Socio
{
    public int IdSocio { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public int? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }

    public ICollection<Prestamo> Prestamos { get; set; } // Relación 1:N con Prestamo
}