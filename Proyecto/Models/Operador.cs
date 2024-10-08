using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models;

public class Operador
{
    [Key]
    public int IdOperador { get; set; }
    public int IdUsuario { get; set; }

    public Usuario Usuario { get; set; }
    public List<Prestamo> PrestamosEntregados { get; set; }
    public List<Prestamo> PrestamosRegresados { get; set; }
}
