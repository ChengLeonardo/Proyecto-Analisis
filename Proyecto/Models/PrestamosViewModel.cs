using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class PrestamosViewModel
    {
        public List<Prestamo> Prestamos { get; set; }
        public bool EsSocio { get; set; }
        public bool EsOperador { get; set; }
        public bool EsAdministrador { get; set; }
        public bool EsActivo { get; set; }
    }
}
