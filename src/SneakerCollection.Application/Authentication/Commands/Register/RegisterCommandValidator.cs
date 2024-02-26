using FluentValidation;

namespace SneakerCollection.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Matches(@"^(?=.*[A-Za-z])[A-Za-z\- ]+$")
                .WithMessage("First name must contain at least one letter and can only contain letters, spaces, and hyphens.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Matches(@"^(?=.*[A-Za-z])[A-Za-z\- ]+$")
                .WithMessage("Last name must contain at least one letter and can only contain letters, spaces, and hyphens.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches(@"\d")
                .WithMessage("Password must contain at least one digit");
        }
    }
}
