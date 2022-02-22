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
    public class ImoveisController : Controller
    {
        public IActionResult CadastrarImoveis()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarImoveis(Imoveis novoImoveis)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            ImoveisService cs = new ImoveisService();
            cs.incluirImoveis(novoImoveis);

            return RedirectToAction("ListarImoveis");
        }

        public IActionResult ListarImoveis()
        {
            Autenticacao.CheckLogin(this);

            return View(new ImoveisService().Listar());
        }

        [HttpPost]
        public IActionResult excluirImoveis(string decisao, int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            if (decisao == "EXCLUIR")
            {
                ViewData["Mensagem"] = "Exclusão do usuário " + new ImoveisService().Listar(id).Nome + " realizada com sucesso.";
                new ImoveisService().excluirImoveis(id);

                return View("ListarImoveis", new ImoveisService().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Exclusão cancelada";

                return View("ListarImoveis", new ImoveisService().Listar());
            }
        }

        public IActionResult excluirImoveis(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);
            return View(new ImoveisService().Listar(id));
        }

        public IActionResult editarImoveis(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            Imoveis i = new ImoveisService().Listar(id);

            return View(i);
        }

        [HttpPost]
        public IActionResult editarImoveis(Imoveis imoveisEditado)
        {
            ImoveisService cs = new ImoveisService();
            cs.editarImoveis(imoveisEditado);

            return RedirectToAction("ListarImoveis");
        }
        public IActionResult NeedAdmin()
        {
            return View();
        }
    }
}