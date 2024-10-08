using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public int TipoUsuarioId { get; set; }
        [NotMapped]
        public TipoUsuario TipoUsuario 
        {
            get => (TipoUsuario)TipoUsuarioId;
            set => TipoUsuarioId = (int)value;
        }
        public Socio? Socio { get; set; }
        public Operador? Operador { get; set; }
    }

    public enum TipoUsuario
    {
        Socio = 1,
        Operador = 2
    }
}
