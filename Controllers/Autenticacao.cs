using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvImoveis.Models;

namespace mvImoveis.Models
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {
            if (string.IsNullOrEmpty(controller.HttpContext.Session.GetString("Login")))
            {
                controller.Request.HttpContext.Response.Redirect("Colaborador/Login");
            }
        }

        public static bool verificaLoginSenha(string Login, string Senha, Controller controller)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                verificaSeColaboradorAdminExiste(db);

                Senha = Criptografo.TextoCriptografado(Senha);

                IQueryable<Colaborador> ColaboradorEncontrado = db.Colaboradores.Where(c => c.Login == Login && c.Senha == Senha);

                List<Colaborador> ListarColaboradorEncontrado = ColaboradorEncontrado.ToList();

                if (ListarColaboradorEncontrado.Count == 0)
                {
                    return false;
                }
                else
                {
                    //controller.HttpContext.Session.SetString("Id", ListarColaboradorEncontrado[0].Login);
                    controller.HttpContext.Session.SetString("Login", ListarColaboradorEncontrado[0].Login);
                    controller.HttpContext.Session.SetString("nome", ListarColaboradorEncontrado[0].Nome);
                    controller.HttpContext.Session.SetInt32("tipo", ListarColaboradorEncontrado[0].Tipo);
                    return true;
                }

            }
        }

        public static void verificaSeColaboradorAdminExiste(DatabaseContext db)
        {
            IQueryable<Colaborador> ColaboradorEncontrado = db.Colaboradores.Where(c => c.Login == "admin");

            if (ColaboradorEncontrado.ToList().Count == 0)
            {
                Colaborador admin = new Colaborador();
                admin.Login = "admin";
                admin.Senha = Criptografo.TextoCriptografado("123");
                admin.Tipo = Colaborador.ADMIN;
                admin.Nome = "administrador";

                db.Colaboradores.Add(admin);
                db.SaveChanges();
            }
        }

        public static void verificaSeColaboradorAdminExiste(Controller controller)
        {
            if (!(controller.HttpContext.Session.GetInt32("tipo") == Colaborador.ADMIN))
            {
                controller.Request.HttpContext.Response.Redirect("/Colaborador/NeedAdmin");
            }
        }
    }
}