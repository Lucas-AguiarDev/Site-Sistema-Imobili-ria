using Microsoft.EntityFrameworkCore;
using mvImoveis.Models;

namespace mvImoveis.Models
{
    public class DatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;DataBase=MVImoveis;Uid=root;Pwd=;");
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Imoveis> Imoveis { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}