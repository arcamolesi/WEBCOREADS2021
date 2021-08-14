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
    public class AgricultoresController : Controller
    {
        private readonly Contexto _context;

        public AgricultoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Agricultores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agricultores.ToListAsync());
        }

        // GET: Agricultores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultores
                .FirstOrDefaultAsync(m => m.id == id);
            if (agricultor == null)
            {
                return NotFound();
            }

            return View(agricultor);
        }

        // GET: Agricultores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agricultores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,proprietario,municipio,bairro,idade")] Agricultor agricultor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agricultor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agricultor);
        }

        // GET: Agricultores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultores.FindAsync(id);
            if (agricultor == null)
            {
                return NotFound();
            }
            return View(agricultor);
        }

        // POST: Agricultores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,proprietario,municipio,bairro,idade")] Agricultor agricultor)
        {
            if (id != agricultor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agricultor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgricultorExists(agricultor.id))
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
            return View(agricultor);
        }

        // GET: Agricultores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agricultor = await _context.Agricultores
                .FirstOrDefaultAsync(m => m.id == id);
            if (agricultor == null)
            {
                return NotFound();
            }

            return View(agricultor);
        }

        // POST: Agricultores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agricultor = await _context.Agricultores.FindAsync(id);
            _context.Agricultores.Remove(agricultor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgricultorExists(int id)
        {
            return _context.Agricultores.Any(e => e.id == id);
        }
    }
}
