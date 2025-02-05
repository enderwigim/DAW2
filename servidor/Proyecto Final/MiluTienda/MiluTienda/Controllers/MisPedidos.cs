using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;

namespace MiluTienda.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisPedidos : Controller
    {

        private readonly TiendaContext _context;

        public MisPedidos(TiendaContext context)
        {
            _context = context;
        }

        // GET: MisPedidos
        public async Task<IActionResult> Index()
        {
            // Obtener el email del usuario actualmente logueado
            var userId = User.Identity.Name;

            // Obtener el cliente asociado al usuario
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == userId);

            if (cliente == null)
            {
                return NotFound();
            }

            // Obtener los pedidos asociados al cliente
            var pedidos = await _context.Pedidos
                .Where(p => p.ClienteId == cliente.Id)
                .Include(p => p.Estado)
                .Include(p => p.LineasPedido)
                .ToListAsync();

            return View(pedidos);
        }

        // GET: MisPedidos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Buscar el pedido correspondiente al id
            var pedido = await _context.Pedidos
                .Include(p => p.LineasPedido)
                .ThenInclude(lp => lp.Producto) 
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            // Asegurarse de que el pedido pertenece al usuario logueado
            var userId = User.Identity.Name;
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == userId);

            if (cliente == null || pedido.ClienteId != cliente.Id)
            {
                return Forbid();
            }

            return View(pedido);
        }
        
}
}