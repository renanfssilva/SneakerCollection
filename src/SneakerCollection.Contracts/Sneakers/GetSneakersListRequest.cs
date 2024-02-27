namespace SneakerCollection.Contracts.Sneakers
{
    public record GetSneakersListRequest(
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page = 1,
        int PageSize = 10);
}
