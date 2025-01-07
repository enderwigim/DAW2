namespace MiluTienda.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? Confirmado { get; set; }
        public DateTime? Preparado { get; set; }
        public DateTime? Enviado { get; set; }
        public DateTime? Cobrado { get; set; }
        public DateTime? Devuelto { get; set; }
        public DateTime? Anulado { get; set; }

        // Claves Foráneas
        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        // Relación: Un Pedido puede tener muchas Líneas de Pedido
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
