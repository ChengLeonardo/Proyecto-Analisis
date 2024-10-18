namespace Proyecto.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; }
    public uint IdEjemplar { get; set; }
    public int IdSocio { get; set; }
    public DateTime? Salida { get; set; } = null;
    public DateTime? Regreso { get; set; } = null;
    public bool Recibido { get; set; } = false;
    public Ejemplar Ejemplar { get; set; }
    public Socio Socio { get; set; }
    public Operador? OperadorEntrega { get; set; }
    public Operador? OperadorRegreso { get; set; }
    public bool Cancelado { get; set; } = false;
    public bool EntregadoPorOperador { get; set; } = false;
    public bool RecibidoConfirmadoPorSocio { get; set; } = false;
    public bool DevueltoPorSocio { get; set; } = false;
    public bool DevolucionConfirmadaPorOperador { get; set; } = false;
}
