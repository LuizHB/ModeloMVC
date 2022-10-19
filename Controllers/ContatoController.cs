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

        //método para criar pagina editar contato, busca Id que recebeu para editar
        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();
            //se usar RedirectToAction(nameof(Index)) em vez de NotFound,
            //ele não retorna erro e sim retorna a página original
            return View(contato);
        }
        // método para editar o contato
        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find((contato.Id));
            //recebe variavel contatoBanco para editar o contato
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            //atualiza o contato com a opção update e saveChanges
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();
            //atualiza a página com o contato editado
            return RedirectToAction(nameof(Index));
        }

        //metodo para criar pagina de detalhes
        public IActionResult Detalhes(int id)
        {    //variavel para procurar pelo ID
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return RedirectToAction(nameof(Index));
            //se variavel for null retorna pra pagina original (não retorna erro)
            return View(contato);
        }

        //metodo para pagina de deletar contato
        public IActionResult Deletar(int id)
        {    //variavel para procurar pelo ID
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return RedirectToAction(nameof(Index));
            //se variavel for null retorna pra pagina original (não retorna erro)
            return View(contato);
        }

        //metodo para deletar o contato
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);
            //busca a variavel pela ID e remove ela
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            //retorna para a pagina da tabela de contatos
            return RedirectToAction(nameof(Index));


        }
    }
}