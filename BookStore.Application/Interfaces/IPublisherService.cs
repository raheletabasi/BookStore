using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces;

public interface IPublisherService
{
    Task<ResultPublisher> AddPublisher(PublisherViewModel publisherViewModel);
    Task<ResultPublisher> UpdatePublisher(PublisherViewModel publisherViewModel);
    Task<ResultPublisher> DeletePublisher(Guid id);
    Task<Publisher> GetPublisherById(Guid id);
    Task<IEnumerable<Publisher>> GetAllPublishers();
}
