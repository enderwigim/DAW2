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
        public decimal Precio { get; set; }

        [Display(Name = "Precio")]
        [RegularExpression(@"^[-0123456789]+[0-9.,]*$",
        ErrorMessage = "El valor introducido debe ser de tipo monetario.")]
        [Required(ErrorMessage = "El precio es un campo requerido")]
        public string PrecioCadena
        {
            get
            {
                return Convert.ToString(Precio).Replace(',', '.');
            }
            set
            {
                Precio = Convert.ToDecimal(value.Replace('.', ','));
            }
        }
        public string? Marca { get; set; }

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
