using FluentValidation;

namespace SneakerCollection.Application.Sneakers.Commands.CreateSneaker
{
    public class CreateSneakerCommandValidator : AbstractValidator<CreateSneakerCommand>
    {
        private const int SneakerNameMaximumLength = 200;
        private const int SneakerBrandNameMaximumLength = 200;

        private const double SneakerMinimumSizeUS = 0;
        private const double SneakerMaximumSizeUS = 25;

        private const int SneakerMinimumRate = 0;
        private const int SneakerMaximumRate = 5;

        private const decimal SneakerMinimumPrice = 0;

        private const int SneakerMinimumYear = 1873;

        public CreateSneakerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(SneakerNameMaximumLength);

            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(IsValidGuid).WithMessage("Invalid User Id");

            RuleFor(x => x.Brand.Name)
                .NotEmpty()
                .MaximumLength(SneakerBrandNameMaximumLength);

            RuleFor(x => x.Price.Amount)
                .GreaterThanOrEqualTo(SneakerMinimumPrice)
                .When(x => x.Price != null);

            RuleFor(x => x.Price.Currency)
                .NotEmpty()
                .When(x => x.Price != null);

            RuleFor(x => x.SizeUS)
                .NotEmpty()
                .ExclusiveBetween(SneakerMinimumSizeUS, SneakerMaximumSizeUS);

            RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(SneakerMinimumYear);

            RuleFor(x => x.Rate)
                .InclusiveBetween(SneakerMinimumRate, SneakerMaximumRate);
        }

        private bool IsValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
