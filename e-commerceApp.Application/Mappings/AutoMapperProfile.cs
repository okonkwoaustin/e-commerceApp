using AutoMapper;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Dtos;

namespace e_commerceApp.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from User to UserDto for user data exposure
            CreateMap<User, UserDto>();

            CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>))
            .ConvertUsing(typeof(PaginatedResultConverter<,>));
        }
    }

    public class PaginatedResultConverter<TSource, TDestination>
    : ITypeConverter<PaginatedResult<TSource>, PaginatedResult<TDestination>>
    {
        private readonly IMapper _mapper;

        public PaginatedResultConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PaginatedResult<TDestination> Convert(PaginatedResult<TSource> source, PaginatedResult<TDestination> destination, ResolutionContext context)
        {
            return new PaginatedResult<TDestination>
            {
                Items = _mapper.Map<List<TDestination>>(source.Items),
                TotalCount = source.TotalCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize
            };
        }
    }
}
