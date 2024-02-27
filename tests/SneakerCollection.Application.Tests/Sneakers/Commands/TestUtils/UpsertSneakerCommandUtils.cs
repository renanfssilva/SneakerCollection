using SneakerCollection.Application.Sneakers.Commands.UpsertSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils
{
    public static class UpsertSneakerCommandUtils
    {
        public static UpsertSneakerCommand UpsertCommand(
            string? userId = null,
            Guid? sneakerId = null,
            string? name = null,
            string? brandName = null,
            decimal? priceAmount = null,
            string? priceCurrency = null,
            double? sizeUS = null,
            int? year = null,
            int? rate = null)
        {
            return new UpsertSneakerCommand(
                        sneakerId ?? Constants.Sneaker.Id.Value,
                        userId ?? Constants.User.Id.Value.ToString()!,
                        name ?? Constants.Sneaker.Name,
                        CreateBrandCommand(brandName),
                        CreatePriceCommand(priceAmount, priceCurrency),
                        sizeUS ?? Constants.Sneaker.SizeUS,
                        year ?? Constants.Sneaker.Year,
                        rate ?? Constants.Sneaker.Rate);
        }

        public static PriceCommand CreatePriceCommand(decimal? priceAmount, string? priceCurrency)
        {
            return new PriceCommand(
                priceAmount ?? Constants.Sneaker.PriceAmount,
                priceCurrency ?? Constants.Sneaker.PriceCurrency);
        }

        public static BrandCommand CreateBrandCommand(string? brandName)
        {
            return new BrandCommand(brandName ?? Constants.Sneaker.BrandName);
        }
    }
}
