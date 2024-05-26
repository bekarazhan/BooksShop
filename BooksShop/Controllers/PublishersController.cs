using BooksShop.Interfaces;
using BooksShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public async Task<ActionResult> Index()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return View(publishers);
        }

        public async Task<ActionResult> Details(int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return View();
            }
            return View(publisher);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PublisherVm publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.AddPublisherAsync(publisher);
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return View();
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PublisherVm publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.UpdatePublisherAsync(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return View();
            }
            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return RedirectToAction("Index");
        }
    }

}
