using System.ComponentModel.DataAnnotations;

namespace MiluTienda.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo electronico es requerido")]
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "La población es requerida")]
        public string? Poblacion { get; set; }
        [Required(ErrorMessage = "El codigo postal es requerido")]
        public string? CodPostal { get; set; }
        [Display(Name = "NIF")]
        [Required(ErrorMessage = "El NIF es requerido")]
        public string? Nif { get; set; }

        // Relación: Un Usuario puede tener muchos Pedidos
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
