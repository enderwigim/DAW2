using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;

namespace MiluTienda.Controllers
{
    public class CarritoController : Controller
    {
        private readonly TiendaContext _context;

        public CarritoController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Carrito/Index/5
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Vacio");
            }

            var pedido = await _context.Pedidos
                .Include(p => p.LineasPedido)
                .ThenInclude(lp => lp.Producto)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
            {
                return RedirectToAction("Vacio");
            }
            return View(pedido);
        }

        // GET: Carrito/Vacio
        public async Task<IActionResult> Vacio()
        {
            return View();
        }

        // POST: Carrito/ActualizarCantidad/5/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarCantidad(int id, int cantidad)
        {
            var lineaPedido = await _context.LineasPedido.FindAsync(id);
            if (lineaPedido == null)
            {
                return NotFound();
            }

            lineaPedido.Cantidad = cantidad;
            _context.Update(lineaPedido);
            await _context.SaveChangesAsync();

            // Redirigir de vuelta al carrito con el id del pedido
            return RedirectToAction("Index", new { id = lineaPedido.PedidoId });
        }

        // POST: Carrito/EliminarProducto/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var lineaPedido = await _context.LineasPedido.FindAsync(id);
            if (lineaPedido == null)
            {
                return NotFound();
            }

            // Eliminar el producto del carrito
            _context.LineasPedido.Remove(lineaPedido);
            await _context.SaveChangesAsync();

            // Redirigir de vuelta al carrito con el id del pedido
            return RedirectToAction("Index", new { id = lineaPedido.PedidoId });
        }

        // GET: Carrito/AgregarCarrito/5
        public async Task<IActionResult> ConfirmarPedido(int id)
        {
            // Buscar el pedido por Id
            var pedido = await _context.Pedidos
                .Include(p => p.LineasPedido)  // Asegurarse de que cargamos las líneas de pedido
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                // Si no se encuentra el pedido, redirigir a Vacio
                return RedirectToAction("Vacio", "Carrito");
            }

            // Verificar si el carrito está vacío (sin líneas de pedido)
            if (pedido.LineasPedido == null || !pedido.LineasPedido.Any())
            {
                // Si el carrito está vacío, no se puede confirmar el pedido
                TempData["ErrorMessage"] = "El carrito está vacío, no se puede confirmar el pedido.";
                return RedirectToAction("Vacio", "Carrito");
            }

            // Modificar el estado del pedido a "Confirmado"
            var estadoConfirmado = await _context.Estados
                .FirstOrDefaultAsync(e => e.Descripcion == "Confirmado");
            if (estadoConfirmado != null)
            {
                pedido.EstadoId = estadoConfirmado.Id;
                pedido.Confirmado = DateTime.Now;  // Establecer la fecha de confirmación
                _context.Update(pedido);
                await _context.SaveChangesAsync();
            }

            // Eliminar la variable de sesión "NumPedido"
            HttpContext.Session.Remove("NumPedido");

            // Redirigir al escaparate (o cualquier otra acción que necesites)
            return RedirectToAction("Index", "Escaparate");
        }

    }
}
