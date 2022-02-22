using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using mvImoveis.Models;

namespace mvImoveis.Models
{
    public class ImoveisService
    {
        public void incluirImoveis(Imoveis novoImoveis)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Imoveis.Add(novoImoveis);
                db.SaveChanges();
            }
        }

        public void excluirImoveis(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Imoveis.Remove(db.Imoveis.Find(id));
                db.SaveChanges();
            }
        }

        public void editarImoveis(Imoveis editarImoveis)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Imoveis imoveis = db.Imoveis.Find(editarImoveis.Id);
                imoveis.Nome = editarImoveis.Nome;
                imoveis.Descricao = editarImoveis.Descricao;
                imoveis.Quartos = editarImoveis.Quartos;
                imoveis.Banheiros = editarImoveis.Banheiros;
                imoveis.Garagem = editarImoveis.Garagem;
                imoveis.Cidade = editarImoveis.Cidade;
                imoveis.Bairro = editarImoveis.Bairro;
                imoveis.Valor = editarImoveis.Valor;
                imoveis.Imagem = editarImoveis.Imagem;

                db.SaveChanges();
            }
        }

        public List<Imoveis> Listar()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Imoveis.ToList();
            }
        }

        public Imoveis Listar(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Imoveis.Find(id);
            }
        }
    }
}