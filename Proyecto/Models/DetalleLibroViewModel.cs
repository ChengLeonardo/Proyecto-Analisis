using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class DetalleLibroViewModel
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string RutaFoto { get; set; }
        public DateTime FechaAgregada { get; set; }
        public double Calificacion { get; set; }
        public string Editorial { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoAutor { get; set; }
        public List<string> Genero { get; set; }
        public int Stock { get; set; }
    }
}