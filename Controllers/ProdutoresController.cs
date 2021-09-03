using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
