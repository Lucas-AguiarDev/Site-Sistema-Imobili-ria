using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using mvImoveis.Models;

namespace mvImoveis.Models
{
    public class ColaboradorService
    {
        public void incluirColaborador(Colaborador novoColaborador)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Colaboradores.Add(novoColaborador);
                db.SaveChanges();
            }
        }

        public void ExcluirColaborador(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Colaboradores.Remove(db.Colaboradores.Find(id));
                db.SaveChanges();
            }
        }

        public void editarColaborador(Colaborador editarColaborador)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Colaborador colaborador = db.Colaboradores.Find(editarColaborador.Id);
                colaborador.Nome = editarColaborador.Nome;
                colaborador.Cpf = editarColaborador.Cpf;
                colaborador.Login = editarColaborador.Login;
                colaborador.Senha = editarColaborador.Senha;

                db.SaveChanges();
            }
        }

        public List<Colaborador> Listar()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Colaboradores.ToList();
            }
        }

        public Colaborador Listar(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Colaboradores.Find(id);
            }
        }
    }
}