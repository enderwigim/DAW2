using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class LineaPedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(11, 2)")]
        public decimal Precio { get; set; }
        [Column(TypeName = "decimal(2, 0)")]
        public decimal Descuento { get; set; }

        // Claves Foráneas
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
