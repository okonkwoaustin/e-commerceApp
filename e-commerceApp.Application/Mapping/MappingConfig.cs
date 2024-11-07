using AutoMapper;
using e_commerceApp.Application.Dto;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCategory, Category>().ReverseMap();
            CreateMap<CreateProduct, Product>().ReverseMap();
        }
    }
}
