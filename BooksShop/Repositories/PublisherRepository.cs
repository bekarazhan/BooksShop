using BooksShop.Data;
using BooksShop.Interfaces;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class PublisherRepository:IPublisherRepository
    {
        private readonly BookContext _context;

        public PublisherRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetAllPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<Publisher> AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }

    }
}
