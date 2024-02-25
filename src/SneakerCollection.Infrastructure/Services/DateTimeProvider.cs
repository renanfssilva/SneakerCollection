using SneakerCollection.Application.Common.Interfaces.Services;

namespace SneakerCollection.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
