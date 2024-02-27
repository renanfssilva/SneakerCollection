using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Utils
{
    public class SneakerUtils
    {
        public static Sneaker CreateSneaker(string? brandName = null, decimal? priceAmount = null, string? priceCurrency = null)
        {
            return Sneaker.Create(
                Constants.Sneaker.Name,
                CreateBrand(brandName),
                CreatePrice(priceAmount, priceCurrency),
                Constants.Sneaker.SizeUS,
                Constants.Sneaker.Year,
                Constants.Sneaker.Rate,
                Constants.User.Id);
        }

        public static Brand CreateBrand(string? name = null)
            => Brand.Create(name ?? Constants.Sneaker.BrandName);

        public static Price CreatePrice(decimal? amount = null, string? currency = null)
            => Price.Create(amount ?? Constants.Sneaker.PriceAmount, currency ?? Constants.Sneaker.PriceCurrency);
    }
}
