﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MiluTienda.Data;
using MiluTienda.Models;
using System.Security.Principal;

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
        public async Task<IActionResult> Index(int? id, int page = 1)
        {
            // Número de productos por página
            int pageSize = 12;

            // Variable para almacenar la lista de productos
            List<Producto> productos;

            // Si se proporciona un id, mostrar productos de esa categoría
            if (id.HasValue)
            {
                // Obtener productos de la categoría especificada
                var totalProductos = await _context.Productos
                    .Where(p => p.CategoriaId == id.Value)
                    .CountAsync();

                productos = await _context.Productos
                    .Where(p => p.CategoriaId == id.Value)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                ViewData["Categorias"] = await _context.Categorias.OrderBy(c => c.Descripcion).ToListAsync();

                // Crear el modelo de paginación
                var model = new PaginatedList<Producto>(productos, totalProductos, page, pageSize);

                return View(model); // Pasar los productos filtrados paginados
            }
            else
            {
                // Si no se proporciona un id, mostrar solo los productos del escaparate
                var totalProductos = await _context.Productos
                    .Where(p => p.Escaparate == true) // Filtrar productos en escaparate
                    .CountAsync();

                productos = await _context.Productos
                    .Where(p => p.Escaparate == true)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                ViewData["Categorias"] = await _context.Categorias.OrderBy(c => c.Descripcion).ToListAsync();

                // Crear el modelo de paginación
                var model = new PaginatedList<Producto>(productos, totalProductos, page, pageSize);

                return View(model); // Pasar los productos del escaparate paginados
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

            if (userId == null && cliente == null)
            {
                return Redirect("/Identity/Account/Login");
            } else if (cliente == null)
            {
                return RedirectToAction("Index");
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

            if (HttpContext.Session.GetInt32("NumPedido") == null)
            {
                // Verificar que el estado "Pendiente" existe en la base de datos
                var estadoPendiente = await _context.Estados
                    .FirstOrDefaultAsync(e => e.Descripcion == "Pendiente");

                if (estadoPendiente == null)
                {
                    return NotFound("Estado 'Pendiente' no encontrado en la base de datos.");
                }

                // Crear un nuevo pedido
                pedido = new Pedido
                {
                    ClienteId = cliente.Id,
                    FechaCreacion = DateTime.Now,
                    EstadoId = estadoPendiente.Id,
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

                if (pedido == null)
                {
                    return NotFound("Pedido no encontrado.");
                }
            }

            // Verificar si ya existe una línea de pedido para este producto
            var lineaPedidoExistente = await _context.LineasPedido
                .FirstOrDefaultAsync(lp => lp.PedidoId == pedido.Id && lp.ProductoId == productoId);

            if (lineaPedidoExistente != null)
            {
                // Si existe, incrementar la cantidad
                lineaPedidoExistente.Cantidad += 1;
            }
            else
            {
                // Si no existe, crear una nueva línea de pedido
                var nuevaLineaPedido = new LineaPedido
                {
                    PedidoId = pedido.Id,
                    ProductoId = producto.Id,
                    Producto = producto,
                    Precio = producto.Precio,
                    Cantidad = 1
                };

                _context.LineasPedido.Add(nuevaLineaPedido);
            }

            // Guardar los cambios
            await _context.SaveChangesAsync();

            // Redirigir a la vista de carrito pasando el id del pedido
            return RedirectToAction("Index", "Carrito", new { id = pedido.Id });
        }




    }
}
