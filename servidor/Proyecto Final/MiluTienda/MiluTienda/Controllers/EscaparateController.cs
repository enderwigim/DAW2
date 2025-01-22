using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    public class EscaparateController : Controller
    {
        private readonly TiendaContext _context;

        public EscaparateController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Escaparate/Index/{id}
        public async Task<IActionResult> Index(int? id)
        {
            // Si se proporciona un id, mostrar productos de esa categoría
            if (id.HasValue)
            {
                // Obtener productos de la categoría especificada
                var productosPorCategoria = await _context.Productos
                    .Where(p => p.CategoriaId == id.Value) // Filtrar por categoría
                .ToListAsync();

                ViewData["Categorias"] = await _context.Categorias.OrderBy(c => c.Descripcion).ToListAsync();

                return View(productosPorCategoria); // Pasar los productos filtrados
            }
            else
            {
                // Si no se proporciona un id, mostrar solo los productos del escaparate
                var productosEscaparate = await _context.Productos
                    .Where(p => p.Escaparate == true) // Filtrar productos en escaparate
                .ToListAsync();

                ViewData["Categorias"] = await _context.Categorias.OrderBy(c => c.Descripcion).ToListAsync();

                return View(productosEscaparate); // Pasar los productos del escaparate
            }
        }

        // GET: Escaparate/AgregarCarrito/5
        public async Task<IActionResult> AgregarCarrito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCarrito(int productoId)
        {
            // Obtener el usuario actual
            var userId = User.Identity.Name;
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == userId);  // Obtener el cliente por email

            if (cliente == null)
            {
                return NotFound();
            }

            // Buscar el producto en la base de datos
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.Id == productoId);

            if (producto == null)
            {
                return NotFound();
            }

            // Crear un nuevo pedido si no existe uno en la sesión
            Pedido pedido;

            // Verificar si ya hay un pedido en la sesión
            if (HttpContext.Session.GetInt32("NumPedido") == null)
            {
                // Crear un nuevo pedido
                pedido = new Pedido
                {
                    ClienteId = cliente.Id,
                    FechaCreacion = DateTime.Now,
                    EstadoId = _context.Estados.FirstOrDefault(e => e.Descripcion == "Pendiente").Id // Estado "Pendiente"
                };

                // Guardar el pedido y asignar el número de pedido en la sesión
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("NumPedido", pedido.Id);
            }
            else
            {
                // Obtener el pedido existente desde la sesión
                var numPedido = HttpContext.Session.GetInt32("NumPedido");
                pedido = await _context.Pedidos.FindAsync(numPedido);
            }

            // Crear una línea de pedido con el producto
            var lineaPedido = new LineaPedido
            {
                PedidoId = pedido.Id,
                Producto = producto,
                Precio = producto.Precio,
                Cantidad = 1
            };

            // Agregar la línea de pedido y guardar los cambios
            _context.LineasPedido.Add(lineaPedido);
            await _context.SaveChangesAsync();

            // Redirigir a la vista de carrito pasando el id del pedido
            return RedirectToAction("Index", "Carrito", new { id = pedido.Id });
        }
        
    }
}
