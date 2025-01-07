namespace MiluTienda.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Relación: Una Categoria puede tener muchos Productos
        public ICollection<Producto> Productos { get; set; }
    }
}
