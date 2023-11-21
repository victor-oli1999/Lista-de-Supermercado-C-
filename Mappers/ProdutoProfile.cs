using AutoMapper;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Entities;

namespace Lista_de_Supermercado.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produtos, ProdutoViewModel>();
            CreateMap<Cupons, CupomViewModel>();
            CreateMap<Usuarios, UsuariosViewModel>();
            CreateMap<ItemListaDeComprasInputModel, ItemListaDeCompras>();
            CreateMap<ItemListaDeCompras, ItemListaDeComprasViewModel>();
        }
    }
}
