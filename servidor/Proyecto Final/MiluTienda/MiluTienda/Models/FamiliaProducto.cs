using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class FamiliaProducto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es un campo requerido")]
        public string Nombre { get; set; }
        
        public string? Marca { get; set; }

        public string? Imagen { get; set; }

        // Clave Foránea
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // Relación: Un Producto puede tener muchas Variantes
        public ICollection<Producto>? Productos { get; set; }


    }
}
