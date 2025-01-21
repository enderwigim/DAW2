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
    }
}
