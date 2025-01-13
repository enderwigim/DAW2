using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime? FechaCreacion { get; set; }
        [Display(Name = "Fecha de confirmación")]
        public DateTime? Confirmado { get; set; }
        [Display(Name = "Fecha de preparación")]
        public DateTime? Preparado { get; set; }
        public DateTime? Enviado { get; set; }
        public DateTime? Cobrado { get; set; }
        public DateTime? Devuelto { get; set; }
        public DateTime? Anulado { get; set; }

        // Claves Foráneas
        public int ClienteId { get; set; }
        public Clientes? Cliente { get; set; }
        public int? EstadoId { get; set; }
        public Estado? Estado { get; set; }

        // Relación: Un Pedido puede tener muchas Líneas de Pedido
        public ICollection<LineaPedido>? LineasPedido { get; set; }
    }
}
