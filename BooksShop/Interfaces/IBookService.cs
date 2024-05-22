using BooksShop.Models;

namespace BooksShop.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);

        // Additional methods for CRUD operations (optional)
        //  - CreateBook(Book book)
        //  - UpdateBook(Book book)
        //  - DeleteBook(int id)
    }
}
