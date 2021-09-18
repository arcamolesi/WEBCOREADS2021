using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCOREADS2021.Models;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Controllers
{
    public class InsumosAreasController : Controller
    {
        private readonly Contexto _context;

        public InsumosAreasController(Contexto context)
        {
            _context = context;
        }

        // GET: InsumosAreas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.InsumosArea.Include(i => i.area).Include(i => i.insumo);
            return View(await contexto.ToListAsync());
        }

        // GET: InsumosAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoArea = await _context.InsumosArea
                .Include(i => i.area)
                .Include(i => i.insumo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (insumoArea == null)
            {
                return NotFound();
            }

            return View(insumoArea);
        }

        // GET: InsumosAreas/Create
        public IActionResult Create()
        {
            ViewData["areaID"] = new SelectList(_context.Areas, "id", "bairro");
            ViewData["insumoID"] = new SelectList(_context.Insumos, "id", "descricao");
            return View();
        }

        // POST: InsumosAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,areaID,insumoID,data,quantidade,valor")] InsumoArea insumoArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumoArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["areaID"] = new SelectList(_context.Areas, "id", "bairro", insumoArea.areaID);
            ViewData["insumoID"] = new SelectList(_context.Insumos, "id", "descricao", insumoArea.insumoID);
            return View(insumoArea);
        }

        // GET: InsumosAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoArea = await _context.InsumosArea.FindAsync(id);
            if (insumoArea == null)
            {
                return NotFound();
            }
            ViewData["areaID"] = new SelectList(_context.Areas, "id", "bairro", insumoArea.areaID);
            ViewData["insumoID"] = new SelectList(_context.Insumos, "id", "descricao", insumoArea.insumoID);
            return View(insumoArea);
        }

        // POST: InsumosAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,areaID,insumoID,data,quantidade,valor")] InsumoArea insumoArea)
        {
            if (id != insumoArea.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumoArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumoAreaExists(insumoArea.id))
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
            ViewData["areaID"] = new SelectList(_context.Areas, "id", "bairro", insumoArea.areaID);
            ViewData["insumoID"] = new SelectList(_context.Insumos, "id", "descricao", insumoArea.insumoID);
            return View(insumoArea);
        }

        // GET: InsumosAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoArea = await _context.InsumosArea
                .Include(i => i.area)
                .Include(i => i.insumo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (insumoArea == null)
            {
                return NotFound();
            }

            return View(insumoArea);
        }

        // POST: InsumosAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumoArea = await _context.InsumosArea.FindAsync(id);
            _context.InsumosArea.Remove(insumoArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumoAreaExists(int id)
        {
            return _context.InsumosArea.Any(e => e.id == id);
        }
    }
}
