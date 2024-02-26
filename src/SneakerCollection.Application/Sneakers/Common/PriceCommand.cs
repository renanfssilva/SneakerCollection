namespace SneakerCollection.Application.Sneakers.Common
{
    public record PriceCommand(
        decimal Amount,
        string Currency);
}
