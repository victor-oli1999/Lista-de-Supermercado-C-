using System.Collections;
using AutoMapper;
using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Lista_de_Supermercado.Repositorio
{

    public class ObterController : IObterController
    {
        public IEnumerable ObterListas(bool IsAtivo)
        {
            var _context = new ListaDbContext();
            var lista = _context.Listas.Where(d => d.IsAtivo == IsAtivo).ToList();
          
            return listaView;
        }
    }
}