using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.database;
using MVC.Models;

namespace MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ContatoController(ApplicationDBContext context)
        {
            _context = context;
        }
        //cria a tela inicial de contatos ("index" => onde esta a tabela criada)
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
        //http get neste ponto, mas no mvc é opcional colocar ele
        public IActionResult Criar()
        {
            return View();
        }

        //metodo para adicionar e salvar um contato na lista
        //metodo cria um contato e retorna para Contato
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                //redirect to action => retorna para outra tela, neste caso index
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
    }
}