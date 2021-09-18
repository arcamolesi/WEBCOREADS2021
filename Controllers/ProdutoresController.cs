using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WEBCOREADS2021.Models;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Controllers
{
    public class ProdutoresController : Controller
    {
        private readonly Contexto _context; 

        public ProdutoresController(Contexto context)
        {
            _context = context; 
        }

        public IActionResult Index() //listar agricultor
        {

            return View(_context.Agricultores.ToList());
        }

        public IActionResult Create() {

            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,proprietario,bairro,municipio,idade,email,cpf")] Agricultor agricultor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agricultor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agricultor);
        }

        //GET
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
                return NotFound();

            var agricultor = await _context.Agricultores.FindAsync(id);
            if (agricultor == null)
                return NotFound();

            return View(agricultor); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,proprietario,bairro,municipio,idade,email,cpf")] Agricultor agricultor) {
            if (id != agricultor.id)
                return NotFound(); 
            if (ModelState.IsValid)
            {
                try {
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

        private bool AgricultorExists(int id)
        {
            return _context.Agricultores.Any(e => e.id == id);
        }


    }

    [Serializable]
    internal class dbupdateConcurrencyException : Exception
    {
        public dbupdateConcurrencyException()
        {
        }

        public dbupdateConcurrencyException(string message) : base(message)
        {
        }

        public dbupdateConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected dbupdateConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
