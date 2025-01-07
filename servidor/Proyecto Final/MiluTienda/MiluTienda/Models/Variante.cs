using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class Variante
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string Atributo { get; set; }
        public string NombreVariante { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal PrecioVariante { get; set; }
    }
}
