using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models;
public class UsuarioViewModel
{
    public int IdUsuario { get; set; }
    [Required]
    [StringLength(50)]
    public string NombreUsuario { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}