using AutoMapper;
using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Models;

namespace Lista_de_Supermercado.Mappers
{
    public class ListaProfile : Profile
    {
        public ListaProfile() 
        {
            CreateMap<Lista, ListaViewModel>();
            CreateMap<ListaItem, ListaItemViewModel>();

            CreateMap<ListaInputModel, Lista>();
            CreateMap<ListaItemInputModel, ListaItem>();

            CreateMap<ListaItem, ItemTeste>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dst => dst.Hash, opt => opt.MapFrom(src => src.Nome.GetHashCode()));
        }
    }
}

public class ItemTeste
{
    public string Name { get; set; }
    public int Hash { get; set; }
}