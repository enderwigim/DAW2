﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    public class FamiliaProductos : Controller
    {
        private readonly TiendaContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FamiliaProductos(TiendaContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            _webHostEnvironment = HostEnvironment;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Productos.Include(p => p.Categoria);
            return View(await tiendaContext.ToListAsync());
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
                .Include(p => p.Variantes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,PrecioCadena,Marca,Stock,Imagen,CategoriaId")] Producto producto)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,PrecioCadena,Marca,Stock,Imagen,CategoriaId")] Producto producto)
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

        // GET: Productos/Variantes/Create/5
        // SE UTILIZARÁ PARA MOSTRAR LA VISTA QUE CREE LA VARIANTE
        public IActionResult CreateVariante(int familiaId)
        {
            var familia = _context.Productos.Find(familiaId);
            if (familia == null)
            {
                return NotFound();
            }

            // Pasa el ProductoId y el producto en si a la vista
            ViewBag.Producto = familia;
            ViewBag.ProductoId = familiaId;
            return View();
        }

        // POST: Productos/Variantes/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVariante(int familiaProductoId, [Bind("Atributo,NombreVariante,PrecioCadena,PrecioVariante")] Variante variante)
        {
            if (ModelState.IsValid)
            {
                // Asigna el ProductoId a la variante
                variante.FamiliaProductoiD = familiaProductoId;

                // Agrega la variante a la base de datos
                _context.Add(variante);
                await _context.SaveChangesAsync();

                // Redirige a los detalles del producto
                return RedirectToAction("Details", "Productos", new { id = familiaProductoId });
            }

            ViewBag.ProductoId = familiaProductoId;
            return View(variante);
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
