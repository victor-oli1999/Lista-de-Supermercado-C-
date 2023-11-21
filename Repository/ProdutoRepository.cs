using AutoMapper;
using Lista_de_Supermercado.Entities;
using Lista_de_Supermercado.Interface;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Lista_de_Supermercado.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Lista_de_Supermercado.Repository
{
    //public class ProdutoRepository : IProdutoRepository, ControllerBase 
    //{

    //    private readonly ProdutoDbContext _context;
    //    private readonly IMapper _mapper;
    //    public ProdutoRepository
    //        (
    //        ProdutoDbContext context,
    //        IMapper mapper
    //        )
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public List<ProdutoViewModel> NomeProduto(int idProduto)
    //    {
    //        var listaProdutos = _context.Produtos.Where(d => d.Id == idProduto).ToList();

    //        var listaProdutosView = _mapper.Map<List<ProdutoViewModel>>(listaProdutos);

    //        return listaProdutosView;
    //    }
    //}
}
