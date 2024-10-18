using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; } = true;
        public TipoUsuario TipoUsuario { get; set; }
        public Socio? Socio { get; set; }
        public Operador? Operador { get; set; }
        
    }

    public enum TipoUsuario
    {
        Socio = 1,
        Operador = 2
    }
}
