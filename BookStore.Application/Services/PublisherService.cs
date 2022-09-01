using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interface.Repositories;

namespace BookStore.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<ResultPublisher> AddPublisher(PublisherViewModel publisherViewModel)
    {
        try
        {
            var isDuplicate = await _publisherRepository.IsDuplicate(publisherViewModel.Title);

            if (!isDuplicate)
            {
                var publisher = new Publisher()
                {
                    Title = publisherViewModel.Title,
                    Address = publisherViewModel.Address
                };

                await _publisherRepository.AddAsync(publisher);
                await _publisherRepository.Save();

                return ResultPublisher.success;
            }
            return ResultPublisher.duplicate;
        }
        catch
        {
            return ResultPublisher.Error;
        }
    }

    public async Task<ResultPublisher> DeletePublisher(Guid id)
    {
        try
        {
            var isExist = await _publisherRepository.IsExist(id);
            if (isExist)
            {
                var publisher = await _publisherRepository.GetByIdAsync(id);
                await _publisherRepository.DeleteAsync(publisher);
                await _publisherRepository.Save();

                return ResultPublisher.success;
            }
            return ResultPublisher.notFound;
        }
        catch
        {
            return ResultPublisher.Error;
        }
    }

    public List<Publisher> GetAllPublishers()
    {
        return _publisherRepository.GetAllAsync();
    }

    public async Task<Publisher> GetPublisherById(Guid id)
    {
        return await _publisherRepository.GetByIdAsync(id);
    }

    public async Task<ResultPublisher> UpdatePublisher(PublisherViewModel publisherViewModel)
    {
        try
        {
            var isExist = await _publisherRepository.IsExist(publisherViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _publisherRepository.IsDuplicate(
                    publisherViewModel.Id, publisherViewModel.Title);

                if (!isDuplicate)
                {
                    var publisher = new Publisher()
                    {
                        Title = publisherViewModel.Title,
                        Address = publisherViewModel.Address
                    };

                    await _publisherRepository.UpdateAsync(publisher);
                    await _publisherRepository.Save();

                    return ResultPublisher.success;
                }
                return ResultPublisher.duplicate;
            }
            return ResultPublisher.notFound;
        }
        catch
        {
            return ResultPublisher.Error;
        }
    }
}
