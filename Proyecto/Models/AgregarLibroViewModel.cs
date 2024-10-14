using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Proyecto.Models
{
    public class AgregarLibroViewModel
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "La calificación es obligatoria")]
        [Range(0, 5, ErrorMessage = "La calificación debe estar entre 0 y 5")]
        public float Calificacion { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string NombreAutor { get; set; }

        [Required(ErrorMessage = "El apellido del autor es obligatorio")]
        public string ApellidoAutor { get; set; }

        public IFormFile? Foto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un género")]
        public List<int> GenerosSeleccionados { get; set; }

        public List<Editorial>? Editoriales { get; set; }
        public List<Genero>? Generos { get; set; }
    }
}