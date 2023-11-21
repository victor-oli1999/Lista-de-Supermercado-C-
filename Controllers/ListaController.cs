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

        /// <summary>
        /// Consulta todas as Listas de compras
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idCarrinho}")]
        public IActionResult GetListaDeCompras(int idCarrinho)
        {
            var listaDeCompras = _context.Carrinho.Where(d => d.IdCarrinho == idCarrinho).ToList();

            var listaDeComprasView = _mapper.Map<List<ListaDeComprasViewModel>>(listaDeCompras);

            return Ok(listaDeComprasView);
        }

        /// <summary>
        /// Atualiza produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCupom"></param>
        /// <returns></returns>
        [Route("Inserir-item-Carrinho")]
        [HttpPost]
        public IActionResult insereItemCarrinho(ListaDeComprasInputModel input)
        {
            var Produto = _context.Produtos.SingleOrDefault(d => d.Id == input.IdProduto);
            var listaCupons = _context.Cupons.SingleOrDefault(d => d.IdCupom == input.IdCupom);
            var usuario = _context.Usuarios.SingleOrDefault(d => d.IdUsuario == input.IdUsuario);

            if (Produto == null || listaCupons == null || usuario == null)
            {
                return NotFound();
            }

            decimal preco_Total = _updateProduto.CalculoPrecoTotal(Produto.Preco_Item, listaCupons.Porcentagem_Desconto);

            var listaDeComprasInput = _mapper.Map<ListaDeCompras>(input);

            listaDeComprasInput.Update_Preco_Total(preco_Total);

            _context.Carrinho.Add(listaDeComprasInput);
            _context.SaveChanges();

            return Ok(listaDeComprasInput);
        }
    }
}
