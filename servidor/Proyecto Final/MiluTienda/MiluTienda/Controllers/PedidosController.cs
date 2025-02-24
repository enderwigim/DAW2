using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PedidosController : Controller
    {
        private readonly TiendaContext _context;

        public PedidosController(TiendaContext context)
        {
            _context = context;
        }

        //GET: Pedidos/Index
        public async Task<IActionResult> Index(string email, int page = 1)
        {
            // Número de elementos por página
            int pageSize = 10;

            // Crear la consulta base
            var pedidosQuery = _context.Pedidos.Include(p => p.Estado)
                                               .Include(p => p.Cliente)
                                               .AsQueryable();



            // Filtrar por email del cliente si es proporcionado
            if (!string.IsNullOrEmpty(email))
            {
                pedidosQuery = pedidosQuery.Where(p => p.Cliente.Email.Contains(email));
            }

            // Obtener el número total de pedidos después de aplicar los filtros
            var totalPedidos = await pedidosQuery.CountAsync();

            // Obtener los pedidos filtrados y paginados
            var pedidos = await pedidosQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Crear el modelo de paginación
            var model = new PaginatedList<Pedido>(pedidos, totalPedidos, page, pageSize);

            // Pasar los parámetros de búsqueda a la vista a través de ViewData
            ViewData["Email"] = email;

            return View(model);
        }



        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Estado)
                .Include(p => p.LineasPedido)
                    .ThenInclude(lp => lp.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CodPostal");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaCreacion,Confirmado,Preparado,Enviado,Cobrado,Devuelto,Anulado,ClienteId,EstadoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CodPostal", pedido.ClienteId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CodPostal", pedido.ClienteId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstadoId")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Aquí solo actualizas el estado, no el cliente ni otras propiedades
                    var existingPedido = await _context.Pedidos.FindAsync(id);

                    if (existingPedido == null)
                    {
                        return NotFound();
                    }

                    // No cambiar el ClienteId, solo actualizar EstadoId
                    existingPedido.EstadoId = pedido.EstadoId;
                    existingPedido.Confirmado = (pedido.EstadoId == 2) ? DateTime.Now : existingPedido.Confirmado;
                    existingPedido.Preparado = (pedido.EstadoId == 3) ? DateTime.Now : existingPedido.Preparado;
                    existingPedido.Enviado = (pedido.EstadoId == 4) ? DateTime.Now : existingPedido.Enviado;
                    existingPedido.Cobrado = (pedido.EstadoId == 5) ? DateTime.Now : existingPedido.Cobrado;
                    existingPedido.Devuelto = (pedido.EstadoId == 6) ? DateTime.Now : existingPedido.Devuelto;
                    existingPedido.Anulado = (pedido.EstadoId == 7) ? DateTime.Now : existingPedido.Anulado;

                    // Guardar los cambios
                    _context.Update(existingPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Descripcion", pedido.EstadoId);
            return View(pedido);
        }


        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }

        // GET: Pedidos/AvanzarEstado/5
        public async Task<IActionResult> AvanzarEstado(int id)
        {
            // Buscar el pedido por ID
            var pedido = await _context.Pedidos
                .Include(p => p.Estado) 
                .FirstOrDefaultAsync(p => p.Id == id);

            // Verificar si el pedido existe
            if (pedido == null)
            {
                return NotFound(); 
            }

            // Verificar que el pedido no esté en el último estado posible (Entregado)
            if (pedido.EstadoId > 4)
            {
                return BadRequest("El pedido ya está en el estado final.");
            }

            // Obtener el siguiente estado
            var siguienteEstado = _context.Estados
                .FirstOrDefault(e => e.Id == pedido.EstadoId + 1);

            if (siguienteEstado == null)
            {
                return NotFound("El siguiente estado no existe.");
            }

            // Actualizar el estado del pedido
            pedido.EstadoId = siguienteEstado.Id;

            // Asignar la fecha correspondiente al nuevo estado
            switch (siguienteEstado.Descripcion)
            {
                case "Confirmado":
                    pedido.Confirmado = DateTime.Now;
                    break;
                case "Preparado":
                    pedido.Preparado = DateTime.Now;
                    break;
                case "Enviado":
                    pedido.Enviado = DateTime.Now;
                    break;
                case "Cobrado":
                    pedido.Cobrado = DateTime.Now;
                    break;
                default:
                    break;
            }

            // Guardar los cambios en la base de datos
            _context.Update(pedido);
            await _context.SaveChangesAsync();

            // Redirigir al usuario a la página de detalles del pedido
            return RedirectToAction("Index");
        }



    }
}
