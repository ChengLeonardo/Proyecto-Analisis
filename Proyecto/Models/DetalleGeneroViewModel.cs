using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class DetalleGeneroViewModel
    {
        public int IdGenero { get; set; }
        public string NombreGenero { get; set; }
        public string RutaFoto { get; set; }
        public List<Libro> Libros { get; set; }
        public bool EsOperador { get; set; }  // Agregar esta propiedad
    }
}