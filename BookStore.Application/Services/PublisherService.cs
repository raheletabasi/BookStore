using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using BookStore.Domain.Interface;

namespace BookStore.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IUnitOfWork _unitOfWork;

    public PublisherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultPublisher> AddPublisher(PublisherViewModel publisherViewModel)
    {
        try
        {
            var isDuplicate = await _unitOfWork.Publishers.IsDuplicate(publisherViewModel.Title);

            if (!isDuplicate)
            {
                var publisher = new Publisher()
                {
                    Title = publisherViewModel.Title,
                    Address = publisherViewModel.Address
                };

                await _unitOfWork.Publishers.AddAsync(publisher);
                await _unitOfWork.Commit();

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
            var isExist = await _unitOfWork.Publishers.IsExist(id);
            if (isExist)
            {
                var publisher = await _unitOfWork.Publishers.GetByIdAsync(id);
                await _unitOfWork.Publishers.DeleteAsync(publisher);
                await _unitOfWork.Commit();

                return ResultPublisher.success;
            }
            return ResultPublisher.notFound;
        }
        catch
        {
            return ResultPublisher.Error;
        }
    }

    public async Task<IEnumerable<Publisher>> GetAllPublishers()
    {
        return await _unitOfWork.Publishers.GetAllAsync();
    }

    public async Task<Publisher> GetPublisherById(Guid id)
    {
        return await _unitOfWork.Publishers.GetByIdAsync(id);
    }

    public async Task<ResultPublisher> UpdatePublisher(PublisherViewModel publisherViewModel)
    {
        try
        {
            var isExist = await _unitOfWork.Publishers.IsExist(publisherViewModel.Id);
            if (isExist)
            {
                var isDuplicate = await _unitOfWork.Publishers.IsDuplicate(
                    publisherViewModel.Id, publisherViewModel.Title);

                if (!isDuplicate)
                {
                    var publisher = new Publisher()
                    {
                        Title = publisherViewModel.Title,
                        Address = publisherViewModel.Address
                    };

                    await _unitOfWork.Publishers.UpdateAsync(publisher);
                    await _unitOfWork.Commit();

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
