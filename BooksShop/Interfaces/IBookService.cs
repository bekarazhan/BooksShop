using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Interfaces
{
    public interface IBookService
    {
        Task<List<BookVm>> GetAllBooks();
        Task<BookVm> GetBookById(int id);
        Task<BookVm> AddBook(Book bookDTO);
        Task UpdateBook(BookVm bookDTO);
        Task DeleteBook(int id);
    }

}
