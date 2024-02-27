using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Common.Interfaces.Persistence
{
    public interface ISneakerRepository
    {
        Task AddAsync(Sneaker sneaker);
        Task<Sneaker?> GetByIdAsync(SneakerId sneakerId, UserId userId);
        Task<bool> ExistsAsync(SneakerId sneakerId, UserId userId);
        IQueryable<Sneaker> List(UserId userId, string? searchTerm = null, string? sortColumn = null,
                                 string? sortOrder = null);
        Task DeleteAsync(SneakerId sneakerId, UserId userId);
        Task UpdateAsync(Sneaker sneaker);
    }
}
