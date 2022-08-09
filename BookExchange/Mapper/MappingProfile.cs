using BookExchange.DTOs;
using BookExchange.Domain.Models;
using AutoMapper;

namespace BookExchange.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressInfo, AddressInfoDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<ExchangeOrder, ExchangeOrderDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
