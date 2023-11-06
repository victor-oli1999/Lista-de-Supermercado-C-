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

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/ProdutoDTO")]
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
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            //var Lista = _context.Listas.Where(d => d.IsAtivo).ToList(); 
            var listaProdutos = _context.ProdutoDTO
                .ToList();

            var listaProdutosView = _mapper.Map<List<ProdutoViewModel>>(listaProdutos);

            return Ok(listaProdutosView);
        }
        /// <summary>
        /// Atualiza produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCupom"></param>
        /// <returns></returns>
        [HttpPut("{id},{idCupom}")]
        public IActionResult Update(int id, int idCupom)
        {
            var Produto = _context.ProdutoDTO.SingleOrDefault(d => d.Id == id);
            var listaCupons = _context.Cupom.SingleOrDefault(d => d.IdCupom == idCupom);
            if (Produto == null || listaCupons == null)
            {
                return NotFound();
            }

            //var UpdateProduto = new UpdateProduto();
            decimal preco_Total = _updateProduto.CalculoPrecoTotal(Produto.Preco_Item, listaCupons.Desconto);

            Produto.UpdateCupom(idCupom, preco_Total);

            _context.ProdutoDTO.Update(Produto);
            _context.SaveChanges();

            return Ok(Produto);
        }

        /// <summary>
        /// Consulta todas as Listas
        /// </summary>
        /// <returns></returns>
        [Route("Cupom")]
        [HttpGet]
        public IActionResult GetAllCupons()
        {
            //var Lista = _context.Listas.Where(d => d.IsAtivo).ToList(); 
            var listaCupons = _context.Cupom
                .ToList();

            var listaCuponsView = _mapper.Map<List<CupomViewModel>>(listaCupons);

            return Ok(listaCuponsView);
        }
    }
}
