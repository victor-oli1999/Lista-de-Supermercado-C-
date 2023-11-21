using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Lista_de_Supermercado.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lista_de_Supermercado.Repository;
using Lista_de_Supermercado.Interface;
using System.Linq;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private readonly ProdutoDbContext _context;
        private readonly IMapper _mapper;
        private IUpdateProduto _updateProduto { get; }
        public ListaController(
            ProdutoDbContext context,
            IMapper mapper,
            IUpdateProduto updateProduto
            )
        {
            _context = context;
            _mapper = mapper;
            _updateProduto = updateProduto;
        }

        /// <summary>
        /// Consulta a lista de produtos
        /// </summary>
        /// <returns></returns>
        [Route("Produtos")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            //var Lista = _context.Listas.Where(d => d.IsAtivo).ToList(); 
            var listaProdutos = _context.Produtos.ToList();

            var listaProdutosView = _mapper.Map<List<ProdutoViewModel>>(listaProdutos);

            return Ok(listaProdutosView);
        }
        /// <summary>
        /// Consulta todas os cupons
        /// </summary>
        /// <returns></returns>
        [Route("Cupons")]
        [HttpGet]
        public IActionResult GetAllCupons()
        {
            var listaCupons = _context.Cupons.ToList();

            var listaCuponsView = _mapper.Map<List<CupomViewModel>>(listaCupons);

            return Ok(listaCuponsView);
        }
    }
}
