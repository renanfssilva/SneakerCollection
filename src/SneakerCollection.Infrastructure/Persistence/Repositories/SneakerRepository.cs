﻿using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Infrastructure.Persistence.Repositories
{
    public class SneakerRepository(SneakerCollectionDbContext dbContext) : ISneakerRepository
    {
        public async Task AddAsync(Sneaker sneaker)
        {
            await dbContext.AddAsync(sneaker);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(SneakerId sneakerId)
            => await dbContext.Sneakers.AnyAsync(sneaker => sneaker.Id == sneakerId);

        public async Task<Sneaker?> GetByIdAsync(SneakerId sneakerId)
            => await dbContext.Sneakers.SingleOrDefaultAsync(sneaker => sneaker.Id == sneaker.Id);

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