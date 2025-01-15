using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Producto
    {
        public int Id { get; set; }
        
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }

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

        public int Stock { get; set; } = 0;

        public string? Imagen { get; set; }

        public string? Marca { get; set; }

        public bool Escaparate { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<LineaPedido>? LineasPedido { get; set; }
        public int FamiliaProductoId { get; set; }
        [Display(Name = "Familia Origen")]
        public FamiliaProducto? FamiliaProducto { get; set; }

    }
}

