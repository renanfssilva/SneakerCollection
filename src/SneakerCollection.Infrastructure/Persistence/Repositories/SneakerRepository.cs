using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System.Linq.Expressions;

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

        public IQueryable<Sneaker> List(UserId userId, string? searchTerm = null, string? sortColumn = null,
                                 string? sortOrder = null)
        {
            var sneakers = dbContext.Sneakers
                    .Where(sneaker => sneaker.UserId == userId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                sneakers = sneakers.Where(sneaker =>
                                sneaker.Name.Contains(searchTerm)
                                || sneaker.Brand.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
                sneakers = sneakers.OrderByDescending(GetSortColumn(sortColumn));
            else
                sneakers = sneakers.OrderBy(GetSortColumn(sortColumn));

            return sneakers;
        }

        public async Task UpdateAsync(Sneaker sneaker)
        {
            dbContext.Sneakers.Update(sneaker);
            await dbContext.SaveChangesAsync();
        }

        private static Expression<Func<Sneaker, object>> GetSortColumn(string? sortColumn = null)
        {
            return sortColumn?.ToLower() switch
            {
                "year" => sneaker => sneaker.Year,
                "size_us" => sneaker => sneaker.SizeUS,
                "amount" => sneaker => sneaker.Price.Amount,
                "currency" => sneaker => sneaker.Price.Currency,
                _ => sneaker => sneaker.Name
            };
        }
    }
}
