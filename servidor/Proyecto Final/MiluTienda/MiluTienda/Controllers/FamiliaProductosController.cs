using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    public class FamiliaProductosController : Controller
    {
        private readonly TiendaContext _context;

        public FamiliaProductosController(TiendaContext context)
        {
            _context = context;
        }

        // GET: FamiliaProductos
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.FamiliaProductos.Include(f => f.Categoria);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: FamiliaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaProducto = await _context.FamiliaProductos
                .Include(f => f.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaProducto == null)
            {
                return NotFound();
            }

            return View(familiaProducto);
        }

        // GET: FamiliaProductos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            return View();
        }

        // POST: FamiliaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Marca,Imagen,CategoriaId")] FamiliaProducto familiaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", familiaProducto.CategoriaId);
            return View(familiaProducto);
        }

        // GET: FamiliaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaProducto = await _context.FamiliaProductos.FindAsync(id);
            if (familiaProducto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", familiaProducto.CategoriaId);
            return View(familiaProducto);
        }

        // POST: FamiliaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca,Imagen,CategoriaId")] FamiliaProducto familiaProducto)
        {
            if (id != familiaProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaProductoExists(familiaProducto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", familiaProducto.CategoriaId);
            return View(familiaProducto);
        }

        // GET: FamiliaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiaProducto = await _context.FamiliaProductos
                .Include(f => f.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiaProducto == null)
            {
                return NotFound();
            }

            return View(familiaProducto);
        }

        // POST: FamiliaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiaProducto = await _context.FamiliaProductos.FindAsync(id);
            if (familiaProducto != null)
            {
                _context.FamiliaProductos.Remove(familiaProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaProductoExists(int id)
        {
            return _context.FamiliaProductos.Any(e => e.Id == id);
        }
    }
}
