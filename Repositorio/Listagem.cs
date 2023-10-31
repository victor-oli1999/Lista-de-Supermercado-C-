using AutoMapper;
using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Lista_de_Supermercado.Repositorio
{

    public class Obter : DbContext
    {
        public List<Lista> Listas { get; }
        public List<ListaItem> ListaItens { get; }

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

        private Lista Ok(List<Lista> lista)
        {
            throw new NotImplementedException();
        }
        public Obter()
        {
            Listas = new List<Lista>();
            ListaItens = new List<ListaItem>();
        }

        public List<Lista> ObterListas(bool IsAtivo)
        {
            var lista = Listas.Where(d => d.IsAtivo == IsAtivo).ToList();
            return lista;
        }
    }
}
