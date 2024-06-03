using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookVm>> GetAllBooksAsync();
        Task<BookVm> GetBookByIdAsync(int id);
        Task AddBookAsync(BookVm book);
        Task UpdateBookAsync(BookVm book);
        Task DeleteBookAsync(int id);

        Task<IEnumerable<BookVm>> GetBooksDescNamesAsync();

        Task<IEnumerable<BookVm>> GetBooksByFirstLetterAsync(string letter);
    }


}
