using BooksShop.Interfaces;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class BookService : IBookService
    {
        private static readonly List<Book> _books = new List<Book>()
  {
    // Add some sample book data here
    new Book { Id = 1, Title = "Pride and Prejudice", Author = "Jane Austen" },
    new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
    // Add more books as needed
  };

        public Task<List<Book>> GetAllBooks()
        {
            // Return a copy of the list to avoid modifying the original data
            return Task.FromResult(new List<Book>(_books));
        }

        public Task<Book> GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }
    }
}
