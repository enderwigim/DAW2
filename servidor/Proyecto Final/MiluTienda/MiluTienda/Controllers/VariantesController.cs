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
    
    public class VariantesController : Controller
    {
        private readonly TiendaContext _context;

        public VariantesController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Variantes
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Variantes.Include(v => v.Producto);
            return View(await tiendaContext.ToListAsync());
        }

        

        // GET: Variantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variante == null)
            {
                return NotFound();
            }

            return View(variante);
        }

        // GET: Variantes/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        // POST: Variantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductoId,Atributo,NombreVariante,PrecioVariante")] Variante variante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // GET: Variantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes.FindAsync(id);
            if (variante == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // POST: Variantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductoId,Atributo,NombreVariante,PrecioVariante")] Variante variante)
        {
            if (id != variante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarianteExists(variante.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // GET: Variantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variante == null)
            {
                return NotFound();
            }

            return View(variante);
        }

        // POST: Variantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variante = await _context.Variantes.FindAsync(id);
            if (variante != null)
            {
                _context.Variantes.Remove(variante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarianteExists(int id)
        {
            return _context.Variantes.Any(e => e.Id == id);
        }
    }
}
