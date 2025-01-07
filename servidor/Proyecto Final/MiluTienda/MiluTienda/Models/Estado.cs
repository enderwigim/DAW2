namespace MiluTienda.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Relación: Un Estado puede aplicarse a muchos Pedidos
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
