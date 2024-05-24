using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherVm>> GetAllPublishers();
        Task<PublisherVm> GetPublisherById(int id);
        Task<PublisherVm> AddPublisher(PublisherVm publisherDTO);
        Task UpdatePublisher(PublisherVm publisherDTO);
        Task DeletePublisher(int id);
    }

}
