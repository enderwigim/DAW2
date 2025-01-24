using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductosController : Controller
    {
        private readonly TiendaContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //[Authorize(Roles = "Administrador")]
        public ProductosController(TiendaContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            _webHostEnvironment = HostEnvironment;
        }

        //// GET: Productos
        public async Task<IActionResult> Index(string Nombre, int? CategoriaId, string PrecioMin, string PrecioMax, int page = 1)
        {
            // Convertir PrecioMin y PrecioMax a decimal si no están vacíos y tienen formato válido
            decimal? precioMinDecimal = null;
            decimal? precioMaxDecimal = null;

            if (!string.IsNullOrEmpty(PrecioMin))
            {
                // Reemplazar coma por punto
                PrecioMin = PrecioMin.Replace(',', '.');
                if (decimal.TryParse(PrecioMin, out var tempMin))
                {
                    precioMinDecimal = tempMin;
                }
            }

            if (!string.IsNullOrEmpty(PrecioMax))
            {
                // Reemplazar coma por punto
                PrecioMax = PrecioMax.Replace(',', '.');
                if (decimal.TryParse(PrecioMax, out var tempMax))
                {
                    precioMaxDecimal = tempMax;
                }
            }


            // Número de elementos por página
            int pageSize = 10;

            // Obtener la lista de categorías para el filtro
            var categorias = await _context.Categorias.OrderBy(c => c.Descripcion).ToListAsync();

            // Añadir la opción "Todas las Categorías" al inicio de la lista
            // Esta no será una categoría de la base de datos, solo una opción visual
            ViewData["Categorias"] = categorias;

            // Filtrar productos según los parámetros
            var productosQuery = _context.Productos.AsQueryable();

            // Filtrar por nombre
            if (!string.IsNullOrEmpty(Nombre))
            {
                productosQuery = productosQuery.Where(p => p.Nombre.Contains(Nombre));
            }

            // Filtrar por categoría
            if (CategoriaId.HasValue && CategoriaId != 0) // No filtrar si CategoriaId es 0 (Todas las Categorías)
            {
                productosQuery = productosQuery.Where(p => p.CategoriaId == CategoriaId);
            }

            if (precioMinDecimal.HasValue)
            {
                productosQuery = productosQuery.Where(p => p.Precio >= precioMinDecimal.Value);
            }

            if (precioMaxDecimal.HasValue)
            {
                productosQuery = productosQuery.Where(p => p.Precio <= precioMaxDecimal.Value);
            }

            // Obtener el número total de productos
            var totalProductos = await productosQuery.CountAsync();

            // Obtener los productos filtrados y paginados
            var productos = await productosQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Categoria)
                .ToListAsync();

            // Crear el modelo de paginación
            var model = new PaginatedList<Producto>(productos, totalProductos, page, pageSize);

            // Pasar los parámetros de búsqueda a la vista a través de ViewData
            ViewData["Nombre"] = Nombre;
            ViewData["CategoriaId"] = CategoriaId;
            ViewData["PrecioMin"] = PrecioMin;
            ViewData["PrecioMax"] = PrecioMax;

            return View(model);
        }




        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        //[Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Atributo,Nombre,Descripcion,Precio,PrecioCadena,Stock,Imagen,Marca,Escaparate,CategoriaId,FamiliaProductoId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Atributo,Nombre,Descripcion,Precio,PrecioCadena,Stock,Imagen,Marca,Escaparate,CategoriaId,FamiliaProductoId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }

        // GET: Productos/CambiarImagen/5 
        public async Task<IActionResult> CambiarImagen(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        // POST: Productos/CambiarImagen/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarImagen(int? id, IFormFile imagen)
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

            if (imagen == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Copiar archivo de imagen 
                string strRutaImagenes = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes/productos");
                string strExtension = Path.GetExtension(imagen.FileName);
                string strNombreFichero = producto.Id.ToString() + strExtension;
                string strRutaFichero = Path.Combine(strRutaImagenes, strNombreFichero);
                using (var fileStream = new FileStream(strRutaFichero, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                // Actualizar producto con nueva imagen 
                producto.Imagen = strNombreFichero;
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(producto);
        }
    }
}
