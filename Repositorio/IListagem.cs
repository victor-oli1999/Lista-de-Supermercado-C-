using AutoMapper;
using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lista_de_Supermercado.Repositorio
{

    public interface IObter
    {
        Lista Obter(bool IsAtivo);
    }
}
