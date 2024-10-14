namespace Proyecto.Models;

public class ModificarGeneroViewModel
{
    public int IdGenero { get; set; }
    public string NombreGenero { get; set; }
    public string? RutaFoto { get; set; }
    public IFormFile? Foto { get; set; }
}