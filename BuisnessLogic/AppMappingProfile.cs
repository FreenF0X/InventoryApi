using AutoMapper;
using Domain.Models;
using Domain.DtoModels;

namespace BuisnessLogic
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, DtoProduct>().ReverseMap().
                ForMember(x => x.Provider, o => o.Ignore());
            CreateMap<Provider, DtoProvider>().ReverseMap().
                ForMember(x => x.Write, o => o.Ignore());
        }
    }
}
