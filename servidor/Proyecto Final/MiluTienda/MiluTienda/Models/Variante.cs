using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiluTienda.Models
{
    public class Variante
    {
        public int Id { get; set; }
        [Display(Name = "Producto Origen")]
        public int ProductoId { get; set; }
        
        public Producto? Producto { get; set; }
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
        public string? Imagen { get; set; }
    }
}
