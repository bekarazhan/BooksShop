using AutoMapper;
using BooksShop.Interfaces;
using BooksShop.Models;
using BooksShop.ViewModels;

namespace BooksShop.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherVm>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishers();
            return _mapper.Map<List<PublisherVm>>(publishers);
        }

        public async Task<PublisherVm> GetPublisherById(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            return _mapper.Map<PublisherVm>(publisher);
        }

        public async Task<PublisherVm> AddPublisher(PublisherVm publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            var addedPublisher = await _publisherRepository.AddPublisher(publisher);
            return _mapper.Map<PublisherVm>(addedPublisher);
        }

        public async Task UpdatePublisher(PublisherVm publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            await _publisherRepository.UpdatePublisher(publisher);
        }

        public async Task DeletePublisher(int id)
        {
            await _publisherRepository.DeletePublisher(id);
        }
    }
}
