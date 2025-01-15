using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es un campo requerido.")]
        public required string Descripcion { get; set; }

        public ICollection<Producto>? Productos { get; set; }
    }
}
