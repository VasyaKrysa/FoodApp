using AutoMapper;
using EatingApp.Core.DTO;
using EatingApp.Entities;

namespace EatingApp.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderDto>().ForMember(destination => destination.UserId, opts => opts.MapFrom(item => item.UserId == 0 ? 1 : item.UserId));

            CreateMap<UserDto, User>().ForMember(destination => destination.FirstName, opts => opts.MapFrom(item => item.FullName.Split()[0]))
            .ForMember(destination => destination.LastName, opts => opts.MapFrom(item => item.FullName.Split()[1]));

            CreateMap<User, UserDto>().ForMember(destination => destination.FullName, opts => opts.MapFrom(item => item.FirstName + " " + item.LastName));

            CreateMap<ProductTypeDto, ProductType>().ReverseMap();

            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
