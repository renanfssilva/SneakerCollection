using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System.Reflection;

namespace SneakerCollection.Infrastructure.Persistence.Repositories
{
    public class SneakerRepository(SneakerCollectionDbContext dbContext) : ISneakerRepository
    {
        public async Task AddAsync(Sneaker sneaker)
        {
            await dbContext.AddAsync(sneaker);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SneakerId sneakerId, UserId userId)
        {
            var sneaker = await GetByIdAsync(sneakerId, userId);

            if (sneaker is not null)
            {
                dbContext.Remove(sneaker);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(SneakerId sneakerId, UserId userId)
            => await dbContext.Sneakers.AnyAsync(sneaker => sneaker.Id == sneakerId
                                                        && sneaker.UserId == userId);

        public async Task<Sneaker?> GetByIdAsync(SneakerId sneakerId, UserId userId)
            => await dbContext.Sneakers.SingleOrDefaultAsync(sneaker => sneaker.Id == sneakerId
                                                                    && sneaker.UserId == userId);

        public async Task<List<Sneaker>> ListAsync(UserId userId)
            => await dbContext.Sneakers
                        .Where(sneaker => sneaker.UserId == userId)
                        .ToListAsync();

        public async Task UpdateAsync(Sneaker sneaker)
        {
            dbContext.Sneakers.Update(sneaker);
            await dbContext.SaveChangesAsync();
        }
    }
}
