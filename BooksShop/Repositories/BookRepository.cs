using BooksShop.Data;
using BooksShop.Interfaces;
using BooksShop.Models;
using BooksShop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }
        

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.Include(x=>x.Publisher).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);

        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
