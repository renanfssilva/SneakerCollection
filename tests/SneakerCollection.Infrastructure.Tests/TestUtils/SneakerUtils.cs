using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Infrastructure.Tests.TestUtils
{
    public static class SneakerUtils
    {
        public static Sneaker GetSneaker(string? name = null, Brand? brand = null, Price? price = null)
            => Sneaker.Create(name ?? Constants.Sneaker.Name,
                                brand ?? GetBrand(),
                                price ?? GetPrice(),
                                Constants.Sneaker.SizeUS,
                                Constants.Sneaker.Year,
                                Constants.Sneaker.Rate,
                                Constants.User.Id);

        public static Brand GetBrand(string? name = null)
            => Brand.Create(name ?? Constants.Sneaker.BrandName);

        public static Price GetPrice(decimal? amount = null, string? currency = null)
            => Price.Create(amount ?? Constants.Sneaker.PriceAmount,
                        currency ?? Constants.Sneaker.PriceCurrency);
    }
}
