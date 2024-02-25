using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Common.Interfaces.Persistence
{
    public interface ISneakerRepository
    {
        Task UpdateAsync(Sneaker sneaker);
        Task AddAsync(Sneaker sneaker);
        Task<Sneaker?> GetByIdAsync(SneakerId sneakerId);
        Task<bool> ExistsAsync(SneakerId sneakerId);
        Task<List<Sneaker>> ListAsync(UserId userId);
    }
}
