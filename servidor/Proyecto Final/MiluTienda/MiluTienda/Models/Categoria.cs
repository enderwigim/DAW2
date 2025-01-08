using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es un campo requerido.")]
        public string Descripcion { get; set; }

        // Relación: Una Categoria puede tener muchos Productos
        public ICollection<Producto> Productos { get; set; }
    }
}
