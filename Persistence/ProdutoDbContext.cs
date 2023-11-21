using Microsoft.EntityFrameworkCore;
using Lista_de_Supermercado.Entities;

namespace Lista_de_Supermercado.Persistence
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {

        }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Cupons> Cupons { get; set; }
        public DbSet<ItemListaDeCompras> Carrinho { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produtos>(e =>
            {
                e.HasKey(de => de.Id);
            });
            builder.Entity<Cupons>(e =>
            {
                e.HasKey(de => de.IdCupom);
            });
            builder.Entity<ItemListaDeCompras>(e =>
            {
                e.HasKey(de => de.IdItem);
            });
            builder.Entity<Usuarios>(e =>
            {
                e.HasKey(de => de.IdUsuario);
            });
        }
    }
}
