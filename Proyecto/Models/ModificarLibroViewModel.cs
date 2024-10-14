using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Proyecto.Models
{
    public class ModificarLibroViewModel
    {
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El campo Título es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo ISBN es obligatorio.")]
        public string ISBN { get; set; }

        public string? RutaFoto { get; set; }

        [Required(ErrorMessage = "La fecha agregada es obligatoria.")]
        public DateTime FechaAgregada { get; set; }
        
        [Range(0, 5, ErrorMessage = "La calificación debe estar entre 0 y 5.")]
        public double Calificacion { get; set; }
        public IFormFile? Foto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una editorial.")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un género")]
        public List<int> GenerosSeleccionados { get; set; }

        public List<Editorial>? Editoriales { get; set; }
        public List<Genero>? Generos { get; set; }
    }
}
