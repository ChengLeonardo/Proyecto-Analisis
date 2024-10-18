namespace Proyecto.Models;

using System.ComponentModel.DataAnnotations;

public class Socio
{
    [Key]
    public int IdSocio { get; set; }
    public int IdUsuario { get; set; }
    public int? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public Usuario Usuario { get; set; }
    public ICollection<Prestamo> Prestamos { get; set; }
}