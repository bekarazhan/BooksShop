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

        public async Task<List<PublisherVm>> GetAllPublishersAsync()
        {
            var publishers = await _publisherRepository.GetAllPublishers();
            return _mapper.Map<List<PublisherVm>>(publishers);
        }

        public async Task<PublisherVm> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            return _mapper.Map<PublisherVm>(publisher);
        }

        public async Task<PublisherVm> AddPublisherAsync(PublisherVm publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            var addedPublisher = await _publisherRepository.AddPublisher(publisher);
            return _mapper.Map<PublisherVm>(addedPublisher);
        }

        public async Task UpdatePublisherAsync(PublisherVm publisherDTO)
        {
            var existingPublisher = await _publisherRepository.GetPublisherById(publisherDTO.Id);
            _mapper.Map(publisherDTO, existingPublisher);
            await _publisherRepository.UpdatePublisher(existingPublisher);
        }

        public async Task DeletePublisherAsync(int id)
        {
            await _publisherRepository.DeletePublisher(id);
        }
    }
}
