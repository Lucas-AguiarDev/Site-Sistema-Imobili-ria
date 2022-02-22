using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using mvImoveis.Models;

namespace mvImoveis.Models
{
    public class ContatoServive
    {
        public void incluirContato(Contato novoContato)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Contatos.Add(novoContato);
                db.SaveChanges();
            }
        }

        public void excluirContato(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Contatos.Remove(db.Contatos.Find(id));
                db.SaveChanges();
            }
        }

        public void editarContato(Contato editarContato)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Contato Contato = db.Contatos.Find(editarContato.Id);
                Contato.Nome = editarContato.Nome;
                Contato.Telefone = editarContato.Telefone;
                Contato.Email = editarContato.Email;
                Contato.Assunto = editarContato.Assunto;
                Contato.Mensagem = editarContato.Mensagem;

                db.SaveChanges();
            }
        }

        public List<Contato> Listar()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Contatos.ToList();
            }
        }

        public Contato Listar(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Contatos.Find(id);
            }
        }
    }
}