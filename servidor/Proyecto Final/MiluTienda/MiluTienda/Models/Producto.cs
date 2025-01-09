using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es un campo requerido")]
        public string Nombre { get; set; }
        
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9, 2)")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es un campo requerido")]
        public decimal Precio { get; set; }
        public string? Marca { get; set; }
        // Establece un valor predeterminado de 0
        public int Stock { get; set; } = 0;  
        public string? Imagen { get; set; }

        // Clave Foránea
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // Relación: Un Producto puede tener muchas Variantes
        public ICollection<Variante>? Variantes { get; set; }

        // Relación: Un Producto puede estar en muchas Líneas de Pedido
        public ICollection<LineaPedido>? LineasPedido { get; set; }
    }
}
