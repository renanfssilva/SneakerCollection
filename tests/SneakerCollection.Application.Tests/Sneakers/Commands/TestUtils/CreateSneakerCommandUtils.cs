using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils
{
    public static class CreateSneakerCommandUtils
    {
        public static CreateSneakerCommand CreateCommand(string? userId = null, BrandCommand? brand = null, PriceCommand? price = null)
            => new(
                userId ?? Constants.User.Id.Value.ToString()!,
                Constants.Sneaker.Name,
                brand ?? CreateBrandCommand(),
                price ?? CreatePriceCommand(),
                Constants.Sneaker.SizeUS,
                Constants.Sneaker.Year,
                Constants.Sneaker.Rate);

        public static BrandCommand CreateBrandCommand(string? name = null)
            => new(name ?? Constants.Sneaker.BrandName);

        public static PriceCommand CreatePriceCommand()
            => new(
                Constants.Sneaker.PriceAmount,
                Constants.Sneaker.PriceCurrency);
    }
}
