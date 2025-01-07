using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal PrecioBase { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }

        // Clave Foránea
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        // Relación: Un Producto puede tener muchas Variantes
        public ICollection<Variante> Variantes { get; set; }

        // Relación: Un Producto puede estar en muchas Líneas de Pedido
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
