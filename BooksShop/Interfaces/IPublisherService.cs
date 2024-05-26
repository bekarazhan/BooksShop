using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherVm>> GetAllPublishersAsync();
        Task<PublisherVm> GetPublisherByIdAsync(int id);
        Task<PublisherVm> AddPublisherAsync(PublisherVm publisherDTO);
        Task UpdatePublisherAsync(PublisherVm publisherDTO);
        Task DeletePublisherAsync(int id);
    }

}
