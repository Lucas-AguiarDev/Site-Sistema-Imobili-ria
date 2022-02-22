using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvImoveis.Models;

namespace mvImoveis.Controllers
{
    public class ContatoController : Controller
    {
         public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contato novoContato)
        {
            ContatoServive cs = new ContatoServive();
            cs.incluirContato(novoContato);

             ViewData["Mensagem"] = "Mensagem enviada com sucesso";

            return View();
        }

        public IActionResult ListarContato()
        {
            Autenticacao.CheckLogin(this);

            return View(new ContatoServive().Listar());
        }

        [HttpPost]
        public IActionResult excluirContato(string decisao, int id)
        {
            Autenticacao.CheckLogin(this);

            if (decisao == "FINALIZAR")
            {
                ViewData["Mensagem"] = "Contato com cliente " + new ContatoServive().Listar(id).Nome + " realizada com sucesso.";
                new ContatoServive().excluirContato(id);

                return View("ListarContato", new ContatoServive().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Contato não foi realizado!";

                return View("ListarContato", new ContatoServive().Listar());
            }
        }

        public IActionResult excluirContato(int id)
        {
           return View(new ContatoServive().Listar(id));
        }
    }
}