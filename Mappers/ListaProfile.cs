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
        }
    }
}
