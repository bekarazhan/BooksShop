using AutoMapper;
using BooksShop.Interfaces;
using BooksShop.Models;
using BooksShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookVm>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooks();
        return _mapper.Map<IEnumerable<BookVm>>(books.OrderBy(x=>x.Title));
    }

    public async Task<BookVm> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookById(id);
        if (book == null) return null;

        return _mapper.Map<BookVm>(book);
    }

    public async Task AddBookAsync(BookVm bookVm)
    {
        var book = _mapper.Map<Book>(bookVm);
        await _bookRepository.AddBook(book);
    }

    public async Task UpdateBookAsync(BookVm bookVm)
    {
        var existingBook = await _bookRepository.GetBookById(bookVm.Id);
        if (existingBook == null)
        {
            throw new ArgumentException("Book not found.");
        }

        // Map changes from BookVm to existing Book entity
        _mapper.Map(bookVm, existingBook);

        await _bookRepository.UpdateBook(existingBook);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _bookRepository.DeleteBook(id);
    }

    public async Task<IEnumerable<BookVm>> GetBooksDescNamesAsync()
    {
        var books = await _bookRepository.GetAllBooks();
        return _mapper.Map<IEnumerable<BookVm>>(books.OrderByDescending(x => x.Title));
    }

    public async Task<IEnumerable<BookVm>> GetBooksByFirstLetterAsync(string letter)
    {
        var books = await _bookRepository.GetAllBooks();
        return _mapper.Map<IEnumerable<BookVm>>(books.Where(x => IsFirstLetter(x, letter))); //book.Title.StartWith()
    }

    private bool IsFirstLetter(Book book, string letter) {
        if (book.Title[0].ToString() == letter) { 
            return true;
        }
        return false;
    }
}
