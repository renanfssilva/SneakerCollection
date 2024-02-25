using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Infrastructure.Persistence.Repositories
{
    public class UserRepository(SneakerCollectionDbContext dbContext) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
            => await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}