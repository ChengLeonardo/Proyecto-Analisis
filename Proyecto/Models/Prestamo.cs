namespace Proyecto.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; }
    public uint IdEjemplar { get; set; }
    public int IdSocio { get; set; }
    public DateTime? Salida { get; set; }
    public int IdOperadorEntrega { get; set; }
    public DateTime? Regreso { get; set; }
    public int? IdOperadorRegreso { get; set; }

    public Ejemplar Ejemplar { get; set; } // Relación N:1 con Ejemplar
    public Socio Socio { get; set; } // Relación N:1 con Socio
    public Operador OperadorEntrega { get; set; } // Relación N:1 con Operador
    public Operador OperadorRegreso { get; set; } // Relación N:1 con Operador
}