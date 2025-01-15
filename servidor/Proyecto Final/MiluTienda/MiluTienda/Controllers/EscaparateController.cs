using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;

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
    }
}
