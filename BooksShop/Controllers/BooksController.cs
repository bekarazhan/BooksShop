using BooksShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService; // Dependency for accessing book data

        public BookController(IBookService bookService) // Injecting BookService dependency
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // ... other action methods for creating, editing, deleting books
    }
}
