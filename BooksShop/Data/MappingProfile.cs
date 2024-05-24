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
              .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
              .ReverseMap(); // Assuming Publisher is a navigation property in Book
        }

    }
}
