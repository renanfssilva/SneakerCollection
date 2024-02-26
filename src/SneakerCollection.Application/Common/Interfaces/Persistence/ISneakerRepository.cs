using Microsoft.AspNetCore.JsonPatch;
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
        Task<List<Sneaker>> ListAsync(UserId userId);
        Task DeleteAsync(SneakerId sneakerId, UserId userId);
        Task UpdateAsync(Sneaker sneaker);
        Task PatchAsync(JsonPatchDocument<Sneaker> sneakerPatch, Sneaker sneaker);
    }
}
