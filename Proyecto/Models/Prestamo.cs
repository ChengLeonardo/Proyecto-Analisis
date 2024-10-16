namespace Proyecto.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; }
    public uint IdEjemplar { get; set; }
    public int IdSocio { get; set; }
    public DateTime? Salida { get; set; }
    public int? IdOperadorEntrega { get; set; }
    public DateTime? Regreso { get; set; }
    public int? IdOperadorRegreso { get; set; }
    public bool Recibido { get; set; }
    public Ejemplar Ejemplar { get; set; }
    public Socio Socio { get; set; }
    public Operador? OperadorEntrega { get; set; }
    public Operador? OperadorRegreso { get; set; }
}
