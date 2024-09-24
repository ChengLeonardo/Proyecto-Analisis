namespace Proyecto.Models;

public class Operador
{
    public int IdOperador { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Usuario { get; set; }
    public string Pass { get; set; }

    public ICollection<Prestamo> PrestamosEntregados { get; set; } // Relación 1:N con Prestamo
    public ICollection<Prestamo> PrestamosRegresados { get; set; } // Relación 1:N con Prestamo
}
