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

            //REVERSE

            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.MapFrom(b => b.Image))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(b => b.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(b => b.Description))
                .ForMember(dest => dest.isApproved, opt => opt.Ignore());

            CreateMap<ExchangeOrderDTO, ExchangeOrder>()
                .ForMember(dest => dest.FirstBookId, opt => opt.MapFrom(o => o.FirstBookId))
                .ForMember(dest => dest.SecondBookId, opt => opt.MapFrom(o => o.SecondBookId))
                .ForMember(dest => dest.IsApproved, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
