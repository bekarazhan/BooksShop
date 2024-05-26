using AutoMapper;
using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookVm>()
               .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));

            CreateMap<BookVm, Book>();

            CreateMap<Publisher, PublisherVm>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<PublisherVm, Publisher>();
        }

    }
}
