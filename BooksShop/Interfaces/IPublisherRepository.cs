using BooksShop.Models;

namespace BooksShop.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        Task<Publisher> AddPublisher(Publisher publisher);
        Task UpdatePublisher(Publisher publisher);
        Task DeletePublisher(int id);

    }
}
