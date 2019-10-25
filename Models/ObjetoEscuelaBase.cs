using System.ComponentModel.DataAnnotations;

namespace platzi_asp_net_core.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [MinLength(5, ErrorMessage = "El nombre debe tener por lo menos 5 caracteres.")]
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase() { }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}