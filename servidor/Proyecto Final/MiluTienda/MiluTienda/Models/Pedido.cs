using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Pedido
    {
        [Display(Name = "Numero Pedido")]
        public int Id { get; set; }

        [Display(Name = "Fecha de creación")]
        [DataType(DataType.Date)]
        public DateTime? FechaCreacion { get; set; }
        [Display(Name = "Fecha de confirmación")]
        [DataType(DataType.Date)]
        public DateTime? Confirmado { get; set; }
        [Display(Name = "Fecha de preparación")]
        [DataType(DataType.Date)]
        public DateTime? Preparado { get; set; }
        [Display(Name = "Fecha de envio")]
        [DataType(DataType.Date)]
        public DateTime? Enviado { get; set; }
        [Display(Name = "Fecha de cobro")]
        [DataType(DataType.Date)]
        public DateTime? Cobrado { get; set; }
        [Display(Name = "Fecha de devolución")]
        [DataType(DataType.Date)]
        public DateTime? Devuelto { get; set; }
        [Display(Name = "Fecha anulado")]
        [DataType(DataType.Date)]
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
