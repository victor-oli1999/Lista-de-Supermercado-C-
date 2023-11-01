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

    public interface IObterController
    {
        public IEnumerable ObterListas(bool IsAtivo);
    }
}