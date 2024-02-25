using ErrorOr;

namespace SneakerCollection.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use");

            public static Error InvalidUserId => Error.Validation(
                code: "User.InvalidId",
                description: "User ID is invalid");
        }
    }
}
