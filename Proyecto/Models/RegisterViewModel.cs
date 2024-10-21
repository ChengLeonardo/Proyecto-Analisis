using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string? CodigoOperador { get; set; }
    }
}
