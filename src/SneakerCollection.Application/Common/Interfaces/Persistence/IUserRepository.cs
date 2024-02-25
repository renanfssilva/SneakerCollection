using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
