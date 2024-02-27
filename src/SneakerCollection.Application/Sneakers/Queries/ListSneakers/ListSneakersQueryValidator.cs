using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers
{
    public class ListSneakersQueryValidator : AbstractValidator<ListSneakersQuery>
    {
        private const int MinimumPageValue = 1;
        private const int MinimumPageSize = 0;

        public ListSneakersQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(IsValidGuid).WithMessage("Invalid User Id");

            RuleFor(x => x.SortOrder)
                .Must(x => x.Equals("asc", StringComparison.InvariantCultureIgnoreCase)
                        || x.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                .When(x => !string.IsNullOrEmpty(x.SortOrder))
                .WithMessage("SortOrder must be either 'asc' or 'desc' when not empty.");

            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(MinimumPageValue);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(MinimumPageSize);
        }

        private bool IsValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
