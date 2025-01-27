using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Estado
    {
        public int Id { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es un campo requerido.")]
        public string? Descripcion { get; set; }

        // Relación: Un Estado puede aplicarse a muchos Pedidos
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
