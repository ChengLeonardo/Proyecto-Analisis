using System.ComponentModel.DataAnnotations;

namespace Proyecto;

public class AgregarGeneroViewModel
{
    [Required(ErrorMessage = "El nombre del género es requerido.")]
    public string NombreGenero { get; set; }
    public IFormFile? Foto { get; set; }
}