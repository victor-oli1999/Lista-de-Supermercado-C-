using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lista_de_Supermercado.Persistence
{
    public class ListaDbContext : DbContext
    {
        public ListaDbContext(DbContextOptions<ListaDbContext> options) : base(options)
        {

        }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<ListaItem> ListaItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Lista>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(de => de.Nome).IsRequired(false);
                e.Property(de => de.IsAtivo);

                e.HasMany(de => de.Item)
                    .WithOne()
                    .HasForeignKey(de => de.IdLista);
            });
            builder.Entity<ListaItem>(e =>
            {
                e.HasKey(de => de.Id);
            });
        }
    }
}
