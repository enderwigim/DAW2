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
        public string? NombreVariante { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9, 2)")]
        [Display(Name = "Precio")]
        [RegularExpression(@"^[-0123456789]+[0-9.,]*$",
        ErrorMessage = "El valor introducido debe ser de tipo monetario.")]
        [Required(ErrorMessage = "El precio es un campo requerido")]
        public decimal PrecioVariante { get; set; }
    }
}
