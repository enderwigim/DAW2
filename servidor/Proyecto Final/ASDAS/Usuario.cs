namespace MiluTienda.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string CodPostal { get; set; }
        public string Nif { get; set; }

        // Relación: Un Usuario puede tener muchos Pedidos
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
