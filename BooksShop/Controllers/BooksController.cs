using BooksShop.Data;
using BooksShop.Interfaces;
using BooksShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService; // Assuming there's a service to handle publishers

        public BooksController(IBookService bookService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
        }

        // Index action to list all books
        public async Task<ActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        // Details action to view a single book
        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return View();
            }
            return View(book);
        }

        // Create actions to create a new book
        public async Task<ActionResult> Create()
        {
            ViewBag.PublisherId = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookVm book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBookAsync(book);
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        // Edit actions to edit an existing book
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return View();
            }

            ViewBag.PublisherId = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BookVm book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "Name", book.PublisherId);
            return View(book);
        }

        // Delete actions to delete an existing book
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return View();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }
    }


}
