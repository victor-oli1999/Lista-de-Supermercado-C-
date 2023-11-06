using Microsoft.EntityFrameworkCore;
using Lista_de_Supermercado.Entities;

namespace Lista_de_Supermercado.Persistence
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {

        }
        public DbSet<ProdutoDTO> ProdutoDTO { get; set; }
        public DbSet<Cupom> Cupom { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProdutoDTO>(e =>
            {
                e.HasKey(de => de.Id);
            });
            builder.Entity<Cupom>(e =>
            {
                e.HasKey(de => de.IdCupom);
            });
        }
    }
}
