using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Display(Name = "Familia Origen")]
        public int FamiliaProductoId { get; set; }

        public FamiliaProducto? FamiliaProducto { get; set; }
        public string? Atributo { get; set; }

        [Display(Name = "Nombre")]
        public string? NombreVariante { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal PrecioVariante { get; set; }

        [Display(Name = "Precio")]
        [RegularExpression(@"^[-0123456789]+[0-9.,]*$",
        ErrorMessage = "El valor introducido debe ser de tipo monetario.")]
        [Required(ErrorMessage = "El precio es un campo requerido")]
        public string PrecioCadena
        {
            get
            {
                return Convert.ToString(PrecioVariante).Replace(',', '.');
            }
            set
            {
                PrecioVariante = Convert.ToDecimal(value.Replace('.', ','));
            }
        }

        public int Stock { get; set; } = 0;
        public string? Imagen { get; set; }

        public ICollection<LineaPedido>? LineasPedido { get; set; }

    }
}

