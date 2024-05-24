using AutoMapper;
using BooksShop.Interfaces;
using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository,
            IMapper mapper
            )
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookVm> AddBook(Book bookDTO)
        {
            var book = _bookRepository.AddBook(bookDTO).Result;
            var bookVm = _mapper.Map<BookVm>(book);

            //BookVm bookVm = new BookVm() { //mapping
            //    Id = book.Id,
            //    Title = book.Title,
            //    PublisherName = book.Publisher.Name
            //};
            return bookVm;
        }

        public async Task DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public async Task<List<BookVm>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var bookVmList = _mapper.Map<List<BookVm>>(books);
            return bookVmList;
        }

        public async Task<BookVm> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            var bookVm = _mapper.Map<BookVm>(book);
            return bookVm;
        }

        public async Task UpdateBook(BookVm bookDTO)
        {
            var book = await _bookRepository.GetBookById(bookDTO.Id);
            book.Title = bookDTO.Title;
            await _bookRepository.UpdateBook(book);
            //book.Publisher.Name = bookDTO.PublisherName;
            return;
        }
    }
}
