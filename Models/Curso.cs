using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace platzi_asp_net_core.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        //[Required]
        //public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        [Display(Prompt = "Dirección correspondencia", Name = "Address")]
        [Required(ErrorMessage = "Se requiere incluir una dirección.")]
        [MinLength(10, ErrorMessage = "La longitud mínimia de la dirección es 10.")]
        public string Dirección { get; set; }
        
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}