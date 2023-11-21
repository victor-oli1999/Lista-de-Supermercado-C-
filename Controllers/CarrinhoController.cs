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
    [Route("Carrinho")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ProdutoDbContext _context;
        private readonly IMapper _mapper;
        private IUpdateProduto _updateProduto { get; }
        public CarrinhoController(
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
        /// Atualiza produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCupom"></param>
        /// <returns></returns>
        [Route("Inserir-item-Carrinho")]
        [HttpPost]
        public IActionResult insereItemCarrinho(ItemListaDeComprasInputModel input)
        {
            var Produto = _context.Produtos.SingleOrDefault(d => d.Id == input.IdProduto);
            var listaCupons = _context.Cupons.SingleOrDefault(d => d.IdCupom == input.IdCupom);
            var usuario = _context.Usuarios.SingleOrDefault(d => d.IdUsuario == input.IdUsuario);

            if (Produto == null || listaCupons == null || usuario == null)
            {
                return NotFound();
            }

            decimal preco_Total = _updateProduto.CalculoPrecoTotal(Produto.Preco_Item, listaCupons.Porcentagem_Desconto);

            var listaDeComprasInput = _mapper.Map<ItemListaDeCompras>(input);

            listaDeComprasInput.Update_Preco_Total(preco_Total);

            _context.Carrinho.Add(listaDeComprasInput);
            _context.SaveChanges();

            return Ok(listaDeComprasInput);
        }
        /// <summary>
        /// Consulta todas as Listas de compras
        /// </summary>
        /// <returns></returns>
        [HttpGet("{idCarrinho}")]
        public IActionResult GetListaDeCompras(int idCarrinho)
        {
            var listaDeCompras = _context.Carrinho.Where(d => d.IdCarrinho == idCarrinho).ToList();

            var listaDeComprasView = _mapper.Map<List<ItemListaDeComprasViewModel>>(listaDeCompras);

            return Ok(listaDeComprasView);
        }
        /// <summary>
        /// Consulta um item
        /// </summary>
        /// <returns></returns>
        [HttpGet("Item/{idItem}")]
        public IActionResult GetItem(int idItem)
        {
            var item = _context.Carrinho.SingleOrDefault(d => d.IdItem == idItem);
            var produto = _context.Produtos.SingleOrDefault(d => d.Id == item.IdProduto);
            var cupom = _context.Cupons.SingleOrDefault(d => d.IdCupom == item.IdCupom);

            var Carrinho = new Item() { Nome = produto.Nome, Cupom = cupom.Nome, Produto_Preco_Total = item.Produto_Preco_Total };

            return Ok(Carrinho);
        }
        /// <summary>
        /// Consulta um item
        /// </summary>
        /// <returns></returns>
        [HttpGet("Por-Itens/{idCarrinho}")]
        public IActionResult GetLista(int idCarrinho)
        {
            var listaDeCompras = _context.Carrinho.Where(d => d.IdCarrinho == idCarrinho).ToList();

            if (listaDeCompras.Count == 0)
            { return BadRequest(); }


            List<Item> BancoItens = new List<Item>
            {
            };

            decimal valor_Total = 0;
            int i = 0;
            while (i < listaDeCompras.Count)
            {
                var produto = _context.Produtos.SingleOrDefault(d => d.Id == listaDeCompras[i].IdProduto);
                var cupom = _context.Cupons.SingleOrDefault(d => d.IdCupom == listaDeCompras[i].IdCupom);

                var Objeto = new Item() { Nome = produto.Nome, Cupom = cupom.Nome, Produto_Preco_Total = listaDeCompras[i].Produto_Preco_Total };

                /* Adiciona a descrição dos itens do carrinho */
                BancoItens.Add(Objeto);
                /* Faz a soma do valor total do carrinho */
                valor_Total = valor_Total + listaDeCompras[i].Produto_Preco_Total;

                i++;
            }
            var ListaDeCompras = new ListaDeCompras() { ItemListaDeCompras = BancoItens, Valor_Total = valor_Total };

            return Ok(ListaDeCompras);
        }
    }
}
