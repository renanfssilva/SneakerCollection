namespace SneakerCollection.Contracts.Sneakers
{
    public record CreateSneakerRequest(
        string Name,
        BrandRequest Brand,
        PriceRequest Price,
        double SizeUS,
        int Year,
        int Rate);

    public record PriceRequest(
        decimal Amount,
        string Currency);

    public record BrandRequest(
        string Name);
}
