using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.DataContext;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {

        private readonly AgendaDataContext _context;

        public ContatoController(AgendaDataContext context)
        {

                _context = context;


        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);

        }

        public IActionResult CriarContato()
        {

            return View();

        }

        [HttpPost]
        public IActionResult CriarContato(Contato contato)
        {

            if(ModelState.IsValid)
            {

                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(contato);


        }

        public IActionResult EditarContato(int id)
        {
            var contato = _context.Contatos.Find(id);
            
            if(contato == null)
            {
                return NotFound();

            }
            return View(contato);

        }

        [HttpPost]
        public IActionResult EditarContato(Contato contato)
        {

            var contatoBanco = _context.Contatos.Find(contato.Id);
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;


            if(ModelState.IsValid)
            {

                _context.Contatos.Update(contatoBanco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(contatoBanco);


        }

         public IActionResult VisualizarContato(int id)
        {
            var contato = _context.Contatos.Find(id);
            
            if(contato == null)
            {
                return NotFound();

            }
            return View(contato);

        }

        public IActionResult DeletarContato(int id)
        {
            var contato = _context.Contatos.Find(id);
            
            if(contato == null)
            {
                return NotFound();

            }
            return View(contato);

        }

         [HttpPost]
        public IActionResult DeletarContato(Contato contato)
        {

            var contatoBanco = _context.Contatos.Find(contato.Id);
          
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));

          


        }


        
        
    }
}