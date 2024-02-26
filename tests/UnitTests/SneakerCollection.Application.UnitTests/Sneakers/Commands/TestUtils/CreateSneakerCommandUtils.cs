using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Application.UnitTests.TestUtils.Constants;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.TestUtils
{
    public static class CreateSneakerCommandUtils
    {
        public static CreateSneakerCommand CreateCommand()
            => new(
                Constants.User.Id.Value.ToString()!,
                Constants.Sneaker.Name,
                CreateBrandCommand(),
                CreatePriceCommand(),
                Constants.Sneaker.SizeUS,
                Constants.Sneaker.Year,
                Constants.Sneaker.Rate);

        public static BrandCommand CreateBrandCommand()
            => new(Constants.Sneaker.BrandName);

        public static PriceCommand CreatePriceCommand()
            => new(
                Constants.Sneaker.PriceAmount,
                Constants.Sneaker.PriceCurrency);
    }
}
