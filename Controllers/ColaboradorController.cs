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
    public class ColaboradorController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            if (Autenticacao.verificaLoginSenha(login, senha, this))
            {
                return RedirectToAction("Home");
            }
            else
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
        }

        public IActionResult CadastrarColaboradores()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarColaboradores(Colaborador novoColaborador)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            novoColaborador.Senha = Criptografo.TextoCriptografado(novoColaborador.Senha);

            ColaboradorService cs = new ColaboradorService();
            cs.incluirColaborador(novoColaborador);

            return RedirectToAction("CadastroRealizado");
        }

        public IActionResult ListarColaboradores()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            return View(new ColaboradorService().Listar());
        }

        [HttpPost]
        public IActionResult ExcluirColaborador(string decisao, int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            if (decisao == "EXCLUIR")
            {
                ViewData["Mensagem"] = "Exclusão do usuário " + new ColaboradorService().Listar(id).Nome + " realizada com sucesso.";
                new ColaboradorService().ExcluirColaborador(id);

                return View("ListarColaboradores", new ColaboradorService().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Exclusão cancelada";

                return View("ListarColaboradores", new ColaboradorService().Listar());
            }
        }

        public IActionResult ExcluirColaborador(int id)
        {
           return View(new ColaboradorService().Listar(id));
        }

        public IActionResult NeedAdmin()
        {
            return View();
        }


//----------------------------------------------------------------------------

        public IActionResult ListarContato()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            return View(new ContatoServive().Listar());
        }

        [HttpPost]
        public IActionResult excluirContato(string decisao, int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeColaboradorAdminExiste(this);

            if (decisao == "EXCLUIR")
            {
                ViewData["Mensagem"] = "Contato com cliente " + new ContatoServive().Listar(id).Nome + " realizada com sucesso.";
                new ContatoServive().excluirContato(id);

                return View("ListarColaboradores", new ContatoServive().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Contato não foi realizado!";

                return View("ListarColaboradores", new ContatoServive().Listar());
            }
        }

        public IActionResult excluirContato(int id)
        {
           return View(new ContatoServive().Listar(id));
        }


    }

}